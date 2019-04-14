namespace Difficulty
{
    partial class Difficulty
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
            this.btnSetAI = new System.Windows.Forms.Button();
            this.rbtnBasicAI = new System.Windows.Forms.RadioButton();
            this.rbtnMediumAI = new System.Windows.Forms.RadioButton();
            this.rbtnHardAI = new System.Windows.Forms.RadioButton();
            this.lblComputerAI = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSetAI
            // 
            this.btnSetAI.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSetAI.Location = new System.Drawing.Point(188, 115);
            this.btnSetAI.Name = "btnSetAI";
            this.btnSetAI.Size = new System.Drawing.Size(75, 23);
            this.btnSetAI.TabIndex = 0;
            this.btnSetAI.Text = "Set the AI";
            this.btnSetAI.UseVisualStyleBackColor = true;
            this.btnSetAI.Click += new System.EventHandler(this.btnSetAI_Click);
            // 
            // rbtnBasicAI
            // 
            this.rbtnBasicAI.AutoSize = true;
            this.rbtnBasicAI.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnBasicAI.Location = new System.Drawing.Point(20, 60);
            this.rbtnBasicAI.Name = "rbtnBasicAI";
            this.rbtnBasicAI.Size = new System.Drawing.Size(112, 21);
            this.rbtnBasicAI.TabIndex = 1;
            this.rbtnBasicAI.TabStop = true;
            this.rbtnBasicAI.Text = "Basic (default)";
            this.rbtnBasicAI.UseVisualStyleBackColor = true;
            // 
            // rbtnMediumAI
            // 
            this.rbtnMediumAI.AutoSize = true;
            this.rbtnMediumAI.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnMediumAI.Location = new System.Drawing.Point(183, 60);
            this.rbtnMediumAI.Name = "rbtnMediumAI";
            this.rbtnMediumAI.Size = new System.Drawing.Size(90, 21);
            this.rbtnMediumAI.TabIndex = 2;
            this.rbtnMediumAI.TabStop = true;
            this.rbtnMediumAI.Text = "Advanced";
            this.rbtnMediumAI.UseVisualStyleBackColor = true;
            // 
            // rbtnHardAI
            // 
            this.rbtnHardAI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbtnHardAI.AutoSize = true;
            this.rbtnHardAI.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnHardAI.Location = new System.Drawing.Point(328, 60);
            this.rbtnHardAI.Name = "rbtnHardAI";
            this.rbtnHardAI.Size = new System.Drawing.Size(97, 21);
            this.rbtnHardAI.TabIndex = 3;
            this.rbtnHardAI.TabStop = true;
            this.rbtnHardAI.Text = "Challenging";
            this.rbtnHardAI.UseVisualStyleBackColor = true;
            // 
            // lblComputerAI
            // 
            this.lblComputerAI.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblComputerAI.AutoSize = true;
            this.lblComputerAI.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComputerAI.Location = new System.Drawing.Point(153, 19);
            this.lblComputerAI.Name = "lblComputerAI";
            this.lblComputerAI.Size = new System.Drawing.Size(149, 17);
            this.lblComputerAI.TabIndex = 4;
            this.lblComputerAI.Text = "Choose your difficulty!";
            // 
            // Difficulty
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lblComputerAI);
            this.Controls.Add(this.rbtnHardAI);
            this.Controls.Add(this.rbtnMediumAI);
            this.Controls.Add(this.rbtnBasicAI);
            this.Controls.Add(this.btnSetAI);
            this.Name = "Difficulty";
            this.Size = new System.Drawing.Size(450, 150);
            this.Load += new System.EventHandler(this.Difficulty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetAI;
        private System.Windows.Forms.RadioButton rbtnBasicAI;
        private System.Windows.Forms.RadioButton rbtnMediumAI;
        private System.Windows.Forms.RadioButton rbtnHardAI;
        private System.Windows.Forms.Label lblComputerAI;
    }
}
