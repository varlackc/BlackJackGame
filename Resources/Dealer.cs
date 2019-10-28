using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame.Resources
{
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

        public void AddCardToHand(Card card)
        {
            hand.Add(card);
        }

        public void ShowHand()
        {

            Console.WriteLine("Show The Dealer Cards At Hand: ");
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

        public void PopulateHandValueArray()
        {
            //Populate HandValueArray
            for (int i = 0; i < hand.Count; i++)
            {
                handValueArray[i] = CardValue(hand[i]);//update the handValueArray
            }
        }

        public int CalculateHandValue()
        {
            int result = 0;

            for (int i = 0; i < hand.Count; i++)
            {
                result += handValueArray[i];
            }

            return result;
        }

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
                //
            }
        }

    }
}