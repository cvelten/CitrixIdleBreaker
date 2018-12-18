using System;
using System.Windows.Forms;

namespace IdleBreaker
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void EventExit(object sender, EventArgs e)
		{
			Close();
		}

		private void EventMinimize(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}

		private void EventShow(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Normal;
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			var windows = User32_Windows.FindWindowsWithText("idle timer expired");
			foreach (var wdw in windows)
			{
				if (wdw == IntPtr.Zero) continue;
				richTextBox1.AppendText(DateTime.Now.ToLongTimeString() + "\n");

				User32_Windows.SetForegroundWindow(wdw);
				User32_Windows.SetActiveWindow(wdw);

				var inputs = new User32_SendInput.INPUT[1];
				var input = new User32_SendInput.INPUT {type = 1};
				input.U.ki.wScan = User32_SendInput.ScanCodeShort.RETURN;
				input.U.ki.dwFlags = User32_SendInput.KEYEVENTF.SCANCODE;
				inputs[0] = input;
				User32_SendInput.SendInput(1, inputs, User32_SendInput.INPUT.Size);

			}
		}
	}
}
