namespace server
{
    partial class UfrmClient
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UfrmClient));
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.ctmenutrip_May_PC_SV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.directClient = new System.Windows.Forms.ToolStripMenuItem();
            this.chatClient = new System.Windows.Forms.ToolStripMenuItem();
            this.lockMouseAndKeyboardClient = new System.Windows.Forms.ToolStripMenuItem();
            this.restartClient = new System.Windows.Forms.ToolStripMenuItem();
            this.shutDownClient = new System.Windows.Forms.ToolStripMenuItem();
            this.lblName = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.ctmenutrip_May_PC_SV.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbStatus
            // 
            this.pbStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbStatus.Location = new System.Drawing.Point(0, 0);
            this.pbStatus.Margin = new System.Windows.Forms.Padding(2);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(138, 115);
            this.pbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStatus.TabIndex = 6;
            this.pbStatus.TabStop = false;
            // 
            // ctmenutrip_May_PC_SV
            // 
            this.ctmenutrip_May_PC_SV.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctmenutrip_May_PC_SV.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctmenutrip_May_PC_SV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.directClient,
            this.chatClient,
            this.lockMouseAndKeyboardClient,
            this.restartClient,
            this.shutDownClient});
            this.ctmenutrip_May_PC_SV.Name = "ctmenutrip_May_PC_SV";
            this.ctmenutrip_May_PC_SV.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ctmenutrip_May_PC_SV.ShowCheckMargin = true;
            this.ctmenutrip_May_PC_SV.Size = new System.Drawing.Size(266, 134);
            // 
            // directClient
            // 
            this.directClient.Image = ((System.Drawing.Image)(resources.GetObject("directClient.Image")));
            this.directClient.Name = "directClient";
            this.directClient.Size = new System.Drawing.Size(265, 26);
            this.directClient.Text = "Điều khiển";
            this.directClient.Click += new System.EventHandler(this.directClient_on_click);
            // 
            // chatClient
            // 
            this.chatClient.Image = ((System.Drawing.Image)(resources.GetObject("chatClient.Image")));
            this.chatClient.Name = "chatClient";
            this.chatClient.Size = new System.Drawing.Size(265, 26);
            this.chatClient.Text = "Trò chuyện";
            this.chatClient.Click += new System.EventHandler(this.chatClient_on_click);
            // 
            // lockMouseAndKeyboardClient
            // 
            this.lockMouseAndKeyboardClient.Image = ((System.Drawing.Image)(resources.GetObject("lockMouseAndKeyboardClient.Image")));
            this.lockMouseAndKeyboardClient.Name = "lockMouseAndKeyboardClient";
            this.lockMouseAndKeyboardClient.Size = new System.Drawing.Size(265, 26);
            this.lockMouseAndKeyboardClient.Text = "Khoá chuột và bàn phím";
            this.lockMouseAndKeyboardClient.Click += new System.EventHandler(this.lockMouseAndKeyboardClient_Click);
            // 
            // restartClient
            // 
            this.restartClient.Image = ((System.Drawing.Image)(resources.GetObject("restartClient.Image")));
            this.restartClient.Name = "restartClient";
            this.restartClient.Size = new System.Drawing.Size(265, 26);
            this.restartClient.Text = "Khởi động lại";
            this.restartClient.Click += new System.EventHandler(this.restartClient_Click);
            // 
            // shutDownClient
            // 
            this.shutDownClient.Image = ((System.Drawing.Image)(resources.GetObject("shutDownClient.Image")));
            this.shutDownClient.Name = "shutDownClient";
            this.shutDownClient.Size = new System.Drawing.Size(265, 26);
            this.shutDownClient.Text = "Tắt máy";
            this.shutDownClient.Click += new System.EventHandler(this.shutDownClient_Click);
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(0, 115);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(138, 55);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Long";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIP
            // 
            this.lblIP.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIP.Location = new System.Drawing.Point(0, 170);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(138, 31);
            this.lblIP.TabIndex = 11;
            this.lblIP.Text = "123.2.32.3.23";
            this.lblIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UfrmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ContextMenuStrip = this.ctmenutrip_May_PC_SV;
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbStatus);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "UfrmClient";
            this.Size = new System.Drawing.Size(138, 207);
            this.Click += new System.EventHandler(this.UfrmClient_Click);
            this.DoubleClick += new System.EventHandler(this.UfrmClient_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.ctmenutrip_May_PC_SV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbStatus;
        private System.Windows.Forms.ContextMenuStrip ctmenutrip_May_PC_SV;
        private System.Windows.Forms.ToolStripMenuItem directClient;
        private System.Windows.Forms.ToolStripMenuItem chatClient;
        private System.Windows.Forms.ToolStripMenuItem lockMouseAndKeyboardClient;
        private System.Windows.Forms.ToolStripMenuItem restartClient;
        private System.Windows.Forms.ToolStripMenuItem shutDownClient;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblIP;
    }
}
