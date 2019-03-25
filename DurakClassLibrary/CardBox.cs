using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakClassLibrary
{
    public partial class CardBox : UserControl
    {

        private Card myCard;
        public Card card
        {
            set
            {
                myCard = value;
                UpdateCardImage();
            }
            get { return card; }
        }

        public Suit suit
        {
            set
            {
                card.Suit = value;
                UpdateCardImage();
            }
            get { return card.Suit; }
        }

        public Rank rank
        {
            set
            {
                card.Rank = value;
                UpdateCardImage();
            }
            get { return card.Rank; }
        }

        public bool FaceUp
        {
            set
            {
                if(card.FaceUp != value)
                {
                    card.FaceUp = value;
                    UpdateCardImage();

                    if(CardFlipped != null)
                    {
                        CardFlipped(this, new EventArgs());
                    }
                }
            }
            get { return card.FaceUp; }
        }

        private Orientation myOrientation;
        public Orientation CardOrientation
        {
            set
            {
                if(myOrientation != null)
                {
                    myOrientation = value;
                    this.Size = new Size(Size.Height, Size.Width);
                    UpdateCardImage();
                }
            }
            get { return myOrientation; }
        }

        private void UpdateCardImage()
        {
            pbMyPictureBox.Image = myCard.GetCardImage();

            if(myOrientation == Orientation.Horizontal)
            {
                pbMyPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone); // Remove to not flip card
            }
        }

        public CardBox()
        {
            InitializeComponent();
            myOrientation = Orientation.Vertical;
            myCard = new Card();
        }

        public CardBox(Card card, Orientation or = Orientation.Vertical)
        {
            InitializeComponent();
            myOrientation = or;
            myCard = card;
        }

        private void Cardbox_Load(object sender, EventArgs e)
        {
            UpdateCardImage();
        }

        public event EventHandler CardFlipped;

        new public event EventHandler Click;

        private void pbMyPictureBox_Click(object sender, EventArgs e)
        {
            if (Click != null)
                Click(this, e);
        }

        public override string ToString()
        {
            return myCard.ToString();
        }
    }
}
