/*
 * DurakForm.cs - The Main application form for playing Durak.
 * 
 * Author: Shaun McCrum, Raymond Michael
 * Since: 22 Mar 2019
 * 
 */

/** ATTRIBUTION
 * Wood table image for form design crated by Pixaby 20 Feb of an unknown year.
 * Images release under the Creative Commons CC0 License.
 * Downloaded from https://www.pexels.com/photo/close-up-of-wooden-plank-326311/.  
 * 
 * 
 * 
 **/

using System;
using DurakClassLibrary;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using StatsLibrary;

namespace DurakProject
{
    public partial class frmDurak : Form
    {
        #region FIELDS AND PROPERTIES
        /// <summary>
        /// The amount, in points, that CardBox controls are enlarged when hovered over. 
        /// </summary>
        private const int POP = 0;

        //Tracks how many times a player has "attacked"
        int playerAttackCounter = 0;

        //Seeding random number generator
        static Random randomNumber = new Random();

        int difficultyChoice = 1; //Stores difficulty that player chooses and determines the AI's moves. (1, 2, or 3)

        //Declares new computer player
        ComputerPlayer newAI;

        //Declares new human player
        Player newPlayer;

        // create a default durak Deck
        Deck durakDeck;

        // create reference to the log form
        frmLog frmLog;

        // create PlayerStats object
        PlayerStats playerStats;

        //Computer names array
        string[] computerNames = new string[]
        {"Salvatore", "Leigh", "Wilmer", "Max",
         "Fredric", "Clifford", "Isiah", "Lucio",
         "Jess", "Leonard", "Marth", "Reginia",
         "Sharri", "Madonna", "Wilhemina", "Jennie",
         "Joanne", "Hermila", "Violette", "Trina",
         "Ray", "Shaun"};

        string playerName = "THE MAN";

        // sets a defautl state for if a player is attacking or defending.
        bool playerAttack = false;

        //declare a trumpSuit  to hold trump suit values
        Suit trumpSuit = Suit.Clubs;
        // declare a cardRank  to hold card rank values
        Rank cardRank = Rank.Ace;

        //declare a cardSuit to hold card suit values
        Suit cardSuit = Suit.Clubs;

        static private Size regularSize = new Size(75, 108);
        #endregion

        #region FORM EVENTS AND HANDLERS
        public frmDurak()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Default form load
        /// </summary>
        private void frmDurak_Load(object sender, EventArgs e)
        {
            // initialize form log ( change to whatever button we want to make the log come from )
            frmLog = new frmLog();
            frmLog.Show();
        }

        /// <summary>
        /// New game clears out previous game session.  Creates a new deck and deals 6 cards to each player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            //prompt the user for their name
            //if name exists in the log-file
            //pull statistics from statistics log file.
            //else store their name and continue 

            //enable buttons if they were not visible
            btnForfeit.Visible = true;

            // Writes to the log screen, which writes to the text file when the form is closed
            frmLog.WriteToLog("New Game started");
            playerStats = Stats.ReadStats();

            // Example to get stats
            //playerStats.gamesPlayed++;
            lblGameNumber.Text += playerStats.gamesPlayed;

            //clear any objects on the table.
            pnlComputerHand.Controls.Clear();
            pnlPlayerHand.Controls.Clear();
            pnlTrumpCard.Controls.Clear();
            pnlPlayArea.Controls.Clear();
            pnlDiscard.Controls.Clear();

            //ranomdizer for first player selection
            int someNumber = randomNumber.Next(1, 20);

            //MessageBox.Show(someNumber.ToString());

            //Instantiate new computer player based on selected difficulty (w/ random name)
            newAI = new ComputerPlayer(computerNames[someNumber], difficultyChoice);
            newPlayer = new Player(playerName); //playerName is a test name. We need to add a form that pops up at 
                                                //newgame click that prompts for player name and then stores the entered value
                                                //At this point we also need to add a form pop-up that prompts for difficulty
            lblAIName.Text = newAI.Name;
            lblPlayerName.Text = newPlayer.Name;

            // create a new deck
            durakDeck = new Deck();
            Card card = new Card();
            //MessageBox.Show(durakDeck.CardsRemaining.ToString());

            // shuffle the new deck.
            durakDeck.Shuffle();
            //MessageBox.Show(durakDeck.CardsRemaining.ToString());

