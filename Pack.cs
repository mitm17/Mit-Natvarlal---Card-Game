using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mitproject
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Value
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

    public class Card
    {
        public Suit Suit { get; private set; }
        public Value Value { get; private set; }

        public Card(Suit suit, Value value)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return string.Format("{0} of {1}", Value, Suit);
        }
    }

    public class Pack
    {
        private List<Card> CardPack;

        public Pack()
        {
            CardPack = new List<Card>();
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value v in Enum.GetValues(typeof(Value)))
                {
                    CardPack.Add(new Card(s, v));
                }
            }
        }
public bool ShuffleCardPack(int TypeOfShuffle)
{
    switch (TypeOfShuffle)
    {
        case 1:
            RiffleShuffle();
            break;
        case 2:
            FisherYatesShuffle();
            break;
        default:
            throw new ArgumentException("shuffle type must be 1 or 2");
    }
    return true; // indicate that the shuffle was successful
}

        public Card deal()
        {
            if (CardPack.Count == 0)
            {
                throw new InvalidOperationException("Nothing left to deal from pack");
            }

            Card CardDealt = CardPack[0];
            CardPack.RemoveAt(0);
            return CardDealt;
        }

        public List<Card> dealCard(int TotalAmount)
        {
            if (CardPack.Count < TotalAmount)
            {
                throw new InvalidOperationException("Not enough cards left in the pack");
            }

            List<Card> DealtCards = new List<Card>();
            for (int i = 0; i < TotalAmount; i++)
            {
                DealtCards.Add(deal());
            }

            return DealtCards;
        }

        private void RiffleShuffle()
        {
            List<Card> LeftHalf = CardPack.Take(CardPack.Count / 2).ToList();
            List<Card> RightHalf = CardPack.Skip(CardPack.Count / 2).ToList();

            int LeftIndex = 0;
            int RightIndex = 0;
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

        private void FisherYatesShuffle()
        {
            Random rand = new Random();
            for (int i = CardPack.Count - 1; i > 0; i--)
            {
                int f = rand.Next(i + 1);
                Card TempCard = CardPack[f];
                CardPack[f] = CardPack[i];
                CardPack[i] = TempCard;
            }
        }            
    }
}