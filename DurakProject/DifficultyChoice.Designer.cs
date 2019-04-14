namespace DurakProject
{
    partial class frmDifficultyChoice
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
            this.rbtnEasyMode = new System.Windows.Forms.RadioButton();
            this.rbtnMediumMode = new System.Windows.Forms.RadioButton();
            this.rbtnHardMode = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbtnEasyMode
            // 
            this.rbtnEasyMode.AutoSize = true;
            this.rbtnEasyMode.Location = new System.Drawing.Point(58, 36);
            this.rbtnEasyMode.Name = "rbtnEasyMode";
            this.rbtnEasyMode.Size = new System.Drawing.Size(48, 17);
            this.rbtnEasyMode.TabIndex = 0;
            this.rbtnEasyMode.TabStop = true;
            this.rbtnEasyMode.Text = "Easy";
            this.rbtnEasyMode.UseVisualStyleBackColor = true;
            // 
            // rbtnMediumMode
            // 
            this.rbtnMediumMode.AutoSize = true;
            this.rbtnMediumMode.Location = new System.Drawing.Point(58, 60);
            this.rbtnMediumMode.Name = "rbtnMediumMode";
            this.rbtnMediumMode.Size = new System.Drawing.Size(62, 17);
            this.rbtnMediumMode.TabIndex = 1;
            this.rbtnMediumMode.TabStop = true;
            this.rbtnMediumMode.Text = "Medium";
            this.rbtnMediumMode.UseVisualStyleBackColor = true;
            // 
            // rbtnHardMode
            // 
            this.rbtnHardMode.AutoSize = true;
            this.rbtnHardMode.Location = new System.Drawing.Point(58, 84);
            this.rbtnHardMode.Name = "rbtnHardMode";
            this.rbtnHardMode.Size = new System.Drawing.Size(48, 17);
            this.rbtnHardMode.TabIndex = 2;
            this.rbtnHardMode.TabStop = true;
            this.rbtnHardMode.Text = "Hard";
            this.rbtnHardMode.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(58, 125);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // frmDifficultyChoice
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 160);
            this.ControlBox = false;
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rbtnHardMode);
            this.Controls.Add(this.rbtnMediumMode);
            this.Controls.Add(this.rbtnEasyMode);
            this.Name = "frmDifficultyChoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Difficulty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnEasyMode;
        private System.Windows.Forms.RadioButton rbtnMediumMode;
        private System.Windows.Forms.RadioButton rbtnHardMode;
        private System.Windows.Forms.Button btnSubmit;
    }
}