            // Set the deck image to a card back image
            pbDeck.Visible = true;
            pbDeck.Image = durakDeck.GetCard(0).GetCardImage();

            // Show the number of cards in the deck
            lblCardsRemaining.Text = durakDeck.CardsRemaining.ToString();

            //deal 12 cards, (6 each) to the players.
            //alternate the cards into each player's hand
            for (int i = 1; i <= 12 /* * playerCount */; i++)
            {
                card = durakDeck.DrawCard();

                if (i % 2 == 0)
                {
                    card.FaceUp = true;
                    CardBox playerCardBox = new CardBox(card);
                    //wire the click event to the cardbox
                    AddClickEvent(playerCardBox);
                    pnlPlayerHand.Controls.Add(playerCardBox);
                }
                else
                {
                    card.FaceUp = true;  //uncomment this to enable AI cards faceUp
                    CardBox computerCardBox = new CardBox(card);
                    pnlComputerHand.Controls.Add(computerCardBox);
                }
            }

            //realign both player and commputer hand
            RealignCards(pnlPlayerHand);
            RealignCards(pnlComputerHand);

            // set the trump suit for this game.
            Card trumpCard = durakDeck.DrawCard();
            CardBox aTrumpCardbox = new CardBox(trumpCard);

            //draw the card to the trump panel face up
            trumpCard.FaceUp = true;
            pnlTrumpCard.Controls.Add(aTrumpCardbox);
            //MessageBox.Show(trumpCard.ToString());
            trumpSuit = trumpCard.Suit;

            // Display remaining cards after the deal
            lblCardsRemaining.Text = durakDeck.CardsRemaining.ToString();

            // ******* Begin game-play flow. *********
            // Begin Attack or Phase based on random determination
            int whoGoesFirst = randomNumber.Next(1, 10);
            if (whoGoesFirst % 2 == 0)
                playerAttack = true; // player goes first
            else
                playerAttack = false; // AI goes first
            if (playerAttack != true)  //if not true, AI attacks first.
            {
                ComputerAttack(playerAttackCounter);
            }
        }
        /// <summary>
        /// Forfet game clears out the game session, assumes a loss and logs statistics
        /// </summary>
        private void btnForfeit_Click(object sender, EventArgs e)
        {
            //close the progra.  REMOVE AFTER ADDING STATS TRACING FUNCTIONALITY
            // Closes log form and writes to file
            frmLog.Close();
            Stats.WriteStats(playerStats);

            this.Close();
        }

        /// <summary>
        /// Button to allow the pickup of cards when the player is defending
        /// </summary>
        private void btnPickUp_Click(object sender, EventArgs e)
        {
            // call pick up cards method
            for (int i = (pnlPlayArea.Controls.Count -1); i > -1; i--)
            {
                //RemoveClickEvent play area cards and give them to the player
                //MessageBox.Show(i.ToString());
                CardBox card = (CardBox)pnlPlayArea.Controls[i];
                pnlPlayArea.Controls.Remove(card);
                pnlPlayerHand.Controls.Add(card);
                RealignCards(pnlPlayerHand);
            }
            ComputerAttack(playerAttackCounter);
            
            
        }

        #endregion

        #region CARDBOX EVENT HANDLERS

