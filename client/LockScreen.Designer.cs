namespace client
{
    partial class LockScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LockScreen));
            this.btnTatMay = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnTatMay
            // 
            this.btnTatMay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTatMay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTatMay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTatMay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTatMay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTatMay.ForeColor = System.Drawing.Color.White;
            this.btnTatMay.Location = new System.Drawing.Point(45, 402);
            this.btnTatMay.Name = "btnTatMay";
            this.btnTatMay.Size = new System.Drawing.Size(180, 45);
            this.btnTatMay.TabIndex = 0;
            this.btnTatMay.Text = "Tắt máy";
            // 
            // LockScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTatMay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LockScreen";
            this.Text = "LockScreen";
            this.Load += new System.EventHandler(this.LockScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnTatMay;
    }
}