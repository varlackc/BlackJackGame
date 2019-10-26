using System;
using BlackJackGame.Resources;

namespace BlackJackGame
{
    class Program
    {
        // execute app
        static void Main(string[] args)
        {
            //Explain the program to the user
            ExplainToUser();
            //Call the shoe of cards
            Shoe shoeOfCards = new Shoe();

            //shuffle the shoe of cards
            shoeOfCards.Shuffle();

            //get a card from the shoe
            Card card = shoeOfCards.Deal();

            //Ask the player for their name
            Player player = new Player();
            player.GetName();

            player.AddCardToHand(card);
            player.AddCardToHand(card);

            player.ShowHand();
            player.DiscardHand();
            player.ShowHand();
            //Wait for the user to quit the program
            Console.ReadLine();


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
