using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsLibrary
{
    public class PlayerStats
    {

        #region FIELDS AND PROPERTIES

        protected int myGamesPlayed;
        public int gamesPlayed
        {
            get { return myGamesPlayed; }
            set { myGamesPlayed = value; }
        }

        protected int myWins;
        public int wins
        {
            get { return myWins; }
            set { myWins = value; }
        }

        protected int myLosses;
        public int losses
        {
            get { return myLosses; }
            set { myLosses = value; }
        }

        protected int myTies;
        public int ties
        {
            get { return myTies; }
            set { myTies = value; }
        }

        #endregion

        public PlayerStats()
        {
            this.myGamesPlayed = 0;
            this.myWins = 0;
            this.myLosses = 0;
            this.myTies = 0;
        }

        public PlayerStats(int gamesPlayed, int wins, int losses, int ties)
        {
            this.myGamesPlayed = gamesPlayed;
            this.myWins = wins;
            this.myLosses = losses;
            this.myTies = ties;
        }

        public string toJson()
        {
            StringBuilder jsonBuilder = new StringBuilder();

            jsonBuilder.Append("{ \ngamesPlayed: @gamesPlayed, \nwins: @wins, \nlosses: @losses, \nties: @ties\n}");
            jsonBuilder.Replace("@gamesPlayed", myGamesPlayed.ToString())
                .Replace("@wins", myWins.ToString())
                .Replace("@losses", myLosses.ToString())
                .Replace("@ties", myTies.ToString());

            return jsonBuilder.ToString();
        }

        public string GetInfo()
        {
            StringBuilder info = new StringBuilder();

            info.Append("{ \ngamesPlayed: @gamesPlayed, \nwins: @wins, \nlosses: @losses, \nties: @ties\n}");
            info.Replace("@gamesPlayed", myGamesPlayed.ToString())
                .Replace("@wins", myWins.ToString())
                .Replace("@losses", myLosses.ToString())
                .Replace("@ties", myTies.ToString());

            return info.ToString();
        }

    }
}
