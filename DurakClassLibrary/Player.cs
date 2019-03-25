
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
            
            if(Hand.Count == 0 && deck.isEmpty())
            {
                winner = true;
            }

            return winner;
        }
    }
}
