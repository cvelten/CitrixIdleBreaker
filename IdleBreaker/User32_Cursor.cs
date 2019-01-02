using System.Drawing;
using System.Runtime.InteropServices;

namespace IdleBreaker
{
	internal class User32_Cursor
	{
		/// <summary>
		/// Struct representing a point.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		internal struct POINT
		{
			public int X;
			public int Y;

			public static implicit operator Point(POINT point)
			{
				return new Point(point.X, point.Y);
			}
		}

		/// <summary>
		/// Retrieves the cursor's position, in screen coordinates.
		/// </summary>
		/// <see>See MSDN documentation for further information.</see>
		[DllImport("user32.dll")]
		internal static extern bool GetCursorPos(out POINT lpPoint);

		internal static Point GetCursorPosition()
		{
			GetCursorPos(out POINT lpPoint);
			return lpPoint;
		}
	}
}
