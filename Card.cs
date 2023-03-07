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
            SetValue(Value);
            SetSuit(Suit);
        }

        // Properties
        public int GetValue()
        {
            return _value;
        }

        public void SetValue(int Value)
        {
            if (Value < 1 || Value > 13)
                throw new ArgumentException("The card value is wrong.");
            _value = Value;
        }

        public int GetSuit()
        {
            return _suit;
        }

        public void SetSuit(int Suit)
        {
            if (Suit < 1 || Suit > 4)
                throw new ArgumentException("The card suit is wrong.");
            _suit = Suit;
        }

        // Methods
        public override string ToString()
        {
            string CardValue;
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
                    CardValue = GetValue().ToString();
                    break;
            }

            string CardSuit;
            switch (GetSuit())
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
                    CardSuit = "";
                    break;
            }

            return CardValue + " of " + CardSuit;
        }
    }
}