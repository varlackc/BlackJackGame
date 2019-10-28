using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame.Resources
{
    /// <summary>
    /// Dealer Class Determines The Dealer Behaviour
    /// </summary>
    class Dealer
    {
        public List<Card> hand = new List<Card>();
        public int[] handValueArray = new int[12];
        
        //create a new card
        Card card = new Card(null, null);

        public Dealer()
        {
            return;
        }

        /// <summary>
        /// Adds A Cards To The Dealer Hand
        /// </summary>
        /// <param name="card">Takes A Cards As A Parameter</param>
        public void AddCardToHand(Card card)
        {
            hand.Add(card);
        }

        /// <summary>
        /// Shows The Hand To The User
        /// </summary>
        public void ShowHand()
        {

            Console.WriteLine("Show The Dealer Cards At Hand: ");
            for (int i = 0; i < (hand.Count); i++)
            {
                Console.WriteLine(hand[i]);//show element in the hand
            }
        }

        /// <summary>
        /// Discard The Dealer Hand
        /// </summary>
        public void DiscardHand()
        {
            hand.Clear();
        }

        /// <summary>
        /// Allows The Dealer To Play The Initial Hand
        /// </summary>
        /// <param name="shoe">Takes The Shoe Of Cards As An Input</param>
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

        /// <summary>
        /// Allows The User To Peak At One Card In The Dealer Hand
        /// </summary>
        public void PeekHand()
        {
            //Explain to the user
            Console.WriteLine("Show The Dealer Cards At Hand: ");
            //get the size of the hand
            int handSize = hand.Count;
            //display the hidden cards
            for (int i = 0; i < handSize -1 ; i++)
            {
                Console.Write(" [X] ");
            }
            //display the visible hand
            Console.Write("["+hand[handSize - 1]+"]");
            Console.WriteLine();
        }

        /// <summary>
        /// Determines The Value Of One Card
        /// </summary>
        /// <param name="card">Takes A Card As A Parameter</param>
        /// <returns>The Value Of The Card</returns>
        public int CardValue(Card card)
        {
            int cardValue = 0;

            //assign values to each possible card combination
            if (card.ToString().Contains("A")) { cardValue = 11; }
            if (card.ToString().Contains("2")) { cardValue = 2; }
            if (card.ToString().Contains("3")) { cardValue = 3; }// check if there is a Three
            if (card.ToString().Contains("4")) { cardValue = 4; }// check if there is a Four
            if (card.ToString().Contains("5")) { cardValue = 5; }// check if there is a Five
            if (card.ToString().Contains("6")) { cardValue = 6; }// check if there is a Six
            if (card.ToString().Contains("7")) { cardValue = 7; }// check if there is a Seven
            if (card.ToString().Contains("8")) { cardValue = 8; }// check if there is a Eight
            if (card.ToString().Contains("9")) { cardValue = 9; }// check if there is a Nine
            if (card.ToString().Contains("10")) { cardValue = 10; }// check if there is a Ten
            if (card.ToString().Contains("J")) { cardValue = 10; }// check if there is a Jack
            if (card.ToString().Contains("Q")) { cardValue = 10; }// check if there is a Queen
            if (card.ToString().Contains("K")) { cardValue = 10; }// check if there is a King

            return cardValue;
        }

        /// <summary>
        /// Populate The Dealer Hand Value Array
        /// </summary>
        public void PopulateHandValueArray()
        {
            //Populate HandValueArray
            for (int i = 0; i < hand.Count; i++)
            {
                handValueArray[i] = CardValue(hand[i]);//update the handValueArray
            }
        }

        /// <summary>
        /// Calculate The Numerical Value Of The Dealer Hand 
        /// </summary>
        /// <returns></returns>
        public int CalculateHandValue()
        {
            int result = 0;

            for (int i = 0; i < hand.Count; i++)
            {
                result += handValueArray[i];
            }

            return result;
        }

        /// <summary>
        /// Allow The Dealer To Play
        /// </summary>
        /// <param name="shoe">Takes A Shoe Of Cards AS An Input</param>
        /// <param name="playerHandValue">Takes The Player Hand Value As An Input</param>
        public void DealerPlay(Shoe shoe, int playerHandValue)
        {
            int dealerHandValue = CalculateHandValue();//issue is here

            if (dealerHandValue < 16)
            {
                card = shoe.Deal();//get a card from the shoe
                AddCardToHand(card);// add to hand
            }

            else if ((playerHandValue < 21) && (dealerHandValue < playerHandValue))
            {
                card = shoe.Deal();//get a card from the shoe
                AddCardToHand(card);// add to hand
            }
            else {
                //An Error Most Likely Has Occurred If This Section Is Reached
            }
        }

    }
}