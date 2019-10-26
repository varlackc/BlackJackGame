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
    }
}
