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
	// Token: 0x02000005 RID: 5
	public class Sorter : MetroForm
	{
		// Token: 0x0600001F RID: 31 RVA: 0x00002BF8 File Offset: 0x00000DF8
		public Sorter()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002C10 File Offset: 0x00000E10
		private void addButton_Click(object sender, EventArgs e)
		{
			bool flag = this.requstField.Text.Contains(",");
			if (flag)
			{
				string[] array = this.requstField.Text.Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					this.requestsListView.Items.Add(array[i]);
				}
			}
			else
			{
				this.requestsListView.Items.Add(this.requstField.Text);
			}
			this.linksCount.Text = "Links:{" + this.requestsListView.Items.Count + "}";
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002CCC File Offset: 0x00000ECC
		private void loadButton_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				bool flag = folderBrowserDialog.ShowDialog() == DialogResult.OK;
				if (flag)
				{
					this.path = folderBrowserDialog.SelectedPath;
					this.selectedPath.Text = "LogPath:{" + this.path + "}";
				}
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002D3C File Offset: 0x00000F3C
		public static void UnZip(string zipFile, string folderPath)
		{
			ZipFile.ExtractToDirectory(zipFile, folderPath);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002D48 File Offset: 0x00000F48
		public void GetDirectoryFromZip(string[] logs)
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

		// Token: 0x06000024 RID: 36 RVA: 0x00002DA4 File Offset: 0x00000FA4
		public Log GetLogFromDirectory(string Directory)
		{
			bool flag = File.Exists(Directory + "\\" + this.Config.PasswordFile) && File.Exists(Directory + "\\" + this.Config.DomainsFile) && File.Exists(Directory + "\\" + this.Config.InformationFile);
			Log result;
			if (flag)
			{
				string text = string.Empty;
				string country = string.Empty;
				string timeZone = string.Empty;
				bool flag2 = this.logTypes.SelectedIndex == 0;
				if (flag2)
				{
					text = File.ReadAllText(Directory + "\\" + this.Config.InformationFile).Split(new char[]
					{
						':',
						';'
					})[0];
					country = File.ReadAllText(Directory + "\\" + this.Config.InformationFile).Split(new char[]
					{
						':',
						';'
					})[1];
				}
				bool flag3 = this.logTypes.SelectedIndex == 1;
				if (flag3)
				{
					text = this.Pars(File.ReadAllText(Directory + "\\" + this.Config.InformationFile), "IP : ", "Country Code", 0, null).Replace("\r\n", "");
					country = this.Pars(File.ReadAllText(Directory + "\\" + this.Config.InformationFile), "Country Code : ", "Country", 0, null).Replace("\r\n", "");
				}
				timeZone = new HttpRequest().Get("https://ipapi.co/" + text + "/utc_offset", null).ToString();
				result = new Log(Directory, Directory + "\\" + this.Config.DomainsFile, Directory + "\\" + this.Config.PasswordFile, text, country, timeZone);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002F94 File Offset: 0x00001194
		private void startButton_Click(object sender, EventArgs e)
		{
			bool @checked = this.unzipToggle.Checked;
			if (@checked)
			{
				this.GetDirectoryFromZip(Directory.GetFiles(this.path));
			}
			string[] directories = Directory.GetDirectories(this.path);
			foreach (string text in directories)
			{
                string dir = Directory.GetParent(text).FullName;
                Log logFromDirectory = this.GetLogFromDirectory(dir);
                bool flag = logFromDirectory != null;
				if (flag)
				{
					string text2 = new Random().Next().ToString() + " [";
					int num = 0;
					for (int j = 0; j < this.requestsListView.Items.Count; j++)
					{
						int num2 = 0;
						string text3 = File.ReadAllText(logFromDirectory.CookiePath);
						string text4 = File.ReadAllText(logFromDirectory.PasswordPath);
						bool flag2 = text3.Contains(this.requestsListView.Items[j].Text) && text4.Contains(this.requestsListView.Items[j].Text);
						if (flag2)
						{
							num++;
							bool flag3 = Directory.Exists(text + "\\Browsers");
							if (flag3)
							{
								bool flag4 = this.logTypes.SelectedIndex == 0;
								if (flag4)
								{
									num2 = logFromDirectory.GetLinesCount(this.requestsListView.Items[j].Text, "\\Browsers\\AutoComplete");
								}
								else
								{
									num2 = logFromDirectory.GetLinesCount(this.requestsListView.Items[j].Text, "\\Browsers");
								}
							}
							text2 = text2 + this.requestsListView.Items[j].Text + string.Format("[{0}] ,", num2);
						}
					}
					bool flag5 = num != 0;
					if (flag5)
					{
						bool flag6 = logFromDirectory.ContainsCC();
						if (flag6)
						{
							text2 += "] + [CC]";
						}
						text2 = string.Concat(new string[]
						{
							text2,
							"] ",
							logFromDirectory.Country,
							"  ",
							logFromDirectory.TimeZone,
							"  ",
							logFromDirectory.OtherDirectorys()
						});
                        Directory.CreateDirectory(this.currentPath + "\\Goods\\");
                        Directory.Move(text, this.currentPath + "\\Goods\\" + text2);
					}
				}
			}
			Process.Start(this.currentPath + "\\Goods\\");
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003218 File Offset: 0x00001418
		private void Sorter_Load(object sender, EventArgs e)
		{
			this.currentPath = Directory.GetCurrentDirectory();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003226 File Offset: 0x00001426
		private void clearButton_Click(object sender, EventArgs e)
		{
			this.requestsListView.Items.Clear();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000323C File Offset: 0x0000143C
		public string Pars(string strSource, string strStart, string strEnd, int startPos = 0, string error = null)
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

		// Token: 0x06000029 RID: 41 RVA: 0x000032B4 File Offset: 0x000014B4
		private void Sorter_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000032C0 File Offset: 0x000014C0
		private void logTypes_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.logTypes.SelectedIndex == 0;
			if (flag)
			{
				this.Config = new Config("PasswordsList.txt", "CookieList.txt", "ip.txt");
			}
			bool flag2 = this.logTypes.SelectedIndex == 1;
			if (flag2)
			{
				this.Config = new Config("passwords.log", "cookieDomains.log", "information.log");
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003328 File Offset: 0x00001528
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003360 File Offset: 0x00001560
		private void InitializeComponent()
		{
			this.requestsListView = new MetroListView();
			this.addButton = new MetroButton();
			this.linksCount = new MetroLabel();
			this.requstField = new MetroTextBox();
			this.loadButton = new MetroButton();
			this.startButton = new MetroButton();
			this.selectedPath = new MetroLabel();
			this.clearButton = new MetroButton();
			this.unzipToggle = new MetroToggle();
			this.metroLabel1 = new MetroLabel();
			this.logTypes = new MetroComboBox();
			base.SuspendLayout();
			this.requestsListView.Font = new Font("Segoe UI", 12f);
			this.requestsListView.FullRowSelect = true;
			this.requestsListView.Location = new Point(23, 85);
			this.requestsListView.Name = "requestsListView";
			this.requestsListView.OwnerDraw = true;
			this.requestsListView.Scrollable = false;
			this.requestsListView.Size = new Size(333, 181);
			this.requestsListView.TabIndex = 0;
			this.requestsListView.UseCompatibleStateImageBehavior = false;
			this.requestsListView.UseSelectable = true;
			this.requestsListView.View = View.List;
			this.addButton.Location = new Point(506, 176);
			this.addButton.Name = "addButton";
			this.addButton.Size = new Size(75, 23);
			this.addButton.TabIndex = 1;
			this.addButton.Text = "add";
			this.addButton.UseSelectable = true;
			this.addButton.Click += this.addButton_Click;
			this.linksCount.AutoSize = true;
			this.linksCount.Location = new Point(21, 57);
			this.linksCount.Name = "linksCount";
			this.linksCount.Size = new Size(72, 25);
			this.linksCount.TabIndex = 2;
			this.linksCount.Text = "Links:{0}";
			this.requstField.CustomButton.Image = null;
			this.requstField.CustomButton.Location = new Point(116, 1);
			this.requstField.CustomButton.Name = "";
			this.requstField.CustomButton.Size = new Size(21, 21);
			this.requstField.CustomButton.UseSelectable = true;
			this.requstField.CustomButton.Visible = false;
			this.requstField.Lines = new string[]
			{
				"link or link,link,link"
			};
			this.requstField.Location = new Point(362, 176);
			this.requstField.MaxLength = 32767;
			this.requstField.Name = "requstField";
			this.requstField.PasswordChar = '\0';
			this.requstField.ScrollBars = ScrollBars.None;
			this.requstField.SelectedText = "";
			this.requstField.SelectionLength = 0;
			this.requstField.SelectionStart = 0;
			this.requstField.ShortcutsEnabled = true;
			this.requstField.Size = new Size(138, 23);
			this.requstField.TabIndex = 3;
			this.requstField.Text = "link or link,link,link";
			this.requstField.UseSelectable = true;
			this.requstField.WaterMarkColor = Color.FromArgb(109, 109, 109);
			this.requstField.WaterMarkFont = new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel);
			this.loadButton.Location = new Point(362, 143);
			this.loadButton.Name = "loadButton";
			this.loadButton.Size = new Size(219, 23);
			this.loadButton.TabIndex = 5;
			this.loadButton.Text = "Load logs";
			this.loadButton.UseSelectable = true;
			this.loadButton.Click += this.loadButton_Click;
			this.startButton.Location = new Point(362, 85);
			this.startButton.Name = "startButton";
			this.startButton.Size = new Size(219, 23);
			this.startButton.TabIndex = 6;
			this.startButton.Text = "Start";
			this.startButton.UseSelectable = true;
			this.startButton.Click += this.startButton_Click;
			this.selectedPath.ForeColor = Color.Lime;
			this.selectedPath.Location = new Point(23, 276);
			this.selectedPath.Name = "selectedPath";
			this.selectedPath.Size = new Size(106, 25);
			this.selectedPath.TabIndex = 7;
			this.selectedPath.Text = "LogPath:{empty}";
			this.clearButton.Location = new Point(362, 114);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new Size(219, 23);
			this.clearButton.TabIndex = 8;
			this.clearButton.Text = "Clear";
			this.clearButton.UseSelectable = true;
			this.clearButton.Click += this.clearButton_Click;
			this.unzipToggle.AutoSize = true;
			this.unzipToggle.Location = new Point(457, 249);
			this.unzipToggle.Name = "unzipToggle";
			this.unzipToggle.Size = new Size(80, 17);
			this.unzipToggle.TabIndex = 10;
			this.unzipToggle.Text = "Off";
			this.unzipToggle.UseSelectable = true;
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.Location = new Point(362, 241);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new Size(89, 25);
			this.metroLabel1.TabIndex = 11;
			this.metroLabel1.Text = "Check .zip";
			this.logTypes.FormattingEnabled = true;
			this.logTypes.ItemHeight = 23;
			this.logTypes.Items.AddRange(new object[]
			{
				"Azor",
				"Baldar"
			});
			this.logTypes.Location = new Point(363, 206);
			this.logTypes.Name = "logTypes";
			this.logTypes.Size = new Size(218, 29);
			this.logTypes.TabIndex = 13;
			this.logTypes.UseSelectable = true;
			this.logTypes.SelectedIndexChanged += this.logTypes_SelectedIndexChanged;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(594, 311);
			base.Controls.Add(this.logTypes);
			base.Controls.Add(this.metroLabel1);
			base.Controls.Add(this.unzipToggle);
			base.Controls.Add(this.clearButton);
			base.Controls.Add(this.selectedPath);
			base.Controls.Add(this.startButton);
			base.Controls.Add(this.loadButton);
			base.Controls.Add(this.requstField);
			base.Controls.Add(this.linksCount);
			base.Controls.Add(this.addButton);
			base.Controls.Add(this.requestsListView);
			base.Name = "Sorter";
			base.Resizable = false;
			this.Text = "Cracked by cr4shed";
			base.Theme = 0;
			base.FormClosed += this.Sorter_FormClosed;
			base.Load += this.Sorter_Load;
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400000F RID: 15
		private string path;

		// Token: 0x04000010 RID: 16
		private string currentPath;

		// Token: 0x04000011 RID: 17
		private Config Config;

		// Token: 0x04000012 RID: 18
		private IContainer components = null;

		// Token: 0x04000013 RID: 19
		private MetroListView requestsListView;

		// Token: 0x04000014 RID: 20
		private MetroButton addButton;

		// Token: 0x04000015 RID: 21
		private MetroLabel linksCount;

		// Token: 0x04000016 RID: 22
		private MetroTextBox requstField;

		// Token: 0x04000017 RID: 23
		private MetroButton loadButton;

		// Token: 0x04000018 RID: 24
		private MetroButton startButton;

		// Token: 0x04000019 RID: 25
		private MetroLabel selectedPath;

		// Token: 0x0400001A RID: 26
		private MetroButton clearButton;

		// Token: 0x0400001B RID: 27
		private MetroToggle unzipToggle;

		// Token: 0x0400001C RID: 28
		private MetroLabel metroLabel1;

		// Token: 0x0400001D RID: 29
		private MetroComboBox logTypes;
	}
}
