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

			Interop.GetCursorPos(out _point);
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
			if (!Interop.GetCursorPos(out var p)) return;
			if (p != _point)
			{
				_point = p;
				//return;
			}

			var windows = Interop.FindWindowsWithText("idle timer expired");
			foreach (var wdw in windows)
			{
				if (wdw == IntPtr.Zero) continue;
				Interop.SetForegroundWindow(wdw);
				Interop.SetActiveWindow(wdw);
				richTextBox1.AppendText(DateTime.Now.ToLongTimeString() + "\n");
				Interop.PostMessage(wdw, new IntPtr(WM_KEYDOWN), new IntPtr(VK_RETURN), new IntPtr(1));
			}
		}
	}
}
