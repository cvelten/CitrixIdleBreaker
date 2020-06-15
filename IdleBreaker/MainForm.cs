using System;
using System.Windows.Forms;

namespace IdleBreaker
{
	public partial class MainForm : Form
	{
		private readonly Random _random;
		private System.Drawing.Point _point;

		public MainForm()
		{
			_random = new Random();

			InitializeComponent();

			_point = User32_Cursor.GetCursorPosition();
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
			//
			// Find and "ok-away" the Citrix idle timeout windows - if activated
			if (checkBoxIB.Checked)
			{
				var windows = User32_Windows.FindWindowsWithText("idle timer expired");
				foreach (var wdw in windows)
                {
                    if (wdw == IntPtr.Zero) continue;
                    richTextBoxLog.AppendText($"{DateTime.Now.ToLongTimeString()} - IdleBreaker\n");

					User32_Windows.SetForegroundWindow(wdw);
					User32_Windows.SetActiveWindow(wdw);

					var inputs = new User32_SendInput.INPUT[1];
					var input = new User32_SendInput.INPUT { type = 1 };
					input.U.ki.wScan = User32_SendInput.ScanCodeShort.RETURN;
					input.U.ki.dwFlags = User32_SendInput.KEYEVENTF.SCANCODE;
					inputs[0] = input;
					User32_SendInput.SendInput(1, inputs, User32_SendInput.INPUT.Size);
				}
			}

			//
			// Move the mouse to prevent the screensaver from activating - if activated
			if (checkBoxSS.Checked)
			{
				//richTextBoxLog.AppendText($"{DateTime.Now.ToLongTimeString()} - ScreenSaverBreaker\n");

				var newPoint = User32_Cursor.GetCursorPosition();

				if (newPoint == _point)
				{
					MoveCursorRandomly();
					MoveCursorRandomly();
				}

				_point = newPoint;
			}
		}

		private void MoveCursorRandomly()
		{
			var inputs = new User32_SendInput.INPUT[1];
			var input = new User32_SendInput.INPUT { type = 0 };
			input.U.mi.dx = Math.Sign(_random.NextDouble() - 0.5) * _random.Next(1, 100);
			input.U.mi.dy = Math.Sign(_random.NextDouble() - 0.5) * _random.Next(1, 100);
			input.U.mi.dwFlags = User32_SendInput.MOUSEEVENTF.MOVE;
			inputs[0] = input;
			User32_SendInput.SendInput(1, inputs, User32_SendInput.INPUT.Size);
		}
	}
}
