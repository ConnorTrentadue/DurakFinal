
namespace DurakClassLibrary
{
    public class Player
    {
        #region CONSTRUCTORS AND FIELD PROPERTIES
        public string Name { get; private set; }

        public Cards Hand { get; private set; }

        public Player() { }

        public Player(string name)
        {
            Name = name;
            Cards PlayHand = new Cards();
        }
        #endregion

        #region METHODS
        /// <summary>
        /// isEmpty boolean method to determine if the hand is empty
        /// </summary>
        /// <returns>is empty</returns>
        public bool HandEmpty()
        {
            bool isEmpty = false;

            if (Hand.Count == 0)
            {
                isEmpty = true;
            }

            return isEmpty;
        }
        #endregion

    }
}
