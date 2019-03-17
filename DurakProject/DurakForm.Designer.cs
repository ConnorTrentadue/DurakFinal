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
            this.grpbComputerPlayer = new System.Windows.Forms.GroupBox();
            this.grpbHumanPlayer = new System.Windows.Forms.GroupBox();
            this.grpbPlayArea = new System.Windows.Forms.GroupBox();
            this.pbTrumpIndicator = new System.Windows.Forms.PictureBox();
            this.grpbDeck = new System.Windows.Forms.GroupBox();
            this.grpbTrumpCard = new System.Windows.Forms.GroupBox();
            this.grpbDiscard = new System.Windows.Forms.GroupBox();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnForfeit = new System.Windows.Forms.Button();
            this.lblGameNumber = new System.Windows.Forms.Label();
            this.lblRoundNumber = new System.Windows.Forms.Label();
            this.lblWins = new System.Windows.Forms.Label();
            this.lblTies = new System.Windows.Forms.Label();
            this.lblCardsRemaining = new System.Windows.Forms.Label();
            this.lblLosses = new System.Windows.Forms.Label();
            this.grpbPlayArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrumpIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // grpbComputerPlayer
            // 
            this.grpbComputerPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbComputerPlayer.BackColor = System.Drawing.Color.Transparent;
            this.grpbComputerPlayer.Location = new System.Drawing.Point(217, 12);
            this.grpbComputerPlayer.Name = "grpbComputerPlayer";
            this.grpbComputerPlayer.Size = new System.Drawing.Size(654, 100);
            this.grpbComputerPlayer.TabIndex = 0;
            this.grpbComputerPlayer.TabStop = false;
            this.grpbComputerPlayer.Text = "Attacker";
            // 
            // grpbHumanPlayer
            // 
            this.grpbHumanPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbHumanPlayer.BackColor = System.Drawing.Color.Transparent;
            this.grpbHumanPlayer.Location = new System.Drawing.Point(217, 494);
            this.grpbHumanPlayer.Name = "grpbHumanPlayer";
            this.grpbHumanPlayer.Size = new System.Drawing.Size(654, 100);
            this.grpbHumanPlayer.TabIndex = 1;
            this.grpbHumanPlayer.TabStop = false;
            this.grpbHumanPlayer.Text = "Defender";
            // 
            // grpbPlayArea
            // 
            this.grpbPlayArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbPlayArea.BackColor = System.Drawing.Color.Transparent;
            this.grpbPlayArea.Controls.Add(this.pbTrumpIndicator);
            this.grpbPlayArea.Location = new System.Drawing.Point(218, 118);
            this.grpbPlayArea.Name = "grpbPlayArea";
            this.grpbPlayArea.Size = new System.Drawing.Size(654, 370);
            this.grpbPlayArea.TabIndex = 2;
            this.grpbPlayArea.TabStop = false;
            // 
            // pbTrumpIndicator
            // 
            this.pbTrumpIndicator.Location = new System.Drawing.Point(6, 19);
            this.pbTrumpIndicator.Name = "pbTrumpIndicator";
            this.pbTrumpIndicator.Size = new System.Drawing.Size(36, 33);
            this.pbTrumpIndicator.TabIndex = 0;
            this.pbTrumpIndicator.TabStop = false;
            // 
            // grpbDeck
            // 
            this.grpbDeck.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbDeck.BackColor = System.Drawing.Color.Transparent;
            this.grpbDeck.Location = new System.Drawing.Point(891, 247);
            this.grpbDeck.Name = "grpbDeck";
            this.grpbDeck.Size = new System.Drawing.Size(76, 100);
            this.grpbDeck.TabIndex = 3;
            this.grpbDeck.TabStop = false;
            // 
            // grpbTrumpCard
            // 
            this.grpbTrumpCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbTrumpCard.BackColor = System.Drawing.Color.Transparent;
            this.grpbTrumpCard.Location = new System.Drawing.Point(973, 247);
            this.grpbTrumpCard.Name = "grpbTrumpCard";
            this.grpbTrumpCard.Size = new System.Drawing.Size(76, 100);
            this.grpbTrumpCard.TabIndex = 4;
            this.grpbTrumpCard.TabStop = false;
            // 
            // grpbDiscard
            // 
            this.grpbDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbDiscard.BackColor = System.Drawing.Color.Transparent;
            this.grpbDiscard.Location = new System.Drawing.Point(120, 247);
            this.grpbDiscard.Name = "grpbDiscard";
            this.grpbDiscard.Size = new System.Drawing.Size(76, 100);
            this.grpbDiscard.TabIndex = 5;
            this.grpbDiscard.TabStop = false;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewGame.Location = new System.Drawing.Point(909, 12);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 6;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
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
            this.lblGameNumber.Click += new System.EventHandler(this.lblGameNumber_Click);
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
            this.lblRoundNumber.Click += new System.EventHandler(this.lblRoundNumber_Click);
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
            this.lblWins.Click += new System.EventHandler(this.lblWins_Click);
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
            this.lblTies.Click += new System.EventHandler(this.lblTies_Click);
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
            this.lblLosses.Click += new System.EventHandler(this.lblLosses_Click);
            // 
            // frmDurak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1091, 606);
            this.Controls.Add(this.lblLosses);
            this.Controls.Add(this.lblCardsRemaining);
            this.Controls.Add(this.lblTies);
            this.Controls.Add(this.lblWins);
            this.Controls.Add(this.lblRoundNumber);
            this.Controls.Add(this.lblGameNumber);
            this.Controls.Add(this.btnForfeit);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.grpbDiscard);
            this.Controls.Add(this.grpbTrumpCard);
            this.Controls.Add(this.grpbDeck);
            this.Controls.Add(this.grpbPlayArea);
            this.Controls.Add(this.grpbHumanPlayer);
            this.Controls.Add(this.grpbComputerPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDurak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak Game";
            this.Load += new System.EventHandler(this.frmDurak_Load);
            this.grpbPlayArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTrumpIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbComputerPlayer;
        private System.Windows.Forms.GroupBox grpbHumanPlayer;
        private System.Windows.Forms.GroupBox grpbPlayArea;
        private System.Windows.Forms.PictureBox pbTrumpIndicator;
        private System.Windows.Forms.GroupBox grpbDeck;
        private System.Windows.Forms.GroupBox grpbTrumpCard;
        private System.Windows.Forms.GroupBox grpbDiscard;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnForfeit;
        private System.Windows.Forms.Label lblGameNumber;
        private System.Windows.Forms.Label lblRoundNumber;
        private System.Windows.Forms.Label lblWins;
        private System.Windows.Forms.Label lblTies;
        private System.Windows.Forms.Label lblCardsRemaining;
        private System.Windows.Forms.Label lblLosses;
    }
}

