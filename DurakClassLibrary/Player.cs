
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

        public bool WinnerCheck()
        {
            bool winner = false;
            
            if(Hand.count == 0 && Deck.isEmpty())
            {
                winner = true;
            }

            return winner;
        }
    }
}
