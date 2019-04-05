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
 **/

using System;
using DurakClassLibrary;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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

        int difficultyChoice = 1; //Stores difficulty that player chooses and determines the AI's moves.

        //Declares new computer player
        ComputerPlayer newAI;

        //Declares new human player
        Player newPlayer;

        //Computer names array
        string[] computerNames = new string[]
        {"Salvatore", "Leigh", "Wilmer", "Max",
         "Fredric", "Clifford", "Isiah", "Lucio",
         "Jess", "Leonard", "Marth", "Reginia",
         "Sharri", "Madonna", "Wilhemina", "Jennie",
         "Joanne", "Hermila", "Violette", "Trina"};

        string playerName = "THE MAN";

        //declare a trumpSuit  to hold trump suit values
        Suit trumpSuit = Suit.Clubs;
        // declare a cardRank  to hold card rank values
        Rank cardRank = Rank.Ace;

        //declare a cardSuit to hold card suit values
        Suit cardSuit = Suit.Clubs;

        static private Size regularSize = new Size(75, 108);
        #endregion

        public frmDurak()
        {
            InitializeComponent();
        }

        private void frmDurak_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Initializes the card dealer/deck on form Load.
            /// </summary>

            // Set the deck image to a card back image
            // pbDeck.Image = (new Card()).GetCardImage();
        }

        /// <summary>
        /// New game clears out previous game session.  Creates a new deck and deals 6 cards to each player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            pnlComputerHand.Controls.Clear();
            pnlPlayerHand.Controls.Clear();
            pnlTrumpCard.Controls.Clear();
            pnlPlayArea.Controls.Clear();
            pnlDiscard.Controls.Clear();

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
            Deck durakDeck = new Deck();
            Card card = new Card();

            // shuffle the new deck.
            durakDeck.Shuffle();

            // Set the deck image to a card back image
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
                    card.FaceUp = false;  //uncomment this to enable AI cards faceUp
                    CardBox computerCardBox = new CardBox(card);
                    pnlComputerHand.Controls.Add(computerCardBox);
                }
            }

            RealignCards(pnlPlayerHand);
            RealignCards(pnlComputerHand);

            // set the trump suit for this game.
            Card trumpCard = durakDeck.DrawCard();
            CardBox aTrumpCardbox = new CardBox(trumpCard);
            trumpCard.FaceUp = true;

            pnlTrumpCard.Controls.Add(aTrumpCardbox);
            //MessageBox.Show(trumpCard.ToString());
            trumpSuit = trumpCard.Suit;
            // set the image of the trump card
            //pnlTrumpCard.Image = trumpCard.GetCardImage();
            //pnlTrumpIndicator.Image = pbTrumpCard.Image;

            //lblCardsRemaining.Text = durakDeck.CardsRemaining.ToString(); //NOTE: This line isn't working correctly but, it should be
        }

        private void btnForfeit_Click(object sender, EventArgs e)
        {
            //close the program
            this.Close();
        }


        #region CARDBOX EVENT HANDLERS

        public void CardBox_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("It works!");
            //convert the sender
            CardBox aCardBox = sender as CardBox;
            bool validPlay = true;

            if (pnlPlayArea.Controls.Count == 0)
            {
                //remove from player hand
                pnlPlayerHand.Controls.Remove(aCardBox);
                //add the card to the play area
                //requires location mapping
                //MessageBox.Show("Card Removed!");
                pnlPlayArea.Controls.Add(aCardBox);
                pnlDiscard.Controls.Add(aCardBox);
                MessageBox.Show(pnlDiscard.Controls.Count.ToString());

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
                MessageBox.Show(aCardBox.ToString() + " is not a valid card");
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

        public void MakeNormalPlay(CardBox cardBox, int playCount, int duplicateCards = 0)
        {
            bool playMade = false;

            switch (playCount)
            {
                case 1:

                    //logic to add a defend card from computer hand
                    for (int i = 0; i < pnlComputerHand.Controls.Count; i++)
                    {
                        CardBox card = (CardBox)pnlComputerHand.Controls[i];
                        if (card.Suit == cardBox.Suit && card.Rank > cardBox.Rank)
                        {
                            
                            pnlComputerHand.Controls.Remove(card);
                            //flip the card as it is played
                            card.FaceUp = true;
                            pnlPlayArea.Controls.Add(card);

                            // remove a cllick event from a card in the playArea
                            //RemoveEvent(card);
                            i += 100;
                            playMade = true;
                            RealignCards(pnlPlayArea);
                        }
                    }

                    // check for attack end.
                    if (playMade == false)
                    {
                        //MessageBox.Show("PlayNot made");
                        pnlPlayArea.Controls.Remove(cardBox);
                        //flip the card before entering computer hand
                        cardBox.FaceUp = false;
                        pnlComputerHand.Controls.Add(cardBox);
                        RealignCards(pnlComputerHand);
                        //reset the attack counter
                        playerAttackCounter = 0;


                    }

                    break;
                case 2:
                    //logic to add a defend card from computer hand
                    for (int i = 0; i < pnlComputerHand.Controls.Count; i++)
                    {
                        CardBox card = (CardBox)pnlComputerHand.Controls[i];
                        if (card.Suit == cardBox.Suit && card.Rank > cardBox.Rank)
                        {
                            pnlComputerHand.Controls.Remove(card);
                            //flip the card as it is played
                            card.FaceUp = true;
                            pnlPlayArea.Controls.Add(card);
                            i += 100;
                            playMade = true;
                        }
                    }

                    // check for attack end.
                    if (playMade == false)
                    {
                        //MessageBox.Show("Play Not made");
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

                    break;
                case 3:
                    //logic to add a defend card from computer hand
                    for (int i = 0; i < pnlComputerHand.Controls.Count; i++)
                    {
                        CardBox card = (CardBox)pnlComputerHand.Controls[i];
                        if (card.Suit == cardBox.Suit && card.Rank > cardBox.Rank)
                        {
                            pnlComputerHand.Controls.Remove(card);
                            //flip the card as it is played
                            card.FaceUp = true;
                            pnlPlayArea.Controls.Add(card);
                            i += 100;
                            playMade = true;
                        }
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
                            card.FaceUp = false;
                            pnlComputerHand.Controls.Add(card);
                            RealignCards(pnlComputerHand);
                            RealignCards(pnlPlayArea);
                            playerAttackCounter = 0;
                        }

                    }

                    break;
                case 4:
                    //logic to add a defend card from computer hand
                    for (int i = 0; i < pnlComputerHand.Controls.Count; i++)
                    {
                        CardBox card = (CardBox)pnlComputerHand.Controls[i];
                        if (card.Suit == cardBox.Suit && card.Rank > cardBox.Rank)
                        {
                            pnlComputerHand.Controls.Remove(card);
                            //flip the card as it is played
                            card.FaceUp = true;
                            pnlPlayArea.Controls.Add(card);
                            i += 100;
                            playMade = true;
                        }
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
                            card.FaceUp = false;
                            pnlComputerHand.Controls.Add(card);
                            RealignCards(pnlComputerHand);
                            RealignCards(pnlPlayArea);
                            playerAttackCounter = 0;
                        }

                    }
                    break;
                case 5:
                    //logic to add a defend card from computer hand
                    for (int i = 0; i < pnlComputerHand.Controls.Count; i++)
                    {
                        CardBox card = (CardBox)pnlComputerHand.Controls[i];
                        if (card.Suit == cardBox.Suit && card.Rank > cardBox.Rank)
                        {
                            pnlComputerHand.Controls.Remove(card);
                            //flip the card as it is played
                            card.FaceUp = true;
                            pnlPlayArea.Controls.Add(card);
                            i += 100;
                            playMade = true;
                        }
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
                            card.FaceUp = false;
                            pnlComputerHand.Controls.Add(card);
                            RealignCards(pnlComputerHand);
                            RealignCards(pnlPlayArea);
                            playerAttackCounter = 0;
                        }

                    }
                    break;
                case 6:
                    //logic to add a defend card from computer hand
                    for (int i = 0; i < pnlComputerHand.Controls.Count; i++)
                    {
                        CardBox card = (CardBox)pnlComputerHand.Controls[i];
                        if (card.Suit == cardBox.Suit && card.Rank > cardBox.Rank)
                        {
                            pnlComputerHand.Controls.Remove(card);
                            //flip the card as it is played
                            card.FaceUp = true;
                            pnlPlayArea.Controls.Add(card);
                            i += 100;
                            playMade = true;
                        }
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
                            card.FaceUp = false;
                            pnlComputerHand.Controls.Add(card);
                            RealignCards(pnlComputerHand);
                            RealignCards(pnlPlayArea);
                            playerAttackCounter = 0;
                        }

                    }
                    break;
                default:
                    break;
            }

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
            //remove the event handler 
            card.Click += CardBox_Click;
        }

        private void btnEndAttack_Click(object sender, EventArgs e)
        {
            //send cards to discard pile
            for (int i = pnlPlayArea.Controls.Count - 1; i > -1; i--)
                {
                    CardBox card = (CardBox)pnlPlayArea.Controls[i];
                    pnlPlayArea.Controls.Remove(card);
                    pnlDiscard.Controls.Add(card);
                    RealignCards(pnlPlayerHand);
                    RealignCards(pnlComputerHand);
            }
        }
    }
}
