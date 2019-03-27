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

using DurakClassLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DurakProject
{
    public partial class frmDurak : Form
    {

        static private Size baseSize = new Size(75, 108);

        private Deck newDeck = new Deck();

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
            //pnlDeck.BackgroundImage = new Card()).GetCardImage();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            newDeck.Shuffle();

            Card card = new Card();

            card = newDeck.DrawCard();
        }
    }
}
