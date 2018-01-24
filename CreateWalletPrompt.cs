using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurtleWallet
{
    public partial class CreateWalletPrompt : Form
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

        public CreateWalletPrompt()
        {
            InitializeComponent();
        }

        private void createWalletButton_MouseEnter(object sender, EventArgs e)
        {
            var backcolor = Color.FromArgb(44, 44, 44);
            var forcolor = Color.FromArgb(39, 170, 107);
            var currentButton = (Label)sender;
            currentButton.BackColor = backcolor;
            currentButton.ForeColor = forcolor;
        }

        private void createWalletButton_MouseLeave(object sender, EventArgs e)
        {
            var backcolor = Color.FromArgb(52, 52, 52);
            var forcolor = Color.FromArgb(224, 224, 224);
            var currentButton = (Label)sender;
            currentButton.BackColor = backcolor;
            currentButton.ForeColor = forcolor;
        }

        private void cancelButton_MouseEnter(object sender, EventArgs e)
        {
            var backcolor = Color.FromArgb(44, 44, 44);
            var forcolor = Color.FromArgb(39, 170, 107);
            var currentButton = (Label)sender;
            currentButton.BackColor = backcolor;
            currentButton.ForeColor = forcolor;
        }

        private void cancelButton_MouseLeave(object sender, EventArgs e)
        {
            var backcolor = Color.FromArgb(52, 52, 52);
            var forcolor = Color.FromArgb(224, 224, 224);
            var currentButton = (Label)sender;
            currentButton.BackColor = backcolor;
            currentButton.ForeColor = forcolor;
        }

        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            var forcolor = Color.FromArgb(39, 170, 107);
            var currentButton = (Label)sender;
            currentButton.ForeColor = forcolor;
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            var forcolor = Color.White;
            var currentButton = (Label)sender;
            currentButton.ForeColor = forcolor;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel your Turtle Wallet creation?", "Cancel wallet creation?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel your Turtle Wallet creation?", "Cancel wallet creation?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void createWalletButton_Click(object sender, EventArgs e)
        {
            createWallet();
        }

        private void walletNameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                createWallet();
            }
        }

        private void createWallet()
        {
            if (walletNameText.Text == "")
            {
                MessageBox.Show("Please enter a valid wallet name", "Turtle Wallet Creation");
                return;
            }
            else if (walletNameText.Text.Any(c => !Char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("Wallet name cannot contain special characters", "Turtle Wallet Creation");
                return;
            }

            if (passwordText.Text == "")
            {
                MessageBox.Show("Please enter a valid password", "Turtle Wallet Creation");
                return;
            }
            else if (passwordText.Text.Length < 6)
            {
                MessageBox.Show("Please enter a password that is larger than 6 characters", "Turtle Wallet Creation");
                return;
            }

            if (passwordText.Text != passwordConfirmText.Text)
            {
                MessageBox.Show("Passwords do not match", "Turtle Wallet Creation");
                return;
            }

            var curDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var _walletFile = System.IO.Path.Combine(curDir, walletNameText.Text + ".wallet");
            var walletdexe = System.IO.Path.Combine(curDir, "walletd.exe");

            if (!System.IO.File.Exists(walletdexe))
            {
                MessageBox.Show("The 'walletd.exe' daemon is missing from the folder the wallet is currently running from! Please place 'walletd.exe' next to your wallet exe and run again!", "Turtle Wallet Creation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            createProgressbar.Visible = true;
            try
            {
                Process p = new Process();
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.FileName = walletdexe;
                p.StartInfo.Arguments = "-w \"" + _walletFile + "\" -p " + passwordText.Text + " -g";
                p.Start();
                p.WaitForExit(10000);

                if (!System.IO.File.Exists(_walletFile))
                {
                    MessageBox.Show("Wallet failed to create after communicating with daemon. Please reinstall the wallet, close any other wallets you may have open, and try again", "Turtle Wallet Creation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
                else
                {
                    walletPath = _walletFile;
                    walletPassword = passwordText.Text;
                    MessageBox.Show("Wallet successfully created at: " + Environment.NewLine + _walletFile, "Turtle Wallet Creation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An exception occured while attempting to create the wallet." + Environment.NewLine + "Error:" + Environment.NewLine + ex.Message, "Turtle Wallet Creation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void passwordText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                createWallet();
            }
        }

        private void passwordConfirmText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                createWallet();
            }
        }
    }
}
