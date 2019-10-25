using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace BlackJackGame.Resources
{
    public class DeckOfCards
    {
        //create one Random object to share among DeckOfCards objects
        private static Random randomNumbers = new Random();

        private const int NumberOfCards = 52;// number of cards in a deck
        private Card[] deck = new Card[NumberOfCards];
        private int currentCard = 0; // index of next Card to be dealt (0 - 51)

        // constructor fills deck of Cards

        public DeckOfCards()
        {
            string[] faces = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            string[] suits = { "Hears", "Spades", "Diamonds", "Clubs" };

            // populate the deck with Card Objects
            for (var count = 0; count < deck.Length; ++count)
            {
                deck[count] = new Card(faces[count % 13], suits[count / 13]);
            }
        }

        // shuffle deck of Cards withone-pass algorithm
        public void Shuffle()
        {
            //after shuffling, dealing should start at deck[0] again
            currentCard = 0;//reinitialize currentCard

            // for each Card, pick another random Card and swap them
            for (var first = 0; first < deck.Length; ++first)
            {
                // select a random number between 0 and 51
                var second = randomNumbers.Next(NumberOfCards);//NumberOfCards 

                //swap current Card with randomly selected Card
                Card temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            }
        }

        //deal one Card
        public Card DealCard()
        {
            //determine whether Cards remain to be dealt
            if (currentCard < deck.Length)
            {
                return deck[currentCard++]; // return current Card in array
            }
            else
            {
                return null; // indicate that all Cards were dealt
            }
        }

        // Additional methods to process hand of Cards
        public static bool ContainsPair(Card[] hand)
        {
            bool result = false;
            string[] faces = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            //loop through the hand to see if there are any pairs
            for (int l = 0; l < hand.Length; l++)
            {
                // loop a second time to get the second value to compare
                for (int r = l + 1; (r < (hand.Length)); r++)
                {
                    var cardL = hand[l];
                    var cardR = hand[r];
                    // check if there is a match
                    for (int n = 0; n < faces.Length; n++)
                    {
                        // Check to see if the card in the left matches the card in the right  
                        if (cardL.ToString().Contains(faces[n]) && cardR.ToString().Contains(faces[n]))
                        {
                            result = true;
                        }
                    }

                }
            }
            return result;
        }

        public static bool ContainsTwoPair(Card[] hand)
        {
            int count = 0;
            bool result = false;
            string[] faces = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };


            //loop through the hand to see if there are any pairs
            for (int l = 0; l < hand.Length; l++)
            {
                // loop a second time to get the second value to compare
                for (int r = l + 1; (r < (hand.Length)); r++)
                {
                    var cardL = hand[l];
                    var cardR = hand[r];
                    // check if there is a match
                    for (int n = 0; n < faces.Length; n++)
                    {
                        // Check to see if the card in the left matches the card in the right  
                        if (cardL.ToString().Contains(faces[n]) && cardR.ToString().Contains(faces[n]))
                        {
                            count += 1;
                        }
                    }

                }
            }

            // if the count is larger or equal to two then there are at least two matches
            if (count >= 2)
            {
                result = true;
            }

            return result;
        }

        public static bool ContainsThreeOfKind(Card[] hand)
        {
            bool result = false;
            int count = 0;
            string[] faces = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            //loop through the hand to see if there are any pairs
            for (int l = 0; l < hand.Length; l++)
            {
                // loop a second time to get the second value to compare
                for (int r = l + 1; (r < (hand.Length)); r++)
                {
                    var cardL = hand[l];
                    var cardR = hand[r];
                    // check if there is a match
                    for (int n = 0; n < faces.Length; n++)
                    {
                        // Check to see if the card in the left matches the card in the right  
                        if (cardL.ToString().Contains(faces[n]) && cardR.ToString().Contains(faces[n]))
                        {
                            count += 1;
                        }

                        //Check to see if there are three or more cards of the same type
                        if (count >= 2)
                        {
                            result = true;
                            return result;
                        }
                    }
                }

                count = 0; //reset the counter
            }
            return result;
        }

        public static bool ContainsFourOfKind(Card[] hand)
        {
            bool result = false;
            int count = 0;
            string[] faces = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            //loop through the hand to see if there are any pairs
            for (int l = 0; l < hand.Length; l++)
            {
                // loop a second time to get the second value to compare
                for (int r = l + 1; (r < (hand.Length)); r++)
                {
                    var cardL = hand[l];
                    var cardR = hand[r];
                    // check if there is a match
                    for (int n = 0; n < faces.Length; n++)
                    {
                        // Check to see if the card in the left matches the card in the right  
                        if (cardL.ToString().Contains(faces[n]) && cardR.ToString().Contains(faces[n]))
                        {
                            count += 1;
                        }

                        //Check to see if there are four or more cards of the same type
                        if (count >= 3)
                        {
                            result = true;
                            return result;
                        }
                    }
                }

                count = 0; //reset the counter
            }
            return result;
        }

        public static bool ContainsFlush(Card[] hand)
        {
            bool result = false;
            int count = 0;
            string[] suits = { "Hears", "Diamonds", "Clubs", "Spades" };

            //loop through the hand to see if there are any pairs
            for (int l = 0; l < hand.Length; l++)
            {
                // loop a second time to get the second value to compare
                for (int r = l + 1; (r < (hand.Length)); r++)
                {
                    var cardL = hand[l];
                    var cardR = hand[r];
                    // check if there is a match
                    for (int n = 0; n < suits.Length; n++)
                    {
                        // Check to see if the card in the left matches the card in the right  
                        if (cardL.ToString().Contains(suits[n]) && cardR.ToString().Contains(suits[n]))
                        {
                            count += 1;
                        }

                        //Check to see if there are four or more cards of the same type
                        if (count >= 4)
                        {
                            result = true;
                            return result;
                        }
                    }
                }

                count = 0; //reset the counter
            }
            return result;
        }

        public static bool ContainsStraight(Card[] hand)
        {
            bool result = false;
            bool gap = false;
            int[] cardValues = new int[5]; // create array of card values
            string[] faces = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            // This method change the card values from text to integers, to make it easier to sort
            cardValues = PopulateCardValue(hand);
            // Sort card value array in ascending order
            Array.Sort(cardValues);

            // loop and try to see if there are any gaps
            for (int n = 0; n < (cardValues.Length - 1); n++)
            {
                //setup the gap conditions
                var gapCondition = cardValues[(n + 1)] - cardValues[n];
                // look for gaps
                if (gapCondition != 1)
                {
                    gap = true;
                }
            }

            // if there are no gaps after the inspection then the hand is straight
            if (gap == false)
            {
                result = true;
            }

            return result;
        }


        public static bool ContainsFullHouse(Card[] hand)
        {
            //Declare Variables
            bool result = false;
            int[] cardValues = new int[5];
            List<int> cardKeys = new List<int>(); //List of the keys for Card Keys
            int cardTypeSize;
            var cardTypeA = 0;
            var cardTypeB = 0;

            //Dictionary of types of cards, dictionaries are used to hold what is called key value pairs
            IDictionary<int, int> cardTypes = new Dictionary<int, int>();//That way we can associate a specific card with the number of times that such card appears in the hand

            // This method change the card values from text to integers, to make it easier to sort
            cardValues = PopulateCardValue(hand);

            //Loop to add values to the cardTypes dictionary
            for (int n = 0; n < cardValues.Length; n++)
            {
                // if there card is new, then it will be added to the dictionary
                if (!cardTypes.ContainsKey(cardValues[n]))
                {
                    cardTypes.Add(cardValues[n], 1);
                    cardKeys.Add(cardValues[n]);
                }
                else
                {
                    cardTypes[cardValues[n]] += 1;
                }
            }

            //verify the number of card types
            cardTypeSize = cardTypes.Count;
            if (cardTypeSize == 2)
            {
                //cardTypeA = cardTypes.ContainsKey
                // get the count of element A
                cardTypeA = cardTypes.Values.ElementAt(0);
                cardTypeB = cardTypes.Values.ElementAt(1);

                //check if there is a combination of (3,2) or (2,3)
                if (((cardTypeA == 3) && (cardTypeB == 2)) || ((cardTypeA == 2) && (cardTypeB == 3)))
                {
                    result = true;
                }
            }
            return result;
        }

        private static int[] PopulateCardValue(Card[] hand)
        {
            //declare variables 
            int[] cardValues = new int[5];
            //Loop to populate card values array
            for (int n = 0; n < hand.Length; n++)
            {
                if (hand[n].ToString().Contains("Ace")) { cardValues[n] = 1; }// check if there is an Ace
                if (hand[n].ToString().Contains("Deuce")) { cardValues[n] = 2; }// check if there is a Deuce
                if (hand[n].ToString().Contains("Three")) { cardValues[n] = 3; }// check if there is a Three
                if (hand[n].ToString().Contains("Four")) { cardValues[n] = 4; }// check if there is a Four
                if (hand[n].ToString().Contains("Five")) { cardValues[n] = 5; }// check if there is a Five
                if (hand[n].ToString().Contains("Six")) { cardValues[n] = 6; }// check if there is a Six
                if (hand[n].ToString().Contains("Seven")) { cardValues[n] = 7; }// check if there is a Seven
                if (hand[n].ToString().Contains("Eight")) { cardValues[n] = 8; }// check if there is a Eight
                if (hand[n].ToString().Contains("Nine")) { cardValues[n] = 9; }// check if there is a Nine
                if (hand[n].ToString().Contains("Ten")) { cardValues[n] = 10; }// check if there is a Ten
                if (hand[n].ToString().Contains("Jack")) { cardValues[n] = 11; }// check if there is a Jack
                if (hand[n].ToString().Contains("Queen")) { cardValues[n] = 12; }// check if there is a Queen
                if (hand[n].ToString().Contains("King")) { cardValues[n] = 13; }// check if there is a King
            }
            return cardValues;
        }
    }
}
