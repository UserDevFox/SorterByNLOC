using System;

namespace LogSorter
{
	// Token: 0x02000002 RID: 2
	internal class Config
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public string PasswordFile { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002061 File Offset: 0x00000261
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002069 File Offset: 0x00000269
		public string DomainsFile { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002072 File Offset: 0x00000272
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000207A File Offset: 0x0000027A
		public string InformationFile { get; set; }

		// Token: 0x06000007 RID: 7 RVA: 0x00002084 File Offset: 0x00000284
		public Config(string passwordFile, string domainsFile, string informationFile)
		{
			if (passwordFile == null)
			{
				throw new ArgumentNullException("passwordFile");
			}
			this.PasswordFile = passwordFile;
			if (domainsFile == null)
			{
				throw new ArgumentNullException("domainsFile");
			}
			this.DomainsFile = domainsFile;
			if (informationFile == null)
			{
				throw new ArgumentNullException("informationFile");
			}
			this.InformationFile = informationFile;
		}
	}
}
