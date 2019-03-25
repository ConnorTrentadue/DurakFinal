/*
 * Cardbox.cs - Cardbox class for a custom user control that holds cards.
 * 
 * Author: Connor Trentadue, Raymond Michael, Shaun McCrum
 * Since: 24 Mar 2019
 * @see <https://www.youtube.com/watch?v=-n21vAPvrtg&list=PLfNfAX7mRzNrF6dkHk31E4xEINXUFe5IM>
 * 
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace DurakClassLibrary
{
    /// <summary>
    /// A control to use in Windows Forms Application to display a playing card
    /// </summary>
    public partial class cbCardBox : UserControl
    {
        #region Fields and Properties
        /// <summary>
        /// Card Property  - Set/Get the card object
        /// </summary>
        private Card myCard;
        public Card Card
        {
            set
            {
                myCard = value;
                UpdateCardImage(); //updates the card image.
            }
            get { return Card; }
        }


        /// <summary>
        /// Suit Property  - Set/Get the card object suit
        /// </summary>
        public Suit Suit
        {
            set
            {
                Card.Suit = value;
                UpdateCardImage();
            }
            get { return Card.Suit; }
        }

        /// <summary>
        /// Rank Property  - Set/Get the card object rank
        /// </summary>
        public Rank Rank
        {
            set
            {
                Card.Rank = value;
                UpdateCardImage();
            }
            get { return Card.Rank; }
        }

        /// <summary>
        /// FaceUp Property  - Set/Get the card object FaceUp property
        /// </summary>
        public bool FaceUp
        {
            set
            {
                //if the value is different than the card's FaceUp property
                if (Card.FaceUp != value)
                {
                    Card.FaceUp = value;  // change the card's FaceUp value
                    UpdateCardImage();  //updates the card's image
                    //if there is a handler for the CardFlipped delegate in teh client program
                    CardFlipped?.Invoke(this, new EventArgs());     // call  it with new event args since we don't pass anything
                }
            }
            get { return Card.FaceUp; }
        }

        /// <summary>
        /// CardOrientation Property - sets/gets the orientation of the card
        /// if the setting this changes the property of the control, swap
        /// the height and width of the control and update the image.
        /// </summary>
        private Orientation myOrientation;
        public Orientation CardOrientation
        {
            set
            {
                // if the value differs from my orientation
                myOrientation = value;       // change the orientation
                this.Size = new Size(Size.Height, Size.Width);  //change the height of the control
                UpdateCardImage();  //update the card image
            }
            get { return myOrientation; }
        }

        /// <summary>
        /// Updates the card image
        /// </summary>
        private void UpdateCardImage()
        {
            //set the image using the card object
            pbMyPictureBox.Image = myCard.GetCardImage();
            //if the orientation is horizontal
            //if (myOrientation == Orientation.Horizontal)
            //{
            //    //rotate the image
            //    pbMyPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone); // Remove to not flip card
            //}
        }

        #endregion

        #region EVENTS AND HANDLERS
        /// <summary>
        /// Event handler for the load event
        /// </summary>
        private void Cardbox_Load(object sender, EventArgs e)
        {
            UpdateCardImage();
        }

        /// <summary>
        /// Event the client program will handle when the card flips face up / down
        /// </summary>
        public event EventHandler CardFlipped;

        /// <summary>
        /// Event the client program will handle when the user clicks the control
        /// </summary>
        new public event EventHandler Click;

        /// <summary>
        /// Event handler for the clicking of the picturebox control
        /// </summary>
        private void pbMyPictureBox_Click(object sender, EventArgs e)
        {
            //if there is a hander for clicking the control in the client that is not null
            Click?.Invoke(this, e); // call the event
        }
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Default Constructor - constructs the control with a new card with vertical orientation
        /// </summary>
        public cbCardBox()
        {
            InitializeComponent(); //required  method for designer support
            myOrientation = Orientation.Vertical; //set the orientation
            myCard = new Card(); //create a card
        }


        /// <summary>
        /// Constructor (Card, Orientation) creates the control with parameters
        /// </summary>
        /// <param name="card">Card object</param>
        /// <param name="orientation">Orientation enumeration</param>
        public cbCardBox(Card card, Orientation or = Orientation.Vertical)
        {
            InitializeComponent(); //required  method for designer support
            myOrientation = or; //set the orientation
            myCard = card; //create a card
        }
        #endregion

        #region OTHER METHODS
        /// <summary>
        /// ToString - overrides System.Object.ToString()
        /// </summary>
        /// <returns> the name of the card as string</returns>
        public override string ToString()
        {
            return myCard.ToString();
        }

        #endregion
    }
}
