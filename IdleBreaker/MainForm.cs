using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace IdleBreaker
{
	public partial class MainForm : Form
	{
		const int BM_CLICK = 0x00F5;
		const int WM_KEYDOWN = 0x0100;
		const int VK_RETURN = 0x0D;

		private Point _point;


		public MainForm()
		{
			InitializeComponent();

			GetCursorPos(out _point);
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void buttonMinimize_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Normal;
		}

		private void notifyIcon_DoubleClick(object sender, EventArgs e)
		{
			toolStripMenuItem1_Click(sender, e);
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			if (!GetCursorPos(out var p)) return;
			if (p != _point)
			{
				_point = p;
				//return;
			}

			var windows = WindowEnum.FindWindowsWithText("idle timer expired");
			foreach (var wdw in windows)
			{
				if (wdw == IntPtr.Zero) continue;
				SetForegroundWindow(wdw);
				SetActiveWindow(wdw);
				richTextBox1.AppendText(DateTime.Now.ToLongTimeString() + "\n");
				PostMessage(wdw, new IntPtr(WM_KEYDOWN), new IntPtr(VK_RETURN), new IntPtr(1));
				//SendMessage(wdw, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
				//SendKeys.Send("{ENTER}");
			}
		}

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, IntPtr uMsg, IntPtr wParam, IntPtr lParam);

		[DllImport("User32.Dll")]
		public static extern IntPtr PostMessage(IntPtr hWnd, IntPtr msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern bool GetCursorPos(out Point p);

		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll")]
		public static extern bool SetActiveWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);
	}
}
