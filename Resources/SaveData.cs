/*
    Programming Challenge: Black Jack Game Simulation
    Author: Carlos Maxwell Varlack

    Description: 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlackJackGame.Resources
{
    /// <summary>
    /// Class To Save Data To The Log File
    /// </summary>
    public class SaveData
    {
        public string path; 
        public SaveData()
        {
            path = Directory.GetCurrentDirectory();
            path += "\\Log.txt";
        }

        /// <summary>
        /// Method to Save Data To A Log File
        /// </summary>
        /// <param name="gameCount">Integer Containing The Number Of Games Played</param>
        /// <param name="winCount">Integer Containing The Number Of Wins By The Played</param>
        /// <param name="gameDictionary">Dictionary Containing The Key Value Pairs Of Winning Games And Their Frequency</param>
        /// <param name="timeTaken">Time Stamp Of How Long The Games Took</param>
        public void Save(int gameCount, int winCount, Dictionary<string, int> gameDictionary, TimeSpan timeTaken)
        {
            double successPercentage = ((double)(winCount) / (double)(gameCount))*100;

            //If the File Exist  Then Write to the file
            if (File.Exists(path))
            {
                Console.WriteLine(path);
                Console.WriteLine("Update File");
                
                    using (StreamWriter streamWriter = new StreamWriter(path, false))
                    {
                        streamWriter.WriteLine("Number of games: "+gameCount);
                        streamWriter.WriteLine("");
                        streamWriter.WriteLine("Player Success: "+ successPercentage +"%");
                        streamWriter.WriteLine("");
                        streamWriter.WriteLine("Player Winning hand => # of times achieved");
                        streamWriter.WriteLine("");

                        foreach (KeyValuePair<string, int> gameKeyValuePair in gameDictionary)
                        {
                        streamWriter.WriteLine("{0} {1}",gameKeyValuePair.Key, gameKeyValuePair.Value);
                        }

                        streamWriter.WriteLine("Time Taken: "+timeTaken);
                }
                
            }
            //If The File Does Not Exist, Create The File And Save Data
            else
            {
                Console.WriteLine(path);
                Console.WriteLine("Create File");
                using (FileStream file = File.Create(path))
                {
                    using (StreamWriter streamWriter = new StreamWriter(path, false))
                    {
                        streamWriter.WriteLine("Number of games: " + gameCount);
                        streamWriter.WriteLine("");
                        streamWriter.WriteLine("Player Success: " + successPercentage + "%");
                        streamWriter.WriteLine("");
                        streamWriter.WriteLine("Player Winning hand => # of times achieved");
                        streamWriter.WriteLine("");

                        foreach (KeyValuePair<string, int> gameKeyValuePair in gameDictionary)
                        {
                            streamWriter.WriteLine("{0} {1}", gameKeyValuePair.Key, gameKeyValuePair.Value);
                        }

                        streamWriter.WriteLine("Time Taken: " + timeTaken);
                    }
                }
            }
        }
    }
}
