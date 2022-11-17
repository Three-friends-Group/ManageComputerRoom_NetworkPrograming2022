namespace server
{
    partial class frmSetTime
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
            this.cboChooseTime = new System.Windows.Forms.ComboBox();
            this.btnSetTime = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboChooseTime
            // 
            this.cboChooseTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChooseTime.FormattingEnabled = true;
            this.cboChooseTime.Location = new System.Drawing.Point(26, 31);
            this.cboChooseTime.Name = "cboChooseTime";
            this.cboChooseTime.Size = new System.Drawing.Size(233, 21);
            this.cboChooseTime.TabIndex = 0;
            // 
            // btnSetTime
            // 
            this.btnSetTime.Location = new System.Drawing.Point(109, 82);
            this.btnSetTime.Name = "btnSetTime";
            this.btnSetTime.Size = new System.Drawing.Size(75, 23);
            this.btnSetTime.TabIndex = 1;
            this.btnSetTime.Text = "OK";
            this.btnSetTime.UseVisualStyleBackColor = true;
            this.btnSetTime.Click += new System.EventHandler(this.btnSetTime_Click);
            // 
            // frmSetTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 117);
            this.Controls.Add(this.btnSetTime);
            this.Controls.Add(this.cboChooseTime);
            this.Name = "frmSetTime";
            this.Text = "Select delay";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboChooseTime;
        private System.Windows.Forms.Button btnSetTime;
    }
}