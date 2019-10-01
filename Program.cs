using System;
using System.Windows.Forms;

namespace WorkshopUploader
{
	// Token: 0x02000006 RID: 6
	internal static class Program
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00003092 File Offset: 0x00001292
		[STAThread]
		private static void Main()
		{
			AppDomain.CurrentDomain.AssemblyResolve += AssemblyReferencer.ResolveAssemblyCallback;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
