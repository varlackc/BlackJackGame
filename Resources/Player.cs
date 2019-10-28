using System;
using System.Collections.Generic;
using System.Text;


namespace BlackJackGame.Resources
{
    /// <summary>
    /// Player Class Controls The Player's Actions
    /// </summary>
    public class Player
    {
        public string name;
        public List<Card> hand = new List<Card>();
        public int winningCount = 0;
        public int[] handValueArray = new int[12];

        public Player()
        {
            return;
        }

        /// <summary>
        /// Get The Name Of The User
        /// </summary>
        public void GetName()
        {
            Console.Write("What Is Your Name? ");
            name = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Hello " + name + " Let's Play A Game Of Black Jack! ");
            Console.WriteLine("");
        }

        /// <summary>
        /// Add A Card To The User Hand
        /// </summary>
        /// <param name="card">Card Type </param>
        public void AddCardToHand(Card card)
        {
            hand.Add(card);
        }

        /// <summary>
        /// Show The Player Hand To The User
        /// </summary>
        public void ShowHand()
        {

            Console.WriteLine("Show The Player Cards At Hand: ");
            for(int i = 0; i < (hand.Count); i++)
            {
                Console.WriteLine(hand[i]);//show element in the hand
            }
        }

        /// <summary>
        /// Discard The Player Hand
        /// </summary>
        public void DiscardHand()
        {
            hand.Clear();
        }

        /// <summary>
        /// Play The Initial Player Hand
        /// </summary>
        /// <param name="shoe"></param>
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
        /// Calculate An Individual Card Value
        /// </summary>
        /// <param name="card">Card Data Type</param>
        /// <returns>Card Value</returns>
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
        /// Populates The Player Hand Value Array
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
        /// Calculates The Numeric Value Of The Entire Hand
        /// </summary>
        /// <returns>The Numeric Value Of The Hand</returns>
        public int CalculateHandValue() {

            int result = 0;
            int secondCount = 0;
            string userResponse;

            for (int i = 0; i < hand.Count; i++)
            {
                result += handValueArray[i];
            }

            //if the maximum value is exided, look to see if an A is present
            if (result > 21) {

                result = 0;
                for (int i = 0; i < hand.Count; i++)
                {
                    if (handValueArray[i] == 11)
                    {
                        Console.WriteLine("");
                        Console.Write("Do you Want to Change The Value Of A From 11 To 1 ? Y/N > ");//ask the user to change values
                        userResponse = Console.ReadLine();
                        Console.WriteLine();

                        if (userResponse.ToUpper() == "Y" || userResponse.ToUpper() == "YES")
                        {
                            handValueArray[i] = 1;
                        }

                    }
                }
                //once all of the values are changed re calculate the hand value
                for (int i = 0; i < hand.Count; i++)
                {
                    secondCount += handValueArray[i];
                }
                result = secondCount;
            }

            return result;
        }
    }
}
