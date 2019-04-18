/*
 * PlayerNaem Entry.cs - The form for adding a player name.
 * 
 * Author: Raymond Michael
 * Since: 10 Apr 2019
 */
using System;
using System.Windows.Forms;

namespace DurakProject
{
    public partial class frmPlayerNameEntry : Form
    {
        public frmPlayerNameEntry()
        {
            InitializeComponent();
        }

        public string PlayerName
        {
            get { return txtNameEntry.Text; }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
