using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mitproject
{
    public enum Suit  //here the suit enumeration is defined
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Value  //here the value enumeration is defined
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
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

    public class Pack //pack class is defined
    {
        private List<Card> CardPack; //private field to store the list of cards in a pack

        public Pack() //contructor-> creating a new pack of cards
        {
            CardPack = new List<Card>();
            //list of cards intialised
            foreach (Suit s in Enum.GetValues(typeof(Suit))) //a new card with a combination
            {                                                //of suit and value is created
                foreach (Value v in Enum.GetValues(typeof(Value))) 
                {
                    CardPack.Add(new Card(s, v));
                }
            }
        }
public bool ShuffleCardPack(int TypeOfShuffle) //method to shuffle cards in a pack
{
    switch (TypeOfShuffle)
    {
        case 1: //if 1 is picked then it performs a RiffleShuffle
            RiffleShuffle();
            break;
        case 2: //if 2 is picked then it performs a FisherYatesShuffle
            FisherYatesShuffle();
            break;
        default:
            throw new ArgumentException("shuffle type must be 1 or 2");
    }       //if 3 is picked then it throws an ArgumentException
    return true; // indicate that the shuffle was successful
}

        public Card deal() //method to deal a single card from top of deck
        {
            if (CardPack.Count == 0) //if nothing left to deal throw the exception
            {
                throw new InvalidOperationException("Nothing left to deal from pack");
            }

            Card CardDealt = CardPack[0];
            CardPack.RemoveAt(0);
            return CardDealt;
        }   //Take the top card from the deck, remove it from the list, and return it

        public List<Card> dealCard(int TotalAmount)
        { //method to deal multiple cards from top of deck
            if (CardPack.Count < TotalAmount)
            {
                throw new InvalidOperationException("Not enough cards left in the pack");
            }      //throws a error message to show not enough cards in the deck

            List<Card> DealtCards = new List<Card>(); //deals specified number of cards
            for (int i = 0; i < TotalAmount; i++)     //and return them in the list
            {
                DealtCards.Add(deal());
            }

            return DealtCards;
        }

        private void RiffleShuffle() //RiffleShuffle method
        {   //deck is split into 2 halves
            List<Card> LeftHalf = CardPack.Take(CardPack.Count / 2).ToList(); //list for 1 half
            List<Card> RightHalf = CardPack.Skip(CardPack.Count / 2).ToList(); //list for 2 half

            int LeftIndex = 0; //shuffle both halves while alternating
            int RightIndex = 0; //through them and updating the deck
            for (int i = 0; i < CardPack.Count; i++)
            {
                if (i % 2 == 0)
                {
                    CardPack[i] = LeftHalf[LeftIndex];
                    LeftIndex++;
                }
                else
                {
                    CardPack[i] = RightHalf[RightIndex];
                    RightIndex++;
                }
            }
        } 

        private void FisherYatesShuffle() //FisherYatesShuffle method
        {
            Random rand = new Random();
            for (int i = CardPack.Count - 1; i > 0; i--)
            {
                int f = rand.Next(i + 1);      //create a random number generator and shuffle
                Card TempCard = CardPack[f];   //the cards by swapping in random order
                CardPack[f] = CardPack[i];
                CardPack[i] = TempCard;
            }
        }            
    }
}