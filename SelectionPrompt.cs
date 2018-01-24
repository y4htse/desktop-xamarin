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
    public partial class SelectionPrompt : Form
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

        public SelectionPrompt()
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

        private void selectWalletButton_MouseEnter(object sender, EventArgs e)
        {
            var backcolor = Color.FromArgb(44, 44, 44);
            var forcolor = Color.FromArgb(39, 170, 107);
            var currentButton = (Label)sender;
            currentButton.BackColor = backcolor;
            currentButton.ForeColor = forcolor;
        }

        private void selectWalletButton_MouseLeave(object sender, EventArgs e)
        {
            var backcolor = Color.FromArgb(52, 52, 52);
            var forcolor = Color.FromArgb(224, 224, 224);
            var currentButton = (Label)sender;
            currentButton.BackColor = backcolor;
            currentButton.ForeColor = forcolor;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close Turtle Wallet?", "Turtle Wallet", MessageBoxButtons.YesNo);
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

        private void createWalletButton_Click(object sender, EventArgs e)
        {
            CreateWalletPrompt CWP = new CreateWalletPrompt();
            this.Hide();
            var CWPreturn = CWP.ShowDialog();
            if(CWPreturn == DialogResult.OK)
            {
                walletPath = CWP.walletPath;
                walletPassword = CWP.walletPassword;
                this.DialogResult = DialogResult.OK;
                CWP.Dispose();
                this.Close();
            }
            this.Show();
        }

        private void selectWalletButton_Click(object sender, EventArgs e)
        {
            var curDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            OpenFileDialog findWalletDialog = new OpenFileDialog();

            findWalletDialog.InitialDirectory = curDir;
            findWalletDialog.Filter = "wallet files (*.wallet)|*.wallet|All files (*.*)|*.*";
            findWalletDialog.FilterIndex = 2;
            findWalletDialog.RestoreDirectory = true;

            if (findWalletDialog.ShowDialog() == DialogResult.OK)
            {
                if(System.IO.File.Exists(findWalletDialog.FileName))
                {
                    walletPath = findWalletDialog.FileName;
                    var pPrompt = new passwordPrompt();
                    this.Hide();
                    var pResult = pPrompt.ShowDialog();
                    if(pResult != DialogResult.OK)
                    {
                        findWalletDialog.Dispose();
                        pPrompt.Dispose();
                        this.Show();
                        return;
                    }
                    else
                    {
                        walletPassword = pPrompt.walletPassword;
                        pPrompt.Dispose();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }
    }
}
