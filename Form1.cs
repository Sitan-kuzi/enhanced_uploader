using System;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using Newtonsoft.Json;
using Steamworks;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Text;

namespace WorkshopUploader
{
	public partial class Form1 : Form
	{
        private static readonly Timer callbacksListener = new Timer();
        public Form1()
		{
			this.InitializeComponent();
			this.cboVisibility.SelectedIndex = 0;
			this.WorkshopItemInfo = default;
			Control[] array = new Control[]
            {
                this.txtTitle,
				this.txtDescription,
				this.txtContentFolder,
				this.txtPreviewImage
            };
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetCueText(this.toolTip1);
			}

            SteamFriends.SetRichPresence("status", "Uploading Workshop Items");
            callbacksListener.Tick += new EventHandler(RunCallbacks);
            callbacksListener.Interval = 100;
        }

        static int i = 0;
        private void RunCallbacks(Object myObject, EventArgs myEventArgs)
        {
            if (this.bIsUploading)
                GetItemUpdateProgress();

            Debug.WriteLine("RunCallbacks(), " + ++i);
            SteamAPI.RunCallbacks();
        }

        private string[] GetWorkshopFileNames()
		{
			return (from x in Directory.GetFiles(this.txtContentFolder.Text, "*.JSON", SearchOption.AllDirectories)
			where Path.GetFileName(x).ToLower() == "workshopiteminfo.json"
			select x).ToArray<string>();
		}

