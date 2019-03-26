using System;
using System.Windows.Forms;

namespace LogSorter
{
	// Token: 0x02000006 RID: 6
	internal static class Program
	{
		// Token: 0x0600002D RID: 45 RVA: 0x00003CF3 File Offset: 0x00001EF3
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new First());
		}
	}
}
