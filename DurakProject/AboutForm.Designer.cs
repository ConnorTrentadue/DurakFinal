namespace DurakProject
{
    partial class frmAboutForm
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
            this.lblAboutInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAboutInfo
            // 
            this.lblAboutInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAboutInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAboutInfo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAboutInfo.Location = new System.Drawing.Point(0, 0);
            this.lblAboutInfo.Name = "lblAboutInfo";
            this.lblAboutInfo.Size = new System.Drawing.Size(449, 323);
            this.lblAboutInfo.TabIndex = 0;
            // 
            // frmAboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 323);
            this.Controls.Add(this.lblAboutInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAboutInfo;
    }
}