        public void CardBox_Click(object sender, EventArgs e)
        {
            //convert the sender
            CardBox aCardBox = sender as CardBox;
            //MessageBox.Show(aCardBox.ToString() + " was clicked");
            bool validPlay = true;

            if (playerAttack != true) //player is defending
            {
                //remove card from player hand
                pnlPlayerHand.Controls.Remove(aCardBox);
                //add the card to the play area
                pnlPlayArea.Controls.Add(aCardBox);

                //MessageBox.Show("Card Added!");
                playerAttackCounter++;
                //MessageBox.Show("Attacker Counter +1!");

                //realign player hand
                RealignCards(pnlPlayerHand);
                //remove the click event from the card as it enters the playarea
                RemoveClickEvent(aCardBox);

                ComputerAttack(playerAttackCounter);
            }
            else //player is attacking
            {
                if (pnlPlayArea.Controls.Count == 0)
                {
                    //remove from player hand
                    pnlPlayerHand.Controls.Remove(aCardBox);
                    //add the card to the play area
                    //MessageBox.Show("Card Removed!");
                    pnlPlayArea.Controls.Add(aCardBox);

                    //MessageBox.Show("Card Added!");
                    playerAttackCounter++;
                    //MessageBox.Show("Attacker Counter +1!");

                    //realign player hand
                    RealignCards(pnlPlayerHand);
                    //remove the click event from the card as it enters the playarea
                    RemoveClickEvent(aCardBox);

                    MakeNormalPlay(aCardBox, playerAttackCounter);
                }
                else if (pnlPlayArea.Controls.Count > 0)
                {

                    for (int i = 0; i < pnlPlayArea.Controls.Count; i++)
                    {
                        CardBox validCardCheck = (CardBox)pnlPlayArea.Controls[i];
                        // check cards in the playarea for valid rank
                        if (aCardBox.Rank == validCardCheck.Rank)
                        {
                            //remove from player hand
                            pnlPlayerHand.Controls.Remove(aCardBox);
                            //add the card to the play area
                            //requires location mapping
                            //MessageBox.Show("Card Removed!");
                            pnlPlayArea.Controls.Add(aCardBox);

                            //MessageBox.Show("Card Added!");
                            playerAttackCounter++;
                            //MessageBox.Show("Attacker Counter +1!");

                            //realign player hand
                            RealignCards(pnlPlayerHand);
                            aCardBox.Click -= CardBox_Click;

                            //remove the click event from the card as it enters the playarea
                            RemoveClickEvent(aCardBox);

                            MakeNormalPlay(aCardBox, playerAttackCounter);

                            //exit the for loop
                            i += 111;
                        }
                        else
                        {
                            validPlay = false;

                        }
                    }

                }
                if (validPlay == false)
                {
                    validPlay = true;
                    // MessageBox.Show(aCardBox.ToString() + " is not a valid card");
                }
                if (pnlPlayerHand.Controls.Count == 0)
                {
                    RedrawCards(durakDeck, playerAttack);
                }
            }



        }

        /// <summary>
        /// Repositions the cards in a panel so that they are evenly distributed in the area available.
        /// </summary>
        /// <param name="panelHand"></param>
        private void RealignCards(Panel panelHand)
        {
            // Determine the number of cards/controls in the panel.
            int myCount = panelHand.Controls.Count;

            // If there are any cards in the panel
            if (myCount > 0)
            {
                // Determine how wide one card/control is.
                int cardWidth = panelHand.Controls[0].Width;

                // Determine where the left-hand edge of a card/control placed 
                // in the middle of the panel should be  
                int startPoint = (panelHand.Width - cardWidth) / 2;

                // An offset for the remaining cards
                int offset = 0;

                // If there are more than one cards/controls in the panel
                if (myCount > 1)
                {
                    // Determine what the offset should be for each card based on the 
                    // space available and the number of card/controls
                    offset = (panelHand.Width - cardWidth - 2 * POP) / (myCount - 1);

                    // If the offset is bigger than the card/control width, i.e. there is lots of room, 
                    // set the offset to the card width. The cards/controls will not overlap at all.
                    if (offset > cardWidth)
                        offset = cardWidth;

                    // Determine width of all the cards/controls 
                    int allCardsWidth = (myCount - 1) * offset + cardWidth;

                    // Set the start point to where the left-hand edge of the "first" card should be.
                    startPoint = (panelHand.Width - allCardsWidth) / 2;
                }

                // Aligning the cards: Note that I align them in reserve order from how they
                // are stored in the controls collection. This is so that cards on the left 
                // appear underneath cards to the right. This allows the user to see the rank
                // and suit more easily.

                // Align the "first" card (which is the last control in the collection)
                //panelHand.Controls[myCount - 1].Top = POP;
                System.Diagnostics.Debug.Write(panelHand.Controls[myCount - 1].Top.ToString() + "\n");
                panelHand.Controls[myCount - 1].Left = startPoint;

                // for each of the remaining controls, in reverse order.
                for (int index = myCount - 2; index >= 0; index--)
                {
                    // Align the current card
                    //panelHand.Controls[index].Top = POP;
                    panelHand.Controls[index].Left = panelHand.Controls[index + 1].Left + offset;
                }
            }
        }

        #endregion

        #region METHODS
        //starts a normal play where the player is attacking and AI is defending
        public void MakeNormalPlay(CardBox cardBox, int playCount, int duplicateCards = 0)
        {
            bool playMade = false;

            btnEndAttack.Visible = true;
            //AI attack logic
            //ComputerAttack(playMade);

            //apply logic to the card added to the table.
            ComputerDefend(cardBox, playMade);

        }

