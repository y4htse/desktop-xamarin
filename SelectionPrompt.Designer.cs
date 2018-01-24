namespace TurtleWallet
{
    partial class SelectionPrompt
    {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.selectWalletButton = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.createWalletButton = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 199);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 293);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(170)))), ((int)(((byte)(107)))));
            this.label2.Location = new System.Drawing.Point(0, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(597, 68);
            this.label2.TabIndex = 99;
            this.label2.Text = "Make your selection:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(597, 68);
            this.label1.TabIndex = 98;
            this.label1.Text = "Welcome to Turtle Wallet";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.selectWalletButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.createWalletButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 153);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(597, 140);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // selectWalletButton
            // 
            this.selectWalletButton.AutoSize = true;
            this.selectWalletButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.selectWalletButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectWalletButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectWalletButton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectWalletButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.selectWalletButton.Location = new System.Drawing.Point(3, 71);
            this.selectWalletButton.Name = "selectWalletButton";
            this.selectWalletButton.Size = new System.Drawing.Size(591, 69);
            this.selectWalletButton.TabIndex = 1;
            this.selectWalletButton.Text = "Select Existing Wallet";
            this.selectWalletButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.selectWalletButton.Click += new System.EventHandler(this.selectWalletButton_Click);
            this.selectWalletButton.MouseEnter += new System.EventHandler(this.selectWalletButton_MouseEnter);
            this.selectWalletButton.MouseLeave += new System.EventHandler(this.selectWalletButton_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(170)))), ((int)(((byte)(107)))));
            this.panel2.Location = new System.Drawing.Point(25, 70);
            this.panel2.Margin = new System.Windows.Forms.Padding(25, 3, 25, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(547, 1);
            this.panel2.TabIndex = 0;
            // 
            // createWalletButton
            // 
            this.createWalletButton.AutoSize = true;
            this.createWalletButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.createWalletButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createWalletButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createWalletButton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createWalletButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.createWalletButton.Location = new System.Drawing.Point(3, 0);
            this.createWalletButton.Name = "createWalletButton";
            this.createWalletButton.Size = new System.Drawing.Size(591, 67);
            this.createWalletButton.TabIndex = 0;
            this.createWalletButton.Text = "Create Wallet";
            this.createWalletButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.createWalletButton.Click += new System.EventHandler(this.createWalletButton_Click);
            this.createWalletButton.MouseEnter += new System.EventHandler(this.createWalletButton_MouseEnter);
            this.createWalletButton.MouseLeave += new System.EventHandler(this.createWalletButton_MouseLeave);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.AutoSize = true;
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(563, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(30, 29);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "✘";
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.MouseEnter += new System.EventHandler(this.exitButton_MouseEnter);
            this.exitButton.MouseLeave += new System.EventHandler(this.exitButton_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::TurtleWallet.Properties.Resources.trtl_banner;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(597, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SelectionPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 492);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectionPrompt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label selectWalletButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label createWalletButton;
        private System.Windows.Forms.Label exitButton;
    }
}