		private void LoadPreviousContent()
		{
			string[] workshopFileNames = this.GetWorkshopFileNames();
			if (workshopFileNames.Length > 1)
			{
				MessageBox.Show("More than one WorkshopItemInfo.JSON found. Please delete one.");
				return;
			}
			if (workshopFileNames.Length == 1)
			{
				using (StreamReader streamReader = new StreamReader(workshopFileNames[0]))
				{
					string text = streamReader.ReadToEnd();
					try
					{
						this.WorkshopItemInfo = JsonConvert.DeserializeObject<WorkshopItemStruct>(text);
						if (this.txtTitle.Text == "")
						{
							this.txtTitle.Text = this.WorkshopItemInfo.Title;
						}
						if (this.txtDescription.Text == "")
						{
							this.txtDescription.Text = this.WorkshopItemInfo.Description;
						}
						if (this.txtPreviewImage.Text == "")
						{
							this.txtPreviewImage.Text = this.WorkshopItemInfo.Preview;
						}
						if (this.cboVisibility.SelectedIndex == 0)
						{
							this.cboVisibility.SelectedIndex = this.WorkshopItemInfo.Visibility;
                        }
                        if (this.WorkshopItemInfo.ItemID != 0)
                        {
                            this.btnSendContentButton.Text = "Update Content";
                        }
                        this.tabControl.SelectTab(this.WorkshopItemInfo.ItemType);
                        IEnumerable<string> tags = from checkbox in this.cboCategory.CheckBoxItems where checkbox.Checked select checkbox.Text;
                        if (tags.Count() > 1 || tags.Count() == 1 && tags.First() != "Item")
                        {
                            foreach (string tag in this.WorkshopItemInfo.Tags)
                            {
                                foreach (CheckBox checkbox in this.cboCategory.CheckBoxItems)
                                {
                                    if (tag == checkbox.Text)
                                    {
                                        checkbox.Checked = true;
                                    }
                                }
                            }
                        }
                        this.workshopId.Text = this.WorkshopItemInfo.ItemID.ToString();
                    }
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString(), "COULD NOT READ FROM JSON FILE");
					}
				}
			}
        }

        private void btnWorkshopType_Changed(object sender, EventArgs e)
        {
            this.cboCategory.Items.Clear();
            if (this.tabControl.SelectedTab == this.workshopTypeMap)
                this.cboCategory.Items.AddRange(new object[] { "Maps", "Training", "Multiplayer" });
            else if (this.tabControl.SelectedTab == this.workshopTypeItem)
                this.cboCategory.Items.AddRange(new object[] { "Items", "Decal", "Wheels", "Boost", "Goal Explotion", "Trail" });

            if (this.cboCategory.CheckBoxItems.Any())
            {
                this.cboCategory.dropDown.Height = this.cboCategory.CheckBoxItems[1].Height * (this.cboCategory.CheckBoxItems.Count - 1) + 6;
                this.cboCategory.CheckBoxItems[1].Checked = true;
            }
        }

        private void btnContentButton_Click(object sender, EventArgs e)
		{
			using (CommonOpenFileDialog folderBrowserDialog = new CommonOpenFileDialog())
			{
				if (Directory.Exists(this.txtContentFolder.Text))
				{
					folderBrowserDialog.InitialDirectory = this.txtContentFolder.Text;
				}
                folderBrowserDialog.IsFolderPicker = true;
                if (folderBrowserDialog.ShowDialog() == CommonFileDialogResult.Ok)
				{
					this.txtContentFolder.Text = folderBrowserDialog.FileName;
					this.LoadPreviousContent();
				}
			}
		}

		private void btnPreviewButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				if (File.Exists(this.txtPreviewImage.Text))
				{
					openFileDialog.InitialDirectory = this.txtPreviewImage.Text;
				}
                openFileDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					this.txtPreviewImage.Text = openFileDialog.FileName;
					if (new FileInfo(this.txtPreviewImage.Text).Length > 1048576L)
					{
						this.txtPreviewImage.Text = "";
						MessageBox.Show("Please select a preview image file that is under 1MB.");
					}
				}
			}
		}

        private void sendContentButton_Click(object sender, EventArgs e)
		{
			if (this.bIsUploading)
			{
				MessageBox.Show("Currently Sending");
				return;
			}
			if (this.txtContentFolder.Text == "")
			{
				MessageBox.Show("Please select a content folder.");
				return;
			}
			if (this.txtTitle.Text == "")
			{
				MessageBox.Show("Please fill out the title.");
				return;
			}
			if (this.txtDescription.Text == "")
			{
				MessageBox.Show("Please fill out the description.");
				return;
			}
			if (this.txtPreviewImage.Text == "")
			{
				MessageBox.Show("Please select a preview image file.");
				return;
			}
			if (this.txtTitle.Text.Length > 50)
			{
				MessageBox.Show("Please pick a shorter title.");
				return;
			}
			if (this.txtDescription.Text.Length > 140)
			{
				MessageBox.Show("Please pick a shorter description.");
				return;
			}
			try
			{
				if (new FileInfo(this.txtPreviewImage.Text).Length > 1048576L)
				{
					MessageBox.Show("Please select a preview image file that is under 1MB.");
					return;
				}
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Failed to find preview picture file.");
				return;
			}
			string[] files = Directory.GetFiles(this.txtContentFolder.Text, "*.udk", SearchOption.AllDirectories);
			string[] files2 = Directory.GetFiles(this.txtContentFolder.Text, "*.umap", SearchOption.AllDirectories);
			if (files.Length + files2.Length <= 0)
			{
				MessageBox.Show("No .udk or .umap files found in this folder.");
				return;
			}

            this.bIsUploading = true;
            callbacksListener.Start();

            using (StreamWriter streamWriter = new StreamWriter(this.txtContentFolder.Text + "\\WorkshopItemInfo.JSON"))
            {
                this.WorkshopItemInfo.ItemID = ulong.Parse(this.workshopId.Text);
                this.WorkshopItemInfo.ItemType = this.tabControl.SelectedIndex;
                this.WorkshopItemInfo.Title = this.txtTitle.Text;
                this.WorkshopItemInfo.Description = this.txtDescription.Text;
                this.WorkshopItemInfo.Tags = (from checkbox in this.cboCategory.CheckBoxItems where checkbox.Checked select checkbox.Text).ToList();
                this.WorkshopItemInfo.Preview = this.txtPreviewImage.Text;
                this.WorkshopItemInfo.Visibility = this.cboVisibility.SelectedIndex;

                string text = JsonConvert.SerializeObject(this.WorkshopItemInfo);
                streamWriter.Write(text);
            }

            if (this.WorkshopItemInfo.ItemID == 0)
                CreateItem();
            else
                UpdateItem((PublishedFileId_t)this.WorkshopItemInfo.ItemID);
		}

        protected CallResult<CreateItemResult_t> m_CreateItemResult;
        private void CreateItem()
        {
            this.bIsUploading = true;
            m_CreateItemResult = CallResult<CreateItemResult_t>.Create(OnCreateItem);
            EWorkshopFileType eFileType = EWorkshopFileType.k_EWorkshopFileTypeCommunity;
            if (this.tabControl.SelectedTab == this.workshopTypeItem)
                eFileType = EWorkshopFileType.k_EWorkshopFileTypeMicrotransaction;

            SteamAPICall_t callHandle = SteamUGC.CreateItem((AppId_t)252950, eFileType);
            m_CreateItemResult.Set(callHandle);

            this.btnSendContentButton.Text = "Creating Item...";
        }

        UGCUpdateHandle_t updateHandle;
        protected CallResult<SubmitItemUpdateResult_t> m_SubmitItemUpdateCallResult;
        private void OnCreateItem(CreateItemResult_t pCallback, bool bIOFailure)
        {
            if (bIOFailure || pCallback.m_eResult != EResult.k_EResultOK)
            {
                this.bIsUploading = false;
                callbacksListener.Stop();
                Debug.WriteLine("CreateItem failed, " + pCallback.m_eResult.ToString().Substring(9));
                MessageBox.Show(AddSpacesToSentence(pCallback.m_eResult.ToString().Substring(9)), "Creating Workshop Item failed");
                this.btnSendContentButton.Text = "Upload Content";
                return;
            }
            if (pCallback.m_bUserNeedsToAcceptWorkshopLegalAgreement)
            {
                Debug.WriteLine("You did not accept legal agreements required to upload this workshop item.");
                Process.Start("steam://url/CommunityFilePage/" + pCallback.m_nPublishedFileId);
            }

            Debug.WriteLine("Created an workshop item: " + pCallback.m_nPublishedFileId);
            this.WorkshopItemInfo.ItemID = (ulong)pCallback.m_nPublishedFileId;
            this.workshopId.Text = pCallback.m_nPublishedFileId.ToString();

            using (StreamWriter streamWriter = new StreamWriter(this.txtContentFolder.Text + "\\WorkshopItemInfo.JSON"))
            {
                this.WorkshopItemInfo.ItemID = ulong.Parse(this.workshopId.Text);
                this.WorkshopItemInfo.ItemType = this.tabControl.SelectedIndex;
                this.WorkshopItemInfo.Title = this.txtTitle.Text;
                this.WorkshopItemInfo.Description = this.txtDescription.Text;
                this.WorkshopItemInfo.Tags = (from checkbox in this.cboCategory.CheckBoxItems where checkbox.Checked select checkbox.Text).ToList();
                this.WorkshopItemInfo.Preview = this.txtPreviewImage.Text;
                this.WorkshopItemInfo.Visibility = this.cboVisibility.SelectedIndex;

                string text = JsonConvert.SerializeObject(this.WorkshopItemInfo);
                streamWriter.Write(text);
            }

            UpdateItem(pCallback.m_nPublishedFileId);
        }

        private void UpdateItem(PublishedFileId_t m_nPublishedFileId)
        {
            this.bIsUploading = true;
            updateHandle = SteamUGC.StartItemUpdate((AppId_t)252950, m_nPublishedFileId);
            SteamUGC.SetItemTitle(updateHandle, this.WorkshopItemInfo.Title);
            SteamUGC.SetItemDescription(updateHandle, this.WorkshopItemInfo.Description);
            SteamUGC.SetItemVisibility(updateHandle, (ERemoteStoragePublishedFileVisibility)this.WorkshopItemInfo.Visibility);
            SteamUGC.SetItemTags(updateHandle, this.WorkshopItemInfo.Tags);
            SteamUGC.SetItemContent(updateHandle, this.txtContentFolder.Text);
            SteamUGC.SetItemPreview(updateHandle, this.WorkshopItemInfo.Preview);

            this.btnSendContentButton.Text = "Uploading Content...";

            m_SubmitItemUpdateCallResult = CallResult<SubmitItemUpdateResult_t>.Create(OnSubmitItemUpdate);
            SteamAPICall_t callHandle = SteamUGC.SubmitItemUpdate(updateHandle, null);
            m_SubmitItemUpdateCallResult.Set(callHandle);
        }

        private Bitmap Progressbar(float progress)
        {
            byte[] _imageBuffer = new byte[4 * this.btnSendContentButton.Width * this.btnSendContentButton.Height];
            for (var x = 0; x < this.btnSendContentButton.Width; x++)
            {
                for (var y = 0; y < this.btnSendContentButton.Height; y++)
                {
                    if (x < this.btnSendContentButton.Width * progress) {
                        // Color.SpringGreen, 00FF7F
                        _imageBuffer[(this.btnSendContentButton.Width * 4 * y) + (x * 4)] =     0;    // red
                        _imageBuffer[(this.btnSendContentButton.Width * 4 * y) + (x * 4) + 1] = 255;  // green
                        _imageBuffer[(this.btnSendContentButton.Width * 4 * y) + (x * 4) + 2] = 127;  // blue
                        _imageBuffer[(this.btnSendContentButton.Width * 4 * y) + (x * 4) + 3] = 255;  // aplha
                    }
                    else {
                        // Button.BackgroundColor, e1e1e1
                        _imageBuffer[(this.btnSendContentButton.Width * 4 * y) + (x * 4)] =     225;  // red
                        _imageBuffer[(this.btnSendContentButton.Width * 4 * y) + (x * 4) + 1] = 225;  // green
                        _imageBuffer[(this.btnSendContentButton.Width * 4 * y) + (x * 4) + 2] = 225;  // blue
                        _imageBuffer[(this.btnSendContentButton.Width * 4 * y) + (x * 4) + 3] = 255;  // aplha
                    }
                }
            }
            unsafe
            {
                fixed (byte* ptr = _imageBuffer)
                {
                    return new Bitmap(this.btnSendContentButton.Width, this.btnSendContentButton.Height, this.btnSendContentButton.Width * 4, PixelFormat.Format32bppRgb, new IntPtr(ptr));
                }
            }
        }

        /* From: https://stackoverflow.com/a/272929 */
        private static string AddSpacesToSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                    newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        private void GetItemUpdateProgress()
        {
            EItemUpdateStatus updateStatus = SteamUGC.GetItemUpdateProgress(updateHandle, out ulong punBytesProcessed, out ulong punBytesTotal);

            Debug.WriteLine("Progress: " + punBytesProcessed + "/" + punBytesTotal + ", " + updateStatus.ToString().Substring(19));
            string progressPerc = "";
            if (updateStatus == EItemUpdateStatus.k_EItemUpdateStatusInvalid)
            {
                return;
            }

            if (punBytesTotal > 0)
            {
                float progress = (float)punBytesProcessed / (float)punBytesTotal;
                progressPerc = " " + (int)(progress * 100) + "%";
                this.btnSendContentButton.BackgroundImage = Progressbar(((float)updateStatus + progress) / 5.0f);
            }
            else
            {
                this.btnSendContentButton.BackgroundImage = Progressbar((float)updateStatus / 5.0f);
            }

            this.btnSendContentButton.Text = AddSpacesToSentence(updateStatus.ToString().Substring(19)) + progressPerc;
        }

        private void OnSubmitItemUpdate(SubmitItemUpdateResult_t pCallback, bool bIOFailure)
        {
            callbacksListener.Stop();
            this.bIsUploading = false;
            this.btnSendContentButton.BackgroundImage = Progressbar(0.0f);

            if (bIOFailure || pCallback.m_eResult != EResult.k_EResultOK)
            {
                Debug.WriteLine("SubmitItemUpdate failed, " + pCallback.m_eResult.ToString().Substring(9));
                MessageBox.Show(AddSpacesToSentence(pCallback.m_eResult.ToString().Substring(9)), "Submitting Workshop Item Update failed");
                if (this.WorkshopItemInfo.ItemID == 0)
                    this.btnSendContentButton.Text = "Upload Content";
                else
                    this.btnSendContentButton.Text = "Update Content";
                return;
            }

            Debug.WriteLine("SubmitItemUpdate finished");
            Process.Start("https://steamcommunity.com/sharedfiles/filedetails/?id=" + pCallback.m_nPublishedFileId);
            this.btnSendContentButton.Text = "Update Content";
        }

		public bool bIsUploading = false;

		public WorkshopItemStruct WorkshopItemInfo;
	}
}
