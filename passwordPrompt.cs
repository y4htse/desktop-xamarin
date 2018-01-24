using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurtleWallet
{
    public partial class passwordPrompt : Form
    {
        public string walletPassword
        {
            get;
            set;
        }

        public passwordPrompt()
        {
            InitializeComponent();
        }

        private void passwordText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (passwordText.Text != "" && passwordText.Text.Length > 6)
                {
                    walletPassword = passwordText.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel?", "Turtle Wallet Cancel?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void createWalletButton_Click(object sender, EventArgs e)
        {
            if(passwordText.Text != "" && passwordText.Text.Length > 6)
            {
                walletPassword = passwordText.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