        // Method to unwire cardbox click events
        public void RemoveClickEvent(CardBox card)
        {
            //remove the event handler 
            card.Click -= CardBox_Click;
        }

        // Method to wire cardbox click events
        public void AddClickEvent(CardBox card)
        {
            //add the event handler 
            card.Click += CardBox_Click;
            //MessageBox.Show(card.ToString() + " enabled.");
        }

        // Method to handle End Attack button click
        private void btnEndAttack_Click(object sender, EventArgs e)
        {
            //send cards to discard pile
            for (int i = pnlPlayArea.Controls.Count - 1; i > -1; i--)
            {
                CardBox card = (CardBox)pnlPlayArea.Controls[i];
                pnlPlayArea.Controls.Remove(card);
                pnlDiscard.Controls.Add(card);
                pnlDiscard.Controls.SetChildIndex(card, 0);
                //MessageBox.Show(card.ToString() + " Added to the discard pile");
                RealignCards(pnlDiscard);
                RealignCards(pnlPlayerHand);
                RealignCards(pnlComputerHand);
            }

            int playCount = 0;
            //fill the player's hands with cards
            RedrawCards(durakDeck, playerAttack);
            // set player to defending
            playerAttack = false;
            // switch to computer attack
            ComputerAttack(playCount);

        }

