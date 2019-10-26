using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame.Resources
{
    class Dealer
    {
        public List<Card> hand = new List<Card>();

        public Dealer()
        {
            return;
        }

        public void AddCardToHand(Card card)
        {
            hand.Add(card);
        }

        public void ShowHand()
        {

            Console.WriteLine("Show The Player Cards At Hand: ");
            for (int i = 0; i < (hand.Count); i++)
            {
                Console.WriteLine(hand[i]);//show element in the hand
            }
        }

        public void DiscardHand()
        {
            hand.Clear();
        }

        public void PlayHand(Shoe shoe)
        {
            //create a new card
            Card card = new Card(null, null);

            //play the hand
            card = shoe.Deal();//get a card from the shoe
            AddCardToHand(card);// add to hand
            card = shoe.Deal();
            AddCardToHand(card);
        }

        public void PeekHand()
        {
            //create a new card
            Card card = new Card(null, null);

            //pay t
        }
    }
}
