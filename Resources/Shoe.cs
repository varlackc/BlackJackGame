using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BlackJackGame.Resources
{
    public class Shoe
    {
        private static Random randomNumbers = new Random();
        private static int deckSize = 52;
        private static int numberOfDecks = 6;
        private static int shoeSize = deckSize * numberOfDecks;
        private List<Card> shoeOfCards = new List<Card>(); //Create an empty list of cards to produce the shoe

        public Shoe()
        {
            //Declare the card information
            string[] faces = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            string[] suits = { "Hears", "Spades", "Diamonds", "Clubs" };


            //populate the shoe
            for (int i = 0; i < shoeSize; i++)
            {
                Card currentCard = new Card(faces[i % 13], suits[i % 4]);//create new card
                shoeOfCards.Add(currentCard);//add the current card to the shoe
            }
        }


        // shuffle deck of Cards 
        public void Shuffle()
        {
            //after shuffling, dealing should start at deck[0] again
            var currentCard = 0;//reinitialize currentCard

            // for each Card, pick another random Card and swap them
            for (var first = 0; first < shoeOfCards.Count; ++first)
            {
                // select a random number between 0 and 311
                var second = randomNumbers.Next(shoeOfCards.Count);

                //swap current Card with randomly selected Card
                Card temp = shoeOfCards.ElementAt(first);
                shoeOfCards[first] = shoeOfCards.ElementAt(second);
                shoeOfCards[second] = temp;
            }
        }

        public Card Deal() {

            Card card = shoeOfCards[0];
            shoeOfCards.RemoveAt(0);

            return card;
        }
    }
}
