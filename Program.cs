using System;
using System.Collections.Generic;
using BlackJackGame.Resources;

namespace BlackJackGame
{
    class Program
    {
        // execute app
        static void Main(string[] args)
        {
            //declare the start time 
            DateTime start = DateTime.Now;

            //declare variables
            bool gameLoop = true;
            bool gameHit = true;
            bool gameWin = false;
            Card card = new Card(null,null);// declare an empty card
            string userResponse;
            string userHit;
            int playerHandValue = 0;
            int dealerHandValue = 0;
            int gameCount = 0;
            int winCount = 0;
            Dictionary<string, int> gameDictionary = new Dictionary<string, int>(); //winning hand, # of times achieved
            string key;
            SaveData dataProcess = new SaveData();

        //Explain the program to the user
        ExplainToUser();
            //Create a dealer
            Dealer dealer = new Dealer();
            //Ask the player for their name
            Player player = new Player();
            player.GetName();//Ask the player for their name
            //Loop until the user desides to quit the game
            while (gameLoop == true) {
                //Call the shoe of cards
                Shoe shoeOfCards = new Shoe();

                //shuffle the shoe of cards
                shoeOfCards.Shuffle();

                //clean the hand before using it
                player.DiscardHand();//check here
                dealer.DiscardHand();
                gameHit = true;//clear the game hit parameter
                gameWin = false;//Game Win value is reset


                //Dealer hand is produced
                dealer.PlayHand(shoeOfCards);
                dealer.PopulateHandValueArray();

                //pay the hand give the shoe of cards to the user
                player.PlayHand(shoeOfCards);
                player.PopulateHandValueArray();

                //Peek Dealer Hand 
                dealer.PeekHand();

                //show player hand
                player.ShowHand();
                playerHandValue = player.CalculateHandValue();
                Console.WriteLine(" The Player Hand Value is: " + playerHandValue);

                // Do you want to hit?
                while (gameHit == true) {
                    Console.WriteLine("");
                    Console.Write("Do You Want To Hit? Y / N > ");
                    userHit = Console.ReadLine();
                    Console.WriteLine();

                    //The User Has Hit 
                    if (userHit.ToUpperInvariant() == "Y" || userHit.ToUpperInvariant() == "YES")
                    {
                        player.AddCardToHand(shoeOfCards.Deal());//add a card to the hand
                        player.ShowHand();//show the hand
                        player.PopulateHandValueArray();
                        playerHandValue = player.CalculateHandValue();
                        Console.WriteLine(" The hand Value is: " + playerHandValue);
                    }
                    //The User Has Not Hit
                    else {
                        dealer.DealerPlay(shoeOfCards, playerHandValue);
                        dealer.ShowHand();
                        dealerHandValue = dealer.CalculateHandValue();
                        Console.WriteLine(" The Dealer hand Value is: "+ dealerHandValue);

                        //Determine the outcome of the game
                        gameWin = GameResult(playerHandValue, dealerHandValue);

                        // increase the win counts if the player wins
                        if (gameWin)
                        {
                            winCount += 1;
                            gameCount += 1;

                            //if the value exist in the dictionary then update the value
                            if (gameDictionary.ContainsKey(dealerHandValue.ToString() + " =>"))
                            {
                                key = (dealerHandValue.ToString() + " =>");
                                gameDictionary[key] += 1;
                            }
                            //if the value does not exist then add to the game dictionary
                            else {

                                gameDictionary.Add(dealerHandValue.ToString() + " =>", 1);
                            }
                        }

                        gameHit = false;
                    }
                }

                Console.WriteLine("");
                Console.Write("Do You Want To Play Another Hand? Y / N > ");
                userResponse = Console.ReadLine();
                Console.WriteLine();

                //determine if the game must stop or continue
                if (userResponse.ToUpperInvariant() == "Y" || userResponse.ToUpperInvariant() == "YES")
                {
                    gameLoop = true;
                    Console.WriteLine("");
                    Console.Clear();
                }
                else {
                    //generate the time stamp
                    TimeSpan timeTaken = DateTime.Now - start;

                    //save the results
                    dataProcess.Save(gameCount, winCount, gameDictionary, timeTaken);
                    //stop the game from running
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

        public static bool GameResult(int playerResult, int dealerResult)
        {
            bool result = false;

            if (dealerResult > 21)
            {
                Console.WriteLine("");
                Console.WriteLine("The Dealer Is Busted, The Player Wins!");
                result = true;
            }
            else if (playerResult > 21)
            {
                Console.WriteLine("");
                Console.WriteLine("The Player Is Busted, The Dealer Wins!");
                result = false;
            }
            else if (playerResult < dealerResult)
            {
                Console.WriteLine("");
                Console.WriteLine("The Dealer Wins!");
                result = false;
            }
            else if (playerResult == dealerResult)
            {
                Console.WriteLine("");
                Console.WriteLine("There Is A Push, No One Wins!");
                result = false;
            }
            else if ((playerResult > dealerResult) && (playerResult <= 21))
            {
                Console.WriteLine("");
                Console.WriteLine("The Player Wins!");
                result = true;
            }
            else {
                Console.WriteLine("");
                Console.WriteLine("There is an Error, The Winner Can Not Be Determined");
                result = false;
            }

            return result;
        }

    }
}