        // logic for computer on attack, player on defense
        public void ComputerAttack(int playCount)
        {

            bool playMade = false;
            bool validPlay = false;

            btnEndAttack.Visible = false;
            // render player hand unclickable before attack cards are played
            //foreach (CardBox playerCard in (CardBox)pnlPlayerHand)
            for (int i = 0; i < pnlPlayerHand.Controls.Count; i++)
            {
                CardBox card = (CardBox)pnlPlayerHand.Controls[i];
                card.BorderStyle = BorderStyle.None;  //clear any border on cards in player hand.
                RemoveClickEvent(card);
            }
            // clear any borders from the playArea cards
            for (int i = 0; i < pnlPlayArea.Controls.Count; i++)
            {
                CardBox card = (CardBox)pnlPlayArea.Controls[i];
                card.BorderStyle = BorderStyle.None;
            }

            // if playarea is empty begin attack
            if (pnlPlayArea.Controls.Count <= 0)
            {
                //logic to add first card from computer hand (no attack logic applied)
                for (int i = 0; i < pnlComputerHand.Controls.Count; i++)
                {
                    //MessageBox.Show("index play " + i);
                    CardBox computerCard = (CardBox)pnlComputerHand.Controls[0];
                    if (pnlPlayArea.Controls.Count <= 0)
                    {
                        //flip the card as it is played
                        computerCard.FaceUp = true;
                        //play the card in the computer hand
                        pnlComputerHand.Controls.Remove(computerCard);
                        pnlPlayArea.Controls.Add(computerCard);
                        computerCard.BorderStyle = BorderStyle.Fixed3D;

                        //if no player cards can defend an attack
                        if (validPlayerDefense(computerCard) == false)
                        {
                            MessageBox.Show("You can not defend, take the card");
                            //for all cards on the table, pick them up
                            for (int j = pnlPlayArea.Controls.Count - 1; j > -1; j--)
                            {
                                //debugging for card indexes on table.
                                //MessageBox.Show(pnlPlayArea.Controls.Count + " cards on table.  Index is " + i);
                                CardBox card = (CardBox)pnlPlayArea.Controls[j];
                                // remove border from the card if it still has one.
                                card.BorderStyle = BorderStyle.None;
                                pnlPlayArea.Controls.Remove(card);
                                //flip the card before entering computer hand
                                //card.FaceUp = false;
                                pnlPlayerHand.Controls.Add(card);
                                RealignCards(pnlPlayerHand);
                                RealignCards(pnlPlayArea);
                                playerAttackCounter = 0;

                            }
                        }
                        else
                        {
                            //MessageBox.Show("You have " + pnlPlayerHand.Controls.Count + " cards, attempt a defense. ");
                            i += 100;
                        }

                    }
                    // flag that a play was made and realign cards
                    playMade = true;
                    RealignCards(pnlPlayArea);
                }
            }
            // if there are cards in the play area and cards remaining in the player hand
            else if (pnlComputerHand.Controls.Count > 0 && pnlPlayerHand.Controls.Count > 0)
            {

                //logic to add card from computer hand (no attack logic applied)
                for (int i = 0; i < pnlComputerHand.Controls.Count; i++)
                {
                    //MessageBox.Show("index ELSE play " + i);
                    //bool validPlay = false;
                    CardBox computerCard = (CardBox)pnlComputerHand.Controls[0];
                    CardBox validCardCheck = new CardBox();

                    //iterate through each card in the playArea
                    for (int playAreaIndex = 0; playAreaIndex < pnlPlayArea.Controls.Count; playAreaIndex++)
                    {
                        validCardCheck = (CardBox)pnlPlayArea.Controls[playAreaIndex];
                        //MessageBox.Show(computerCard.ToString() + " vs >> " + validCardCheck.ToString());

                        if (computerCard.Rank == validCardCheck.Rank)
                        {
                            //uncomment to show validation of playable card
                            //MessageBox.Show(computerCard.ToString() + " vs >> " + validCardCheck.ToString() + "\n" + computerCard.ToString() + " is playable");
                            validPlay = true;

                            //debug to display when each individual card is unplayable by the AI
                            if (validPlay == true)
                            {
                                computerCard.FaceUp = true; //set chosen card face up.
                                MessageBox.Show(computerCard.ToString() + " is playable");
                                i += 100; // end the examination loop
                                playAreaIndex += 100;
                                //remove from player hand
                                pnlComputerHand.Controls.Remove(computerCard);
                                computerCard.BorderStyle = BorderStyle.Fixed3D;
                                pnlPlayArea.Controls.Add(computerCard);

                                playerAttackCounter++;
                                //MessageBox.Show("Attacker Counter +1!");
                            }



                            //realign computer hand
                            RealignCards(pnlComputerHand);

                            //determine which player cards can be played to defend an attack
                            if (validPlayerDefense(computerCard) == false)
                            {
                                MessageBox.Show(pnlPlayArea.Controls.Count +
                                    " cards on table. \nYou can not mount a defense");
                                //for all cards on the table, pick them up
                                for (int k = (pnlPlayArea.Controls.Count - 1); k > -1; k--)
                                {
                                    CardBox card = (CardBox)pnlPlayArea.Controls[k];
                                    //debugging for card indexes on table.
                                    MessageBox.Show("Picking up " + card + " at index " + k);
                                    pnlPlayArea.Controls.Remove(card);
                                    //flip the card before entering computer hand
                                    //card.FaceUp = false;
                                    pnlPlayerHand.Controls.Add(card);
                                    RealignCards(pnlPlayerHand);
                                    RealignCards(pnlPlayArea);
                                    //ComputerAttack(playerAttackCounter);
                                }
                                i += 100; // end the examination loop
                                playAreaIndex += 100;
                                ComputerAttack(playerAttackCounter);
                            }
                            else
                            {
                                //validPlay = true;
                                i += 100;
                                MessageBox.Show("You have " + pnlPlayerHand.Controls.Count +
                                    " cards, attempt a defense. ");
                            }
                            //computerCard.BorderStyle = BorderStyle.None;
                        }
                    }

                }

                // The computer can not make another valid play
                if (validPlay == false)
                {
                    //validPlay = true;  //reset validPlay
                    MessageBox.Show("There are no valid plays for the Computer");
                    //i += 100;

                    //send cards to discard pile
                    for (int j = pnlPlayArea.Controls.Count - 1; j > -1; j--)
                    {
                        CardBox card = (CardBox)pnlPlayArea.Controls[j];
                        // remove border from the card if it still has one.
                        card.BorderStyle = BorderStyle.None;
                        pnlPlayArea.Controls.Remove(card);
                        pnlDiscard.Controls.Add(card);
                        pnlDiscard.Controls.SetChildIndex(card, 0);
                        //MessageBox.Show(card.ToString() + " Added to the discard pile");
                        RealignCards(pnlDiscard);
                        RealignCards(pnlPlayerHand);
                        RealignCards(pnlComputerHand);

                    }

                    RedrawCards(durakDeck, playerAttack); // draw cards to fill hand

                    playerAttack = true; //set player to attack phase
                    //render player hand to be clickable
                    for (int j = pnlPlayerHand.Controls.Count - 1; j > -1; j--)
                    {
                        CardBox card = (CardBox)pnlPlayerHand.Controls[j];
                        AddClickEvent(card);
                    }
                }
                // set boolean playMade successfully and realign the playArea
                playMade = true;
                RealignCards(pnlPlayArea);
            }

            // if the AI hand is empty, redraw and check for win
            if (pnlComputerHand.Controls.Count == 0)
            {
                RedrawCards(durakDeck, playerAttack);
                WinCheck(durakDeck);
            }

            // if the playerhand is empty, redraw and check for win
            if (pnlPlayerHand.Controls.Count == 0)
            {
                RedrawCards(durakDeck, playerAttack);
                WinCheck(durakDeck);
            }

        }

