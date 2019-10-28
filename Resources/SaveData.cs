using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlackJackGame.Resources
{
    public class SaveData
    {
        public string path; 
        public SaveData()
        {
            path = Directory.GetCurrentDirectory();
            path += "\\Log.txt";
        }

        public void Save(int gameCount, int winCount, Dictionary<string, int> gameDictionary)
        {
            double successPercentage = ((double)(winCount) / (double)(gameCount))*100;

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

                        foreach (KeyValuePair<string, int> gameKeyValuePair in gameDictionary)
                        {
                        streamWriter.WriteLine("{0} {1}",gameKeyValuePair.Key, gameKeyValuePair.Value);
                        }
                    }
                
            }
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

                        foreach (KeyValuePair<string, int> gameKeyValuePair in gameDictionary)
                        {
                            streamWriter.WriteLine("{0} {1}", gameKeyValuePair.Key, gameKeyValuePair.Value);
                        }
                    }
                }
            }
        }
    }
}
