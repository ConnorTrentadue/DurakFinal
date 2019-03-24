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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //pnlDeck.BackgroundImage = new Card()).GetCardImage();
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
    }
}
