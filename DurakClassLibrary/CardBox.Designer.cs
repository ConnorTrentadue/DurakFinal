﻿namespace DurakClassLibrary
{
    partial class cbCardBox
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
            this.pbMyPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMyPictureBox
            // 
            this.pbMyPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMyPictureBox.Location = new System.Drawing.Point(0, 0);
            this.pbMyPictureBox.Name = "pbMyPictureBox";
            this.pbMyPictureBox.Size = new System.Drawing.Size(75, 108);
            this.pbMyPictureBox.TabIndex = 0;
            this.pbMyPictureBox.TabStop = false;
            this.pbMyPictureBox.Click += new System.EventHandler(this.pbMyPictureBox_Click);
            // 
            // cbCardBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbMyPictureBox);
            this.Name = "cbCardBox";
            this.Size = new System.Drawing.Size(75, 108);
            this.Load += new System.EventHandler(this.Cardbox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMyPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMyPictureBox;
    }
}