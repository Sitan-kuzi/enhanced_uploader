namespace WorkshopUploader
{
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.workshopTypeMap = new System.Windows.Forms.TabPage();
            this.workshopTypeItem = new System.Windows.Forms.TabPage();
            this.btnContentButton = new System.Windows.Forms.Button();
            this.txtContentFolder = new System.Windows.Forms.TextBox();
            this.workshopId = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPreviewImage = new System.Windows.Forms.TextBox();
            this.btnPreviewButton = new System.Windows.Forms.Button();
            this.btnSendContentButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label(); 
            this.cboCategory = new System.Windows.Forms.CheckBoxComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cboVisibility = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.workshopTypeMap);
            this.tabControl.Controls.Add(this.workshopTypeItem);
            this.tabControl.ItemSize = new System.Drawing.Size(12, 18);
            this.tabControl.Location = new System.Drawing.Point(4, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(860, 260);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.btnWorkshopType_Changed);
            // 
            // workshopTypeMap
            // 
            this.workshopTypeMap.Location = new System.Drawing.Point(4, 22);
            this.workshopTypeMap.Name = "workshopTypeMap";
            this.workshopTypeMap.Size = new System.Drawing.Size(852, 234);
            this.workshopTypeMap.TabIndex = 3;
            this.workshopTypeMap.Text = "Map";
            // 
            // workshopTypeItem
            // 
            this.workshopTypeItem.Location = new System.Drawing.Point(4, 22);
            this.workshopTypeItem.Name = "workshopTypeItem";
            this.workshopTypeItem.Size = new System.Drawing.Size(852, 234);
            this.workshopTypeItem.TabIndex = 3;
            this.workshopTypeItem.Text = "Item";
            // 
            // btnContentButton
            // 
            this.btnContentButton.Location = new System.Drawing.Point(750, 171);
            this.btnContentButton.Name = "btnContentButton";
            this.btnContentButton.Size = new System.Drawing.Size(104, 25);
            this.btnContentButton.TabIndex = 9;
            this.btnContentButton.Text = "Content Folder";
            this.toolTip1.SetToolTip(this.btnContentButton, "Browse...");
            this.btnContentButton.UseVisualStyleBackColor = true;
            this.btnContentButton.Click += new System.EventHandler(this.btnContentButton_Click);
            // 
            // txtContentFolder
            // 
            this.txtContentFolder.Location = new System.Drawing.Point(13, 174);
            this.txtContentFolder.Name = "txtContentFolder";
            this.txtContentFolder.Size = new System.Drawing.Size(728, 20);
            this.txtContentFolder.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtContentFolder, "Choose a folder on your machine that contains the contents of the Workshop Item. " +
        "Examples: 3D Models, 2D Art, ideas, ect.");
            // 
            // workshopId
            // 
            this.workshopId.Enabled = false;
            this.workshopId.Location = new System.Drawing.Point(729, 6);
            this.workshopId.Name = "workshopId";
            this.workshopId.Size = new System.Drawing.Size(125, 20);
            this.workshopId.TabIndex = 1;
            this.workshopId.TabStop = false;
            this.workshopId.Text = "0";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(75, 47);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(779, 20);
            this.txtTitle.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtTitle, "This will be the title of the Workshop Item shown to others on the Workshop Page");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Title";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(75, 88);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(779, 20);
            this.txtDescription.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtDescription, "This will be the description of the Workshop Item shown to others when viewing th" +
        "e item");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description";
            // 
            // txtPreviewImage
            // 
            this.txtPreviewImage.Location = new System.Drawing.Point(13, 217);
            this.txtPreviewImage.Name = "txtPreviewImage";
            this.txtPreviewImage.Size = new System.Drawing.Size(728, 20);
            this.txtPreviewImage.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtPreviewImage, "Choose a PNG/JPG file on your computer that shows off your Workshop content.");
            // 
            // btnPreviewButton
            // 
            this.btnPreviewButton.Location = new System.Drawing.Point(750, 214);
            this.btnPreviewButton.Name = "btnPreviewButton";
            this.btnPreviewButton.Size = new System.Drawing.Size(104, 25);
            this.btnPreviewButton.TabIndex = 12;
            this.btnPreviewButton.Text = "Preview Image";
            this.toolTip1.SetToolTip(this.btnPreviewButton, "Browse...");
            this.btnPreviewButton.UseVisualStyleBackColor = true;
            this.btnPreviewButton.Click += new System.EventHandler(this.btnPreviewButton_Click);
            // 
            // btnSendContentButton
            // 
            this.btnSendContentButton.Location = new System.Drawing.Point(337, 269);
            this.btnSendContentButton.Name = "btnSendContentButton";
            this.btnSendContentButton.Size = new System.Drawing.Size(191, 30);
            this.btnSendContentButton.TabIndex = 50;
            this.btnSendContentButton.Text = "Upload Content";
            this.toolTip1.SetToolTip(this.btnSendContentButton, "This will upload the Workshop Item up to Steam and open your Workshop Page.");
            this.btnSendContentButton.UseVisualStyleBackColor = true;
            this.btnSendContentButton.Click += new System.EventHandler(this.sendContentButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Category";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cboCategory.Items.AddRange(new object[] { "Maps", "Training", "Multiplayer" });
            this.cboCategory.dropDown.Height = 63;
            this.cboCategory.Location = new System.Drawing.Point(75, 132);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(121, 19);
            this.cboCategory.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cboCategory, "This will be the category the Workshop Item will be placed in on the Workshop Page");

            this.cboCategory.CheckBoxItems[1].Checked = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 15000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.ReshowDelay = 200;
            // 
            // cboVisibility
            // 
            this.cboVisibility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVisibility.FormattingEnabled = true;
            this.cboVisibility.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cboVisibility.Items.AddRange(new object[] {
            "Public",
            "Friends Only",
            "Private"});
            this.cboVisibility.Location = new System.Drawing.Point(320, 132);
            this.cboVisibility.Name = "cboVisibility";
            this.cboVisibility.Size = new System.Drawing.Size(121, 21);
            this.cboVisibility.TabIndex = 51;
            this.toolTip1.SetToolTip(this.cboVisibility, "This will set the Workshop Item\'s visibility on the Workshop Page");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Visibility";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(657, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Workshop ID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 311);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboVisibility);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSendContentButton);
            this.Controls.Add(this.txtPreviewImage);
            this.Controls.Add(this.btnPreviewButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.workshopId);
            this.Controls.Add(this.txtContentFolder);
            this.Controls.Add(this.btnContentButton);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Rocket League ® Steam Workshop Uploader";
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage workshopTypeItem;
        private System.Windows.Forms.TabPage workshopTypeMap;

        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Button btnContentButton;
		private System.Windows.Forms.TextBox txtContentFolder;
        private System.Windows.Forms.TextBox workshopId;
        private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPreviewImage;
		private System.Windows.Forms.Button btnPreviewButton;
		private System.Windows.Forms.Button btnSendContentButton;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBoxComboBox cboCategory;
        private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ComboBox cboVisibility;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