        //Method for Player on attack, computer on defense
        public void ComputerDefend(CardBox cardBox, bool playMade)
        {
            //logic to add a defend card from computer hand
            for (int i = 0; i < pnlComputerHand.Controls.Count; i++)
            {
                CardBox card = (CardBox)pnlComputerHand.Controls[i];
                if (card.Suit == cardBox.Suit || card.Suit == trumpSuit)
                {
                    //card.Rank > cardBox.Rank
                    if (card.Suit == trumpSuit)
                    {
                        if (cardBox.Suit == trumpSuit && card.Rank > cardBox.Rank)
                        {
                            pnlComputerHand.Controls.Remove(card);
                            //flip the card as it is played
                            card.FaceUp = true;
                            pnlPlayArea.Controls.Add(card);

                            // remove a click event from a card in the playArea
                            //RemoveEvent(card);
                            i += 100;
                            playMade = true;
                            RealignCards(pnlPlayArea);
                        }
                    }

                    else if (card.Suit == cardBox.Suit && card.Rank > cardBox.Rank)
                    {
                        pnlComputerHand.Controls.Remove(card);
                        //flip the card as it is played
                        card.FaceUp = true;
                        pnlPlayArea.Controls.Add(card);

                        // remove a click event from a card in the playArea
                        //RemoveEvent(card);
                        i += 100;
                        playMade = true;
                        RealignCards(pnlPlayArea);
                    }
                }
            }

            // check for attack end.
            if (playMade == false)
            {
                ////MessageBox.Show("Play Not made");
                //pnlPlayArea.Controls.Remove(cardBox);
                ////flip the card before entering computer hand
                //cardBox.FaceUp = false;
                //pnlComputerHand.Controls.Add(cardBox);
                //RealignCards(pnlComputerHand);
                ////reset the attack counter
                //playerAttackCounter = 0;


                for (int i = pnlPlayArea.Controls.Count - 1; i > -1; i--)
                {
                    //debugging for card indexes on table.
                    //MessageBox.Show(pnlPlayArea.Controls.Count + " cards on table.  Index is " + i);
                    CardBox card = (CardBox)pnlPlayArea.Controls[i];
                    pnlPlayArea.Controls.Remove(card);
                    //flip the card before entering computer hand
                    card.FaceUp = false;
                    pnlComputerHand.Controls.Add(card);
                    RealignCards(pnlComputerHand);
                    RealignCards(pnlPlayArea);
                    playerAttackCounter = 0;
                }
            }
        }

        //Method to determine which cards are valid when defending
        public bool validPlayerDefense(CardBox computerCard)
        {
            bool canPlay = false;
            //determine which cards are playable by the player 
            for (int j = 0; j < pnlPlayerHand.Controls.Count; j++)
            {
                CardBox playerCard = (CardBox)pnlPlayerHand.Controls[j];

                //player card suit matches the AI card suit or the player card is a tump
                if (playerCard.Suit == computerCard.Suit || playerCard.Suit == trumpSuit)
                {
                    //if the player card is trump
                    if (playerCard.Suit == trumpSuit)
                    {
                        //if the AI card is trump and that card is higher rank than an AI card
                        if (computerCard.Suit == trumpSuit && playerCard.Rank > computerCard.Rank)
                        {
                            AddClickEvent(playerCard);
                            //MessageBox.Show(playerCard.ToString() + " is clickable.");
                            //i += 100;
                            canPlay = true;
                        }
                        //else if the player card is trump and AI card is not trump
                        else if (playerCard.Suit == trumpSuit && computerCard.Suit != trumpSuit)
                        {
                            AddClickEvent(playerCard);
                            //MessageBox.Show(playerCard.ToString() + " is clickable.");
                            //i += 100;
                            canPlay = true;
                        }
                    }

                    // else if the suit is the same and the player's card is greater than the AI card.
                    else if (playerCard.Suit == computerCard.Suit && playerCard.Rank > computerCard.Rank)
                    {
                        AddClickEvent(playerCard);
                        //MessageBox.Show(playerCard.ToString() + " is clickable.");
                        //i += 100;
                        canPlay = true;
                    }
                }
                //else
                //MessageBox.Show(playerCard.ToString() + " can not be clicked.");
                //canPlay = false;
            }
            return canPlay;
        }

