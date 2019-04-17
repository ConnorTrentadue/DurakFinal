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
 **/

/** ATTRIBUTION 
* Card images used in class were created by Byron Knoll
* These images are released into the public domain - attribution is appreciated but not required.
* Downloaded from : http://code.google.com/p/vector-playing-cards/ on 4 Mar 2019
*/

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

        //Counters for repositioning the Play Area cards (These are used in the RepositionPlayedCards method)
        private int repositionCounter = 0;
        private int everyTwoCards = 0;

        //Tracks how many times a player has "attacked"
        int playerAttackCounter = 0;
        int aiAttackCounter = 0;

        //Seeding random number generator
        static Random randomNumber = new Random();

        //*************************
        //*************************
        //*************************
        int difficultyChoice = 1; //Stores difficulty that player chooses and determines the AI's moves. (1, 2, or 3)
        //*************************
        //*************************
        //*************************

        int pickUpCounter = 0;

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

        string playerName = "";

        // sets a defautl state for if a player is attacking or defending.
        bool playerAttack = false;

        bool winCheckPassed = false;

        //declare a trumpSuit  to hold trump suit values
        Suit trumpSuit;
        // declare a cardRank  to hold card rank values
        //Rank cardRank = Rank.Ace;

        //declare a cardSuit to hold card suit values
        //Suit cardSuit = Suit.Clubs;

        static private Size regularSize = new Size(75, 108);
        #endregion

        #region FORM EVENTS AND HANDLERS

        public frmDurak()
        {
            InitializeComponent();
            //Set the initial button controls
            btnPickUp.Visible = false;
            btnEndAttack.Visible = false;
            btnForfeit.Visible = false;
            mnuForfeit.Visible = false;

            lblGameNumber.Visible = false;
            lblRoundNumber.Visible = false;
            lblWins.Visible = false;
            lblLosses.Visible = false;
            lblTies.Visible = false;
            lblDiscard.Visible = false;
            lblCardsRemaining.Visible = false;
        }

        /// <summary>
        /// Default form load
        /// </summary>
        private void frmDurak_Load(object sender, EventArgs e)
        {
            // initialize form log ( change to whatever button we want to make the log come from )
            frmLog = new frmLog();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            string aboutInfo = "This project was developed by:\n\n" +
                "Raymond Michael, Shaun McCrum and Connor Trentadue\n\n" +
                "It was developed for OOP4200 as a semester long project.\n\n" +
                "This program allows you to play Durak (or Fool), a Russian card game.\n\n\n" +
                "ATTRIBUTION: \n\n" +
                "Wood table image for form design created by Pixaby 20 Feb of an unknown year. " +
                "Images release under the Creative Commons CC0 License. " +
                "Downloaded from https://www.pexels.com/photo/close-up-of-wooden-plank-326311/. \n\n\n\n" +
                "Card images used in class were created by Byron Knoll\n" +
                "These images are released into the public domain - attribution is appreciated but not required.\n" +
                "Downloaded from : http://code.google.com/p/vector-playing-cards/ on 4 Mar 2019\n\n" +
                "                                                                          " +
                "                                                     V1.0 ©" + DateTime.Now.ToString("yyyy");

            frmAboutForm about = new frmAboutForm(aboutInfo);
            
            about.Show();
        }

        private void mnuHelp_Click(object sender, EventArgs e)
        {
            string videoLink = "<INSERT VIDEO LINK HERE>";

            try
            {
                System.Diagnostics.Process.Start(videoLink);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error redirecting to help video. Please see this link for the video: <INSERT VIDEO LINK HERE>.");
            }
        }

        private void mnuLog_Click(object sender, EventArgs e)
        {
            if (frmLog != null)
                frmLog.Show();
        }

        /// <summary>
        /// Begins a new game
        /// </summary>
        private void mnuNewGame_Click(object sender, EventArgs e)
        {

            btnNewGame_Click(sender, e);
        }

        /// <summary>
        /// Forfeit a game
        /// </summary>
        private void mnuForfeit_Click(object sender, EventArgs e)
        {
            btnForfeit_Click(sender, e);
        }

        /// <summary>
        /// Closes the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuClose_Click(object sender, EventArgs e)
        {
            //close the progra.  REMOVE AFTER ADDING STATS TRACING FUNCTIONALITY
            // Closes log form and writes to file
            if (frmLog != null)
                frmLog.Close();
            if (playerStats != null)
            {
                playerStats.round = 0;
                Stats.WriteStats(playerStats);
            }


            Close();
        }

        /// <summary>
        /// NEW GAME - Clear out previous game session, select difficulty
        /// Creates a new deck and deals 6 cards to each player.
        /// Determine who attacks first.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            //clear any existing att / pickup buttons
            btnEndAttack.Visible = false;
            btnPickUp.Visible = false;
            aiAttackCounter = 0;
            winCheckPassed = false;

            //enable forfeit button and menu option
            btnForfeit.Visible = true;
            mnuForfeit.Visible = true;

            // If player has not entered a name have them do so
            while (playerName == "")
            {
                //prompt the user for their name
                frmPlayerNameEntry namePrompt = new frmPlayerNameEntry();

                //check if the dialog has been been click OK.
                if (namePrompt.ShowDialog() == DialogResult.OK)
                {
                    playerName = namePrompt.PlayerName;
                }
                if (playerName == "")
                    MessageBox.Show("Please enter a name.");
            }

            //if name exists in the log-file
            //pull statistics from statistics log file.
            //else store their name and continue 

            //prompt the user for their choice of difficulty
            frmDifficultyChoice difficultyPrompt = new frmDifficultyChoice();
            if (difficultyPrompt.ShowDialog() == DialogResult.OK)
            {
                difficultyChoice = difficultyPrompt.DifficultyValue;
            }

             // Get player existing stats
            playerStats = Stats.ReadStats();
            if (playerStats != null)
            {
                playerStats.gamesPlayed += 1;
                playerStats.round += 1;
            }

            // Writes to the log screen, which writes to the text file when the form is closed
            frmLog.WriteToLog("\nNew Game # " + playerStats.gamesPlayed + " has started");

            //set the game labels.
            lblGameNumber.Text = "Game #: " + playerStats.gamesPlayed;
            lblRoundNumber.Text = "Round #: " + playerStats.round;
            lblWins.Text = "Wins: " + playerStats.wins;
            lblLosses.Text = "Losses: " + playerStats.losses;
            lblTies.Text = "Ties: " + playerStats.ties;

            //clear any objects on the table.
            pnlComputerHand.Controls.Clear();
            pnlPlayerHand.Controls.Clear();
            pnlTrumpCard.Controls.Clear();
            pnlPlayArea.Controls.Clear();
            pnlDiscard.Controls.Clear();

            //enable the new-game buttons
            lblGameNumber.Visible = true;
            lblRoundNumber.Visible = true;
            lblWins.Visible = true;
            lblLosses.Visible = true;
            lblTies.Visible = true;
            lblDiscard.Visible = true;
            lblCardsRemaining.Visible = true;

            //ranomdizer for first player selection
            int someNumber = randomNumber.Next(1, 20);

            //Instantiate new computer player based on selected difficulty (w/ random name)
            newAI = new ComputerPlayer(computerNames[someNumber], difficultyChoice);
            newPlayer = new Player(playerName); //playerName is assigned from the user entry 

            // set the label of the AI and Player names                                    
            lblAIName.Text = newAI.Name;
            lblPlayerName.Text = newPlayer.Name.ToString();
            playerStats.playerName = "\"" + newPlayer.Name.ToString() + "\"";


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
            lblCardsRemaining.Text = "Remaining: " + durakDeck.CardsRemaining.ToString();

            //deal 12 cards, (6 each) to the players.
            //alternate the cards into each player's hand
            for (int i = 1; i <= 12; i++)
            {
                card = durakDeck.DrawCard();

                if (i % 2 == 0)
                {
                    card.FaceUp = true;
                    CardBox playerCardBox = new CardBox(card);
                    //wire the click event to the cardbox
                    if (!playerCardBox.IsEventHandlerRegistered())
                    {
                        AddClickEvent(playerCardBox);
                    }
                    pnlPlayerHand.Controls.Add(playerCardBox);
                }
                else
                {
                    //card.FaceUp = true;  //uncomment this to enable AI cards faceUp
                    CardBox computerCardBox = new CardBox(card);
                    pnlComputerHand.Controls.Add(computerCardBox);
                }
            }

            //realign both player and commputer hand
            FlipPlayerHand(pnlPlayerHand);
            FlipAiHand(pnlComputerHand);

            // set the trump suit for this game.
            Card trumpCard = durakDeck.DrawCard();
            CardBox aTrumpCardbox = new CardBox(trumpCard);

            //draw the card to the trump panel face up
            trumpCard.FaceUp = true;
            pnlTrumpCard.Controls.Add(aTrumpCardbox);
            // assign the trump suit for the game
            trumpSuit = trumpCard.Suit;

            // Set the trump image to the trump suit and its label
            Image trumpImage = Properties.Resources.ResourceManager.GetObject(trumpSuit.ToString()) as Image;
            pbTrumpIndicator.Image = trumpImage;
            pbTrumpIndicator.BackColor = Color.White;
            pbTrumpIndicator.BorderStyle = BorderStyle.Fixed3D;
            lblTrumpIndicator.Text = trumpSuit.ToString();
            lblTrumpIndicator.Visible = true;

            // Display remaining cards after the deal
            lblCardsRemaining.Text = "Remaining: " + durakDeck.CardsRemaining.ToString();

            // ******* Begin game-play flow. *********
            //decide whom take the first turn
            PlayerFirst();
            if (playerAttack != true)  //if not true, AI attacks first.
            {
                MessageBox.Show(newAI.Name + " will go first");
                ComputerAttack(aiAttackCounter);
            }
            else
            {
                MessageBox.Show(newPlayer.Name + " will go first");
                btnEndAttack.Visible = true;
            }

        }

        /// <summary>
        /// Forfet game clears out the game session, assumes a loss and logs statistics
        /// </summary>
        private void btnForfeit_Click(object sender, EventArgs e)
        {
            // Log the game as a loss for the player
            if (playerStats != null)
                playerStats.losses += 1;
            // close the lof if it was open.
            if (frmLog != null)
                frmLog.Close();
            Stats.WriteStats(playerStats);
            // disable all player controls
            btnForfeit.Visible = false;
            mnuForfeit.Visible = false;
            btnEndAttack.Visible = false;
            btnPickUp.Visible = false;
            // remove all click-events from cards on the table.
            // remove all click events
            for (int i = 0; i < pnlPlayerHand.Controls.Count; i++)
            {
                CardBox card = (CardBox)pnlPlayerHand.Controls[i];
                RemoveClickEvent(card);
                //RemoveBorder(card);
            }

        }

        /// <summary>
        /// Button to allow the pickup of cards when the player is defending
        /// </summary>
        private void btnPickUp_Click(object sender, EventArgs e)
        {
            PickUpCards(ref pnlPlayerHand, true);
            //MessageBox.Show("Pickup Counter: " + pickUpCounter + "AI attack Counter: " + aiAttackCounter);

            if (pickUpCounter < 6)
            {
                //if (difficultyChoice == 3)
                //    HardAiAttack();

                ComputerAttack(aiAttackCounter);
            }
            else if (pickUpCounter == 6 && aiAttackCounter == 6)
            {
                //MessageBox.Show("Pickup Counter: " + pickUpCounter + " & AI attack Counter: " + aiAttackCounter + " REACHED");
                pickUpCounter = 0;
                btnEndAttack.Visible = true;
                btnPickUp.Visible = false;
                playerAttack = true; //set player to attack phase
                                     //render player hand to be clickable
                for (int j = pnlPlayerHand.Controls.Count - 1; j > -1; j--)
                {
                    CardBox card = (CardBox)pnlPlayerHand.Controls[j];
                    if (!card.IsEventHandlerRegistered())
                    {
                        AddClickEvent(card);
                    }
                }
            }
            else
            {
                //MessageBox.Show("AI attack Counter: " + aiAttackCounter);
                ComputerAttack(aiAttackCounter);
            }

        }

        #endregion

        #region CARDBOX EVENT HANDLERS

        public void CardBox_Click(object sender, EventArgs e)
        {
            //convert the sender
            CardBox aCardBox = sender as CardBox;
            RemoveClickEvent(aCardBox);
            //MessageBox.Show(aCardBox.ToString() + " was clicked");
            bool validPlay = true;

            if (playerAttack != true) //player is defending
            {
                //MessageBox.Show("playerAttack variable was false. Player is defending.");
                //remove card from player hand
                pnlPlayerHand.Controls.Remove(aCardBox);
                //add the card to the play area
                pnlPlayArea.Controls.Add(aCardBox);

                //MessageBox.Show("Card Added!");
                //playerAttackCounter++;
                //MessageBox.Show("Attacker Counter +1!");

                //realign player hand
                FlipPlayerHand(pnlPlayerHand);
                RepositionPlayedCards(pnlPlayArea);
                //remove the click event from the card as it enters the playarea
                //RemoveBorder(aCardBox);
                RemoveClickEvent(aCardBox);

                //MessageBox.Show("player Counter " + playerAttackCounter.ToString());
                ComputerAttack(playerAttackCounter);
            }
            else //player is attacking
            {
                //MessageBox.Show("playerAttack variable was true. Player is attacking.");
                if (pnlPlayArea.Controls.Count == 0)
                {
                    //MessageBox.Show("Play area has 0 cards in it during player attack.");
                    //remove from player hand
                    pnlPlayerHand.Controls.Remove(aCardBox);
                    //add the card to the play area
                    //MessageBox.Show("Card Removed!");
                    pnlPlayArea.Controls.Add(aCardBox);

                    //MessageBox.Show("Card Added!");
                    playerAttackCounter++;
                    //MessageBox.Show("Attacker Counter +1!");

                    //realign player hand
                    FlipPlayerHand(pnlPlayerHand);
                    RepositionPlayedCards(pnlPlayArea);
                    //remove the click event from the card as it enters the playarea
                    //RemoveBorder(aCardBox);
                    RemoveClickEvent(aCardBox);

                    //MessageBox.Show("Computer is playing a defense against a single card in play area");
                    MakeNormalPlay(aCardBox, playerAttackCounter);
                }
                else if (pnlPlayArea.Controls.Count > 0)
                {
                    //MessageBox.Show("Play area has more than 0 cards in it during player attack.");
                    //MessageBox.Show("Else trigged " + pnlPlayArea.Controls.Count + " Cards on the table");
                    for (int i = 0; i < pnlPlayArea.Controls.Count; i++)
                    {
                        //MessageBox.Show("Looping through play area.");
                        //MessageBox.Show("entering if (pnlPlayArea > 0), index is " + i);
                        CardBox validCardCheck = (CardBox)pnlPlayArea.Controls[i];
                        // check cards in the playarea for valid rank
                        if (aCardBox.Rank == validCardCheck.Rank)
                        {
                            //MessageBox.Show("Checking that the current player card is valid by comparing it to each card in the play area.");
                            //remove from player hand
                            pnlPlayerHand.Controls.Remove(aCardBox);
                            //add the card to the play area
                            //requires location mapping
                            //MessageBox.Show("Card Removed!");
                            pnlPlayArea.Controls.Add(aCardBox);
                            RepositionPlayedCards(pnlPlayArea);

                            //MessageBox.Show("Card Added!");
                            playerAttackCounter++;
                            //MessageBox.Show("Attacker Counter +1!");

                            //realign player hand
                            FlipPlayerHand(pnlPlayerHand);
                            //aCardBox.Click -= CardBox_Click;
                            RemoveClickEvent(aCardBox);

                            //remove the click event from the card as it enters the playarea
                            //RemoveBorder(aCardBox);
                            //RemoveClickEvent(aCardBox);

                            MakeNormalPlay(aCardBox, playerAttackCounter);

                            //exit the for loop
                            //MessageBox.Show("Breaking the computer defense loop that occurs when there is more than 1 card in play.");
                            i += 111;
                            //break;
                        }
                        else
                        {
                            //MessageBox.Show("The current checked card was not valid for play. Setting validPlay bool to false.");
                            validPlay = false;
                            //break;
                        }
                    }

                }
                if (validPlay == false)
                {
                    //MessageBox.Show("If validPlay bool is false resetting validPlay.");
                    validPlay = true;
                    //MessageBox.Show(aCardBox.ToString() + " is not a valid card");
                }
                if (pnlPlayerHand.Controls.Count == 0)
                {
                    //MessageBox.Show("Player hand it empty, redrawing cards.");
                    RedrawCards(durakDeck, playerAttack);
                }
                // revaluate click events
                //MessageBox.Show("re-evaluate click events");  //debugging

                //for (int i = 0; i < pnlPlayerHand.Controls.Count; i++)
                //{
                //    CardBox playerCard = (CardBox)pnlPlayerHand.Controls[i];
                //    //remove click event
                //    RemoveClickEvent(playerCard);
                //}
                //for (int i = 0; i < pnlPlayerHand.Controls.Count; i++)
                //{
                //    bool foundCard = false;
                //    CardBox playerCard = (CardBox)pnlPlayerHand.Controls[i];
                //    for (int j = 0; j < pnlPlayArea.Controls.Count && !foundCard; j++)
                //    {
                //        CardBox validCardCheck = (CardBox)pnlPlayArea.Controls[j];
                //        // check cards in the playarea for valid rank
                //        //MessageBox.Show("evaluate " + playerCard.ToString() + " vs " + validCardCheck.ToString() );
                //        if ((int)playerCard.Rank == (int)validCardCheck.Rank)
                //        {
                //            MessageBox.Show("Click Event Added:  " + playerCard.ToString());
                //            AddClickEvent(playerCard);
                //            foundCard = true;
                //        }
                //        //else
                //        //{
                //        //    RemoveClickEvent(playerCard);
                //        //}
                //        //MessageBox.Show("Index value is " + i); //debugging
                //    }
                //}

                for (int i = pnlPlayerHand.Controls.Count - 1; i > -1; i--)
                {
                    //MessageBox.Show("Looping through player hand to remove/add click events for valid cards.");
                    bool foundCard = false;
                    CardBox playerCard = (CardBox)pnlPlayerHand.Controls[i];
                    RemoveClickEvent(playerCard);

                    for (int j = pnlPlayArea.Controls.Count - 1; j > -1 && foundCard == false; j--)
                    {
                        CardBox validCardCheck = (CardBox)pnlPlayArea.Controls[j];

                        if ((int)playerCard.Rank == (int)validCardCheck.Rank)
                        {
                            if (!playerCard.IsEventHandlerRegistered())
                            {
                                //MessageBox.Show("Click Event Added:  " + playerCard.ToString());
                                AddClickEvent(playerCard);
                                DrawBorder(playerCard);
                                foundCard = true;
                            }
                        }
                    }
                }

                if (pnlPlayArea.Controls.Count == 0)
                {
                    for (int i = pnlPlayerHand.Controls.Count - 1; i > -1; i--)
                    {
                        CardBox playerCard = (CardBox)pnlPlayerHand.Controls[i];
                        if (!playerCard.IsEventHandlerRegistered())
                        {
                            AddClickEvent(playerCard);
                            DrawBorder(playerCard);
                        }
                    }
                }
            }

            WinCheck(durakDeck);
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
                        offset = (cardWidth);

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

        /// <summary>
        /// Repositions the cards in the play area so that each attack/defense card is grouped together
        /// THIS METHOD CAUSES WEIRD BUGS DO NOT USE
        /// </summary>
        /// <param name="playArea"></param>
        private void RepositionPlayedCards(Panel playArea)
        {
            // Determine the number of cards/controls in the panel.
            int myCount = playArea.Controls.Count;

            // If there are any cards in the panel
            if (myCount > 0)
            {
                // Determine how wide one card/control is.
                int cardWidth = playArea.Controls[0].Width;
                int cardHeight = playArea.Controls[0].Height;

                // Determine where the left-hand edge of a card/control placed 
                // in the middle of the panel should be  
                int startPoint = (playArea.Width - cardWidth) / 2;

                // An offset for the remaining cards
                int offset = 0;

                // If there are more than one cards/controls in the panel
                if (myCount > 1)
                {
                    // Determine what the offset should be for each card based on the 
                    // space available and the number of card/controls
                    offset = (playArea.Width - cardWidth - 2 * POP) / (myCount - 1);

                    // If the offset is bigger than the card/control width, i.e. there is lots of room, 
                    // set the offset to the card width. The cards/controls will not overlap at all.
                    if (offset > cardWidth)
                        offset = cardWidth;

                    // Determine width of all the cards/controls 
                    int allCardsWidth = (myCount - 1) * offset + cardWidth;

                    // Set the start point to where the left-hand edge of the "first" card should be.
                    startPoint = (playArea.Width - allCardsWidth) / 2;
                }

                // Aligning the cards: Note that I align them in reserve order from how they
                // are stored in the controls collection. This is so that cards on the left 
                // appear underneath cards to the right. This allows the user to see the rank
                // and suit more easily.

                // Align the "first" card (which is the last control in the collection)
                //panelHand.Controls[myCount - 1].Top = POP;
                System.Diagnostics.Debug.Write(playArea.Controls[myCount - 1].Top.ToString() + "\n");
                playArea.Controls[myCount - 1].Left = startPoint;

                // for each of the remaining controls, in reverse order.
                for (int index = myCount - 2; index >= 0; index--)
                {
                    
                    //on 4th card play reduce the offset.
                    if (index == myCount - 4)
                    {
                        offset = offset / 2;
                    }
                    //everyTwoCards++;
                    if (index % 2 != 0)
                    {
                        repositionCounter += 10;

                        playArea.Controls[index].Left = playArea.Controls[index + 1].Left + (offset) + repositionCounter;
                        repositionCounter = 0;
                    }
                    else
                    // Align the current card
                    //panelHand.Controls[index].Top = POP;
                    playArea.Controls[index].Left = playArea.Controls[index + 1].Left + offset + repositionCounter;

                    //if (index % 2 != 0)
                    //{
                    //    //everyTwoCards = 0;
                    //    repositionCounter = 0;
                    //}
                }
            }
        }

        #endregion

        #region METHODS

        //starts a normal play where the player is attacking and AI is defending
        public void MakeNormalPlay(CardBox cardBox, int playCount, int duplicateCards = 0)
        {
            //bool playMade = false;

            btnEndAttack.Visible = true;
            btnPickUp.Visible = false;
            //AI attack logic
            //ComputerAttack(playMade);

            //apply logic to the card added to the table.
            //determine AI difficulty
            if (difficultyChoice == 3)
                HardAiDefense();
            else if (difficultyChoice == 2)
            {
                int choiceNumber = randomNumber.Next(1, 3);
                if (choiceNumber == 2)
                    HardAiDefense();
            }

            ComputerDefend(cardBox);

        }

        // Method to unwire cardbox click events
        public void RemoveClickEvent(CardBox card)
        {
            //remove the event handler 
            card.Click -= CardBox_Click;
            RemoveBorder(card);
        }

        // Method to wire cardbox click events
        public void AddClickEvent(CardBox card)
        {
            //add the event handler 
            card.Click += CardBox_Click;
            DrawBorder(card);
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
                lblDiscard.Text = "Discarded: " + pnlDiscard.Controls.Count.ToString();
                //MessageBox.Show(card.ToString() + " Added to the discard pile");
                RealignCards(pnlDiscard);
                FlipPlayerHand(pnlPlayerHand);
                FlipAiHand(pnlComputerHand);
            }

            // remove all click events
            for (int i = 0; i < pnlPlayerHand.Controls.Count; i++)
            {
                CardBox card = (CardBox)pnlPlayerHand.Controls[i];
                RemoveClickEvent(card);
                //RemoveBorder(card);
            }
            aiAttackCounter = 0;
            //fill the player's hands with cards
            RedrawCards(durakDeck, playerAttack);
            // set player to defending
            playerAttack = false;
            // switch to computer attack
            ComputerAttack(aiAttackCounter);

        }

        // logic for computer on attack, player on defense
        public void ComputerAttack(int playCount)
        {
            bool playMade = false;  //conditionally bool to see if a play was made
            bool validPlay = false;
            bool highCard = false;  //is the card a highcard
            const int HIGH_CARD = 13; //rank of a card that is high

            //Checks for Hard difficulty
            if (difficultyChoice == 3)
                HardAiAttack();
            else if (difficultyChoice == 2)
            {
                int choiceNumber = randomNumber.Next(1, 3);
                if (choiceNumber == 2)
                    HardAiAttack();
            }

            //remove the btnEndAttack
            btnEndAttack.Visible = false;
            //remove the btnPickup
            btnPickUp.Visible = true;
            // render player hand unclickable before attack cards are played
            //foreach (CardBox playerCard in (CardBox)pnlPlayerHand)
            for (int i = 0; i < pnlPlayerHand.Controls.Count; i++)
            {
                CardBox card = (CardBox)pnlPlayerHand.Controls[i];
                RemoveClickEvent(card);
                //RemoveBorder(card);
            }
            // clear any borders from the playArea cards
            for (int i = 0; i < pnlPlayArea.Controls.Count; i++)
            {
                CardBox card = (CardBox)pnlPlayArea.Controls[i];
                card.BorderStyle = BorderStyle.None;
            }

            // if playArea is empty begin attack
            if (pnlPlayArea.Controls.Count <= 0)
            {
                CardBox computerCard = new CardBox();
                //logic to add first card from computer hand (no attack logic applied)
                for (int i = pnlComputerHand.Controls.Count; i > -1; i--)
                {
                    if (pnlComputerHand.Controls.Count != 0)
                    {
                        //MessageBox.Show("index play " + i);

                        // ------------------------------------------------ NEW HARD AI CODE HERE ----------------------------------
                        // -------------------------------------------------------------------------------------------------
                        //Checks if Hard difficulty is selected
                        if (difficultyChoice == 3)
                        {
                            //Loops through computer hand
                            for (int m = 0; m < pnlComputerHand.Controls.Count; m++)
                            {
                                //Creates cardbox for each control in the computer hand for checking
                                CardBox tempCard = (CardBox)pnlComputerHand.Controls[m];

                                //Checks if the current card in the hand is trump
                                if (tempCard.Suit == trumpSuit)
                                {
                                    //Checks that we're not looking at the last card in hand
                                    if (m != pnlComputerHand.Controls.Count - 1)
                                    {
                                        //Sets the computers choice to the NEXT card in hand 
                                        computerCard = (CardBox)pnlComputerHand.Controls[m + 1];
                                    }
                                    //Checks that we're looking at the last card in the hand
                                    //All cards in hand were trump suit (WOW!) sets computer choice to LOWEST of the bunch
                                    else if (m == pnlComputerHand.Controls.Count - 1)
                                    {
                                        //Sets the computer choice to the last card
                                        computerCard = (CardBox)pnlComputerHand.Controls[0];
                                    }
                                }
                                else // Card chosen is not a trump
                                {
                                    computerCard = (CardBox)pnlComputerHand.Controls[0];
                                    m += 100;
                                }
                            }
                            // if the card is a queen or higher,  save it for later
                            if ((int)computerCard.Rank >= HIGH_CARD)
                            {
                                // if not playing in end-game
                                if (durakDeck.CardsRemaining > 1)
                                {
                                    highCard = true;
                                }
                            }
                        }
                        else // Easy AI always plays the first card in hand
                        {
                            computerCard = (CardBox)pnlComputerHand.Controls[0];
                        }

                        // triggers if hardAI flags the next card playable as high.
                        if (highCard == true)
                        {
                            i -= 100;  //end the loop that play cards
                        }
                        // --------------------------------------------- NEW HARD AI CODE ENDS HERE ------------------------------------------
                        // -----------------------------------------------------------------------------------------------------------
                        //the card at 0 is not high, play as normal
                        else
                        {
                            //If no cards are in the playArea
                            if (pnlPlayArea.Controls.Count <= 0)
                            {
                                //flip the card as it is played
                                computerCard.FaceUp = true;
                                //play the card in the computer hand
                                pnlComputerHand.Controls.Remove(computerCard);
                                aiAttackCounter++;
                                pnlPlayArea.Controls.Add(computerCard);
                                computerCard.BorderStyle = BorderStyle.Fixed3D;
                                FlipAiHand(pnlComputerHand);
                                RepositionPlayedCards(pnlPlayArea);

                                //if no player cards can defend an attack
                                if (validPlayerDefense(computerCard) == false)
                                {
                                    pickUpCounter++;
                                    //MessageBox.Show("You can not defend, take the card");
                                    //for all cards on the table, pick them up
                                    for (int j = pnlPlayArea.Controls.Count - 1; j > -1; j--)
                                    {
                                        //debugging for card indexes on table.
                                        //MessageBox.Show(pnlPlayArea.Controls.Count + " cards on table.  Index is " + i);
                                        CardBox card = (CardBox)pnlPlayArea.Controls[j];
                                        // remove border from the card if it still has one.
                                        RemoveBorder(card);
                                        pnlPlayArea.Controls.Remove(card);
                                        //card.FaceUp = false;
                                        pnlPlayerHand.Controls.Add(card);
                                        RemoveClickEvent(card);
                                        FlipPlayerHand(pnlPlayerHand);
                                        RepositionPlayedCards(pnlPlayArea);
                                        playerAttackCounter = 0;

                                    }
                                }
                                else
                                {
                                    //MessageBox.Show("You have " + pnlPlayerHand.Controls.Count + " cards, attempt a defense. ");
                                    i -= 100;

                                }
                            }
                        }
                        // flag that a play was made and realign cards
                        if (!highCard)
                            playMade = true;

                        RepositionPlayedCards(pnlPlayArea);
                    }
                }

                // if the card a [0] was a high card end the turn (can only happen duting hardAI)
                if (highCard == true && pnlPlayArea.Controls.Count <= 0)
                {
                    //Swap player attack / pickup buttons at the end of thae phase.
                    btnPickUp.Visible = false;
                    btnEndAttack.Visible = true;

                    //validPlay = true;  //reset validPlay
                    MessageBox.Show(newAI.Name + " chose not to play.");
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
                        lblDiscard.Text = "Discarded: " + pnlDiscard.Controls.Count.ToString();
                        //MessageBox.Show(card.ToString() + " Added to the discard pile");
                        RealignCards(pnlDiscard);
                        FlipPlayerHand(pnlPlayerHand);
                        FlipAiHand(pnlComputerHand);

                    }

                    RedrawCards(durakDeck, playerAttack); // draw cards to fill hand

                    playerAttack = true; //set player to attack phase
                                         //render player hand to be clickable
                    for (int j = pnlPlayerHand.Controls.Count - 1; j > -1; j--)
                    {
                        CardBox card = (CardBox)pnlPlayerHand.Controls[j];
                        if (!card.IsEventHandlerRegistered())
                        {
                            AddClickEvent(card);
                        }
                    }
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
                    CardBox computerCard = (CardBox)pnlComputerHand.Controls[i];
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
                                //MessageBox.Show(computerCard.ToString() + " is playable");
                                i += 100; // end the examination loop
                                playAreaIndex += 100;
                                //remove from player hand
                                pnlComputerHand.Controls.Remove(computerCard);
                                aiAttackCounter++;
                                computerCard.BorderStyle = BorderStyle.Fixed3D;
                                pnlPlayArea.Controls.Add(computerCard);
                            }

                            //realign computer hand
                            FlipAiHand(pnlComputerHand);
                            RepositionPlayedCards(pnlPlayArea);

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
                                    //MessageBox.Show("Picking up " + card + " at index " + k);
                                    pnlPlayArea.Controls.Remove(card);
                                    //flip the card before entering computer hand
                                    card.FaceUp = false;
                                    RemoveBorder(card);
                                    pnlPlayerHand.Controls.Add(card);
                                    FlipPlayerHand(pnlPlayerHand);
                                    RepositionPlayedCards(pnlPlayArea);
                                    //ComputerAttack(playerAttackCounter);
                                }
                                i += 100; // end the examination loop
                                playAreaIndex += 100;
                                ComputerAttack(aiAttackCounter);
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
                if (validPlay == false || aiAttackCounter == 6)
                {
                    WinCheck(durakDeck);
                    //Swap player attack / pickup buttons at the end of thae phase.
                    btnPickUp.Visible = false;
                    btnEndAttack.Visible = true;

                    //validPlay = true;  //reset validPlay
                    MessageBox.Show(newAI.Name + " will not play.");
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
                        lblDiscard.Text = "Discarded: " + pnlDiscard.Controls.Count.ToString();
                        //MessageBox.Show(card.ToString() + " Added to the discard pile");
                        RealignCards(pnlDiscard);
                        FlipPlayerHand(pnlPlayerHand);
                        FlipAiHand(pnlComputerHand);

                    }

                    RedrawCards(durakDeck, playerAttack); // draw cards to fill hand

                    playerAttack = true; //set player to attack phase
                                         //render player hand to be clickable
                    for (int j = pnlPlayerHand.Controls.Count - 1; j > -1; j--)
                    {
                        CardBox card = (CardBox)pnlPlayerHand.Controls[j];
                        if (!card.IsEventHandlerRegistered())
                        {
                            AddClickEvent(card);
                        }
                    }
                }
                // set boolean playMade successfully and realign the playArea
                playMade = true;
                RepositionPlayedCards(pnlPlayArea);
            }


            // if the AI hand is empty, redraw and check for win
            if (pnlComputerHand.Controls.Count == 0 || pnlPlayerHand.Controls.Count == 0)
            {
                RedrawCards(durakDeck, playerAttack);
                WinCheck(durakDeck);
            }

        }

        //Method for Player on attack, computer on defense
        public void ComputerDefend(CardBox playerCard)
        {
            //ensure buttons are visible
            btnPickUp.Visible = false;
            btnEndAttack.Visible = true;

            bool playMade = false; //bool to track if a play was made
            //logic to add a defend card from computer hand
            for (int i = 0; i < pnlComputerHand.Controls.Count && !playMade; i++)
            {
                CardBox aiCard = (CardBox)pnlComputerHand.Controls[i];
                if (aiCard.Suit == playerCard.Suit /*playerCard*/ || aiCard.Suit == trumpSuit)
                {
                    //card.Rank > cardBox.Rank
                    if (aiCard.Suit == trumpSuit)
                    {
                        if (playerCard.Suit == trumpSuit && aiCard.Rank > playerCard.Rank)
                        {
                            pnlComputerHand.Controls.Remove(aiCard);
                            //MessageBox.Show(aiCard.ToString() + " was played (if Trump valid)");
                            //flip the card as it is played
                            aiCard.FaceUp = true;
                            pnlPlayArea.Controls.Add(aiCard);

                            // remove a click event from a card in the playArea
                            // RemoveEvent(card);
                            //i += 100;
                            playMade = true;
                            RepositionPlayedCards(pnlPlayArea);
                            //break;
                        }
                        else if (aiCard.Rank < playerCard.Rank && playerCard.Suit != trumpSuit)
                        {
                            pnlComputerHand.Controls.Remove(aiCard);
                            //MessageBox.Show(aiCard.ToString() + " was played (ELSE trump valid)");
                            //flip the card as it is played
                            aiCard.FaceUp = true;
                            pnlPlayArea.Controls.Add(aiCard);
                            // remove border
                            // remove a click event from a card in the playArea
                            //RemoveEvent(card);
                            //i += 100;
                            playMade = true;
                            RepositionPlayedCards(pnlPlayArea);
                            //break;
                        }

                    }

                    else if (aiCard.Suit == playerCard.Suit && aiCard.Rank > playerCard.Rank)
                    {
                        pnlComputerHand.Controls.Remove(aiCard);
                        //MessageBox.Show(aiCard.ToString() + " was played (ELSE not trump)");
                        //flip the card as it is played
                        aiCard.FaceUp = true;
                        pnlPlayArea.Controls.Add(aiCard);

                        // remove a click event from a card in the playArea
                        //RemoveEvent(card);
                        //i += 100;
                        playMade = true;
                        RepositionPlayedCards(pnlPlayArea);
                        //break;
                    }
                }
                //end the for loop
                //if (playMade)
                //    i += 100;
                WinCheck(durakDeck);
            }

            // check for attack end.
            if (playMade == false)
            {
                for (int i = pnlPlayArea.Controls.Count - 1; i > -1; i--)
                {
                    //debugging for card indexes on table.
                    //MessageBox.Show(pnlPlayArea.Controls.Count + " cards on table.  Index is " + i);
                    CardBox card = (CardBox)pnlPlayArea.Controls[i];
                    pnlPlayArea.Controls.Remove(card);
                    //flip the card before entering computer hand
                    //card.FaceUp = !card.FaceUp;
                    pnlComputerHand.Controls.Add(card);
                    RemoveBorder(card);
                    //FlipAiHand(pnlComputerHand);
                    FlipAiHand(pnlComputerHand);
                    RepositionPlayedCards(pnlPlayArea);
                    playerAttackCounter = 0;
                }
                for (int i = 0; i < pnlPlayerHand.Controls.Count; i++)
                {
                    //re-enable player clickable hand
                    CardBox card = (CardBox)pnlPlayerHand.Controls[i];
                    if (!card.IsEventHandlerRegistered())
                    {
                        AddClickEvent(card);
                    }
                }
            }
            WinCheck(durakDeck);
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
                            if (!playerCard.IsEventHandlerRegistered())
                            {
                                AddClickEvent(playerCard);
                            }
                            //DrawBorder(playerCard);
                            //MessageBox.Show(playerCard.ToString() + " is clickable.");
                            //i += 100;
                            canPlay = true;
                        }
                        //else if the player card is trump and AI card is not trump
                        else if (playerCard.Suit == trumpSuit && computerCard.Suit != trumpSuit)
                        {
                            if (!playerCard.IsEventHandlerRegistered())
                            {
                                AddClickEvent(playerCard);
                            }
                            //DrawBorder(playerCard);
                            //MessageBox.Show(playerCard.ToString() + " is clickable.");
                            //i += 100;
                            canPlay = true;
                        }
                    }

                    // else if the suit is the same and the player's card is greater than the AI card.
                    else if (playerCard.Suit == computerCard.Suit && playerCard.Rank > computerCard.Rank)
                    {
                        if (!playerCard.IsEventHandlerRegistered())
                        {
                            AddClickEvent(playerCard);
                        }
                        //DrawBorder(playerCard);
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

        /// <summary>
        /// Draw a border on a card
        /// </summary>
        /// <param name="card">receives a card to </param>
        private void DrawBorder(CardBox card)
        {
            if (card != null)
            {
                card.BackgroundImageLayout = ImageLayout.Center;
                card.BackColor = Color.FromArgb(237, 117, 4);
                card.Padding = new Padding(3);

            }
        }

        /// <summary>
        /// Remove a border from a card
        /// </summary>
        /// <param name="card">Receives a card</param>
        private void RemoveBorder(CardBox card)
        {
            if (card != null)
            {
                card.Padding = new Padding(0);
                card.BorderStyle = BorderStyle.None;
            }
        }

        /// <summary>
        /// RedrawCards Method to redraw cards into player hands
        /// Uses a boolean to determine who gets their cards first.
        /// </summary>
        /// <param name="durakDeck">a Deck is required</param>
        /// <param name="playerAttack">boolean status of which player is attacking</param>
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
                            //check if the trump card has been dealt
                            if (pnlTrumpCard.Controls.Count > 0)
                            {
                                CardBox trumpCard = (CardBox)pnlTrumpCard.Controls[0];
                                pnlTrumpCard.Controls.Remove(trumpCard);
                                pnlPlayerHand.Controls.Add(trumpCard);
                                FlipPlayerHand(pnlPlayerHand);
                            }
                            //no cards are in the deck at a redraw, check to see if a player has won
                            else if (pnlTrumpCard.Controls.Count == 0)
                                WinCheck(durakDeck);

                            i += 100; //end the for since there are no cards left
                        }
                        else
                        {
                            //draw a card
                            card = durakDeck.DrawCard();
                            // adjust the cards label showing how many cards are left in the deck
                            lblCardsRemaining.Text = "Remaining: " + durakDeck.CardsRemaining.ToString();
                            //set the card faceup for a player hand
                            card.FaceUp = true;
                            CardBox cardBox = new CardBox(card);
                            //wire the click event to the cardbox
                            if (!cardBox.IsEventHandlerRegistered())
                            {
                                AddClickEvent(cardBox);
                            }
                            //add the card to the hand and realign the hand
                            pnlPlayerHand.Controls.Add(cardBox);
                            FlipPlayerHand(pnlPlayerHand);
                            RepositionPlayedCards(pnlPlayArea);
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
                            //check if the trump card has been dealt
                            if (pnlTrumpCard.Controls.Count > 0)
                            {
                                CardBox trumpCard = (CardBox)pnlTrumpCard.Controls[0];
                                pnlTrumpCard.Controls.Remove(trumpCard);
                                pnlComputerHand.Controls.Add(trumpCard);
                                card.FaceUp = false;
                                FlipAiHand(pnlComputerHand);
                            }
                            //no cards are in the deck at a redraw, check to see if a player has won
                            else if (pnlTrumpCard.Controls.Count == 0)
                                WinCheck(durakDeck);
                            i += 100; //no cards in the deck
                        }
                        else
                        {
                            //draw a card
                            card = durakDeck.DrawCard();
                            // adjsut the cards label showing how many cards are left in the deck
                            lblCardsRemaining.Text = "Remaining: " + durakDeck.CardsRemaining.ToString();
                            //card.FaceUp = true;  //not required for AI hands, use only for debugging
                            CardBox cardBox = new CardBox(card);
                            //add card to AI hand and realign the hand
                            pnlComputerHand.Controls.Add(cardBox);
                            FlipAiHand(pnlComputerHand);
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
                            pbDeck.Visible = false;  //deck is empty
                            //check if the trump card has been dealt
                            if (pnlTrumpCard.Controls.Count > 0)
                            {
                                CardBox trumpCard = (CardBox)pnlTrumpCard.Controls[0];
                                pnlTrumpCard.Controls.Remove(trumpCard);
                                pnlComputerHand.Controls.Add(trumpCard);
                                card.FaceUp = false;
                                FlipAiHand(pnlComputerHand);
                            }
                            //no cards are in the deck at a redraw, check to see if a player has won
                            else if (pnlTrumpCard.Controls.Count == 0)
                                WinCheck(durakDeck);

                            i += 100;
                        }
                        else
                        {
                            //draw a card
                            card = durakDeck.DrawCard();
                            // adjsut the cards label showing how many cards are left in the deck
                            lblCardsRemaining.Text = "Remaining: " + durakDeck.CardsRemaining.ToString();
                            //card.FaceUp = true;  //not required for AI hands, use only for debugging
                            CardBox cardBox = new CardBox(card);
                            //add card to AI hand and realign the hand
                            pnlComputerHand.Controls.Add(cardBox);
                            FlipAiHand(pnlComputerHand);
                        }
                    }

                    // for each card less than 6 in a player hand
                    for (int i = 1; i <= (6 - attackHandCount); i++)
                    {
                        Card card = new Card();
                        if (durakDeck.CardsRemaining <= 0)
                        {
                            pbDeck.Visible = false;  //deck is empty
                            //check if the trump card has been dealt
                            if (pnlTrumpCard.Controls.Count > 0)
                            {
                                CardBox trumpCard = (CardBox)pnlTrumpCard.Controls[0];
                                pnlTrumpCard.Controls.Remove(trumpCard);
                                pnlPlayerHand.Controls.Add(trumpCard);
                                FlipPlayerHand(pnlPlayerHand);

                            }
                            else if (pnlTrumpCard.Controls.Count == 0)
                                WinCheck(durakDeck);
                            i += 100; // deck is empty
                        }
                        else
                        {
                            //draw a card
                            card = durakDeck.DrawCard();
                            // adjsut the cards label showing how many cards are left in the deck
                            lblCardsRemaining.Text = "Remaining: " + durakDeck.CardsRemaining.ToString();
                            //set the card faceup for a player hand
                            card.FaceUp = true;
                            CardBox cardBox = new CardBox(card);
                            //wire the click event to the cardbox
                            if (!cardBox.IsEventHandlerRegistered())
                            {
                                AddClickEvent(cardBox);
                            }
                            //add the card to the hand and realign the hand
                            pnlPlayerHand.Controls.Add(cardBox);
                            FlipPlayerHand(pnlPlayerHand);
                            //MessageBox.Show(pnlPlayerHand.Controls.Count.ToString() + " cards in hand");
                        }
                    }
                }
            }
            else if (durakDeck.CardsRemaining == 0 && pnlTrumpCard.Controls.Count == 0) //there are no cards in the deck.
                WinCheck(durakDeck);
        }

        /// <summary>
        /// Method to check to see if a player has won the game
        /// </summary>
        /// <param name="durakDeck">requires the current durakDeck to begin if it is empty or not.</param>
        public void WinCheck(Deck durakDeck)
        {
            //MessageBox.Show("Calling win check...");
            if (winCheckPassed == false)
            {
               //MessageBox.Show("WinCheckPassed was false.");
                if (durakDeck.CardsRemaining == 0)
                {
                    //MessageBox.Show("No cards left in Durak deck check passed");
                    if (pnlPlayerHand.Controls.Count == 0 && pnlComputerHand.Controls.Count == 0)
                    {
                        winCheckPassed = true;
                        frmLog.WriteToLog("\nThere is no fool?! \n\nGame has ended in a tie.");
                        MessageBox.Show("There is no fool?! \n\nGame has ended in a tie.");
                        playerStats.ties += 1;
                        lblTies.Text = "Ties: " + playerStats.ties;
                        Stats.WriteStats(playerStats);
                        //MessageBox.Show("The game ended in a tie. Unmapping all control events except new game.");
                        if (pnlPlayerHand.Controls.Count > 0)
                        {
                            for (int i = (pnlPlayerHand.Controls.Count - 1); i > -1; i--)
                            {
                                CardBox cardBox = (CardBox)pnlPlayerHand.Controls[i];
                                RemoveClickEvent(cardBox);
                                //RemoveBorder(cardBox);
                            }
                        }
                        btnEndAttack.Visible = false;
                        btnPickUp.Visible = false;
                        btnForfeit.Visible = false;
                        //track stats
                    }
                    else if (pnlPlayerHand.Controls.Count > 0 && pnlComputerHand.Controls.Count == 0)
                    {
                        winCheckPassed = true;
                        frmLog.WriteToLog("\n" + "You're a fool! \n\n" + newAI.Name + " has won.");
                        MessageBox.Show("You're a fool! \n\n" + newAI.Name + " has won.");
                        playerStats.losses += 1;
                        lblLosses.Text = "Wins: " + playerStats.losses;
                        Stats.WriteStats(playerStats);
                        //MessageBox.Show("The AI Won. Unmapping all control events except new game.");
                        for (int i = (pnlPlayerHand.Controls.Count - 1); i > -1; i--)
                        {
                            CardBox cardBox = (CardBox)pnlPlayerHand.Controls[i];
                            RemoveClickEvent(cardBox);
                            //RemoveBorder(cardBox);
                        }
                        btnEndAttack.Visible = false;  // should already be not visible, but set it anyway
                        btnPickUp.Visible = false;
                        btnForfeit.Visible = false;
                        //track stats

                    }
                    else if (pnlPlayerHand.Controls.Count == 0 && pnlComputerHand.Controls.Count > 0)
                    {
                        winCheckPassed = true;
                        frmLog.WriteToLog("\n"+ newAI.Name + " is the fool! \n\n" + newPlayer.Name + " has won.");
                        MessageBox.Show(newAI.Name + " is the fool! \n\n" + newPlayer.Name + " has won.");
                        playerStats.wins += 1;
                        lblWins.Text = "Wins: " + playerStats.wins;
                        Stats.WriteStats(playerStats);
                        //MessageBox.Show("The player Won. Unmapping all control events except new game.");
                        for (int i = (pnlPlayerHand.Controls.Count - 1); i > -1; i--)
                        {
                            CardBox cardBox = (CardBox)pnlPlayerHand.Controls[i];
                            RemoveClickEvent(cardBox);
                            //RemoveBorder(cardBox);
                        }
                        btnEndAttack.Visible = false;
                        btnPickUp.Visible = false;
                        btnForfeit.Visible = false;
                        //track stats
                    }
                }
                //else no win condition found.  Keep playing.
            }
            //MessageBox.Show("End of win check.");
        }

        /// <summary>
        /// Reshuffles the Computer Hand and places a "best" defense card in the "Card-to-be-played" index
        /// </summary>
        public void HardAiDefense()
        {
            // set a cardbox to the last index added to the play area
            CardBox lastCard = (CardBox)pnlPlayArea.Controls[(pnlPlayArea.Controls.Count - 1)];
            List<CardBox> validPlays = new List<CardBox>(); // stores all playable cards for AI defense
            List<int> validIndexes = new List<int>();
            const int HIGH_PLAY = 42; //value of cards in the playarea
            //bool endLogic = false;  //tracks if we continue processing logic

            // look at AI hand 
            for (int i = (pnlComputerHand.Controls.Count - 1); i > -1; i--)
            {
                CardBox card = (CardBox)pnlComputerHand.Controls[i];

                // if card is trump, played Card is not trump and the lastCard played is a face card
                if (card.Suit == trumpSuit && lastCard.Suit != trumpSuit && (int)lastCard.Rank > 10)
                {
                    //MessageBox.Show("comparing " + card.ToString() + " with " + lastCard.ToString());
                    //if card is less than 4 rank values apart from the lastCard played - card can be playedy
                    if ((int)card.Rank <= ((int)lastCard.Rank - 3))
                    {
                        //MessageBox.Show("comparing " + card.ToString() + " with " + lastCard.ToString());
                        // store the card in the validPlays list
                        validPlays.Add(card);
                        validIndexes.Add(i);
                    }
                    // is the card in hand a 3 point difference from the card on the table
                    else if ((int)card.Rank >= ((int)lastCard.Rank + 3))
                    {
                        // total value of playArea to determine if the playArea is to be picked up
                        int cardSum = 0;
                        for (int playIndex = (pnlPlayArea.Controls.Count - 1); playIndex > -1; playIndex--)
                        {
                            CardBox rankCheck = (CardBox)pnlPlayArea.Controls[playIndex];
                            cardSum += (int)rankCheck.Rank;
                        }
                        if (cardSum > HIGH_PLAY)
                        {
                            PickUpCards(ref pnlComputerHand, true); // pick up cards in players
                            i -= 100; // end defense logic
                        }

                    }
                }
                // Card in hand is not a trump
                //if card value is higher than played card
                else /*if ((int)card.Rank > (int)lastCard.Rank && card.Suit == lastCard.Suit)*/
                {
                    //MessageBox.Show("comparing " + card.ToString() + " with " + lastCard.ToString());
                    //if card is less than 4 rank values apart from the lastCard played - card can be playedy
                    if ((int)card.Rank > (int)lastCard.Rank && card.Suit == lastCard.Suit)
                    {
                        //MessageBox.Show("comparing " + card.ToString() + " with " + lastCard.ToString());
                        // store the card in the validPlays list
                        validPlays.Add(card);
                        validIndexes.Add(i);
                    }
                    // is the card in hand a 3 point difference from the card on the table
                    else if ((int)card.Rank < ((int)lastCard.Rank + 3))
                    {
                        // total value of playArea to determine if the playArea is to be picked up
                        int cardSum = 0;
                        for (int playIndex = (pnlPlayArea.Controls.Count - 1); playIndex > -1; playIndex--)
                        {
                            CardBox rankCheck = (CardBox)pnlPlayArea.Controls[playIndex];
                            cardSum += (int)rankCheck.Rank;
                        }
                        if (cardSum > HIGH_PLAY)
                        {
                            PickUpCards(ref pnlComputerHand, true); // pick up cards in players
                            i -= 100; // end defense logic

                        }

                    }

                }
            }

            // check if the validPlays has more than 1 card
            if (validPlays.Count > 1)
            {
                for (int listIndex = 0; listIndex < validPlays.Count; listIndex++)
                {
                    CardBox card = validPlays[0];
                    // check for array out of bounds exception
                    if ((listIndex + 1) < validPlays.Count)
                    {
                        CardBox cardCompare = validPlays[listIndex + 1];
                        //if the card compared is smaller, set the card to index 0
                        if ((int)card.Rank < (int)cardCompare.Rank)
                        {
                            TempHand(validIndexes[0]);
                        }
                        else //sort the hand
                            TempHand(validIndexes[listIndex + 1]);
                    }
                }
            }
            else if (validPlays.Count == 1)
            {
                TempHand(validIndexes[0]);

            }
        }

        /// <summary>
        /// Reshuffles the computer hand and places the "best" attack card in the "Card-to-be-played" index
        /// </summary>
        public void HardAiAttack()
        {
            // Temporary hand to empty the computer hand into
            List<CardBox> tempHand = new List<CardBox>();

            for (int i = pnlComputerHand.Controls.Count - 1; i > -1; i--)
            {
                CardBox tempCard = (CardBox)pnlComputerHand.Controls[i];
                //MessageBox.Show("Moving " + tempCard.ToString() + " to temporary list.");
                tempHand.Add(tempCard);
            }

            //MessageBox.Show("Sorting List!");
            // Sorts the temp hand into a new list by rank from lowest to highest 
            // ONLY CHANGES THE INDEXES NOT THE PHYSICAL ORDER
            List<CardBox> SortedList = tempHand.OrderBy(o => (int)o.Rank).ToList();

            // Dumps the computer hand
            for (int i = pnlComputerHand.Controls.Count - 1; i > -1; i--)
            {
                CardBox tempCard = (CardBox)pnlComputerHand.Controls[i];
                //MessageBox.Show(tempCard.ToString());
                pnlComputerHand.Controls.Remove(tempCard);
            }

            // Fills computer hand with re-indexed cards
            for (int i = 0; i < SortedList.Count; i++)
            {
                CardBox tempCard = SortedList[i];
                //MessageBox.Show("Adding " + tempCard.ToString() + " to computer hand.");
                pnlComputerHand.Controls.Add(tempCard);
            }
        }

        /// <summary>
        /// Pick up the cards from the play area into a hand
        /// </summary>
        /// <param name="hand">the AI or Player hand</param>
        /// <param name="flipped">card flip status</param>
        public void PickUpCards(ref Panel hand, bool flipped)
        {
            pickUpCounter++;
            // call pick up cards method
            for (int i = (pnlPlayArea.Controls.Count - 1); i > -1; i--)
            {
                //Pick up play area cards and give them to the player
                //MessageBox.Show(i.ToString());
                CardBox card = (CardBox)pnlPlayArea.Controls[i];
                RemoveBorder(card);
                pnlPlayArea.Controls.Remove(card);
                card.FaceUp = flipped; //  changes the flip value of the card based on the bool passed.
                hand.Controls.Add(card);
                FlipPlayerHand(pnlPlayerHand);
            }
        }

        /// <summary>
        /// PlayerFirst() Logic to determine which player goes first 
        /// </summary>
        /// <returns>playerattack boolean</returns>
        private bool PlayerFirst()
        {
            //declare two cardboxes for comparison
            CardBox playerCard = (CardBox)pnlPlayerHand.Controls[0];
            CardBox aiCard = (CardBox)pnlComputerHand.Controls[0];

            //loop through the player hand for lowest trump card
            for (int i = 0; i < pnlPlayerHand.Controls.Count; i++)
            {
                CardBox tempCard = (CardBox)pnlPlayerHand.Controls[i];
                //MessageBox.Show(tempCard.Suit + ": TempCard vs  Trump: " + trumpSuit);
                if (tempCard.Suit == trumpSuit) // Check if the card from the hand is trump
                {
                    //MessageBox.Show("passed.");
                    //If the tempCard is less than the comparison card and the tempCard is also trump
                    if ((int)tempCard.Rank <= (int)playerCard.Rank && tempCard.Suit == trumpSuit)
                    {
                        playerCard = tempCard;
                        //MessageBox.Show("Card is now " + playerCard.ToString());
                    }
                }
            }
            //MessageBox.Show(playerCard.ToString() + " was chosen");

            //loop throught the AI hand for lowest trump card
            for (int i = 0; i < pnlComputerHand.Controls.Count; i++)
            {
                CardBox tempCard = (CardBox)pnlComputerHand.Controls[i];
                if (tempCard.Suit == trumpSuit)
                {
                    //MessageBox.Show("passed.");
                    //If the tempCard is less than the comparison card and the tempCard is also trump
                    if ((int)tempCard.Rank < (int)aiCard.Rank && tempCard.Suit == trumpSuit)
                    {
                        aiCard = tempCard;  // change the comparison card
                        //MessageBox.Show("Card is now " + aiCard.ToString());
                    }
                }
            }
            //MessageBox.Show(aiCard.ToString() + " was chosen");

            //Determine which of the comparison cards are lowest if they are trump
            if (playerCard.Suit == trumpSuit && aiCard.Suit == trumpSuit)
            {
                if ((int)playerCard.Rank < (int)aiCard.Rank)
                {
                    playerAttack = true;
                }
                else
                {
                    playerAttack = false;
                }
            }
            // playerCard is trump, but AI card is not
            else if (playerCard.Suit == trumpSuit && aiCard.Suit != trumpSuit)
            {
                playerAttack = true;
            }
            // aiCard is trump but playerCard is not
            else if (playerCard.Suit != trumpSuit && aiCard.Suit == trumpSuit)
            {
                playerAttack = false;

            }
            else
            {
                //// No player has trump
                int whoGoesFirst = randomNumber.Next(1, 10);   //randomizer since no player has trump
                if (whoGoesFirst % 2 == 0)
                {
                    playerAttack = true;
                }
                else
                {
                    playerAttack = false; // AI goes first
                }

            }


            return playerAttack;
        }

        /// <summary>
        /// Creates a temporary hand for card ordering
        /// </summary>
        /// <param name="index"></param>
        private void TempHand(int index)
        {
            //create a temp hand
            List<CardBox> tempHand = new List<CardBox>();
            CardBox sourceCard = new CardBox();

            //for each card in the hand
            for (int i = 0; i < pnlComputerHand.Controls.Count; i++)
            {
                //store the hand into the temporary hand
                sourceCard = (CardBox)pnlComputerHand.Controls[i];
                tempHand.Add(sourceCard);
            }

            if (pnlComputerHand.Controls.Count > 0)  //if there are cards in the hand
            {
                // empty the hand
                for (int k = (pnlComputerHand.Controls.Count - 1); k > -1; k--)
                {
                    sourceCard = (CardBox)pnlComputerHand.Controls[k];
                    pnlComputerHand.Controls.Remove(sourceCard);
                }
            }
            CardBox transferCard = tempHand[index];
            //MessageBox.Show(transferCard.ToString() + " will be shuffled to index 0.");
            int tempHandSize = tempHand.Count;

            tempHand.Remove(transferCard);
            pnlComputerHand.Controls.Add(transferCard);
            tempHandSize = tempHand.Count;
            //MessageBox.Show(tempHandSize + " cards remain in tempHand ");
            // populate the rest of the hand
            for (int j = (tempHandSize - 1); j > -1; j--)
            {
                //MessageBox.Show("card from tempHand "+ j.ToString() + " index will be re-inserted");
                transferCard = tempHand[j];
                tempHand.Remove(transferCard);
                pnlComputerHand.Controls.Add(transferCard);
            }
            FlipAiHand(pnlComputerHand);
        }

        private void FlipAiHand(Panel computerHand)
        {
            for (int i = computerHand.Controls.Count - 1; i > -1; i--)
            {
                CardBox tempCard = (CardBox)computerHand.Controls[i];

                tempCard.FaceUp = false;
            }

            RealignCards(computerHand);
        }

        private void FlipPlayerHand(Panel playerHand)
        {
            for (int i = playerHand.Controls.Count - 1; i > -1; i--)
            {
                CardBox tempCard = (CardBox)playerHand.Controls[i];

                tempCard.FaceUp = true;
            }

            RealignCards(playerHand);
        }

        #endregion
    }
}
