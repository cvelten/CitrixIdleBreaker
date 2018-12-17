using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace IdleBreaker
{
	internal class Interop
	{
		[DllImport("User32.Dll")]
		public static extern IntPtr PostMessage(IntPtr hWnd, IntPtr msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern bool GetCursorPos(out Point p);

		[DllImport("user32.dll")]
		public static extern bool SetActiveWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern int GetWindowTextLength(IntPtr hWnd);

		[DllImport("user32.dll")]
		private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

		// Delegate to filter which windows to include 
		public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

		/// <summary> Get the text for the window pointed to by hWnd </summary>
		public static string GetWindowText(IntPtr hWnd)
		{
			var size = GetWindowTextLength(hWnd);
			if (size <= 0) return string.Empty;
			var builder = new StringBuilder(size + 1);
			GetWindowText(hWnd, builder, builder.Capacity);
			return builder.ToString();
		}

		/// <summary> Find all windows that match the given filter </summary>
		/// <param name="filter"> A delegate that returns true for windows
		///    that should be returned and false for windows that should
		///    not be returned </param>
		public static IEnumerable<IntPtr> FindWindows(EnumWindowsProc filter = null)
		{
			var found = IntPtr.Zero;
			var windows = new List<IntPtr>();

			EnumWindows(delegate(IntPtr wnd, IntPtr param)
			{
				if (filter is null)
					windows.Add(wnd);
				else if (filter(wnd, param))
				{
					// only add the windows that pass the filter
					windows.Add(wnd);
				}

				// but return true here so that we iterate all windows
				return true;
			}, IntPtr.Zero);

			return windows;
		}

		/// <summary> Find all windows that contain the given title text </summary>
		/// <param name="titleText"> The text that the window title must contain. </param>
		public static IEnumerable<IntPtr> FindWindowsWithText(string titleText)
		{
			return FindWindows((wnd, param) => GetWindowText(wnd).ToLowerInvariant().Contains(titleText.ToLowerInvariant()));
		}
	}
}