        //Method to redraw cards into player hands
        public void RedrawCards(Deck durakDeck, bool playerAttack)
        {
            // Check that there are cards in the deck
            if (durakDeck.CardsRemaining >= 0)
            {
                //MessageBox.Show(durakDeck.CardsRemaining.ToString());
                //Store the amount of cards currently in the player and AI hand
                int attackHandCount = pnlPlayerHand.Controls.Count;
                int defendHandCount = pnlComputerHand.Controls.Count;

                // if the player attacked 
                if (playerAttack == true)
                {
                    // for each card less than 6 in a player hand
                    for (int i = 1; i <= (6 - attackHandCount); i++)
                    {
                        Card card = new Card();
                        if (durakDeck.CardsRemaining <= 0)
                        {
                            pbDeck.Visible = false;
                            if (pnlTrumpCard.Controls.Count > 0)
                            {
                                CardBox trumpCard = (CardBox)pnlTrumpCard.Controls[0];
                                pnlTrumpCard.Controls.Remove(trumpCard);
                                pnlPlayerHand.Controls.Add(trumpCard);
                            }
                            else if (pnlTrumpCard.Controls.Count == 0)
                                WinCheck(durakDeck);

                            i += 100;
                        }
                        else
                        {
                            //draw a card
                            card = durakDeck.DrawCard();
                            // adjsut the cards label showing how many cards are left in the deck
                            lblCardsRemaining.Text = durakDeck.CardsRemaining.ToString();
                            //set the card faceup for a player hand
                            card.FaceUp = true;
                            CardBox cardBox = new CardBox(card);
                            //wire the click event to the cardbox
                            AddClickEvent(cardBox);
                            //add the card to the hand and realign the hand
                            pnlPlayerHand.Controls.Add(cardBox);
                            RealignCards(pnlPlayerHand);
                            //MessageBox.Show(pnlPlayerHand.Controls.Count.ToString() + " cards in hand");
                        }

                    }
                    // for each card less than 6 in the AI hand
                    for (int i = 1; i <= (6 - defendHandCount); i++)
                    {
                        Card card = new Card();
                        if (durakDeck.CardsRemaining <= 0)
                        {
                            pbDeck.Visible = false;
                            if (pnlTrumpCard.Controls.Count > 0)
                            {
                                CardBox trumpCard = (CardBox)pnlTrumpCard.Controls[0];
                                pnlTrumpCard.Controls.Remove(trumpCard);
                                pnlComputerHand.Controls.Add(trumpCard);
                            }
                            else if (pnlTrumpCard.Controls.Count == 0)
                                WinCheck(durakDeck);
                            i += 100;
                        }
                        else
                        {
                            //draw a card
                            card = durakDeck.DrawCard();
                            // adjsut the cards label showing how many cards are left in the deck
                            lblCardsRemaining.Text = durakDeck.CardsRemaining.ToString();
                            card.FaceUp = true;  //not required for AI hands, use only for debugging
                            CardBox cardBox = new CardBox(card);
                            //add card to AI hand and realign the hand
                            pnlComputerHand.Controls.Add(cardBox);
                            RealignCards(pnlComputerHand);
                        }
                    }
                }
                //else the computer attacked, swap the draw order
                else
                {
                    // for each card less than 6 in the AI hand
                    for (int i = 1; i <= (6 - defendHandCount); i++)
                    {
                        Card card = new Card();
                        if (durakDeck.CardsRemaining <= 0)
                        {
                            pbDeck.Visible = false;
                            if (pnlTrumpCard.Controls.Count > 0)
                            {
                                CardBox trumpCard = (CardBox)pnlTrumpCard.Controls[0];
                                pnlTrumpCard.Controls.Remove(trumpCard);
                                pnlComputerHand.Controls.Add(trumpCard);
                            }
                            else if (pnlTrumpCard.Controls.Count == 0)
                                WinCheck(durakDeck);

                            i += 100;
                        }
                        else
                        {
                            //draw a card
                            card = durakDeck.DrawCard();
                            // adjsut the cards label showing how many cards are left in the deck
                            lblCardsRemaining.Text = durakDeck.CardsRemaining.ToString();
                            card.FaceUp = true;  //not required for AI hands, use only for debugging
                            CardBox cardBox = new CardBox(card);
                            //add card to AI hand and realign the hand
                            pnlComputerHand.Controls.Add(cardBox);
                            RealignCards(pnlComputerHand);
                        }
                    }

                    // for each card less than 6 in a player hand
                    for (int i = 1; i <= (6 - attackHandCount); i++)
                    {
                        Card card = new Card();
                        if (durakDeck.CardsRemaining <= 0)
                        {
                            pbDeck.Visible = false;
                            if (pnlTrumpCard.Controls.Count > 0)
                            {
                                CardBox trumpCard = (CardBox)pnlTrumpCard.Controls[0];
                                pnlTrumpCard.Controls.Remove(trumpCard);
                                pnlPlayerHand.Controls.Add(trumpCard);
                            }
                            else if (pnlTrumpCard.Controls.Count == 0)
                                WinCheck(durakDeck);

                            i += 100;
                        }
                        else
                        {
                            //draw a card
                            card = durakDeck.DrawCard();
                            // adjsut the cards label showing how many cards are left in the deck
                            lblCardsRemaining.Text = durakDeck.CardsRemaining.ToString();
                            //set the card faceup for a player hand
                            card.FaceUp = true;
                            CardBox cardBox = new CardBox(card);
                            //wire the click event to the cardbox
                            AddClickEvent(cardBox);
                            //add the card to the hand and realign the hand
                            pnlPlayerHand.Controls.Add(cardBox);
                            RealignCards(pnlPlayerHand);
                            //MessageBox.Show(pnlPlayerHand.Controls.Count.ToString() + " cards in hand");
                        }

                    }
                }
            }
            else //there are no cards in the deck.
                WinCheck(durakDeck);
        }

