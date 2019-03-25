using System;
using System.Drawing;
using System.Windows.Forms;

namespace DurakClassLibrary
{
    public partial class cbCardBox : UserControl
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
                if (card.FaceUp != value)
                {
                    card.FaceUp = value;
                    UpdateCardImage();

                    CardFlipped?.Invoke(this, new EventArgs());
                }
            }
            get { return card.FaceUp; }
        }

        private Orientation myOrientation;
        public Orientation CardOrientation
        {
            set
            {
                myOrientation = value;
                this.Size = new Size(Size.Height, Size.Width);
                UpdateCardImage();
            }
            get { return myOrientation; }
        }

        private void UpdateCardImage()
        {
            pbMyPictureBox.Image = myCard.GetCardImage();

            if (myOrientation == Orientation.Horizontal)
            {
                pbMyPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone); // Remove to not flip card
            }
        }

        public cbCardBox()
        {
            InitializeComponent();
            myOrientation = Orientation.Vertical;
            myCard = new Card();
        }

        public cbCardBox(Card card, Orientation or = Orientation.Vertical)
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
            Click?.Invoke(this, e);
        }

        public override string ToString()
        {
            return myCard.ToString();
        }
    }
}
