/*
 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame.Resources
{
    /// <summary>
    /// Card Class 
    /// </summary>
    public class Card
    {

        private string Face { get; }// Card's face ("Ace", "Deuce",...)
        private string Suit { get; }//Card's suit ("Hearts", "diamonds",...)

        // two-parameter constructor initializes card's Face and Suit
        public Card(string face, string suit)
        {
            Face = face; // initialize face of card
            Suit = suit; // initialize suit of card
        }
        //return string representation of Card
       public override string ToString() => $"{Face} of {Suit}";
    }
}

