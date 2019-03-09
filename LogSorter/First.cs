using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Authed;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Win32;

namespace LogSorter
{
	// Token: 0x02000002 RID: 2
	public class First : MetroForm
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public First()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
		private void Авторизация_Click(object sender, EventArgs e)
		{
			Auth auth = new Auth();
			bool flag = auth.Authenticate("cF2QSm8WOthuj81GP9xCRswByqEPO0ecB48eXJcuib0lf");
			bool flag2 = auth.Login(this.metroTextBox1.Text, this.GetMachineGuid());
			bool flag3 = flag2;
			if (flag3)
			{
				Sorter sorter = new Sorter();
				base.Hide();
				sorter.ShowDialog();
			}
			else
			{
				MessageBox.Show("Не работает!");
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020CC File Offset: 0x000002CC
		public string GetMachineGuid()
		{
			string text = "SOFTWARE\\Microsoft\\Cryptography";
			string text2 = "MachineGuid";
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
				{
					bool flag = registryKey2 == null;
					if (flag)
					{
						throw new KeyNotFoundException(string.Format("Key Not Found: {0}", text));
					}
					object value = registryKey2.GetValue(text2);
					bool flag2 = value == null;
					if (flag2)
					{
						throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", text2));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002180 File Offset: 0x00000380
		private void Регистрац_Click(object sender, EventArgs e)
		{
			Auth auth = new Auth();
			bool flag = auth.Authenticate("cF2QSm8WOthuj81GP9xCRswByqEPO0ecB48eXJcuib0lf");
			bool flag2 = auth.Register(this.metroTextBox1.Text, this.GetMachineGuid(), "123123", this.metroTextBox4.Text);
			bool flag3 = flag2;
			if (flag3)
			{
				File.AppendAllText("data.txt", this.metroTextBox1.Text);
				Sorter sorter = new Sorter();
				base.Hide();
				sorter.ShowDialog();
				base.Show();
			}
			else
			{
				MessageBox.Show("Не работает!");
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002214 File Offset: 0x00000414
		private void First_Load(object sender, EventArgs e)
		{
			try
			{
				string text = File.ReadAllText("data.txt");
				Auth auth = new Auth();
				bool flag = auth.Authenticate("x1CB18f7hq7UAzbQzu17lFa9xmbQiAe9SynMSS5F90p1E");
				bool flag2 = auth.Login(text, this.GetMachineGuid());
				bool flag3 = flag2;
				if (flag3)
				{
					Sorter sorter = new Sorter();
					base.Hide();
					sorter.ShowDialog();
				}
				else
				{
					MessageBox.Show("Не работает!");
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002294 File Offset: 0x00000494
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000022CC File Offset: 0x000004CC
		private void InitializeComponent()
		{
			this.Авторизация = new MetroButton();
			this.Регистрац = new MetroButton();
			this.metroTextBox1 = new MetroTextBox();
			this.metroTextBox4 = new MetroTextBox();
			base.SuspendLayout();
			this.Авторизация.Location = new Point(43, 121);
			this.Авторизация.Name = "Авторизация";
			this.Авторизация.Size = new Size(150, 23);
			this.Авторизация.TabIndex = 0;
			this.Авторизация.Text = "Авторизация";
			this.Авторизация.UseSelectable = true;
			this.Авторизация.Click += this.Авторизация_Click;
			this.Регистрац.Location = new Point(43, 150);
			this.Регистрац.Name = "Регистрац";
			this.Регистрац.Size = new Size(150, 23);
			this.Регистрац.TabIndex = 1;
			this.Регистрац.Text = "Регистрация";
			this.Регистрац.UseSelectable = true;
			this.Регистрац.Click += this.Регистрац_Click;
			this.metroTextBox1.CustomButton.Image = null;
			this.metroTextBox1.CustomButton.Location = new Point(128, 1);
			this.metroTextBox1.CustomButton.Name = "";
			this.metroTextBox1.CustomButton.Size = new Size(21, 21);
			this.metroTextBox1.CustomButton.Style = 4;
			this.metroTextBox1.CustomButton.TabIndex = 1;
			this.metroTextBox1.CustomButton.Theme = 1;
			this.metroTextBox1.CustomButton.UseSelectable = true;
			this.metroTextBox1.CustomButton.Visible = false;
			this.metroTextBox1.Lines = new string[]
			{
				"Логин"
			};
			this.metroTextBox1.Location = new Point(43, 63);
			this.metroTextBox1.MaxLength = 32767;
			this.metroTextBox1.Name = "metroTextBox1";
			this.metroTextBox1.PasswordChar = '\0';
			this.metroTextBox1.ScrollBars = ScrollBars.None;
			this.metroTextBox1.SelectedText = "";
			this.metroTextBox1.SelectionLength = 0;
			this.metroTextBox1.SelectionStart = 0;
			this.metroTextBox1.ShortcutsEnabled = true;
			this.metroTextBox1.Size = new Size(150, 23);
			this.metroTextBox1.TabIndex = 2;
			this.metroTextBox1.Text = "Логин";
			this.metroTextBox1.UseSelectable = true;
			this.metroTextBox1.WaterMarkColor = Color.FromArgb(109, 109, 109);
			this.metroTextBox1.WaterMarkFont = new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel);
			this.metroTextBox4.CustomButton.Image = null;
			this.metroTextBox4.CustomButton.Location = new Point(128, 1);
			this.metroTextBox4.CustomButton.Name = "";
			this.metroTextBox4.CustomButton.Size = new Size(21, 21);
			this.metroTextBox4.CustomButton.Style = 4;
			this.metroTextBox4.CustomButton.TabIndex = 1;
			this.metroTextBox4.CustomButton.Theme = 1;
			this.metroTextBox4.CustomButton.UseSelectable = true;
			this.metroTextBox4.CustomButton.Visible = false;
			this.metroTextBox4.Lines = new string[]
			{
				"Ключ"
			};
			this.metroTextBox4.Location = new Point(43, 92);
			this.metroTextBox4.MaxLength = 32767;
			this.metroTextBox4.Name = "metroTextBox4";
			this.metroTextBox4.PasswordChar = '\0';
			this.metroTextBox4.ScrollBars = ScrollBars.None;
			this.metroTextBox4.SelectedText = "";
			this.metroTextBox4.SelectionLength = 0;
			this.metroTextBox4.SelectionStart = 0;
			this.metroTextBox4.ShortcutsEnabled = true;
			this.metroTextBox4.Size = new Size(150, 23);
			this.metroTextBox4.TabIndex = 5;
			this.metroTextBox4.Text = "Ключ";
			this.metroTextBox4.UseSelectable = true;
			this.metroTextBox4.WaterMarkColor = Color.FromArgb(109, 109, 109);
			this.metroTextBox4.WaterMarkFont = new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(244, 201);
			base.Controls.Add(this.metroTextBox4);
			base.Controls.Add(this.metroTextBox1);
			base.Controls.Add(this.Регистрац);
			base.Controls.Add(this.Авторизация);
			base.Name = "First";
			base.Resizable = false;
			this.Text = "Auth";
			base.Load += this.First_Load;
			base.ResumeLayout(false);
		}

		// Token: 0x04000001 RID: 1
		private IContainer components = null;

		// Token: 0x04000002 RID: 2
		private MetroButton Авторизация;

		// Token: 0x04000003 RID: 3
		private MetroButton Регистрац;

		// Token: 0x04000004 RID: 4
		private MetroTextBox metroTextBox1;

		// Token: 0x04000005 RID: 5
		private MetroTextBox metroTextBox4;
	}
}
