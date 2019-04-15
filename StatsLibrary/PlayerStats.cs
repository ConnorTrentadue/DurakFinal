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

        protected string myPlayerName;
        public string playerName
        {
            get { return myPlayerName; }
            set { myPlayerName = value; }
        }

        protected int myGamesPlayed;
        public int gamesPlayed
        {
            get { return myGamesPlayed; }
            set { myGamesPlayed = value; }
        }

        protected int myRound;
        public int round
        {
            get { return myRound; }
            set { myRound = value; }
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
            this.myPlayerName = "";
            this.myGamesPlayed = 0;
            this.myRound = 0;
            this.myWins = 0;
            this.myLosses = 0;
            this.myTies = 0;
        }

        public PlayerStats(string playerName, int gamesPlayed, int round, int wins, int losses, int ties)
        {
            this.myPlayerName = playerName;
            this.myGamesPlayed = gamesPlayed;
            this.myRound = round;
            this.myWins = wins;
            this.myLosses = losses;
            this.myTies = ties;
        }

        public string toJson()
        {
            StringBuilder jsonBuilder = new StringBuilder();

            jsonBuilder.Append("{ \nplayerName: @playerName, \ngamesPlayed: @gamesPlayed, \nround: @round, \nwins: @wins, \nlosses: @losses, \nties: @ties\n}");
            jsonBuilder.Replace("@playerName", myPlayerName.ToString())
                .Replace("@gamesPlayed", myGamesPlayed.ToString())
                .Replace("@round", myRound.ToString())
                .Replace("@wins", myWins.ToString())
                .Replace("@losses", myLosses.ToString())
                .Replace("@ties", myTies.ToString());

            return jsonBuilder.ToString();
        }

        public string GetInfo()
        {
            StringBuilder info = new StringBuilder();

            info.Append("{\nplayerName: @playerName \ngamesPlayed: @gamesPlayed, \nround: @round, \nwins: @wins, \nlosses: @losses, \nties: @ties\n}");
            info.Replace("@playerName", myPlayerName.ToString())
                .Replace("@gamesPlayed", myGamesPlayed.ToString())
                .Replace("@round", myRound.ToString())
                .Replace("@wins", myWins.ToString())
                .Replace("@losses", myLosses.ToString())
                .Replace("@ties", myTies.ToString());

            return info.ToString();
        }

    }
}
