/*
 * DeckSize.cs - The application form for changing deck size.
 * 
 * Author: Raymond Michael, Shaun McCrum
 * Since: 10 Apr 2019
 */

using System;
using System.Windows.Forms;

namespace DurakProject
{
    /// <summary>
    /// Class for initializing player skill level
    /// </summary>
    public partial class frmDeckSize : Form
    {
        public frmDeckSize()
        {
            InitializeComponent();
        }

        public int DeckSize
        {
            get
            {
                if (rbtnTenToAce.Checked)
                {
                    return 10;
                }
                else if (rbtnSixToAce.Checked)
                {
                    return 6;
                }
                else if (rbtnStandardDeck.Checked)
                {
                    return 2;
                }
                else
                    return 6;
            }
        }
        /// <summary>
        /// Submit button submission
        /// </summary>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (rbtnTenToAce.Checked)
                DialogResult = DialogResult.OK;
            if (rbtnSixToAce.Checked)
                DialogResult = DialogResult.OK;
            if (rbtnStandardDeck.Checked)
                DialogResult = DialogResult.OK;
        }
    }
}
