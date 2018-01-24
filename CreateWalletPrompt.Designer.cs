namespace TurtleWallet
{
    partial class CreateWalletPrompt { 
       /// <summary>
       /// Required designer variable.
       /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.createMainPanel = new System.Windows.Forms.Panel();
            this.CreateLabel = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.createProgressbar = new System.Windows.Forms.ProgressBar();
            this.createMainTable = new System.Windows.Forms.TableLayoutPanel();
            this.passwordConfirmTable = new System.Windows.Forms.TableLayoutPanel();
            this.passwordConfirmText = new System.Windows.Forms.TextBox();
            this.passwordConfirmLabel = new System.Windows.Forms.Label();
            this.passwordTable = new System.Windows.Forms.TableLayoutPanel();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.buttonsTable = new System.Windows.Forms.TableLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Label();
            this.createWalletButton = new System.Windows.Forms.Label();
            this.walletNameTable = new System.Windows.Forms.TableLayoutPanel();
            this.walletNameLabel = new System.Windows.Forms.Label();
            this.walletNameText = new System.Windows.Forms.TextBox();
            this.exitButton = new System.Windows.Forms.Label();
            this.createLogo = new System.Windows.Forms.PictureBox();
            this.createMainPanel.SuspendLayout();
            this.createMainTable.SuspendLayout();
            this.passwordConfirmTable.SuspendLayout();
            this.passwordTable.SuspendLayout();
            this.buttonsTable.SuspendLayout();
            this.walletNameTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.createLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // createMainPanel
            // 
            this.createMainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.createMainPanel.Controls.Add(this.CreateLabel);
            this.createMainPanel.Controls.Add(this.welcomeLabel);
            this.createMainPanel.Controls.Add(this.createProgressbar);
            this.createMainPanel.Controls.Add(this.createMainTable);
            this.createMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createMainPanel.Location = new System.Drawing.Point(0, 199);
            this.createMainPanel.Name = "createMainPanel";
            this.createMainPanel.Size = new System.Drawing.Size(597, 293);
            this.createMainPanel.TabIndex = 1;
            // 
            // CreateLabel
            // 
            this.CreateLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.CreateLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateLabel.Font = new System.Drawing.Font("Segoe UI Light", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(170)))), ((int)(((byte)(107)))));
            this.CreateLabel.Location = new System.Drawing.Point(0, 61);
            this.CreateLabel.Name = "CreateLabel";
            this.CreateLabel.Size = new System.Drawing.Size(597, 39);
            this.CreateLabel.TabIndex = 2;
            this.CreateLabel.Text = "Wallet Creation:";
            this.CreateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.welcomeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI Light", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.White;
            this.welcomeLabel.Location = new System.Drawing.Point(0, 5);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(597, 56);
            this.welcomeLabel.TabIndex = 1;
            this.welcomeLabel.Text = "Welcome to Turtle Wallet";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createProgressbar
            // 
            this.createProgressbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.createProgressbar.ForeColor = System.Drawing.Color.Green;
            this.createProgressbar.Location = new System.Drawing.Point(0, 0);
            this.createProgressbar.Name = "createProgressbar";
            this.createProgressbar.Size = new System.Drawing.Size(597, 5);
            this.createProgressbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.createProgressbar.TabIndex = 3;
            this.createProgressbar.Visible = false;
            // 
            // createMainTable
            // 
            this.createMainTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.createMainTable.ColumnCount = 1;
            this.createMainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.createMainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.createMainTable.Controls.Add(this.passwordConfirmTable, 0, 2);
            this.createMainTable.Controls.Add(this.passwordTable, 0, 1);
            this.createMainTable.Controls.Add(this.buttonsTable, 0, 3);
            this.createMainTable.Controls.Add(this.walletNameTable, 0, 0);
            this.createMainTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.createMainTable.Location = new System.Drawing.Point(0, 103);
            this.createMainTable.Name = "createMainTable";
            this.createMainTable.RowCount = 4;
            this.createMainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.32332F));
            this.createMainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.32332F));
            this.createMainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.32332F));
            this.createMainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.03003F));
            this.createMainTable.Size = new System.Drawing.Size(597, 190);
            this.createMainTable.TabIndex = 0;
            // 
            // passwordConfirmTable
            // 
            this.passwordConfirmTable.ColumnCount = 2;
            this.passwordConfirmTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.passwordConfirmTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.passwordConfirmTable.Controls.Add(this.passwordConfirmText, 0, 0);
            this.passwordConfirmTable.Controls.Add(this.passwordConfirmLabel, 0, 0);
            this.passwordConfirmTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordConfirmTable.Location = new System.Drawing.Point(3, 91);
            this.passwordConfirmTable.Name = "passwordConfirmTable";
            this.passwordConfirmTable.RowCount = 1;
            this.passwordConfirmTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.passwordConfirmTable.Size = new System.Drawing.Size(591, 38);
            this.passwordConfirmTable.TabIndex = 6;
            // 
            // passwordConfirmText
            // 
            this.passwordConfirmText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.passwordConfirmText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordConfirmText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordConfirmText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordConfirmText.ForeColor = System.Drawing.Color.White;
            this.passwordConfirmText.Location = new System.Drawing.Point(239, 3);
            this.passwordConfirmText.MaxLength = 24;
            this.passwordConfirmText.Name = "passwordConfirmText";
            this.passwordConfirmText.Size = new System.Drawing.Size(349, 34);
            this.passwordConfirmText.TabIndex = 6;
            this.passwordConfirmText.UseSystemPasswordChar = true;
            this.passwordConfirmText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordConfirmText_KeyDown);
            // 
            // passwordConfirmLabel
            // 
            this.passwordConfirmLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.passwordConfirmLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.passwordConfirmLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordConfirmLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(170)))), ((int)(((byte)(107)))));
            this.passwordConfirmLabel.Location = new System.Drawing.Point(5, 0);
            this.passwordConfirmLabel.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.passwordConfirmLabel.Name = "passwordConfirmLabel";
            this.passwordConfirmLabel.Size = new System.Drawing.Size(228, 38);
            this.passwordConfirmLabel.TabIndex = 4;
            this.passwordConfirmLabel.Text = "Password Confirm:";
            this.passwordConfirmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // passwordTable
            // 
            this.passwordTable.ColumnCount = 2;
            this.passwordTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.passwordTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.passwordTable.Controls.Add(this.passwordText, 0, 0);
            this.passwordTable.Controls.Add(this.passwordLabel, 0, 0);
            this.passwordTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordTable.Location = new System.Drawing.Point(3, 47);
            this.passwordTable.Name = "passwordTable";
            this.passwordTable.RowCount = 1;
            this.passwordTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.passwordTable.Size = new System.Drawing.Size(591, 38);
            this.passwordTable.TabIndex = 5;
            // 
            // passwordText
            // 
            this.passwordText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.passwordText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordText.ForeColor = System.Drawing.Color.White;
            this.passwordText.Location = new System.Drawing.Point(239, 3);
            this.passwordText.MaxLength = 24;
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(349, 34);
            this.passwordText.TabIndex = 5;
            this.passwordText.UseSystemPasswordChar = true;
            this.passwordText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordText_KeyDown);
            // 
            // passwordLabel
            // 
            this.passwordLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.passwordLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(170)))), ((int)(((byte)(107)))));
            this.passwordLabel.Location = new System.Drawing.Point(5, 0);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(228, 38);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonsTable
            // 
            this.buttonsTable.ColumnCount = 2;
            this.buttonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonsTable.Controls.Add(this.cancelButton, 1, 0);
            this.buttonsTable.Controls.Add(this.createWalletButton, 0, 0);
            this.buttonsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonsTable.Location = new System.Drawing.Point(3, 135);
            this.buttonsTable.Name = "buttonsTable";
            this.buttonsTable.RowCount = 1;
            this.buttonsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.buttonsTable.Size = new System.Drawing.Size(591, 52);
            this.buttonsTable.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.AutoSize = true;
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cancelButton.Location = new System.Drawing.Point(298, 5);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(290, 47);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            this.cancelButton.MouseEnter += new System.EventHandler(this.cancelButton_MouseEnter);
            this.cancelButton.MouseLeave += new System.EventHandler(this.cancelButton_MouseLeave);
            // 
            // createWalletButton
            // 
            this.createWalletButton.AutoSize = true;
            this.createWalletButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.createWalletButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createWalletButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createWalletButton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createWalletButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.createWalletButton.Location = new System.Drawing.Point(3, 5);
            this.createWalletButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.createWalletButton.Name = "createWalletButton";
            this.createWalletButton.Size = new System.Drawing.Size(289, 47);
            this.createWalletButton.TabIndex = 1;
            this.createWalletButton.Text = "Create Wallet";
            this.createWalletButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.createWalletButton.Click += new System.EventHandler(this.createWalletButton_Click);
            this.createWalletButton.MouseEnter += new System.EventHandler(this.createWalletButton_MouseEnter);
            this.createWalletButton.MouseLeave += new System.EventHandler(this.createWalletButton_MouseLeave);
            // 
            // walletNameTable
            // 
            this.walletNameTable.ColumnCount = 2;
            this.walletNameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.walletNameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.walletNameTable.Controls.Add(this.walletNameLabel, 0, 0);
            this.walletNameTable.Controls.Add(this.walletNameText, 1, 0);
            this.walletNameTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.walletNameTable.Location = new System.Drawing.Point(3, 3);
            this.walletNameTable.Name = "walletNameTable";
            this.walletNameTable.RowCount = 1;
            this.walletNameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.walletNameTable.Size = new System.Drawing.Size(591, 38);
            this.walletNameTable.TabIndex = 4;
            // 
            // walletNameLabel
            // 
            this.walletNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.walletNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.walletNameLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.walletNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(170)))), ((int)(((byte)(107)))));
            this.walletNameLabel.Location = new System.Drawing.Point(5, 0);
            this.walletNameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.walletNameLabel.Name = "walletNameLabel";
            this.walletNameLabel.Size = new System.Drawing.Size(228, 38);
            this.walletNameLabel.TabIndex = 3;
            this.walletNameLabel.Text = "Wallet Name:";
            this.walletNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // walletNameText
            // 
            this.walletNameText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.walletNameText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.walletNameText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.walletNameText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.walletNameText.ForeColor = System.Drawing.Color.White;
            this.walletNameText.Location = new System.Drawing.Point(239, 3);
            this.walletNameText.MaxLength = 24;
            this.walletNameText.Name = "walletNameText";
            this.walletNameText.Size = new System.Drawing.Size(349, 34);
            this.walletNameText.TabIndex = 4;
            this.walletNameText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.walletNameText_KeyDown);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.AutoSize = true;
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(563, 2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(30, 29);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "✘";
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.MouseEnter += new System.EventHandler(this.exitButton_MouseEnter);
            this.exitButton.MouseLeave += new System.EventHandler(this.exitButton_MouseLeave);
            // 
            // createLogo
            // 
            this.createLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.createLogo.Image = global::TurtleWallet.Properties.Resources.trtl_banner;
            this.createLogo.Location = new System.Drawing.Point(0, 0);
            this.createLogo.Name = "createLogo";
            this.createLogo.Size = new System.Drawing.Size(597, 199);
            this.createLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.createLogo.TabIndex = 0;
            this.createLogo.TabStop = false;
            // 
            // CreateWalletPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 492);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.createMainPanel);
            this.Controls.Add(this.createLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateWalletPrompt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.createMainPanel.ResumeLayout(false);
            this.createMainTable.ResumeLayout(false);
            this.passwordConfirmTable.ResumeLayout(false);
            this.passwordConfirmTable.PerformLayout();
            this.passwordTable.ResumeLayout(false);
            this.passwordTable.PerformLayout();
            this.buttonsTable.ResumeLayout(false);
            this.buttonsTable.PerformLayout();
            this.walletNameTable.ResumeLayout(false);
            this.walletNameTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.createLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox createLogo;
    private System.Windows.Forms.Panel createMainPanel;
    private System.Windows.Forms.Label welcomeLabel;
    private System.Windows.Forms.TableLayoutPanel createMainTable;
    private System.Windows.Forms.Label CreateLabel;
    private System.Windows.Forms.Label cancelButton;
    private System.Windows.Forms.Label createWalletButton;
        private System.Windows.Forms.ProgressBar createProgressbar;
        private System.Windows.Forms.TableLayoutPanel buttonsTable;
        private System.Windows.Forms.TableLayoutPanel passwordConfirmTable;
        private System.Windows.Forms.TextBox passwordConfirmText;
        private System.Windows.Forms.Label passwordConfirmLabel;
        private System.Windows.Forms.TableLayoutPanel passwordTable;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TableLayoutPanel walletNameTable;
        private System.Windows.Forms.Label walletNameLabel;
        private System.Windows.Forms.TextBox walletNameText;
        private System.Windows.Forms.Label exitButton;
    }
}