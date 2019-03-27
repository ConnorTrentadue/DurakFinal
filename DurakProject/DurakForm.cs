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

        private void lblGameNumber_Click(object sender, EventArgs e)
        {

        }

        private void lblRoundNumber_Click(object sender, EventArgs e)
        {

        }

        private void lblWins_Click(object sender, EventArgs e)
        {

        }

        private void lblTies_Click(object sender, EventArgs e)
        {

        }

        private void lblLosses_Click(object sender, EventArgs e)
        {

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
            
            // shuffle the new deck.
            durakDeck.Shuffle();

            // Set the deck image to a card back image
            pbDeck.Image = durakDeck.ElementAt(0).GetCardImage();

            // Show the number of cards in the deck
            //lblCardsRemaining.Text = cards.CardsRemaining.ToString();

            //deal 12 cards, (6 each) to the players.
            //alternate the cards into each player's hand

            // set the image of the trump card
            pbTrumpCard.Image = (new Card()).GetCardImage();
            pbTrumpIndicator.Image = (new Card()).GetCardImage();
        }

        private void btnForfeit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
