using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BlackJackGame.Resources
{
    public class Shoe
    {
        private static int  deckSize = 52;
        private static int numberOfDecks = 6;
        private static int  shoeSize = deckSize * numberOfDecks;
        private List<Card> shoeOfCards = new List<Card>(); //Create an empty list of cards to produce the shoe

        public Shoe() {
            //Declare the card information
            string[] faces = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            string[] suits = { "Hears", "Spades", "Diamonds", "Clubs" };

            

            //populate the shoe
            for (int i = 0; i < shoeSize; i++) {
                Card currentCard = new Card(faces[i%13], suits[i%4]);//create new card
                shoeOfCards.Add(currentCard);//add the current card to the shoe
            }

            /*
            // show the elements in the shoe
            for (int i = 0; i < shoeSize; i++) {
                Console.WriteLine(shoeOfCards.ElementAt(i));
            }
            */

            //Add a section to create the shoe, it should be a list of cards

            //

        }

    }
}
