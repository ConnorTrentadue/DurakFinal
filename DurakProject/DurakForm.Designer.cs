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
            this.lblAIName = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.btnEndAttack = new System.Windows.Forms.Button();
            this.btnPickUp = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuForfeit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDiscard = new System.Windows.Forms.Label();
            this.lblTrumpIndicator = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrumpIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewGame
            // 
            this.btnNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewGame.Location = new System.Drawing.Point(923, 610);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 6;
            this.btnNewGame.Text = "&New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnForfeit
            // 
            this.btnForfeit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForfeit.Location = new System.Drawing.Point(1004, 610);
            this.btnForfeit.Name = "btnForfeit";
            this.btnForfeit.Size = new System.Drawing.Size(75, 23);
            this.btnForfeit.TabIndex = 7;
            this.btnForfeit.Text = "&Forfeit";
            this.btnForfeit.UseVisualStyleBackColor = true;
            this.btnForfeit.Click += new System.EventHandler(this.btnForfeit_Click);
            // 
            // lblGameNumber
            // 
            this.lblGameNumber.AutoSize = true;
            this.lblGameNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblGameNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblGameNumber.Location = new System.Drawing.Point(12, 40);
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
            this.lblRoundNumber.Location = new System.Drawing.Point(12, 57);
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
            this.lblWins.Location = new System.Drawing.Point(12, 74);
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
            this.lblTies.Location = new System.Drawing.Point(12, 91);
            this.lblTies.Name = "lblTies";
            this.lblTies.Size = new System.Drawing.Size(30, 13);
            this.lblTies.TabIndex = 11;
            this.lblTies.Text = "Ties:";
            // 
            // lblCardsRemaining
            // 
            this.lblCardsRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblCardsRemaining.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCardsRemaining.Location = new System.Drawing.Point(894, 385);
            this.lblCardsRemaining.Name = "lblCardsRemaining";
            this.lblCardsRemaining.Size = new System.Drawing.Size(76, 21);
            this.lblCardsRemaining.TabIndex = 12;
            this.lblCardsRemaining.Text = "Remaining: ";
            this.lblCardsRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLosses
            // 
            this.lblLosses.AutoSize = true;
            this.lblLosses.BackColor = System.Drawing.Color.Transparent;
            this.lblLosses.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLosses.Location = new System.Drawing.Point(12, 107);
            this.lblLosses.Name = "lblLosses";
            this.lblLosses.Size = new System.Drawing.Size(43, 13);
            this.lblLosses.TabIndex = 13;
            this.lblLosses.Text = "Losses:";
            // 
            // pnlPlayerHand
            // 
            this.pnlPlayerHand.BackColor = System.Drawing.Color.Transparent;
            this.pnlPlayerHand.Location = new System.Drawing.Point(218, 523);
            this.pnlPlayerHand.Name = "pnlPlayerHand";
            this.pnlPlayerHand.Size = new System.Drawing.Size(654, 110);
            this.pnlPlayerHand.TabIndex = 14;
            // 
            // pnlComputerHand
            // 
            this.pnlComputerHand.BackColor = System.Drawing.Color.Transparent;
            this.pnlComputerHand.Location = new System.Drawing.Point(218, 37);
            this.pnlComputerHand.Name = "pnlComputerHand";
            this.pnlComputerHand.Size = new System.Drawing.Size(654, 110);
            this.pnlComputerHand.TabIndex = 15;
            // 
            // pnlDiscard
            // 
            this.pnlDiscard.BackColor = System.Drawing.Color.Transparent;
            this.pnlDiscard.Location = new System.Drawing.Point(116, 278);
            this.pnlDiscard.Name = "pnlDiscard";
            this.pnlDiscard.Size = new System.Drawing.Size(75, 108);
            this.pnlDiscard.TabIndex = 16;
            // 
            // pbTrumpIndicator
            // 
            this.pbTrumpIndicator.BackColor = System.Drawing.Color.Transparent;
            this.pbTrumpIndicator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbTrumpIndicator.Location = new System.Drawing.Point(137, 151);
            this.pbTrumpIndicator.Name = "pbTrumpIndicator";
            this.pbTrumpIndicator.Size = new System.Drawing.Size(36, 36);
            this.pbTrumpIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTrumpIndicator.TabIndex = 0;
            this.pbTrumpIndicator.TabStop = false;
            // 
            // pnlPlayArea
            // 
            this.pnlPlayArea.BackColor = System.Drawing.Color.Transparent;
            this.pnlPlayArea.Location = new System.Drawing.Point(219, 151);
            this.pnlPlayArea.Name = "pnlPlayArea";
            this.pnlPlayArea.Size = new System.Drawing.Size(652, 368);
            this.pnlPlayArea.TabIndex = 19;
            // 
            // pbDeck
            // 
            this.pbDeck.BackColor = System.Drawing.Color.Transparent;
            this.pbDeck.Location = new System.Drawing.Point(894, 278);
            this.pbDeck.Name = "pbDeck";
            this.pbDeck.Size = new System.Drawing.Size(75, 108);
            this.pbDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeck.TabIndex = 20;
            this.pbDeck.TabStop = false;
            // 
            // pnlTrumpCard
            // 
            this.pnlTrumpCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlTrumpCard.Location = new System.Drawing.Point(991, 278);
            this.pnlTrumpCard.Name = "pnlTrumpCard";
            this.pnlTrumpCard.Size = new System.Drawing.Size(75, 108);
            this.pnlTrumpCard.TabIndex = 21;
            // 
            // lblAIName
            // 
            this.lblAIName.AutoSize = true;
            this.lblAIName.BackColor = System.Drawing.Color.Transparent;
            this.lblAIName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAIName.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAIName.Location = new System.Drawing.Point(878, 81);
            this.lblAIName.Name = "lblAIName";
            this.lblAIName.Size = new System.Drawing.Size(0, 24);
            this.lblAIName.TabIndex = 22;
            this.lblAIName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPlayerName.Location = new System.Drawing.Point(112, 574);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(0, 24);
            this.lblPlayerName.TabIndex = 23;
            this.lblPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEndAttack
            // 
            this.btnEndAttack.Location = new System.Drawing.Point(137, 610);
            this.btnEndAttack.Name = "btnEndAttack";
            this.btnEndAttack.Size = new System.Drawing.Size(75, 23);
            this.btnEndAttack.TabIndex = 24;
            this.btnEndAttack.Text = "End Attack";
            this.btnEndAttack.UseVisualStyleBackColor = true;
            this.btnEndAttack.Click += new System.EventHandler(this.btnEndAttack_Click);
            // 
            // btnPickUp
            // 
            this.btnPickUp.Location = new System.Drawing.Point(59, 610);
            this.btnPickUp.Name = "btnPickUp";
            this.btnPickUp.Size = new System.Drawing.Size(75, 23);
            this.btnPickUp.TabIndex = 25;
            this.btnPickUp.Text = "Pick Up";
            this.btnPickUp.UseVisualStyleBackColor = true;
            this.btnPickUp.Click += new System.EventHandler(this.btnPickUp_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuLog,
            this.mnuAbout,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1091, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewGame,
            this.mnuForfeit,
            this.mnuClose});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuNewGame
            // 
            this.mnuNewGame.Name = "mnuNewGame";
            this.mnuNewGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.mnuNewGame.Size = new System.Drawing.Size(171, 22);
            this.mnuNewGame.Text = "New Game";
            this.mnuNewGame.Click += new System.EventHandler(this.mnuNewGame_Click);
            // 
            // mnuForfeit
            // 
            this.mnuForfeit.Name = "mnuForfeit";
            this.mnuForfeit.Size = new System.Drawing.Size(171, 22);
            this.mnuForfeit.Text = "Forfeit";
            this.mnuForfeit.Click += new System.EventHandler(this.mnuForfeit_Click);
            // 
            // mnuClose
            // 
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.mnuClose.Size = new System.Drawing.Size(171, 22);
            this.mnuClose.Text = "&Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // mnuLog
            // 
            this.mnuLog.Name = "mnuLog";
            this.mnuLog.Size = new System.Drawing.Size(39, 20);
            this.mnuLog.Text = "Log";
            this.mnuLog.Click += new System.EventHandler(this.mnuLog_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(52, 20);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // lblDiscard
            // 
            this.lblDiscard.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscard.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDiscard.Location = new System.Drawing.Point(115, 387);
            this.lblDiscard.Name = "lblDiscard";
            this.lblDiscard.Size = new System.Drawing.Size(76, 21);
            this.lblDiscard.TabIndex = 27;
            this.lblDiscard.Text = "Discarded:";
            this.lblDiscard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrumpIndicator
            // 
            this.lblTrumpIndicator.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTrumpIndicator.BackColor = System.Drawing.Color.Transparent;
            this.lblTrumpIndicator.ForeColor = System.Drawing.Color.White;
            this.lblTrumpIndicator.Location = new System.Drawing.Point(119, 189);
            this.lblTrumpIndicator.Name = "lblTrumpIndicator";
            this.lblTrumpIndicator.Size = new System.Drawing.Size(73, 23);
            this.lblTrumpIndicator.TabIndex = 28;
            this.lblTrumpIndicator.Text = "Trump";
            this.lblTrumpIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTrumpIndicator.Visible = false;
            // 
            // frmDurak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(47)))), ((int)(((byte)(33)))));
            this.BackgroundImage = global::DurakProject.Properties.Resources.WoodTexture1024;
            this.ClientSize = new System.Drawing.Size(1091, 636);
            this.Controls.Add(this.lblTrumpIndicator);
            this.Controls.Add(this.lblDiscard);
            this.Controls.Add(this.pbTrumpIndicator);
            this.Controls.Add(this.btnPickUp);
            this.Controls.Add(this.btnEndAttack);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.lblAIName);
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
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDurak";
            this.Text = "Durak Game";
            this.Load += new System.EventHandler(this.frmDurak_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTrumpIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Label lblAIName;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Button btnEndAttack;
        private System.Windows.Forms.Button btnPickUp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuNewGame;
        private System.Windows.Forms.ToolStripMenuItem mnuForfeit;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.ToolStripMenuItem mnuLog;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.Label lblDiscard;
        private System.Windows.Forms.Label lblTrumpIndicator;
    }
}

