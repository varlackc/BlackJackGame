using System;
using BlackJackGame.Resources;

namespace BlackJackGame
{
    class Program
    {
        // execute app
        static void Main(string[] args)
        {
            //Call the shoe of cards
            Shoe shoeOfCards = new Shoe();

            //Explain the program to the user
            ExplainToUser();


        }
        public static void ExplainToUser()
        {
            Console.WriteLine();
            Console.WriteLine("\t-----------------------------------------------");
            Console.WriteLine("\t|                                             |");
            Console.WriteLine("\t| This Program Simulates A Black Jack Game.   |");
            Console.WriteLine("\t|                                             |");
            Console.WriteLine("\t|                                             |");
            Console.WriteLine("\t| Author: Carlos Maxwell Varlack              |");
            Console.WriteLine("\t|                                             |");
            Console.WriteLine("\t-----------------------------------------------");
            Console.WriteLine();
        }

    }
}
