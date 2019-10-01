using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WorkshopUploader
{
	internal static class ControlExtensions
	{
		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		public static void SetCueText(this Control C, string text)
		{
			ControlExtensions.SendMessage(C.Handle, 5377, IntPtr.Zero, Marshal.StringToBSTR(text));
		}

		public static void SetCueText(this Control C, ToolTip Tips)
		{
			C.SetCueText(Tips.GetToolTip(C));
		}

		public const int EM_SETCUEBANNER = 5377;
	}
}
