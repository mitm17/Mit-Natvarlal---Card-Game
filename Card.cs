using System;

namespace mitproject// Note: actual namespace depends on the project name.
{
 class CardType
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation
        
        private int _value;
        private int _suit;

        // Constructor
        public CardType(int Value, int Suit)
        {
            SetValue(Value); //both card value and card suit
            SetSuit(Suit);   //are set with validations
        }
         public class Card //card class is defined
    {
        public Suit Suit { get; private set; }   //here are the properties for 
        public Value Value { get; private set; } //suit and value of the card 

        public Card(Suit suit, Value value) //the constructor creates a new Card
        {                                   //with a specific suit and value
            Suit = suit;
            Value = value;
        }

        public override string ToString() //method-> coverting the card to a string
        {
            return string.Format("{0} of {1}", Value, Suit);
        }
    }
        // Properties
        public int GetValue()
        {
            return _value;
        } //returns the card value

        public void SetValue(int Value)
        {
            if (Value < 1 || Value > 13)
                throw new ArgumentException("The card value is wrong.");
            _value = Value; //card value is set
        }

        public int GetSuit()
        {
            return _suit; //the card suit is returned
        }

        public void SetSuit(int Suit)
        {
            if (Suit < 1 || Suit > 4)
                throw new ArgumentException("The card suit is wrong.");
            _suit = Suit; //card suit is set
        }

        // Methods
        public override string ToString()
        {
            string CardValue; //switch statement to handle card values
            switch (GetValue())
            {
                case 1:
                    CardValue = "Ace";
                    break;
                case 11:
                    CardValue = "Jack";
                    break;
                case 12:
                    CardValue = "Queen";
                    break;
                case 13:
                    CardValue = "King";
                    break;
                default:
                    CardValue = GetValue().ToString(); //if the value is not 1, 11, 12 or 13
                    break;                             //just use the numeric value
            }

            string CardSuit;
            switch (GetSuit()) //switch statement to handle card suits
            {
                case 1:
                    CardSuit = "Hearts";
                    break;
                case 2:
                    CardSuit = "Diamonds";
                    break;
                case 3:
                    CardSuit = "Clubs";
                    break;
                case 4:
                    CardSuit = "Spades";
                    break;
                default:
                    CardSuit = ""; //if the suit is not between 1-4
                    break;         //just leave it blank
            }

            return CardValue + " of " + CardSuit;
        }   //the card value and card suit are returned as a string
    }
}