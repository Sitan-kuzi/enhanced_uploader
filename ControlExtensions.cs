using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WorkshopUploader
{
	// Token: 0x02000003 RID: 3
	internal static class ControlExtensions
	{
		// Token: 0x06000007 RID: 7
		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x06000008 RID: 8
		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x06000009 RID: 9 RVA: 0x000021E9 File Offset: 0x000003E9
		public static void SetCueText(this Control C, string text)
		{
			ControlExtensions.SendMessage(C.Handle, 5377, IntPtr.Zero, Marshal.StringToBSTR(text));
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002207 File Offset: 0x00000407
		public static void SetCueText(this Control C, ToolTip Tips)
		{
			C.SetCueText(Tips.GetToolTip(C));
		}

		// Token: 0x04000002 RID: 2
		public const int EM_SETCUEBANNER = 5377;
	}
}
