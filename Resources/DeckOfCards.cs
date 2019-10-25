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

        
        // shuffle deck of Cards 
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


        private static int[] PopulateCardValue(Card[] hand)
        {
            //declare variables 
            int[] handValues = new int[5];
            //Loop to populate card values array
            for (int n = 0; n < hand.Length; n++)
            {
                //assign values to each possible card combination
                if (hand[n].ToString().Contains("A")) { handValues[n] = 11; }// check if there is an Ace
                if (hand[n].ToString().Contains("2")) { handValues[n] = 2; }// check if there is a Deuce
                if (hand[n].ToString().Contains("3")) { handValues[n] = 3; }// check if there is a Three
                if (hand[n].ToString().Contains("4")) { handValues[n] = 4; }// check if there is a Four
                if (hand[n].ToString().Contains("5")) { handValues[n] = 5; }// check if there is a Five
                if (hand[n].ToString().Contains("6")) { handValues[n] = 6; }// check if there is a Six
                if (hand[n].ToString().Contains("7")) { handValues[n] = 7; }// check if there is a Seven
                if (hand[n].ToString().Contains("8")) { handValues[n] = 8; }// check if there is a Eight
                if (hand[n].ToString().Contains("9")) { handValues[n] = 9; }// check if there is a Nine
                if (hand[n].ToString().Contains("10")) { handValues[n] = 10; }// check if there is a Ten
                if (hand[n].ToString().Contains("J")) { handValues[n] = 10; }// check if there is a Jack
                if (hand[n].ToString().Contains("Q")) { handValues[n] = 10; }// check if there is a Queen
                if (hand[n].ToString().Contains("K")) { handValues[n] = 10; }// check if there is a King
                
                //Use a switch statement to  assign values to the cardValue array
                
            }
            return handValues;
        }
    }
}
