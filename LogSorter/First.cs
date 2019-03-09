using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
//using Authed;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Win32;

namespace LogSorter
{
	// Token: 0x02000002 RID: 2
	public partial class First : MetroForm
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public First()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
		private void Авторизация_Click(object sender, EventArgs e)
		{
			//Auth auth = new Auth();
			//bool flag = auth.Authenticate("cF2QSm8WOthuj81GP9xCRswByqEPO0ecB48eXJcuib0lf");
			//bool flag2 = auth.Login(this.metroTextBox1.Text, this.GetMachineGuid());
			//bool flag3 = flag2;
			if (metroTextBox1.Text != "Кодер" && metroTextBox4.Text != "Жопорук")
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
			//Auth auth = new Auth();
			//bool flag = auth.Authenticate("cF2QSm8WOthuj81GP9xCRswByqEPO0ecB48eXJcuib0lf");
			//bool flag2 = auth.Register(this.metroTextBox1.Text, this.GetMachineGuid(), "123123", this.metroTextBox4.Text);
			//bool flag3 = flag2;
			//if (flag3)
			{
				File.AppendAllText("data.txt", this.metroTextBox1.Text);
				Sorter sorter = new Sorter();
				base.Hide();
				sorter.ShowDialog();
				base.Show();
			}
			//else
			{
			//	MessageBox.Show("Не работает!");
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002214 File Offset: 0x00000414
		private void First_Load(object sender, EventArgs e)
		{
			try
			{
				string username = File.ReadAllText("data.txt");
				//Auth auth = new Auth();
				//bool flag = auth.Authenticate("x1CB18f7hq7UAzbQzu17lFa9xmbQiAe9SynMSS5F90p1E");
				//bool flag2 = auth.Login(username, this.GetMachineGuid());
				//bool flag3 = flag2;
			    if (metroTextBox1.Text != "Кодер" && metroTextBox4.Text != "Жопорук")
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
	}
}
