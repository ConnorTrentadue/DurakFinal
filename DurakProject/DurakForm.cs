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
            for(int i = 1; i <= 6 /* * playerCount */; i++)
            {
                card = durakDeck.DrawCard();
                CardBox aCardBox = new CardBox(card);

                if(i % 2 == 0)
                {
                    pnlPlayerHand.Controls.Add(aCardBox);
                }
                else
                {
                    pnlComputerHand.Controls.Add(aCardBox);
                }
            }           

            // set the trump suit for this game.
            Card trumpCard = durakDeck.DrawCard();
            //trumpCard.FaceUp = true;
            Suit trumpSuit = durakDeck.GetCard(0).Suit;
            // set the image of the trump card
            pbTrumpCard.Image = durakDeck.GetCard(0).GetCardImage();
            pbTrumpIndicator.Image = pbTrumpCard.Image;
        }

        private void btnForfeit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
