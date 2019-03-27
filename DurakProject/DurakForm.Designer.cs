namespace DurakProject
{
    partial class frmDurak
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDurak));
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnForfeit = new System.Windows.Forms.Button();
            this.lblGameNumber = new System.Windows.Forms.Label();
            this.lblRoundNumber = new System.Windows.Forms.Label();
            this.lblWins = new System.Windows.Forms.Label();
            this.lblTies = new System.Windows.Forms.Label();
            this.lblCardsRemaining = new System.Windows.Forms.Label();
            this.lblLosses = new System.Windows.Forms.Label();
            this.pnlPlayerHand = new System.Windows.Forms.Panel();
            this.pnlComputerHand = new System.Windows.Forms.Panel();
            this.pnlDiscard = new System.Windows.Forms.Panel();
            this.pbTrumpIndicator = new System.Windows.Forms.PictureBox();
            this.pnlPlayArea = new System.Windows.Forms.Panel();
            this.pbDeck = new System.Windows.Forms.PictureBox();
            this.pnlTrumpCard = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrumpIndicator)).BeginInit();
            this.pnlPlayArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewGame
            // 
            this.btnNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewGame.Location = new System.Drawing.Point(910, 12);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 6;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnForfeit
            // 
            this.btnForfeit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForfeit.Location = new System.Drawing.Point(1004, 12);
            this.btnForfeit.Name = "btnForfeit";
            this.btnForfeit.Size = new System.Drawing.Size(75, 23);
            this.btnForfeit.TabIndex = 7;
            this.btnForfeit.Text = "Forfeit";
            this.btnForfeit.UseVisualStyleBackColor = true;
            this.btnForfeit.Click += new System.EventHandler(this.btnForfeit_Click);
            // 
            // lblGameNumber
            // 
            this.lblGameNumber.AutoSize = true;
            this.lblGameNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblGameNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblGameNumber.Location = new System.Drawing.Point(12, 509);
            this.lblGameNumber.Name = "lblGameNumber";
            this.lblGameNumber.Size = new System.Drawing.Size(48, 13);
            this.lblGameNumber.TabIndex = 8;
            this.lblGameNumber.Text = "Game #:";
            // 
            // lblRoundNumber
            // 
            this.lblRoundNumber.AutoSize = true;
            this.lblRoundNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblRoundNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRoundNumber.Location = new System.Drawing.Point(12, 526);
            this.lblRoundNumber.Name = "lblRoundNumber";
            this.lblRoundNumber.Size = new System.Drawing.Size(52, 13);
            this.lblRoundNumber.TabIndex = 9;
            this.lblRoundNumber.Text = "Round #:";
            // 
            // lblWins
            // 
            this.lblWins.AutoSize = true;
            this.lblWins.BackColor = System.Drawing.Color.Transparent;
            this.lblWins.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblWins.Location = new System.Drawing.Point(12, 543);
            this.lblWins.Name = "lblWins";
            this.lblWins.Size = new System.Drawing.Size(34, 13);
            this.lblWins.TabIndex = 10;
            this.lblWins.Text = "Wins:";
            // 
            // lblTies
            // 
            this.lblTies.AutoSize = true;
            this.lblTies.BackColor = System.Drawing.Color.Transparent;
            this.lblTies.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTies.Location = new System.Drawing.Point(12, 560);
            this.lblTies.Name = "lblTies";
            this.lblTies.Size = new System.Drawing.Size(30, 13);
            this.lblTies.TabIndex = 11;
            this.lblTies.Text = "Ties:";
            // 
            // lblCardsRemaining
            // 
            this.lblCardsRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblCardsRemaining.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCardsRemaining.Location = new System.Drawing.Point(891, 350);
            this.lblCardsRemaining.Name = "lblCardsRemaining";
            this.lblCardsRemaining.Size = new System.Drawing.Size(76, 21);
            this.lblCardsRemaining.TabIndex = 12;
            this.lblCardsRemaining.Text = "Remaining: 0";
            this.lblCardsRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLosses
            // 
            this.lblLosses.AutoSize = true;
            this.lblLosses.BackColor = System.Drawing.Color.Transparent;
            this.lblLosses.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLosses.Location = new System.Drawing.Point(12, 576);
            this.lblLosses.Name = "lblLosses";
            this.lblLosses.Size = new System.Drawing.Size(43, 13);
            this.lblLosses.TabIndex = 13;
            this.lblLosses.Text = "Losses:";
            // 
            // pnlPlayerHand
            // 
            this.pnlPlayerHand.BackColor = System.Drawing.Color.Transparent;
            this.pnlPlayerHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlayerHand.Location = new System.Drawing.Point(218, 490);
            this.pnlPlayerHand.Name = "pnlPlayerHand";
            this.pnlPlayerHand.Size = new System.Drawing.Size(654, 112);
            this.pnlPlayerHand.TabIndex = 14;
            // 
            // pnlComputerHand
            // 
            this.pnlComputerHand.BackColor = System.Drawing.Color.Transparent;
            this.pnlComputerHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlComputerHand.Location = new System.Drawing.Point(218, 4);
            this.pnlComputerHand.Name = "pnlComputerHand";
            this.pnlComputerHand.Size = new System.Drawing.Size(654, 112);
            this.pnlComputerHand.TabIndex = 15;
            // 
            // pnlDiscard
            // 
            this.pnlDiscard.BackColor = System.Drawing.Color.Transparent;
            this.pnlDiscard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDiscard.Location = new System.Drawing.Point(116, 247);
            this.pnlDiscard.Name = "pnlDiscard";
            this.pnlDiscard.Size = new System.Drawing.Size(75, 108);
            this.pnlDiscard.TabIndex = 16;
            // 
            // pbTrumpIndicator
            // 
            this.pbTrumpIndicator.BackColor = System.Drawing.Color.Transparent;
            this.pbTrumpIndicator.Location = new System.Drawing.Point(3, 3);
            this.pbTrumpIndicator.Name = "pbTrumpIndicator";
            this.pbTrumpIndicator.Size = new System.Drawing.Size(36, 36);
            this.pbTrumpIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTrumpIndicator.TabIndex = 0;
            this.pbTrumpIndicator.TabStop = false;
            // 
            // pnlPlayArea
            // 
            this.pnlPlayArea.BackColor = System.Drawing.Color.Transparent;
            this.pnlPlayArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlayArea.Controls.Add(this.pbTrumpIndicator);
            this.pnlPlayArea.Location = new System.Drawing.Point(219, 118);
            this.pnlPlayArea.Name = "pnlPlayArea";
            this.pnlPlayArea.Size = new System.Drawing.Size(652, 368);
            this.pnlPlayArea.TabIndex = 19;
            // 
            // pbDeck
            // 
            this.pbDeck.BackColor = System.Drawing.Color.Transparent;
            this.pbDeck.Location = new System.Drawing.Point(894, 247);
            this.pbDeck.Name = "pbDeck";
            this.pbDeck.Size = new System.Drawing.Size(75, 108);
            this.pbDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeck.TabIndex = 20;
            this.pbDeck.TabStop = false;
            // 
            // pnlTrumpCard
            // 
            this.pnlTrumpCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlTrumpCard.Location = new System.Drawing.Point(991, 247);
            this.pnlTrumpCard.Name = "pnlTrumpCard";
            this.pnlTrumpCard.Size = new System.Drawing.Size(75, 108);
            this.pnlTrumpCard.TabIndex = 21;
            // 
            // frmDurak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(47)))), ((int)(((byte)(33)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1091, 606);
            this.Controls.Add(this.pnlTrumpCard);
            this.Controls.Add(this.pbDeck);
            this.Controls.Add(this.pnlPlayArea);
            this.Controls.Add(this.pnlDiscard);
            this.Controls.Add(this.pnlComputerHand);
            this.Controls.Add(this.pnlPlayerHand);
            this.Controls.Add(this.lblLosses);
            this.Controls.Add(this.lblCardsRemaining);
            this.Controls.Add(this.lblTies);
            this.Controls.Add(this.lblWins);
            this.Controls.Add(this.lblRoundNumber);
            this.Controls.Add(this.lblGameNumber);
            this.Controls.Add(this.btnForfeit);
            this.Controls.Add(this.btnNewGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDurak";
            this.Text = "Durak Game";
            this.Load += new System.EventHandler(this.frmDurak_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTrumpIndicator)).EndInit();
            this.pnlPlayArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnForfeit;
        private System.Windows.Forms.Label lblGameNumber;
        private System.Windows.Forms.Label lblRoundNumber;
        private System.Windows.Forms.Label lblWins;
        private System.Windows.Forms.Label lblTies;
        private System.Windows.Forms.Label lblCardsRemaining;
        private System.Windows.Forms.Label lblLosses;
        private System.Windows.Forms.Panel pnlPlayerHand;
        private System.Windows.Forms.Panel pnlComputerHand;
        private System.Windows.Forms.Panel pnlDiscard;
        private System.Windows.Forms.PictureBox pbTrumpIndicator;
        private System.Windows.Forms.Panel pnlPlayArea;
        private System.Windows.Forms.PictureBox pbDeck;
        private System.Windows.Forms.Panel pnlTrumpCard;
    }
}

