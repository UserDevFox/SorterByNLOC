namespace LogSorter
{
	// Token: 0x02000004 RID: 4
	public partial class Sorter : global::MetroFramework.Forms.MetroForm
	{
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
			this.metroListView1 = new global::MetroFramework.Controls.MetroListView();
			this.metroButton1 = new global::MetroFramework.Controls.MetroButton();
			this.linksCount = new global::MetroFramework.Controls.MetroLabel();
			this.metroTextBox1 = new global::MetroFramework.Controls.MetroTextBox();
			this.metroButton2 = new global::MetroFramework.Controls.MetroButton();
			this.metroButton3 = new global::MetroFramework.Controls.MetroButton();
			this.spath = new global::MetroFramework.Controls.MetroLabel();
			this.metroButton4 = new global::MetroFramework.Controls.MetroButton();
			this.metroCheckBox1 = new global::MetroFramework.Controls.MetroCheckBox();
			this.metroToggle1 = new global::MetroFramework.Controls.MetroToggle();
			this.metroLabel1 = new global::MetroFramework.Controls.MetroLabel();
			this.metroCheckBox2 = new global::MetroFramework.Controls.MetroCheckBox();
			base.SuspendLayout();
			this.metroListView1.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.metroListView1.FullRowSelect = true;
			this.metroListView1.Location = new global::System.Drawing.Point(23, 85);
			this.metroListView1.Name = "metroListView1";
			this.metroListView1.OwnerDraw = true;
			this.metroListView1.Scrollable = false;
			this.metroListView1.Size = new global::System.Drawing.Size(333, 160);
			this.metroListView1.TabIndex = 0;
			this.metroListView1.Theme = global::MetroFramework.MetroThemeStyle.Light;
			this.metroListView1.UseCompatibleStateImageBehavior = false;
			this.metroListView1.UseSelectable = true;
			this.metroListView1.View = global::System.Windows.Forms.View.List;
			this.metroButton1.Location = new global::System.Drawing.Point(506, 176);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new global::System.Drawing.Size(75, 23);
			this.metroButton1.TabIndex = 1;
			this.metroButton1.Text = "add";
			this.metroButton1.Theme = global::MetroFramework.MetroThemeStyle.Light;
			this.metroButton1.UseSelectable = true;
			this.metroButton1.Click += new global::System.EventHandler(this.metroButton1_Click);
			this.linksCount.AutoSize = true;
			this.linksCount.FontSize = global::MetroFramework.MetroLabelSize.Tall;
			this.linksCount.Location = new global::System.Drawing.Point(21, 57);
			this.linksCount.Name = "linksCount";
			this.linksCount.Size = new global::System.Drawing.Size(72, 25);
			this.linksCount.TabIndex = 2;
			this.linksCount.Text = "Links:{0}";
			this.linksCount.Theme = global::MetroFramework.MetroThemeStyle.Light;
			this.metroTextBox1.CustomButton.Image = null;
			this.metroTextBox1.CustomButton.Location = new global::System.Drawing.Point(116, 1);
			this.metroTextBox1.CustomButton.Name = "";
			this.metroTextBox1.CustomButton.Size = new global::System.Drawing.Size(21, 21);
			this.metroTextBox1.CustomButton.Style = global::MetroFramework.MetroColorStyle.Blue;
			this.metroTextBox1.CustomButton.TabIndex = 1;
			this.metroTextBox1.CustomButton.Theme = global::MetroFramework.MetroThemeStyle.Light;
			this.metroTextBox1.CustomButton.UseSelectable = true;
			this.metroTextBox1.CustomButton.Visible = false;
			this.metroTextBox1.Lines = new string[]
			{
				"link or link,link,link"
			};
			this.metroTextBox1.Location = new global::System.Drawing.Point(362, 176);
			this.metroTextBox1.MaxLength = 32767;
			this.metroTextBox1.Name = "metroTextBox1";
			this.metroTextBox1.PasswordChar = '\0';
			this.metroTextBox1.ScrollBars = global::System.Windows.Forms.ScrollBars.None;
			this.metroTextBox1.SelectedText = "";
			this.metroTextBox1.SelectionLength = 0;
			this.metroTextBox1.SelectionStart = 0;
			this.metroTextBox1.ShortcutsEnabled = true;
			this.metroTextBox1.Size = new global::System.Drawing.Size(138, 23);
			this.metroTextBox1.TabIndex = 3;
			this.metroTextBox1.Text = "link or link,link,link";
			this.metroTextBox1.Theme = global::MetroFramework.MetroThemeStyle.Light;
			this.metroTextBox1.UseSelectable = true;
			this.metroTextBox1.WaterMarkColor = global::System.Drawing.Color.FromArgb(109, 109, 109);
			this.metroTextBox1.WaterMarkFont = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Italic, global::System.Drawing.GraphicsUnit.Pixel);
			this.metroButton2.Location = new global::System.Drawing.Point(362, 143);
			this.metroButton2.Name = "metroButton2";
			this.metroButton2.Size = new global::System.Drawing.Size(219, 23);
			this.metroButton2.TabIndex = 5;
			this.metroButton2.Text = "Load logs";
			this.metroButton2.Theme = global::MetroFramework.MetroThemeStyle.Light;
			this.metroButton2.UseSelectable = true;
			this.metroButton2.Click += new global::System.EventHandler(this.metroButton2_Click);
			this.metroButton3.Location = new global::System.Drawing.Point(362, 85);
			this.metroButton3.Name = "metroButton3";
			this.metroButton3.Size = new global::System.Drawing.Size(219, 23);
			this.metroButton3.TabIndex = 6;
			this.metroButton3.Text = "Start";
			this.metroButton3.Theme = global::MetroFramework.MetroThemeStyle.Light;
			this.metroButton3.UseSelectable = true;
			this.metroButton3.Click += new global::System.EventHandler(this.metroButton3_Click);
			this.spath.AutoSize = true;
			this.spath.FontSize = global::MetroFramework.MetroLabelSize.Tall;
			this.spath.ForeColor = global::System.Drawing.Color.Lime;
			this.spath.Location = new global::System.Drawing.Point(21, 260);
			this.spath.Name = "spath";
			this.spath.Size = new global::System.Drawing.Size(106, 25);
			this.spath.TabIndex = 7;
			this.spath.Text = "Path:{empty}";
			this.spath.Theme = global::MetroFramework.MetroThemeStyle.Light;
			this.spath.Click += new global::System.EventHandler(this.spath_Click);
			this.metroButton4.Location = new global::System.Drawing.Point(362, 114);
			this.metroButton4.Name = "metroButton4";
			this.metroButton4.Size = new global::System.Drawing.Size(219, 23);
			this.metroButton4.TabIndex = 8;
			this.metroButton4.Text = "Clear";
			this.metroButton4.Theme = global::MetroFramework.MetroThemeStyle.Light;
			this.metroButton4.UseSelectable = true;
			this.metroButton4.Click += new global::System.EventHandler(this.metroButton4_Click);
			this.metroCheckBox1.AutoSize = true;
			this.metroCheckBox1.Checked = true;
			this.metroCheckBox1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.metroCheckBox1.Location = new global::System.Drawing.Point(367, 230);
			this.metroCheckBox1.Name = "metroCheckBox1";
			this.metroCheckBox1.Size = new global::System.Drawing.Size(75, 15);
			this.metroCheckBox1.TabIndex = 9;
			this.metroCheckBox1.Text = "Check CC";
			this.metroCheckBox1.UseSelectable = true;
			this.metroToggle1.AutoSize = true;
			this.metroToggle1.Location = new global::System.Drawing.Point(457, 209);
			this.metroToggle1.Name = "metroToggle1";
			this.metroToggle1.Size = new global::System.Drawing.Size(80, 17);
			this.metroToggle1.TabIndex = 10;
			this.metroToggle1.Text = "Off";
			this.metroToggle1.UseSelectable = true;
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.FontSize = global::MetroFramework.MetroLabelSize.Tall;
			this.metroLabel1.Location = new global::System.Drawing.Point(362, 202);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new global::System.Drawing.Size(89, 25);
			this.metroLabel1.TabIndex = 11;
			this.metroLabel1.Text = "Check .zip";
			this.metroCheckBox2.AutoSize = true;
			this.metroCheckBox2.Location = new global::System.Drawing.Point(448, 230);
			this.metroCheckBox2.Name = "metroCheckBox2";
			this.metroCheckBox2.Size = new global::System.Drawing.Size(111, 15);
			this.metroCheckBox2.TabIndex = 12;
			this.metroCheckBox2.Text = "Check Timezone";
			this.metroCheckBox2.UseSelectable = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(594, 292);
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
			base.Theme = global::MetroFramework.MetroThemeStyle.Default;
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.Sorter_FormClosed);
			base.Load += new global::System.EventHandler(this.Sorter_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400000E RID: 14
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400000F RID: 15
		private global::MetroFramework.Controls.MetroListView metroListView1;

		// Token: 0x04000010 RID: 16
		private global::MetroFramework.Controls.MetroButton metroButton1;

		// Token: 0x04000011 RID: 17
		private global::MetroFramework.Controls.MetroLabel linksCount;

		// Token: 0x04000012 RID: 18
		private global::MetroFramework.Controls.MetroTextBox metroTextBox1;

		// Token: 0x04000013 RID: 19
		private global::MetroFramework.Controls.MetroButton metroButton2;

		// Token: 0x04000014 RID: 20
		private global::MetroFramework.Controls.MetroButton metroButton3;

		// Token: 0x04000015 RID: 21
		private global::MetroFramework.Controls.MetroLabel spath;

		// Token: 0x04000016 RID: 22
		private global::MetroFramework.Controls.MetroButton metroButton4;

		// Token: 0x04000017 RID: 23
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox1;

		// Token: 0x04000018 RID: 24
		private global::MetroFramework.Controls.MetroToggle metroToggle1;

		// Token: 0x04000019 RID: 25
		private global::MetroFramework.Controls.MetroLabel metroLabel1;

		// Token: 0x0400001A RID: 26
		private global::MetroFramework.Controls.MetroCheckBox metroCheckBox2;
	}
}
