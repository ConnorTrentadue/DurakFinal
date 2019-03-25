
namespace DurakClassLibrary
{
    class Player
    {
        public string Name { get; private set; }

        public Cards Hand { get; private set; }

        private Player() { }

        public Player(string name)
        {
            Name = name;
            Cards PlayHand = new Cards();
        }
        
        public bool HandEmpty()
        {
            bool isEmpty = false;
            
            if(Hand.Count == 0)
            {
                isEmpty = true;
            }

            return isEmpty;
        }
    }
}
