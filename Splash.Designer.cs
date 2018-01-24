namespace TurtleWallet
{
    partial class Splash
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splashBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Top;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(627, 678);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.TabStop = false;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.StatusLabel);
            this.panel1.Controls.Add(this.versionLabel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 678);
            this.panel1.MaximumSize = new System.Drawing.Size(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 37);
            this.panel1.TabIndex = 1;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusLabel.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Location = new System.Drawing.Point(22, 0);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(512, 37);
            this.StatusLabel.TabIndex = 3;
            this.StatusLabel.Text = "Wallet opening ...";
            // 
            // versionLabel
            // 
            this.versionLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.versionLabel.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.ForeColor = System.Drawing.Color.White;
            this.versionLabel.Location = new System.Drawing.Point(534, 0);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(93, 37);
            this.versionLabel.TabIndex = 2;
            this.versionLabel.Text = "v 1.0.0.0";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(22, 37);
            this.panel2.TabIndex = 0;
            // 
            // splashBackgroundWorker
            // 
            this.splashBackgroundWorker.WorkerReportsProgress = true;
            this.splashBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.splashBackgroundWorker_DoWork);
            this.splashBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.splashBackgroundWorker_ProgressChanged);
            this.splashBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.splashBackgroundWorker_RunWorkerCompleted);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 715);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Splash_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.ComponentModel.BackgroundWorker splashBackgroundWorker;
    }
}

