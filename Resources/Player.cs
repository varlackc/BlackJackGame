using System;
using System.Collections.Generic;
using System.Text;


namespace BlackJackGame.Resources
{
    public class Player
    {
        public string name;
        public List<Card> hand = new List<Card>();
        public int winningCount = 0;

        public Player()
        {
            return;
        }

        public void GetName() {
            Console.Write("What Is Your Name? ");
            name = Console.ReadLine();
            Console.WriteLine("Hello " + name + " Let's Play A Game Of Black Jack! ");
        }

        public void AddCardToHand(Card card) {
            hand.Add(card);
        }

        public void ShowHand() {

            Console.WriteLine("Show The Player Cards At Hand: ");
            for(int i = 0; i < (hand.Count); i++)
            {
                Console.WriteLine(hand[i]);//show element in the hand
            }
        }
    }
}