        /// <summary>
        /// Method to check to see if a player has won the game
        /// </summary>
        /// <param name="durakDeck">requires the current durakDeck to begin if it is empty or not.</param>
        public void WinCheck(Deck durakDeck)
        {
            if (durakDeck.CardsRemaining == 0)
            {
                if (pnlPlayerHand.Controls.Count > 0 && pnlComputerHand.Controls.Count <= 0)
                {
                    MessageBox.Show("You're a fool! \n" + newAI.Name + "has won.");
                    for (int i = pnlPlayerHand.Controls.Count; i > -1; i--)
                    {
                        CardBox cardBox = (CardBox)pnlPlayerHand.Controls[i];
                        RemoveClickEvent(cardBox);
                    }
                    btnEndAttack.Visible = false;  // should already be not visible, but set it anyway
                    btnForfeit.Visible = false;
                    //track stats

                }
                else if (pnlPlayerHand.Controls.Count <= 0 && pnlComputerHand.Controls.Count > 0)
                {
                    MessageBox.Show(newAI.Name + "is the fool! \n" + newPlayer.Name + "has won.");
                    btnEndAttack.Visible = false;
                    btnForfeit.Visible = false;
                    //track stats
                }
                else
                {
                    MessageBox.Show("There is no fool?! \nGame has ended in a tie.");
                    if (pnlPlayerHand.Controls.Count > 0)
                    {
                        for (int i = pnlPlayerHand.Controls.Count; i > -1; i--)
                        {
                            CardBox cardBox = (CardBox)pnlPlayerHand.Controls[i];
                            RemoveClickEvent(cardBox);
                        }
                    }
                    btnEndAttack.Visible = false;
                    btnForfeit.Visible = false;
                    //track stats
                }
            }
            //else no win condition found.  Keep playing.
        }

        /// <summary>
        /// 
        /// </summary>
        public void HardAi()
        {
            //check last index added to the play area
            CardBox lastCard = (CardBox)pnlPlayArea.Controls[(pnlPlayArea.Controls.Count - 1)];
            // look at AI hand 
            for (int i = (pnlComputerHand.Controls.Count-1); i > -1; i--)
            {
                //

            }

        }

        #endregion


    }
}
