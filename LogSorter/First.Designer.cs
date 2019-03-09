namespace LogSorter
{
	// Token: 0x02000002 RID: 2
	public partial class First : global::MetroFramework.Forms.MetroForm
	{
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
			this.Авторизация = new global::MetroFramework.Controls.MetroButton();
			this.Регистрац = new global::MetroFramework.Controls.MetroButton();
			this.metroTextBox1 = new global::MetroFramework.Controls.MetroTextBox();
			this.metroTextBox4 = new global::MetroFramework.Controls.MetroTextBox();
			base.SuspendLayout();
			this.Авторизация.Location = new global::System.Drawing.Point(43, 121);
			this.Авторизация.Name = "Авторизация";
			this.Авторизация.Size = new global::System.Drawing.Size(150, 23);
			this.Авторизация.TabIndex = 0;
			this.Авторизация.Text = "Авторизация";
			this.Авторизация.UseSelectable = true;
			this.Авторизация.Click += new global::System.EventHandler(this.Авторизация_Click);
			this.Регистрац.Location = new global::System.Drawing.Point(43, 150);
			this.Регистрац.Name = "Регистрац";
			this.Регистрац.Size = new global::System.Drawing.Size(150, 23);
			this.Регистрац.TabIndex = 1;
			this.Регистрац.Text = "Регистрация";
			this.Регистрац.UseSelectable = true;
			this.Регистрац.Click += new global::System.EventHandler(this.Регистрац_Click);
			this.metroTextBox1.CustomButton.Image = null;
			this.metroTextBox1.CustomButton.Location = new global::System.Drawing.Point(128, 1);
			this.metroTextBox1.CustomButton.Name = "";
			this.metroTextBox1.CustomButton.Size = new global::System.Drawing.Size(21, 21);
			this.metroTextBox1.CustomButton.Style = global::MetroFramework.MetroColorStyle.Blue;
			this.metroTextBox1.CustomButton.TabIndex = 1;
			this.metroTextBox1.CustomButton.Theme = global::MetroFramework.MetroThemeStyle.Light;
			this.metroTextBox1.CustomButton.UseSelectable = true;
			this.metroTextBox1.CustomButton.Visible = false;
			this.metroTextBox1.Lines = new string[]
			{
				"Логин"
			};
			this.metroTextBox1.Location = new global::System.Drawing.Point(43, 63);
			this.metroTextBox1.MaxLength = 32767;
			this.metroTextBox1.Name = "metroTextBox1";
			this.metroTextBox1.PasswordChar = '\0';
			this.metroTextBox1.ScrollBars = global::System.Windows.Forms.ScrollBars.None;
			this.metroTextBox1.SelectedText = "";
			this.metroTextBox1.SelectionLength = 0;
			this.metroTextBox1.SelectionStart = 0;
			this.metroTextBox1.ShortcutsEnabled = true;
			this.metroTextBox1.Size = new global::System.Drawing.Size(150, 23);
			this.metroTextBox1.TabIndex = 2;
			this.metroTextBox1.Text = "Логин";
			this.metroTextBox1.UseSelectable = true;
			this.metroTextBox1.WaterMarkColor = global::System.Drawing.Color.FromArgb(109, 109, 109);
			this.metroTextBox1.WaterMarkFont = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Italic, global::System.Drawing.GraphicsUnit.Pixel);
			this.metroTextBox4.CustomButton.Image = null;
			this.metroTextBox4.CustomButton.Location = new global::System.Drawing.Point(128, 1);
			this.metroTextBox4.CustomButton.Name = "";
			this.metroTextBox4.CustomButton.Size = new global::System.Drawing.Size(21, 21);
			this.metroTextBox4.CustomButton.Style = global::MetroFramework.MetroColorStyle.Blue;
			this.metroTextBox4.CustomButton.TabIndex = 1;
			this.metroTextBox4.CustomButton.Theme = global::MetroFramework.MetroThemeStyle.Light;
			this.metroTextBox4.CustomButton.UseSelectable = true;
			this.metroTextBox4.CustomButton.Visible = false;
			this.metroTextBox4.Lines = new string[]
			{
				"Ключ"
			};
			this.metroTextBox4.Location = new global::System.Drawing.Point(43, 92);
			this.metroTextBox4.MaxLength = 32767;
			this.metroTextBox4.Name = "metroTextBox4";
			this.metroTextBox4.PasswordChar = '\0';
			this.metroTextBox4.ScrollBars = global::System.Windows.Forms.ScrollBars.None;
			this.metroTextBox4.SelectedText = "";
			this.metroTextBox4.SelectionLength = 0;
			this.metroTextBox4.SelectionStart = 0;
			this.metroTextBox4.ShortcutsEnabled = true;
			this.metroTextBox4.Size = new global::System.Drawing.Size(150, 23);
			this.metroTextBox4.TabIndex = 5;
			this.metroTextBox4.Text = "Ключ";
			this.metroTextBox4.UseSelectable = true;
			this.metroTextBox4.WaterMarkColor = global::System.Drawing.Color.FromArgb(109, 109, 109);
			this.metroTextBox4.WaterMarkFont = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Italic, global::System.Drawing.GraphicsUnit.Pixel);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(244, 201);
			base.Controls.Add(this.metroTextBox4);
			base.Controls.Add(this.metroTextBox1);
			base.Controls.Add(this.Регистрац);
			base.Controls.Add(this.Авторизация);
			base.Name = "First";
			base.Resizable = false;
			this.Text = "Auth";
			base.Load += new global::System.EventHandler(this.First_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x04000001 RID: 1
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000002 RID: 2
		private global::MetroFramework.Controls.MetroButton Авторизация;

		// Token: 0x04000003 RID: 3
		private global::MetroFramework.Controls.MetroButton Регистрац;

		// Token: 0x04000004 RID: 4
		private global::MetroFramework.Controls.MetroTextBox metroTextBox1;

		// Token: 0x04000005 RID: 5
		private global::MetroFramework.Controls.MetroTextBox metroTextBox4;
	}
}
