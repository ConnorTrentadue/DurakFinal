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
