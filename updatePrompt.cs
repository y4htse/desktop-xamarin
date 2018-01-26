using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurtleWallet
{
    public partial class updatePrompt : Form
    {
        public updatePrompt()
        {
            InitializeComponent();
        }

        private void updatePrompt_Load(object sender, EventArgs e)
        {
            try
            {
                if (System.AppDomain.CurrentDomain.FriendlyName == "TurtleWallet_update.exe")
                {
                    System.Threading.Thread.Sleep(500);
                    System.IO.File.Copy("TurtleWallet_update.exe", "TurtleWallet.exe", true);
                    System.Diagnostics.Process.Start("TurtleWallet.exe");
                    Environment.Exit(0);
                }
                else if (System.AppDomain.CurrentDomain.FriendlyName == "TurtleWallet.exe")
                {
                    if (System.IO.File.Exists("TurtleWallet_update.exe"))
                        System.IO.File.Delete("TurtleWallet_update.exe");
                }
            }
            catch
            {
                MessageBox.Show("Failed to check for updates!", "TurtleCoin Wallet");
            }

            updateRequest();
            this.Close();
        }

        void updateRequest()
        {
            try
            {
                string thisVersionString = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                bool needsUpdate = false;
                var builtURL = "https://api.github.com/repos/turtlecoin/desktop-xamarin/releases/latest";

                var cli = new WebClient();
                cli.Headers[HttpRequestHeader.ContentType] = "application/json";
                cli.Headers[HttpRequestHeader.UserAgent] = "TurtleCoin Wallet " + thisVersionString;
                string response = cli.DownloadString(builtURL);

                var jobj = JObject.Parse(response);

                string gitVersionString = jobj["tag_name"].ToString();
               

                var gitVersion = new Version(gitVersionString);
                var thisVersion = new Version(thisVersionString);

                var result = gitVersion.CompareTo(thisVersion);
                if (result > 0)
                    needsUpdate = true;
                else if (result < 0)
                    needsUpdate = false;
                else
                    needsUpdate = false;

                if (needsUpdate)
                {
                    foreach (var item in jobj["assets"])
                    {
                        string name = item["name"].ToString();
                        if (name.Contains("TurtleWallet.exe"))
                        {
                            DialogResult dialogResult = MessageBox.Show("A new version of TurtleCoin Wallet is out. Download?", "TurtleCoin Wallet", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.No)
                            {
                                return;
                            }
                            new WebClient().DownloadFile(item["browser_download_url"].ToString(), "TurtleWallet_update.exe");
                            System.Diagnostics.Process.Start("TurtleWallet_update.exe");
                            Environment.Exit(0);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to check for updates!", "TurtleCoin Wallet");
            }
        }
    }

}
