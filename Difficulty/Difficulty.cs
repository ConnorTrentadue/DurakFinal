using System;
using System.Windows.Forms;

namespace Difficulty
{
    public partial class Difficulty : UserControl
    {
        #region FIELDS AND PROPERTIES

        /// <summary>
        /// holds the AI difficulty setting to be used in another form.
        /// </summary>
        private int difficultyChoice = 1;

        public Difficulty Card
        {
            set
            {
                difficultyChoice = value;
                 
            }
            get { return difficultyChoice; }
        }

        #endregion

        public Difficulty()
        {
            InitializeComponent();
            /// <summary>
            /// holds the AI difficulty setting to be used in another form.
            /// </summary>
        }


        private void Difficulty_Load(object sender, EventArgs e)
        {
            rbtnBasicAI.Checked = true;

        }

        //new public event EventHandler Click;

        public void btnSetAI_Click(object sender, EventArgs e)
        {
            if (rbtnBasicAI.Checked == true)
            {
                difficultyChoice = 1;
            }

            else if (rbtnMediumAI.Checked == true)
            {
                difficultyChoice = 2;
            }

            else if (rbtnHardAI.Checked == true)
            {
                difficultyChoice = 3;
            }

        }

    }
}
