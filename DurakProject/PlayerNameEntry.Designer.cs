namespace DurakProject
{
    partial class frmPlayerNameEntry
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
            this.lblNamePrompt = new System.Windows.Forms.Label();
            this.txtNameEntry = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNamePrompt
            // 
            this.lblNamePrompt.AutoSize = true;
            this.lblNamePrompt.Location = new System.Drawing.Point(12, 30);
            this.lblNamePrompt.Name = "lblNamePrompt";
            this.lblNamePrompt.Size = new System.Drawing.Size(126, 13);
            this.lblNamePrompt.TabIndex = 0;
            this.lblNamePrompt.Text = "Please Enter Your Name:";
            // 
            // txtNameEntry
            // 
            this.txtNameEntry.Location = new System.Drawing.Point(189, 27);
            this.txtNameEntry.Name = "txtNameEntry";
            this.txtNameEntry.Size = new System.Drawing.Size(100, 20);
            this.txtNameEntry.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(214, 58);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "&Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // frmPlayerNameEntry
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 93);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtNameEntry);
            this.Controls.Add(this.lblNamePrompt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPlayerNameEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNamePrompt;
        private System.Windows.Forms.TextBox txtNameEntry;
        private System.Windows.Forms.Button btnSubmit;
    }
}