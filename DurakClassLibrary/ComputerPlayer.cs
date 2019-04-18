/*
 * ComputerPlayer.cs - Computer Player class for creating computer players.
 * 
 * Author: Raymond Michael
 * Since: 24 Mar 2019
 * 
 */

namespace DurakClassLibrary
{
    /// <summary>
    /// ComputerPlayer class; inherits from Player class
    /// </summary>
    public class ComputerPlayer : Player
    {
        /// <summary>
        /// Difficulty parameter used to determine AI skill
        /// </summary>
        public int AiDifficulty { get; private set; } 

        /// <summary>
        /// Parameterized Constructor.
        /// Calls Player class constructor and passses it a name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="difficulty"></param>
        public ComputerPlayer(string name, int difficulty) : base (name) { AiDifficulty = difficulty; }
    }
}
