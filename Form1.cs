using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WorkshopUploader
{
	// Token: 0x02000005 RID: 5
	public partial class Form1 : Form
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00002218 File Offset: 0x00000418
		public Form1()
		{
			this.InitializeComponent();
			this.cboCategory.SelectedIndex = 0;
			this.cboVisibility.SelectedIndex = 0;
			this.WorkshopItemInfo = default(WorkshopItemStruct);
			this.WorkshopItemInfo.ItemID = -1;
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
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000022A8 File Offset: 0x000004A8
		private string[] GetWorkshopFileNames()
		{
			return (from x in Directory.GetFiles(this.txtContentFolder.Text, "*.JSON", SearchOption.AllDirectories)
			where Path.GetFileName(x).ToLower() == "workshopiteminfo.json"
			select x).ToArray<string>();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000022F4 File Offset: 0x000004F4
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
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString(), "COULD NOT READ FROM JSON FILE");
					}
				}
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002424 File Offset: 0x00000624
		private void btnContentButton_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				if (Directory.Exists(this.txtContentFolder.Text))
				{
					folderBrowserDialog.SelectedPath = this.txtContentFolder.Text;
				}
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				{
					this.txtContentFolder.Text = folderBrowserDialog.SelectedPath;
					this.LoadPreviousContent();
				}
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002498 File Offset: 0x00000698
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

		// Token: 0x06000010 RID: 16 RVA: 0x00002548 File Offset: 0x00000748
		private void sendContentButton_Click(object sender, EventArgs e)
		{
			if (this.SubmitProcess != null && !this.SubmitProcess.HasExited)
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
			string arguments = string.Concat(new object[]
			{
				"WORKSHOP Title=\"",
				this.txtTitle.Text,
				"\" Description=\"",
				this.txtDescription.Text,
				"\" Content=\"",
				this.txtContentFolder.Text,
				"\" Preview=\"",
				this.txtPreviewImage.Text,
				"\" Tag=",
				this.cboCategory.SelectedItem,
				" ItemID=",
				this.WorkshopItemInfo.ItemID,
				" Visibility=",
				this.cboVisibility.SelectedIndex,
				" -nopause"
			});
			if (File.Exists("Win32\\RocketLeague.exe"))
			{
				this.SubmitProcess = Process.Start("Win32\\RocketLeague.exe", arguments);
				return;
			}
			if (File.Exists("Win32\\TAGame-Win32-Shipping.exe"))
			{
				this.SubmitProcess = Process.Start("Win32\\TAGame-Win32-Shipping.exe", arguments);
				return;
			}
			if (File.Exists("Win32\\TAGame.exe"))
			{
				this.SubmitProcess = Process.Start("Win32\\TAGame.exe", arguments);
				return;
			}
			MessageBox.Show("Please run this program in the directory where Rocket League's exe exists.");
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000027FC File Offset: 0x000009FC
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("www.psyonix.com/dt_portfolio/rocket-league/");
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000027FC File Offset: 0x000009FC
		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("www.psyonix.com/dt_portfolio/rocket-league/");
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000027FC File Offset: 0x000009FC
		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("www.psyonix.com/dt_portfolio/rocket-league/");
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000027FC File Offset: 0x000009FC
		private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("www.psyonix.com/dt_portfolio/rocket-league/");
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000027FC File Offset: 0x000009FC
		private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("www.psyonix.com/dt_portfolio/rocket-league/");
		}

		// Token: 0x04000008 RID: 8
		public Process SubmitProcess;

		// Token: 0x04000009 RID: 9
		public WorkshopItemStruct WorkshopItemInfo;
	}
}
