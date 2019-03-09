using System;
using System.Windows.Forms;

namespace LogSorter
{
	// Token: 0x02000005 RID: 5
	internal static class Program
	{
		// Token: 0x06000023 RID: 35 RVA: 0x00003A71 File Offset: 0x00001C71
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new First());
		}
	}
}
