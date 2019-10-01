using Steamworks;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WorkshopUploader
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            if (!InitSteam())
            {
                MessageBox.Show("Steam must be running to upload to the workshop.");
                return;
            }

            Application.Run(new Form1());
            SteamAPI.Shutdown();
        }

        private static bool InitSteam()
        {
            // Sneaky trick to avoid the steam_appid.txt.
            Environment.SetEnvironmentVariable("SteamAppId", "252950");

            if (!SteamAPI.Init())
            {
                Debug.WriteLine("SteamAPI.Init() failed");
                return false;
            }
            if (!SteamUser.BLoggedOn())
            {
                Debug.WriteLine("SteamUser.BLoggedOn() failed");
                return false;
            }

            return true;
        }
	}
}
