using System;

namespace LogSorter
{
	// Token: 0x02000003 RID: 3
	public class Log
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000008 RID: 8 RVA: 0x0000286D File Offset: 0x00000A6D
		// (set) Token: 0x06000009 RID: 9 RVA: 0x00002875 File Offset: 0x00000A75
		public string Path { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000A RID: 10 RVA: 0x0000287E File Offset: 0x00000A7E
		// (set) Token: 0x0600000B RID: 11 RVA: 0x00002886 File Offset: 0x00000A86
		public string CookiePath { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000C RID: 12 RVA: 0x0000288F File Offset: 0x00000A8F
		// (set) Token: 0x0600000D RID: 13 RVA: 0x00002897 File Offset: 0x00000A97
		public string PasswordPath { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000028A0 File Offset: 0x00000AA0
		// (set) Token: 0x0600000F RID: 15 RVA: 0x000028A8 File Offset: 0x00000AA8
		public string Ip { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000010 RID: 16 RVA: 0x000028B1 File Offset: 0x00000AB1
		// (set) Token: 0x06000011 RID: 17 RVA: 0x000028B9 File Offset: 0x00000AB9
		public string Country { get; set; }

		// Token: 0x06000012 RID: 18 RVA: 0x000028C4 File Offset: 0x00000AC4
		public Log(string path, string cookiePath, string passwordPath, string ip, string country)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			this.Path = path;
			if (cookiePath == null)
			{
				throw new ArgumentNullException("cookiePath");
			}
			this.CookiePath = cookiePath;
			if (passwordPath == null)
			{
				throw new ArgumentNullException("passwordPath");
			}
			this.PasswordPath = passwordPath;
			if (ip == null)
			{
				throw new ArgumentNullException("ip");
			}
			this.Ip = ip;
			if (country == null)
			{
				throw new ArgumentNullException("country");
			}
			this.Country = country;
		}
	}
}
