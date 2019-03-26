using System;
using System.Collections.Generic;
using System.IO;

namespace LogSorter
{
	// Token: 0x02000004 RID: 4
	public class Log
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000028FD File Offset: 0x00000AFD
		// (set) Token: 0x06000010 RID: 16 RVA: 0x00002905 File Offset: 0x00000B05
		public string LogPath { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000011 RID: 17 RVA: 0x0000290E File Offset: 0x00000B0E
		// (set) Token: 0x06000012 RID: 18 RVA: 0x00002916 File Offset: 0x00000B16
		public string CookiePath { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000013 RID: 19 RVA: 0x0000291F File Offset: 0x00000B1F
		// (set) Token: 0x06000014 RID: 20 RVA: 0x00002927 File Offset: 0x00000B27
		public string PasswordPath { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002930 File Offset: 0x00000B30
		// (set) Token: 0x06000016 RID: 22 RVA: 0x00002938 File Offset: 0x00000B38
		public string Ip { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002941 File Offset: 0x00000B41
		// (set) Token: 0x06000018 RID: 24 RVA: 0x00002949 File Offset: 0x00000B49
		public string Country { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000019 RID: 25 RVA: 0x00002952 File Offset: 0x00000B52
		// (set) Token: 0x0600001A RID: 26 RVA: 0x0000295A File Offset: 0x00000B5A
		public string TimeZone { get; set; }

		// Token: 0x0600001B RID: 27 RVA: 0x00002964 File Offset: 0x00000B64
		public Log(string path, string cookiePath, string passwordPath, string ip, string country, string timeZone)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			this.LogPath = path;
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
			if (timeZone == null)
			{
				throw new ArgumentNullException("timeZone");
			}
			this.TimeZone = timeZone;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002A08 File Offset: 0x00000C08
		public int GetLinesCount(string request, string path)
		{
			int num = 0;
			foreach (string path2 in Directory.GetFiles(this.LogPath + path))
			{
				string[] array = File.ReadAllLines(path2);
				for (int j = 0; j < array.Length; j++)
				{
					bool flag = array[j].Contains(request);
					if (flag)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002A80 File Offset: 0x00000C80
		public bool ContainsCC()
		{
			try
			{
				string[] directories = Directory.GetDirectories(this.LogPath);
				List<string> list = new List<string>();
				for (int i = 0; i < directories.Length; i++)
				{
					foreach (string item in Directory.GetFiles(directories[i]))
					{
						list.Add(item);
					}
				}
				foreach (string text in list)
				{
					bool flag = text.Contains("CC") || text.Contains("cards");
					if (flag)
					{
						return true;
					}
				}
			}
			catch
			{
				return false;
			}
			return false;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002B6C File Offset: 0x00000D6C
		public string OtherDirectorys()
		{
			string[] directories = Directory.GetDirectories(this.LogPath);
			string text = "";
			foreach (string path in directories)
			{
				bool flag = new DirectoryInfo(path).Name != "Browsers";
				if (flag)
				{
					text = text + "[" + new DirectoryInfo(path).Name + "]";
				}
			}
			bool flag2 = directories.Length != 0;
			string result;
			if (flag2)
			{
				result = text;
			}
			else
			{
				result = "";
			}
			return result;
		}
	}
}
