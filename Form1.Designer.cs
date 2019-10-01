namespace WorkshopUploader
{
	// Token: 0x02000005 RID: 5
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x06000016 RID: 22 RVA: 0x00002809 File Offset: 0x00000A09
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002828 File Offset: 0x00000A28
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::WorkshopUploader.Form1));
			this.btnContentButton = new global::System.Windows.Forms.Button();
			this.txtContentFolder = new global::System.Windows.Forms.TextBox();
			this.txtTitle = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.txtDescription = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.txtPreviewImage = new global::System.Windows.Forms.TextBox();
			this.btnPreviewButton = new global::System.Windows.Forms.Button();
			this.btnSendContentButton = new global::System.Windows.Forms.Button();
			this.label3 = new global::System.Windows.Forms.Label();
			this.cboCategory = new global::System.Windows.Forms.ComboBox();
			this.toolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
			this.cboVisibility = new global::System.Windows.Forms.ComboBox();
			this.label4 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnContentButton.Location = new global::System.Drawing.Point(751, 136);
			this.btnContentButton.Name = "btnContentButton";
			this.btnContentButton.Size = new global::System.Drawing.Size(104, 25);
			this.btnContentButton.TabIndex = 9;
			this.btnContentButton.Text = "Content Folder";
			this.toolTip1.SetToolTip(this.btnContentButton, "Browse...");
			this.btnContentButton.UseVisualStyleBackColor = true;
			this.btnContentButton.Click += new global::System.EventHandler(this.btnContentButton_Click);
			this.txtContentFolder.Location = new global::System.Drawing.Point(14, 139);
			this.txtContentFolder.Name = "txtContentFolder";
			this.txtContentFolder.Size = new global::System.Drawing.Size(728, 20);
			this.txtContentFolder.TabIndex = 8;
			this.toolTip1.SetToolTip(this.txtContentFolder, "Choose a folder on your machine that contains the contents of the Workshop Item. Examples: 3D Models, 2D Art, ideas, ect.");
			this.txtTitle.Location = new global::System.Drawing.Point(76, 9);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new global::System.Drawing.Size(779, 20);
			this.txtTitle.TabIndex = 2;
			this.toolTip1.SetToolTip(this.txtTitle, "This will be the title of the Workshop Item shown to others on the Workshop Page");
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(14, 12);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(27, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Title";
			this.txtDescription.Location = new global::System.Drawing.Point(76, 53);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new global::System.Drawing.Size(779, 20);
			this.txtDescription.TabIndex = 4;
			this.toolTip1.SetToolTip(this.txtDescription, "This will be the description of the Workshop Item shown to others when viewing the item");
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(14, 56);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(60, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Description";
			this.txtPreviewImage.Location = new global::System.Drawing.Point(14, 182);
			this.txtPreviewImage.Name = "txtPreviewImage";
			this.txtPreviewImage.Size = new global::System.Drawing.Size(728, 20);
			this.txtPreviewImage.TabIndex = 11;
			this.toolTip1.SetToolTip(this.txtPreviewImage, "Choose a PNG/JPG file on your computer that shows off your Workshop content.");
			this.btnPreviewButton.Location = new global::System.Drawing.Point(751, 179);
			this.btnPreviewButton.Name = "btnPreviewButton";
			this.btnPreviewButton.Size = new global::System.Drawing.Size(104, 25);
			this.btnPreviewButton.TabIndex = 12;
			this.btnPreviewButton.Text = "Preview Image";
			this.toolTip1.SetToolTip(this.btnPreviewButton, "Browse...");
			this.btnPreviewButton.UseVisualStyleBackColor = true;
			this.btnPreviewButton.Click += new global::System.EventHandler(this.btnPreviewButton_Click);
			this.btnSendContentButton.Location = new global::System.Drawing.Point(338, 234);
			this.btnSendContentButton.Name = "btnSendContentButton";
			this.btnSendContentButton.Size = new global::System.Drawing.Size(191, 30);
			this.btnSendContentButton.TabIndex = 50;
			this.btnSendContentButton.Text = "Upload Content";
			this.toolTip1.SetToolTip(this.btnSendContentButton, "This will upload the Workshop Item up to Steam and open your Workshop Page.  PLEASE BE LOGGED IN TO STEAM ON THE STEAM WEBSITE!");
			this.btnSendContentButton.UseVisualStyleBackColor = true;
			this.btnSendContentButton.Click += new global::System.EventHandler(this.sendContentButton_Click);
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(15, 100);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(49, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Category";
			this.cboCategory.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCategory.FormattingEnabled = true;
			this.cboCategory.ImeMode = global::System.Windows.Forms.ImeMode.On;
			this.cboCategory.Items.AddRange(new object[]
			{
				"Maps"
			});
			this.cboCategory.Location = new global::System.Drawing.Point(76, 97);
			this.cboCategory.Name = "cboCategory";
			this.cboCategory.Size = new global::System.Drawing.Size(121, 21);
			this.cboCategory.TabIndex = 6;
			this.toolTip1.SetToolTip(this.cboCategory, "This will be the category the Workshop Item will be placed in on the Workshop Page");
			this.toolTip1.AutomaticDelay = 0;
			this.toolTip1.AutoPopDelay = 15000;
			this.toolTip1.InitialDelay = 200;
			this.toolTip1.ReshowDelay = 200;
			this.cboVisibility.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboVisibility.FormattingEnabled = true;
			this.cboVisibility.ImeMode = global::System.Windows.Forms.ImeMode.On;
			this.cboVisibility.Items.AddRange(new object[]
			{
				"Public",
				"Friends Only",
				"Private"
			});
			this.cboVisibility.Location = new global::System.Drawing.Point(321, 97);
			this.cboVisibility.Name = "cboVisibility";
			this.cboVisibility.Size = new global::System.Drawing.Size(121, 21);
			this.cboVisibility.TabIndex = 51;
			this.toolTip1.SetToolTip(this.cboVisibility, "This will set the Workshop Item's visibility on the Workshop Page");
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(266, 100);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(43, 13);
			this.label4.TabIndex = 52;
			this.label4.Text = "Visibility";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(867, 276);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.cboVisibility);
			base.Controls.Add(this.cboCategory);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.btnSendContentButton);
			base.Controls.Add(this.txtPreviewImage);
			base.Controls.Add(this.btnPreviewButton);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.txtDescription);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.txtTitle);
			base.Controls.Add(this.txtContentFolder);
			base.Controls.Add(this.btnContentButton);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Form1";
			this.Text = "Rocket League ® Steam Workshop Uploader";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400000A RID: 10
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Button btnContentButton;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.TextBox txtContentFolder;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.TextBox txtTitle;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.TextBox txtDescription;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.TextBox txtPreviewImage;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.Button btnPreviewButton;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.Button btnSendContentButton;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.ComboBox cboCategory;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.ToolTip toolTip1;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.ComboBox cboVisibility;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.Label label4;
	}
}
