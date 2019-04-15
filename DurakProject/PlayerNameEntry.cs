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
