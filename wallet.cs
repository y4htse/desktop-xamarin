using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurtleWallet
{
    public partial class wallet : Form
    {
        public static System.Windows.Forms.Timer statsTimer = new System.Windows.Forms.Timer();
        public static int watchdogTimeout = 3;
        public static int watchdogMaxTry = 3;
        public static int currentTimeout = 0;
        public static int currentTry = 0;
        public static int staticFee = 10;
        public static Label _selectedTab;
        public static List<string> cachedTrx = new List<string>();
        public static Process runningDaemon;

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

        //List view header formatters
        public static void colorListViewHeader(ref ListView list, Color backColor, Color foreColor)
        {
            list.OwnerDraw = true;
            list.DrawColumnHeader +=
                new DrawListViewColumnHeaderEventHandler
                (
                    (sender, e) => headerDraw(sender, e, backColor, foreColor)
                );
            list.DrawItem += new DrawListViewItemEventHandler(bodyDraw);
            list.DrawSubItem += List_DrawSubItem;
        }

        private static void List_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private static void headerDraw(object sender, DrawListViewColumnHeaderEventArgs e, Color backColor, Color foreColor)
        {
            e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);
            e.Graphics.DrawRectangle(SystemPens.GradientInactiveCaption,
        new Rectangle(e.Bounds.X, 0, e.Bounds.Width, e.Bounds.Height));
            e.Graphics.DrawString(e.Header.Text, e.Font, new SolidBrush(foreColor), e.Bounds);
        }
        private static void bodyDraw(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        public wallet(string _wallet, string _pass, System.Diagnostics.Process wd)
        {
            InitializeComponent();
            runningDaemon = wd;
            wallet.colorListViewHeader(ref txList, Color.FromArgb(29, 29, 29), Color.FromArgb(187, 186, 185));
            _selectedTab = homeButton;
            walletPath = _wallet;
            walletPassword = _pass;
            Properties.Settings.Default.walletPath = _wallet;
            Properties.Settings.Default.hasWallet = true;
            Properties.Settings.Default.Save();
        }

        private void wallet_Load(object sender, EventArgs e)
        {
            versionLabel.Text = "v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            new Thread(new ThreadStart(update_live_stats)).Start();
            statsTimer.Interval = 30000;
            statsTimer.Tick += StatsTimer_Tick;
            statsTimer.Start();
            resyncer.RunWorkerAsync();
        }

        private void StatsTimer_Tick(object sender, EventArgs e)
        {
            this.updateLabel.BeginInvoke((MethodInvoker)delegate ()
            {
                updateLabel.Text = "Updating LiveStats ...";
                updateLabel.ForeColor = Color.FromArgb(255, 128, 0);
            });
            new Thread(new ThreadStart(update_live_stats)).Start();
        }

        private void update_live_stats()
        {
            try
            {
                var jobj = ConnectionManager.get_live_stats();
                if(jobj.Item1 == false)
                {
                    this.heightAmountLabel.BeginInvoke((MethodInvoker)delegate () { heightAmountLabel.Text = "N/A"; });
                    this.difficultyAmountLabel.BeginInvoke((MethodInvoker)delegate () { difficultyAmountLabel.Text = "N/A"; });
                    this.updateLabel.BeginInvoke((MethodInvoker)delegate ()
                    {
                        updateLabel.Text = "LiveStats update failed ...";
                        updateLabel.ForeColor = Color.FromArgb(205, 12, 47);
                    });
                    System.Threading.Thread.Sleep(2000);
                    this.updateLabel.BeginInvoke((MethodInvoker)delegate ()
                    {
                        updateLabel.Text = "Wallet Idle ...";
                        updateLabel.ForeColor = Color.Gray;
                    });
                    return;
                }
                var stats = (Newtonsoft.Json.Linq.JObject)jobj.Item2["network"];
                if(stats.ContainsKey("difficulty"))
                    this.difficultyAmountLabel.BeginInvoke((MethodInvoker)delegate () { difficultyAmountLabel.Text = stats["difficulty"].ToString(); });
                else
                {
                    this.difficultyAmountLabel.BeginInvoke((MethodInvoker)delegate () { difficultyAmountLabel.Text = "N/A"; });
                }
                if (stats.ContainsKey("height"))
                    this.heightAmountLabel.BeginInvoke((MethodInvoker)delegate () { heightAmountLabel.Text = stats["height"].ToString(); });
                else
                {
                    this.heightAmountLabel.BeginInvoke((MethodInvoker)delegate () { heightAmountLabel.Text = "N/A"; });
                }
                this.updateLabel.BeginInvoke((MethodInvoker)delegate ()
                {
                    updateLabel.Text = "Updated livestats ...";
                    updateLabel.ForeColor = Color.FromArgb(0, 192, 0);
                });
                System.Threading.Thread.Sleep(2000);
                this.updateLabel.BeginInvoke((MethodInvoker)delegate ()
                {
                    updateLabel.Text = "Wallet Idle ...";
                    updateLabel.ForeColor = Color.Gray;
                });
            }
            catch (Exception)
            {
                this.heightAmountLabel.BeginInvoke((MethodInvoker)delegate () { heightAmountLabel.Text = "N/A"; });
                this.difficultyAmountLabel.BeginInvoke((MethodInvoker)delegate () { difficultyAmountLabel.Text = "N/A"; });
                this.updateLabel.BeginInvoke((MethodInvoker)delegate () 
                {
                    updateLabel.Text = "Livestats update failed ...";
                    updateLabel.ForeColor = Color.FromArgb(205, 12, 47);
                });
                System.Threading.Thread.Sleep(2000);
                this.updateLabel.BeginInvoke((MethodInvoker)delegate ()
                {
                    updateLabel.Text = "Wallet Idle ...";
                    updateLabel.ForeColor = Color.Gray;
                });
            }
        }

        private void refresh_ui()
        {
            Newtonsoft.Json.Linq.JObject status = null;
            Newtonsoft.Json.Linq.JToken blocks = null;
            try
            {
                this.updateLabel.BeginInvoke((MethodInvoker)delegate ()
                {
                    updateLabel.Text = "Syncing Network ...";
                    updateLabel.ForeColor = Color.FromArgb(255, 128, 0);
                });
                var balances = ConnectionManager.request("getBalance");
                if (balances.Item1 == false)
                {
                    throw new Exception("getBalance call failed: " + balances.Item2);
                }
                float availableBal = (float)(balances.Item3["availableBalance"]) / 100;
                float lockedBal = (float)(balances.Item3["lockedAmount"]) / 100;
                this.availableAmountLabel.BeginInvoke((MethodInvoker)delegate () { this.availableAmountLabel.Text = availableBal.ToString("0.00") + " TRTL"; });
                this.lockedAmountLabel.BeginInvoke((MethodInvoker)delegate () { this.lockedAmountLabel.Text = lockedBal.ToString("0.00") + " TRTL"; });

                var Addresses = ConnectionManager.request("getAddresses");
                if (Addresses.Item1 == false)
                {
                    throw new Exception("getAddresses call failed: " + balances.Item2);
                }
                var addressList = Addresses.Item3["addresses"];
                this.myAddressText.BeginInvoke((MethodInvoker)delegate () { myAddressText.Text = addressList[0].ToString(); });

                status = ConnectionManager.request("getStatus").Item3;
                var parameters = new Dictionary<string, object>()
                {
                    { "blockCount",  (int)status["blockCount"] },
                    { "firstBlockIndex", 1 },
                    { "addresses", addressList }
                };
                var blocksRet = ConnectionManager.request("getTransactions", parameters);
                if (blocksRet.Item1 == false)
                {
                    throw new Exception("getTransactions call failed: " + balances.Item2);
                }
                blocks = blocksRet.Item3["items"];
                currentTimeout = 0;
                currentTry = 0;
            }
            catch(Exception ex)
            {
                this.updateLabel.BeginInvoke((MethodInvoker)delegate ()
                {
                    updateLabel.Text = "Daemon error, retrying ...";
                    updateLabel.ForeColor = Color.FromArgb(205, 12, 47);
                });
                if (currentTimeout >= watchdogTimeout)
                {
                    if (currentTry <= watchdogMaxTry)
                    {
                        //daemon restart
                    }
                    else
                    {
                        MessageBox.Show("Turtle Wallet has tried numerous times to relaunch the needed daemon and has failed. Please relaunch the wallet!", "Walletd daemon could not be recovered!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                else
                    currentTimeout++;
                return;
            }
            if (blocks == null)
                return;
            foreach(var block in blocks.Reverse())
            {
                var bblock = (Newtonsoft.Json.Linq.JObject)block;
                if(bblock.ContainsKey("transactions"))
                {
                    foreach(var transaction in block["transactions"])
                    {
                        if (cachedTrx.Contains(transaction["transactionHash"].ToString()))
                            continue;
                        string address = "";
                        long desired_transfer_amount = 0;
                        if ((long)transaction["amount"] < 0)
                        {
                            desired_transfer_amount = ((long)transaction["amount"] + (long)transaction["fee"]) * -1;
                        }
                        else
                        {
                            desired_transfer_amount = ((long)transaction["amount"]);
                        }

                        foreach(var transfer in transaction["transfers"])
                        {
                            if((long)transfer["amount"] == desired_transfer_amount)
                            {
                                address = transfer["address"].ToString();
                            }
                        }

                        List<ListViewItem.ListViewSubItem> subitems = new List<ListViewItem.ListViewSubItem>();

                        if((long)transaction["unlockTime"] == 0 || (long)transaction["unlockTime"] <= (long)status["blockCount"] - 40)
                        {
                            var confirmItem = new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "  🐢  ✔", System.Drawing.Color.Green, System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29))))), new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                            subitems.Add(confirmItem);
                        }
                        else
                        {
                            var confirmItem = new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "  🐢  ✘", System.Drawing.Color.DarkRed, System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29))))), new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                            subitems.Add(confirmItem);
                        }

                        if((long)transaction["amount"] > 0)
                        {
                            var directionItem = new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "IN\u2007\u2007⇚\u2007\u2007\u2007", System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))), System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29))))), new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                            subitems.Add(directionItem);
                        }
                        else
                        {
                            var directionItem = new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "OUT ⇛\u2007\u2007\u2007", System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))), System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29))))), new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                            subitems.Add(directionItem);
                        }

                        var amountItem = new System.Windows.Forms.ListViewItem.ListViewSubItem(null, ((long)(transaction["amount"]) / 100).ToString("0.00"), System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29))))), new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                        subitems.Add(amountItem);

                        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                        dtDateTime = dtDateTime.AddSeconds((long)(transaction["timestamp"])).ToLocalTime();
                        var ts = dtDateTime.ToString("yyyy/MM/dd HH:mm:ss tt");
                        var dateItem = new System.Windows.Forms.ListViewItem.ListViewSubItem(null, ts, System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29))))), new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                        subitems.Add(dateItem);

                        var addItem = new System.Windows.Forms.ListViewItem.ListViewSubItem(null, address, System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29))))), new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                        subitems.Add(addItem);

                        System.Windows.Forms.ListViewItem trxItem = new System.Windows.Forms.ListViewItem(subitems.ToArray(), -1);
                        trxItem.UseItemStyleForSubItems = false;
                        txList.BeginInvoke((MethodInvoker)delegate ()
                        {
                            txList.Items.Add(trxItem);
                        });
                        cachedTrx.Add(transaction["transactionHash"].ToString());
                    }
                }
            }

            string titleUpdate = "TurtleCoin Wallet - Network Sync [" + status["blockCount"].ToString() + " / " + status["knownBlockCount"].ToString() + "] | Peers: " + status["peerCount"].ToString() + " | Updated: " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss tt");
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                this.Text = titleUpdate;
                this.Update();
            });


            txList.BeginInvoke((MethodInvoker)delegate ()
            {
                foreach (ColumnHeader column in txList.Columns)
                {
                    column.Width = -2;
                }
            });

        }

        private void homeButton_MouseEnter(object sender, EventArgs e)
        {
            var currentButton = (Label)sender;
            if (_selectedTab != currentButton)
            {
                var backcolor = Color.FromArgb(44, 44, 44);
                var forcolor = Color.FromArgb(39, 170, 107);
                currentButton.BackColor = backcolor;
                currentButton.ForeColor = forcolor;
            }
        }

        private void sendButton_MouseEnter(object sender, EventArgs e)
        {
            var currentButton = (Label)sender;
            if (_selectedTab != currentButton)
            {
                var backcolor = Color.FromArgb(44, 44, 44);
                var forcolor = Color.FromArgb(39, 170, 107);
                currentButton.BackColor = backcolor;
                currentButton.ForeColor = forcolor;
            }
        }

        private void logButton_MouseEnter(object sender, EventArgs e)
        {
            var currentButton = (Label)sender;
            if (_selectedTab != currentButton)
            {
                var backcolor = Color.FromArgb(44, 44, 44);
                var forcolor = Color.FromArgb(39, 170, 107);
                currentButton.BackColor = backcolor;
                currentButton.ForeColor = forcolor;
            }
        }

        private void rpcButton_MouseEnter(object sender, EventArgs e)
        {
            var currentButton = (Label)sender;
            if (_selectedTab != currentButton)
            {
                var backcolor = Color.FromArgb(44, 44, 44);
                var forcolor = Color.FromArgb(39, 170, 107);
                currentButton.BackColor = backcolor;
                currentButton.ForeColor = forcolor;
            }
        }

        private void homeButton_MouseLeave(object sender, EventArgs e)
        {
            var currentButton = (Label)sender;
            if (_selectedTab != currentButton)
            {
                var backcolor = Color.FromArgb(52, 52, 52);
                var forcolor = Color.FromArgb(224, 224, 224);
                currentButton.BackColor = backcolor;
                currentButton.ForeColor = forcolor;
            }
        }

        private void sendButton_MouseLeave(object sender, EventArgs e)
        {
            var currentButton = (Label)sender;
            if (_selectedTab != currentButton)
            {
                var backcolor = Color.FromArgb(52, 52, 52);
                var forcolor = Color.FromArgb(224, 224, 224);
                currentButton.BackColor = backcolor;
                currentButton.ForeColor = forcolor;
            }
        }

        private void logButton_MouseLeave(object sender, EventArgs e)
        {
            var currentButton = (Label)sender;
            if (_selectedTab != currentButton)
            {
                var backcolor = Color.FromArgb(52, 52, 52);
                var forcolor = Color.FromArgb(224, 224, 224);
                currentButton.BackColor = backcolor;
                currentButton.ForeColor = forcolor;
            }
        }

        private void rpcButton_MouseLeave(object sender, EventArgs e)
        {
            var currentButton = (Label)sender;
            if (_selectedTab != currentButton)
            {
                var backcolor = Color.FromArgb(52, 52, 52);
                var forcolor = Color.FromArgb(224, 224, 224);
                currentButton.BackColor = backcolor;
                currentButton.ForeColor = forcolor;
            }
        }

        private void copyAddressButton_MouseEnter(object sender, EventArgs e)
        {
            var currentButton = (Label)sender;
            var backcolor = Color.FromArgb(44, 44, 44);
            var forcolor = Color.FromArgb(39, 170, 107);
            currentButton.BackColor = backcolor;
            currentButton.ForeColor = forcolor;
        }

        private void copyAddressButton_MouseLeave(object sender, EventArgs e)
        {
            var currentButton = (Label)sender;
            var backcolor = Color.FromArgb(52,52,52);
            var forcolor = Color.FromArgb(224, 224, 224);
            currentButton.BackColor = backcolor;
            currentButton.ForeColor = forcolor;
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            var currentButton = (Label)sender;
            if (_selectedTab != currentButton)
            {
                var backcolor = Color.FromArgb(52, 52, 52);
                var forcolor = Color.FromArgb(224, 224, 224);
                _selectedTab.BackColor = backcolor;
                _selectedTab.ForeColor = forcolor;

                walletTabControl.SelectedIndex = 0;
                _selectedTab = currentButton;

                backcolor = Color.FromArgb(82, 82, 82);
                forcolor = Color.FromArgb(39, 170, 107);
                _selectedTab.BackColor = backcolor;
                _selectedTab.ForeColor = forcolor;
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            var currentButton = (Label)sender;
            if (_selectedTab != currentButton)
            {
                var backcolor = Color.FromArgb(52, 52, 52);
                var forcolor = Color.FromArgb(224, 224, 224);
                _selectedTab.BackColor = backcolor;
                _selectedTab.ForeColor = forcolor;

                walletTabControl.SelectedIndex = 1;
                _selectedTab = currentButton;

                backcolor = Color.FromArgb(82,82,82);
                forcolor = Color.FromArgb(39, 170, 107);
                _selectedTab.BackColor = backcolor;
                _selectedTab.ForeColor = forcolor;
            }
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Blue, e.Bounds);
            e.DrawText();
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void copyAddressButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(myAddressText.Text);
        }

        private void resyncer_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                refresh_ui();
                System.Threading.Thread.Sleep(5000);
                this.updateLabel.BeginInvoke((MethodInvoker)delegate ()
                {
                    updateLabel.Text = "Wallet Idle ...";
                    updateLabel.ForeColor = Color.Gray;
                });
            }
        }

        private void wallet_FormClosing(object sender, FormClosingEventArgs e)
        {
            runningDaemon.Kill();
        }
    }
}
