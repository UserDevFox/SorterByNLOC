using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
using xNet;

namespace LogSorter
{
	// Token: 0x02000004 RID: 4
	public class Sorter : MetroForm
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
				Log logFromDirectory = this.GetLogFromDirectory(text);
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
						Directory.Move(text, this.currentpath + "\\Goods\\" + text2);
					}
				}
			}
			Process.Start(this.currentpath + "\\Goods\\");
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

		// Token: 0x06000021 RID: 33 RVA: 0x0000301C File Offset: 0x0000121C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003054 File Offset: 0x00001254
		private void InitializeComponent()
		{
			this.metroListView1 = new MetroListView();
			this.metroButton1 = new MetroButton();
			this.linksCount = new MetroLabel();
			this.metroTextBox1 = new MetroTextBox();
			this.metroButton2 = new MetroButton();
			this.metroButton3 = new MetroButton();
			this.spath = new MetroLabel();
			this.metroButton4 = new MetroButton();
			this.metroCheckBox1 = new MetroCheckBox();
			this.metroToggle1 = new MetroToggle();
			this.metroLabel1 = new MetroLabel();
			this.metroCheckBox2 = new MetroCheckBox();
			base.SuspendLayout();
			this.metroListView1.Font = new Font("Segoe UI", 12f);
			this.metroListView1.FullRowSelect = true;
			this.metroListView1.Location = new Point(23, 85);
			this.metroListView1.Name = "metroListView1";
			this.metroListView1.OwnerDraw = true;
			this.metroListView1.Scrollable = false;
			this.metroListView1.Size = new Size(333, 160);
			this.metroListView1.TabIndex = 0;
			this.metroListView1.Theme = 1;
			this.metroListView1.UseCompatibleStateImageBehavior = false;
			this.metroListView1.UseSelectable = true;
			this.metroListView1.View = View.List;
			this.metroButton1.Location = new Point(506, 176);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new Size(75, 23);
			this.metroButton1.TabIndex = 1;
			this.metroButton1.Text = "add";
			this.metroButton1.Theme = 1;
			this.metroButton1.UseSelectable = true;
			this.metroButton1.Click += this.metroButton1_Click;
			this.linksCount.AutoSize = true;
			this.linksCount.FontSize = 2;
			this.linksCount.Location = new Point(21, 57);
			this.linksCount.Name = "linksCount";
			this.linksCount.Size = new Size(72, 25);
			this.linksCount.TabIndex = 2;
			this.linksCount.Text = "Links:{0}";
			this.linksCount.Theme = 1;
			this.metroTextBox1.CustomButton.Image = null;
			this.metroTextBox1.CustomButton.Location = new Point(116, 1);
			this.metroTextBox1.CustomButton.Name = "";
			this.metroTextBox1.CustomButton.Size = new Size(21, 21);
			this.metroTextBox1.CustomButton.Style = 4;
			this.metroTextBox1.CustomButton.TabIndex = 1;
			this.metroTextBox1.CustomButton.Theme = 1;
			this.metroTextBox1.CustomButton.UseSelectable = true;
			this.metroTextBox1.CustomButton.Visible = false;
			this.metroTextBox1.Lines = new string[]
			{
				"link or link,link,link"
			};
			this.metroTextBox1.Location = new Point(362, 176);
			this.metroTextBox1.MaxLength = 32767;
			this.metroTextBox1.Name = "metroTextBox1";
			this.metroTextBox1.PasswordChar = '\0';
			this.metroTextBox1.ScrollBars = ScrollBars.None;
			this.metroTextBox1.SelectedText = "";
			this.metroTextBox1.SelectionLength = 0;
			this.metroTextBox1.SelectionStart = 0;
			this.metroTextBox1.ShortcutsEnabled = true;
			this.metroTextBox1.Size = new Size(138, 23);
			this.metroTextBox1.TabIndex = 3;
			this.metroTextBox1.Text = "link or link,link,link";
			this.metroTextBox1.Theme = 1;
			this.metroTextBox1.UseSelectable = true;
			this.metroTextBox1.WaterMarkColor = Color.FromArgb(109, 109, 109);
			this.metroTextBox1.WaterMarkFont = new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel);
			this.metroButton2.Location = new Point(362, 143);
			this.metroButton2.Name = "metroButton2";
			this.metroButton2.Size = new Size(219, 23);
			this.metroButton2.TabIndex = 5;
			this.metroButton2.Text = "Load logs";
			this.metroButton2.Theme = 1;
			this.metroButton2.UseSelectable = true;
			this.metroButton2.Click += this.metroButton2_Click;
			this.metroButton3.Location = new Point(362, 85);
			this.metroButton3.Name = "metroButton3";
			this.metroButton3.Size = new Size(219, 23);
			this.metroButton3.TabIndex = 6;
			this.metroButton3.Text = "Start";
			this.metroButton3.Theme = 1;
			this.metroButton3.UseSelectable = true;
			this.metroButton3.Click += this.metroButton3_Click;
			this.spath.AutoSize = true;
			this.spath.FontSize = 2;
			this.spath.ForeColor = Color.Lime;
			this.spath.Location = new Point(21, 260);
			this.spath.Name = "spath";
			this.spath.Size = new Size(106, 25);
			this.spath.TabIndex = 7;
			this.spath.Text = "Path:{empty}";
			this.spath.Theme = 1;
			this.spath.Click += this.spath_Click;
			this.metroButton4.Location = new Point(362, 114);
			this.metroButton4.Name = "metroButton4";
			this.metroButton4.Size = new Size(219, 23);
			this.metroButton4.TabIndex = 8;
			this.metroButton4.Text = "Clear";
			this.metroButton4.Theme = 1;
			this.metroButton4.UseSelectable = true;
			this.metroButton4.Click += this.metroButton4_Click;
			this.metroCheckBox1.AutoSize = true;
			this.metroCheckBox1.Checked = true;
			this.metroCheckBox1.CheckState = CheckState.Checked;
			this.metroCheckBox1.Location = new Point(367, 230);
			this.metroCheckBox1.Name = "metroCheckBox1";
			this.metroCheckBox1.Size = new Size(75, 15);
			this.metroCheckBox1.TabIndex = 9;
			this.metroCheckBox1.Text = "Check CC";
			this.metroCheckBox1.UseSelectable = true;
			this.metroToggle1.AutoSize = true;
			this.metroToggle1.Location = new Point(457, 209);
			this.metroToggle1.Name = "metroToggle1";
			this.metroToggle1.Size = new Size(80, 17);
			this.metroToggle1.TabIndex = 10;
			this.metroToggle1.Text = "Off";
			this.metroToggle1.UseSelectable = true;
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.FontSize = 2;
			this.metroLabel1.Location = new Point(362, 202);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new Size(89, 25);
			this.metroLabel1.TabIndex = 11;
			this.metroLabel1.Text = "Check .zip";
			this.metroCheckBox2.AutoSize = true;
			this.metroCheckBox2.Location = new Point(448, 230);
			this.metroCheckBox2.Name = "metroCheckBox2";
			this.metroCheckBox2.Size = new Size(111, 15);
			this.metroCheckBox2.TabIndex = 12;
			this.metroCheckBox2.Text = "Check Timezone";
			this.metroCheckBox2.UseSelectable = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(594, 292);
			base.Controls.Add(this.metroCheckBox2);
			base.Controls.Add(this.metroLabel1);
			base.Controls.Add(this.metroToggle1);
			base.Controls.Add(this.metroCheckBox1);
			base.Controls.Add(this.metroButton4);
			base.Controls.Add(this.spath);
			base.Controls.Add(this.metroButton3);
			base.Controls.Add(this.metroButton2);
			base.Controls.Add(this.metroTextBox1);
			base.Controls.Add(this.linksCount);
			base.Controls.Add(this.metroButton1);
			base.Controls.Add(this.metroListView1);
			base.Name = "Sorter";
			base.Resizable = false;
			this.Text = "Sorter by NLOC Production";
			base.Theme = 0;
			base.FormClosed += this.Sorter_FormClosed;
			base.Load += this.Sorter_Load;
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400000B RID: 11
		private string path;

		// Token: 0x0400000C RID: 12
		private string currentpath;

		// Token: 0x0400000D RID: 13
		private int i;

		// Token: 0x0400000E RID: 14
		private IContainer components = null;

		// Token: 0x0400000F RID: 15
		private MetroListView metroListView1;

		// Token: 0x04000010 RID: 16
		private MetroButton metroButton1;

		// Token: 0x04000011 RID: 17
		private MetroLabel linksCount;

		// Token: 0x04000012 RID: 18
		private MetroTextBox metroTextBox1;

		// Token: 0x04000013 RID: 19
		private MetroButton metroButton2;

		// Token: 0x04000014 RID: 20
		private MetroButton metroButton3;

		// Token: 0x04000015 RID: 21
		private MetroLabel spath;

		// Token: 0x04000016 RID: 22
		private MetroButton metroButton4;

		// Token: 0x04000017 RID: 23
		private MetroCheckBox metroCheckBox1;

		// Token: 0x04000018 RID: 24
		private MetroToggle metroToggle1;

		// Token: 0x04000019 RID: 25
		private MetroLabel metroLabel1;

		// Token: 0x0400001A RID: 26
		private MetroCheckBox metroCheckBox2;
	}
}
