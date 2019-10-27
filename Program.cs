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
            bool gameHit = true;
            Card card = new Card(null,null);// declare an empty card
            string userResponse;
            string userHit;

            //Explain the program to the user
            ExplainToUser();

            //Create a dealer
            Dealer dealer = new Dealer();

            //Ask the player for their name
            Player player = new Player();
            player.GetName();

            //Loop until the user desides to quit the game
            while (gameLoop == true) {
                //Call the shoe of cards
                Shoe shoeOfCards = new Shoe();

                //shuffle the shoe of cards
                shoeOfCards.Shuffle();

                //Dealer hand is produced
                dealer.PlayHand(shoeOfCards);

                //pay the hand give the shoe of cards to the user
                player.PlayHand(shoeOfCards);
                player.PopulateHandValueArray();

                //Peek Dealer Hand 
                dealer.PeekHand();

                //show player hand
                player.ShowHand();
                player.CalculateHandValue();

                // Do you want to hit?
                while (gameHit == true) {
                    Console.Write("Do You Want To Hit? Y / N > ");
                    userHit = Console.ReadLine();

                    if (userHit.ToUpperInvariant() == "Y" || userHit.ToUpperInvariant() == "YES")
                    {
                        player.AddCardToHand(shoeOfCards.Deal());//add a card to the hand
                        player.ShowHand();//show the hand
                        player.PopulateHandValueArray();
                        player.CalculateHandValue();
                    }
                    else {
                        gameHit = false;
                    }
                }
                
                //discard hand
                player.DiscardHand();
                dealer.DiscardHand();

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