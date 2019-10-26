using System;
using BlackJackGame.Resources;

namespace BlackJackGame
{
    class Program
    {
        // execute app
        static void Main(string[] args)
        {
            //declare variables
            bool gameLoop = true;
            Card card = new Card(null,null);// declare an empty card
            string userResponse;

            //Explain the program to the user
            ExplainToUser();


            //Ask the player for their name
            Player player = new Player();
            player.GetName();

            //Loop until the user desides to quit the game
            while (gameLoop == true) {
                //Call the shoe of cards
                Shoe shoeOfCards = new Shoe();

                //shuffle the shoe of cards
                shoeOfCards.Shuffle();

                //pay the hand give the shoe of cards to the user
                player.PlayHand(shoeOfCards);

                //show hand
                player.ShowHand();
                
                //discard hand
                player.DiscardHand();

                Console.Write("Do You Want To Play Another Hand? Y / N > ");
                userResponse = Console.ReadLine();
                Console.WriteLine();

                //determine if the game must stop or continue
                if (userResponse.ToUpperInvariant() == "Y" || userResponse.ToUpperInvariant() == "YES")
                {
                    gameLoop = true;
                }
                else {
                    gameLoop = false;
                    Environment.Exit(0);
                }
            }   
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