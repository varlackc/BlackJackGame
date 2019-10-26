using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame.Resources
{
    public class Shoe
    {
        private static int  deckSize = 52;
        private static int numberOfDecks = 6;
        private static int  shoeSize = deckSize * numberOfDecks;
        Card[] shoeOfCards = new Card[shoeSize];

        public Shoe() {

            // create the shoe


            //create deck
            var myDeckOfCards = new DeckOfCards();

            //update the shoe of cards
            for (int i = 0; i < shoeSize; ++i)
            {
                    Card tempCardValue = myDeckOfCards.DealCard();
                for (int j = 0; j < deckSize; ++j)
                {
                    shoeOfCards[i] = tempCardValue;

                }
            }

            for (int i = 0; i < shoeSize; ++i)
            {

            }

            //populate the shoe
            


        }
         
    }
}
