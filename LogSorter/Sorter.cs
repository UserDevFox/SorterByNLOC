using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using xNet;

namespace LogSorter
{
	// Token: 0x02000004 RID: 4
	public partial class Sorter : MetroForm
	{
		// Token: 0x06000013 RID: 19 RVA: 0x0000294E File Offset: 0x00000B4E
		public Sorter()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002968 File Offset: 0x00000B68
		private void metroButton1_Click(object sender, EventArgs e)
		{
			bool flag = this.metroTextBox1.Text.Contains(",");
			if (flag)
			{
				string[] array = this.metroTextBox1.Text.Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					this.metroListView1.Items.Add(array[i]);
				}
				this.linksCount.Text = "Links:{" + this.metroListView1.Items.Count + "}";
			}
			else
			{
				this.metroListView1.Items.Add(this.metroTextBox1.Text);
				MessageBox.Show("Вы добавили ссылку");
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002A30 File Offset: 0x00000C30
		private void metroButton2_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				bool flag = folderBrowserDialog.ShowDialog() == DialogResult.OK;
				if (flag)
				{
					this.path = folderBrowserDialog.SelectedPath;
					this.spath.Text = "Path:{" + this.path + "}";
				}
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002AA0 File Offset: 0x00000CA0
		public int GetCountCookie(string request, Log log)
		{
			int num = 0;
			foreach (string text in Directory.GetFiles(log.Path + "\\Browsers\\Cookies"))
			{
				string[] array = File.ReadAllLines(text);
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

		// Token: 0x06000017 RID: 23 RVA: 0x00002B1A File Offset: 0x00000D1A
		public static void UnZip(string zipFile, string folderPath)
		{
			ZipFile.ExtractToDirectory(zipFile, folderPath);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002B28 File Offset: 0x00000D28
		public void DirectoryFromZip(string[] logs)
		{
			for (int i = 0; i < logs.Length; i++)
			{
				try
				{
					Sorter.UnZip(logs[i], this.path + "\\" + i);
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002B84 File Offset: 0x00000D84
		public bool ContainsCC(string directory)
		{
			try
			{
				string[] files = Directory.GetFiles(directory + "\\Browsers\\AutoComplete");
				foreach (string text in files)
				{
					bool flag = text.Contains("CC") || text.Contains("cc");
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

		// Token: 0x0600001A RID: 26 RVA: 0x00002C04 File Offset: 0x00000E04
		public Log GetLogFromDirectory(string Directory)
		{
			bool flag = File.Exists(Directory + "\\PasswordsList.txt") && File.Exists(Directory + "\\CookieList.txt") && File.Exists(Directory + "\\ip.txt");
			Log result;
			if (flag)
			{
				result = new Log(Directory, Directory + "\\CookieList.txt", Directory + "\\PasswordsList.txt", File.ReadAllText(Directory + "\\ip.txt").Split(new char[]
				{
					':'
				})[0], File.ReadAllText(Directory + "\\ip.txt").Split(new char[]
				{
					':'
				})[1]);
			}
			else
			{
				result = new Log("empty", "empty", "empty", "empty", "empty");
			}
			return result;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002CD4 File Offset: 0x00000ED4
		private void metroButton3_Click(object sender, EventArgs e)
		{
			bool @checked = this.metroToggle1.Checked;
			if (@checked)
			{
				this.DirectoryFromZip(Directory.GetFiles(this.path));
			}
		    
            string[] directories = Directory.GetDirectories(this.path);
            
			foreach (string text in directories)
			{
			    string dir = Directory.GetParent(text).FullName;
                Log logFromDirectory = this.GetLogFromDirectory(dir);
				bool flag = logFromDirectory.CookiePath != "empty";
				if (flag)
				{
					int num = this.i + 1;
					this.i = num;
					string text2 = num + " [";
					for (int j = 0; j < this.metroListView1.Items.Count; j++)
					{
						string text3 = File.ReadAllText(logFromDirectory.CookiePath);
						int num2 = 0;
						string text4 = File.ReadAllText(logFromDirectory.PasswordPath);
						bool flag2 = text3.Contains(this.metroListView1.Items[j].Text) && text4.Contains(this.metroListView1.Items[j].Text);
						if (flag2)
						{
							bool flag3 = Directory.Exists(text + "\\Browsers\\Cookies");
							if (flag3)
							{
								num2 = this.GetCountCookie(this.metroListView1.Items[j].Text, logFromDirectory);
							}
							text2 = text2 + this.metroListView1.Items[j].Text + string.Format("[{0}] ,", num2);
						}
					}
					bool flag4 = text2 != this.i + " [";
					if (flag4)
					{
						bool checked2 = this.metroCheckBox1.Checked;
						if (checked2)
						{
							bool flag5 = this.ContainsCC(text);
							if (flag5)
							{
								text2 = text2 + "] + [CC]  " + logFromDirectory.Country;
							}
						}
						else
						{
							text2 = text2 + "]  " + logFromDirectory.Country;
						}
						bool checked3 = this.metroCheckBox2.Checked;
						if (checked3)
						{
							HttpRequest httpRequest = new HttpRequest();
							string str = Sorter.Pars("https://check-host.net/ip-info?host=" + logFromDirectory.Ip, "<td>Часовой пояс</td><td>", "</td>", 0, null);
							text2 = text2 + str + "  " + logFromDirectory.Ip;
                        }
					    Directory.CreateDirectory(this.currentpath + "\\Goods\\");
					    Directory.Move(text, this.currentpath + "\\Goods\\" + text2);
                    }
				}
			}
			//Process.Start(this.currentpath + "\\Goods\\");
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002F75 File Offset: 0x00001175
		private void Sorter_Load(object sender, EventArgs e)
		{
			this.currentpath = Directory.GetCurrentDirectory();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002F83 File Offset: 0x00001183
		private void metroButton4_Click(object sender, EventArgs e)
		{
			this.metroListView1.Items.Clear();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002F98 File Offset: 0x00001198
		public static string Pars(string strSource, string strStart, string strEnd, int startPos = 0, string error = null)
		{
			string result;
			try
			{
				int length = strStart.Length;
				string text = "";
				int num = strSource.IndexOf(strStart, startPos);
				int num2 = strSource.IndexOf(strEnd, num + length);
				bool flag = num != -1 & num2 != -1;
				if (flag)
				{
					text = strSource.Substring(num + length, num2 - (num + length));
				}
				result = text;
			}
			catch
			{
				result = error;
			}
			return result;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003010 File Offset: 0x00001210
		private void Sorter_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003019 File Offset: 0x00001219
		private void spath_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0400000B RID: 11
		private string path;

		// Token: 0x0400000C RID: 12
		private string currentpath;

		// Token: 0x0400000D RID: 13
		private int i;
	}
}
