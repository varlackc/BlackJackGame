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
            if (File.Exists(path))
            {
                Console.WriteLine(path);
                Console.WriteLine("The File Exist");
                
                    using (StreamWriter streamWriter = new StreamWriter(path, true))
                    {
                        streamWriter.WriteLine("Number of games: ####");
                        streamWriter.WriteLine("");
                        streamWriter.WriteLine("Player Success: ");
                        streamWriter.WriteLine("");
                        streamWriter.WriteLine("Player Winning hand => # of times achieved");
                    }
                
            }
            else
            {
                Console.WriteLine(path);
                Console.WriteLine("The File Has Been Created");
                using (FileStream file = File.Create(path))
                {
                    using (StreamWriter streamWriter = new StreamWriter(path, true))
                    {
                        streamWriter.WriteLine("Number of games: ####");
                        streamWriter.WriteLine("");
                        streamWriter.WriteLine("Player Success: ");
                        streamWriter.WriteLine("");
                        streamWriter.WriteLine("Player Winning hand => # of times achieved");
                    }
                }
            }
        }
    }
}
