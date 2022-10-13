namespace server
{
    partial class frmDieuKhienMayClient
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
            this.pictureBoxRemote = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRemote)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxRemote
            // 
            this.pictureBoxRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxRemote.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxRemote.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxRemote.Name = "pictureBoxRemote";
            this.pictureBoxRemote.Size = new System.Drawing.Size(944, 605);
            this.pictureBoxRemote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRemote.TabIndex = 1;
            this.pictureBoxRemote.TabStop = false;
            this.pictureBoxRemote.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxRemote_MouseClick);
            this.pictureBoxRemote.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxRemote_MouseDoubleClick);
            this.pictureBoxRemote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxRemote_MouseDown);
            this.pictureBoxRemote.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxRemote_MouseMove);
            this.pictureBoxRemote.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxRemote_MouseUp);
            // 
            // frmDieuKhienMayClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 605);
            this.Controls.Add(this.pictureBoxRemote);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDieuKhienMayClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều khiển client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDieuKhienMayClient_FormClosing);
            this.Load += new System.EventHandler(this.frmDieuKhienMayClient_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmDieuKhienMayClient_KeyPress_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRemote)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxRemote;
    }
}