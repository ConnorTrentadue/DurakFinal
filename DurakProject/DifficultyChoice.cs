/*
 * DifficultyChoice.cs - The application form for changing difficulties.
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
    public partial class frmDifficultyChoice : Form
    {
        public frmDifficultyChoice()
        {
            InitializeComponent();
        }

        public int DifficultyValue
        {
            get
            {
                if (rbtnEasyMode.Checked)
                {
                    return 1;
                }
                else if (rbtnMediumMode.Checked)
                {
                    return 2;
                }
                else if (rbtnHardMode.Checked)
                {
                    return 3;
                }
                else
                    return 1;
            }
        }
        /// <summary>
        /// Submit button submission
        /// </summary>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(rbtnEasyMode.Checked)
                DialogResult = DialogResult.OK;
            if(rbtnMediumMode.Checked)
                DialogResult = DialogResult.OK;
            if(rbtnHardMode.Checked)
                DialogResult = DialogResult.OK;
        }
    }
}
