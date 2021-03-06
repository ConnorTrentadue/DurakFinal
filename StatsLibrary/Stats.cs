﻿/*
 * Stats.cs - The class for defining player logged stats.
 * 
 * Author: Raymond Michael, Shaun McCrum
 * Since: 10 Apr 2019
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;


namespace StatsLibrary
{
    public class Stats
    {

        const string STATS_PATH = "Log/stats.json";
        const string LOG_PATH = "Log/log.txt";

        /// <summary>
        /// WriteStats writes statistics to the file
        /// </summary>
        /// <param name="player">Player statistics object</param>
        public static void WriteStats(PlayerStats player)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Log"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Log");

            using (StreamWriter writer = new StreamWriter(STATS_PATH /**, true REMOVE WHEN WANT MULTIPLE PLAYER STATS**/))
            {
                if(player != null) {
                    writer.WriteLine(player.toJson());
                }
                writer.Close();
            }
        }

        /// <summary>
        /// WriteLog writes to a file
        /// </summary>
        /// <param name="toWrite">stat to be written</param>
        public static void WriteLog(string toWrite)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Log"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Log");

            using (StreamWriter writer = new StreamWriter(LOG_PATH, true))
            {
                writer.WriteLine(toWrite);
                writer.WriteLine("----------------------");
            }
        }

        /// <summary>
        /// ReadStats reads jSon from the file
        /// </summary>
        /// <returns>playerstats object</returns>
        public static PlayerStats ReadStats()
        {
            PlayerStats aPlayerStats = new PlayerStats();

            if(Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Log"))
            {
                if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + STATS_PATH))
                {
                    using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + STATS_PATH))
                    {
                        string json = reader.ReadToEnd();
                        var serializer = new JavaScriptSerializer();
                        aPlayerStats = serializer.Deserialize<PlayerStats>(json);
                        if (aPlayerStats == null)
                            aPlayerStats = new PlayerStats();
                        reader.Close();
                    }
                }
            } else
            {
                aPlayerStats = new PlayerStats("", 0, 0, 0, 0, 0);
            }


            return aPlayerStats;
        }

    }
}
