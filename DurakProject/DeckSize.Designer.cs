namespace DurakProject
{
    partial class frmDeckSize
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
            this.rbtnTenToAce = new System.Windows.Forms.RadioButton();
            this.rbtnSixToAce = new System.Windows.Forms.RadioButton();
            this.rbtnStandardDeck = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblDeckSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbtnTenToAce
            // 
            this.rbtnTenToAce.AutoSize = true;
            this.rbtnTenToAce.Location = new System.Drawing.Point(62, 52);
            this.rbtnTenToAce.Name = "rbtnTenToAce";
            this.rbtnTenToAce.Size = new System.Drawing.Size(67, 17);
            this.rbtnTenToAce.TabIndex = 0;
            this.rbtnTenToAce.TabStop = true;
            this.rbtnTenToAce.Text = "20 Cards";
            this.rbtnTenToAce.UseVisualStyleBackColor = true;
            // 
            // rbtnSixToAce
            // 
            this.rbtnSixToAce.AutoSize = true;
            this.rbtnSixToAce.Location = new System.Drawing.Point(62, 76);
            this.rbtnSixToAce.Name = "rbtnSixToAce";
            this.rbtnSixToAce.Size = new System.Drawing.Size(67, 17);
            this.rbtnSixToAce.TabIndex = 1;
            this.rbtnSixToAce.TabStop = true;
            this.rbtnSixToAce.Text = "36 Cards";
            this.rbtnSixToAce.UseVisualStyleBackColor = true;
            // 
            // rbtnStandardDeck
            // 
            this.rbtnStandardDeck.AutoSize = true;
            this.rbtnStandardDeck.Location = new System.Drawing.Point(62, 100);
            this.rbtnStandardDeck.Name = "rbtnStandardDeck";
            this.rbtnStandardDeck.Size = new System.Drawing.Size(67, 17);
            this.rbtnStandardDeck.TabIndex = 2;
            this.rbtnStandardDeck.TabStop = true;
            this.rbtnStandardDeck.Text = "52 Cards";
            this.rbtnStandardDeck.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(58, 137);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblDeckSize
            // 
            this.lblDeckSize.AutoSize = true;
            this.lblDeckSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeckSize.Location = new System.Drawing.Point(28, 21);
            this.lblDeckSize.Name = "lblDeckSize";
            this.lblDeckSize.Size = new System.Drawing.Size(136, 16);
            this.lblDeckSize.TabIndex = 4;
            this.lblDeckSize.Text = "Size of the Card Deck";
            // 
            // frmDeckSize
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 179);
            this.ControlBox = false;
            this.Controls.Add(this.lblDeckSize);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rbtnStandardDeck);
            this.Controls.Add(this.rbtnSixToAce);
            this.Controls.Add(this.rbtnTenToAce);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDeckSize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Difficulty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnTenToAce;
        private System.Windows.Forms.RadioButton rbtnSixToAce;
        private System.Windows.Forms.RadioButton rbtnStandardDeck;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblDeckSize;
    }
}