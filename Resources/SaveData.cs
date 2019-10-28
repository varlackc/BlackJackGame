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
            path += "Log.txt";
            if (File.Exists(path))
            {
                Console.WriteLine(path);
                Console.WriteLine("The File Exist");
            }
            else
            {
                Console.WriteLine(path);
                Console.WriteLine("The File Does Not Exist");
            }

        }
    }
}
