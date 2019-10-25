using System;
using BlackJackGame.Resources;

namespace BlackJackGame
{
    class Program
    {
        // execute app
        static void Main(string[] args)
        {

            Card[] hand = new Card[5]; // declare a card  to represent the hand 

            var myDeckOfCards = new Resources.DeckOfCards();
            myDeckOfCards.Shuffle(); // place Cards in random order

            // Explain the program to the user
            ExplainToUser();

            // display all 52 Cards in the order which they are dealt
            for (var i = 0; i < 52; ++i)
            {
                var tempCarValue = myDeckOfCards.DealCard(); // create a temporary card value that holds the dealed card
                int handPosition = i % hand.Length; //get the position the card in the hand
                hand[handPosition] = tempCarValue; // set the card in the hand
                Console.Write($"{ tempCarValue,-19}");//display element 
                                                      // determines the size of the hand
                if ((i + 1) % 5 == 0)
                {
                    //Run the Hand operations in this code section
                    Console.WriteLine("\n");

                    //var handResult = DeckOfCards.ContainsPair(hand);//Check if the hand contains pairs 
                    //Console.WriteLine("Contains a Pair: " + handResult);
                    //handResult = DeckOfCards.ContainsTwoPair(hand);//Check if the hand contains pairs 
                    //Console.WriteLine("Contains two Pairs: " + handResult);
                    //handResult = DeckOfCards.ContainsThreeOfKind(hand);
                    //Console.WriteLine("Contains three Cards Of Same Type: " + handResult);
                    //handResult = DeckOfCards.ContainsFourOfKind(hand);
                    //Console.WriteLine("Contains Four Cards Of Same Type: " + handResult);
                    //handResult = DeckOfCards.ContainsFlush(hand);
                    //Console.WriteLine("Contains A Flush: " + handResult);
                    //handResult = DeckOfCards.ContainsStraight(hand);
                    //Console.WriteLine("Contains A Straight: " + handResult);
                    //handResult = DeckOfCards.ContainsFullHouse(hand);
                    //Console.WriteLine("Contains Contains Full House: " + handResult);
                    //Console.WriteLine("\n\n");
                }
            }

            Console.Read(); //wait until the user closes the program


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
