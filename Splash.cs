using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurtleWallet
{
    public partial class Splash : Form
    {
        public string walletPath
        {
            get;
            set;
        }

        public string walletPassword
        {
            get;
            set;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public Splash(string _wallet, string _password)
        {
            InitializeComponent();
            walletPath = _wallet;
            walletPassword = _password;
            versionLabel.Text = "v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            webBrowser1.Navigate(new Uri(String.Format("file:///{0}/html/trtl.html", curDir)));
            ((Control)webBrowser1).Enabled = false;
            StatusLabel.Text = "Connecting to daemon ...";
            splashBackgroundWorker.RunWorkerAsync();
        }

        private void splashBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int failcount = 0;

            try
            {
                var connReturn = ConnectionManager.startDaemon(walletPath, walletPassword);
                if(connReturn.Item1 == false)
                {
                    this.StatusLabel.BeginInvoke((MethodInvoker)delegate () { this.StatusLabel.Text = "Daemon Connection Failed: " + connReturn.Item2; });
                    System.Threading.Thread.Sleep(5000);
                    Environment.Exit(3);
                }

                while (true)
                {
                    System.Threading.Thread.Sleep(500);
                    try
                    {
                        if(Process.GetProcessesByName("walletd").Length < 1)
                        {
                            throw new Exception("Daemon exited!");
                        }
                        var resp = ConnectionManager.request("getStatus");
                        if (resp.Item1 == false)
                            throw new Exception("No RPC connection/Failed");
                        var block_count = (int)resp.Item3["blockCount"];
                        var known_block_count = (int)resp.Item3["knownBlockCount"];
                        if(known_block_count == 0)
                        {
                            this.StatusLabel.BeginInvoke((MethodInvoker)delegate () { this.StatusLabel.Text = "Waiting on known block count..." ; });
                            continue;
                        }
                        this.StatusLabel.BeginInvoke((MethodInvoker)delegate () { this.StatusLabel.Text = "Syncing... [" + block_count.ToString() + " / " + known_block_count.ToString() + "]"; });
                        if(known_block_count > 0 && (block_count >= known_block_count))
                        {
                            this.StatusLabel.BeginInvoke((MethodInvoker)delegate () { this.StatusLabel.Text = "Wallet is synced, opening..."; });
                            e.Result = connReturn.Item3;
                            break;
                        }

                    }
                    catch (Exception ex)
                    {
                        failcount += 1;
                        if(failcount >= 15)
                            throw new Exception("MAXTRYERROR: " + ex.Message);
                        this.StatusLabel.BeginInvoke((MethodInvoker)delegate () { this.StatusLabel.Text = "Daemon Connect Error, trying..(" + failcount.ToString() + "/15)"; });
                    }
                }
            }
            catch (Exception ex)
            {
                this.StatusLabel.BeginInvoke((MethodInvoker)delegate () { this.StatusLabel.Text = "Daemon Connection Failed: " + ex.Message ; });
                MessageBox.Show("Daemon Connection Failed: " + ex.Message, "TurtleCoin Wallet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(3);
            }
        }

        private void splashBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void splashBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Hide();
            var walletWindow = new wallet(walletPath, walletPassword, (Process)e.Result);
            walletWindow.Closed += (s, args) => this.Close();
            walletWindow.Show();
        }
    }
}
