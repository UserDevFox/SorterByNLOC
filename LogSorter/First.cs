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
	// Token: 0x02000003 RID: 3
	public class First : MetroForm
	{
		// Token: 0x06000008 RID: 8 RVA: 0x000020DE File Offset: 0x000002DE
		public First()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020F8 File Offset: 0x000002F8
		private void Auth_Click(object sender, EventArgs e)
		{
			Auth auth = new Auth();
            string login = metroTextBox1.Text;
            string pass = metroTextBox4.Text;
			if (login != "Софт хуйня" && pass != "кста, я крол")
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

		// Token: 0x0600000A RID: 10 RVA: 0x0000215C File Offset: 0x0000035C
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

		// Token: 0x0600000B RID: 11 RVA: 0x00002210 File Offset: 0x00000410
		private void Registration_Click(object sender, EventArgs e)
		{
			
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000022A4 File Offset: 0x000004A4
		private void First_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002324 File Offset: 0x00000524
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000235C File Offset: 0x0000055C
		private void InitializeComponent()
		{
			this.Auth = new MetroButton();
			this.Registration = new MetroButton();
			this.metroTextBox1 = new MetroTextBox();
			this.metroTextBox4 = new MetroTextBox();
			base.SuspendLayout();
			this.Auth.Location = new Point(43, 121);
			this.Auth.Name = "Auth";
			this.Auth.Size = new Size(150, 23);
			this.Auth.TabIndex = 0;
			this.Auth.Text = "Авторизация";
			this.Auth.UseSelectable = true;
			this.Auth.Click += this.Auth_Click;
			this.Registration.Location = new Point(43, 150);
			this.Registration.Name = "Registration";
			this.Registration.Size = new Size(150, 23);
			this.Registration.TabIndex = 1;
			this.Registration.Text = "Регистрация";
			this.Registration.UseSelectable = true;
			this.Registration.Click += this.Registration_Click;
			this.metroTextBox1.CustomButton.Image = null;
			this.metroTextBox1.CustomButton.Location = new Point(128, 1);
			this.metroTextBox1.CustomButton.Name = "";
			this.metroTextBox1.CustomButton.Size = new Size(21, 21);
			this.metroTextBox1.CustomButton.TabIndex = 1;
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
			this.metroTextBox4.CustomButton.TabIndex = 1;
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
			base.Controls.Add(this.Registration);
			base.Controls.Add(this.Auth);
			base.Name = "First";
			base.Resizable = false;
			this.Text = "Auth";
			base.Load += this.First_Load;
			base.ResumeLayout(false);
		}

		// Token: 0x04000004 RID: 4
		private IContainer components = null;

		// Token: 0x04000005 RID: 5
		private MetroButton Auth;

		// Token: 0x04000006 RID: 6
		private MetroButton Registration;

		// Token: 0x04000007 RID: 7
		private MetroTextBox metroTextBox1;

		// Token: 0x04000008 RID: 8
		private MetroTextBox metroTextBox4;
	}
}
