using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mitproject// Note: actual namespace depends on the project name.
{
   public class Testing
    {
         public static void RunTest()
        {
            Pack FreshPack = new Pack(); //new pack object is created
            if (FreshPack.ShuffleCardPack(1)) //cards being shuffled
            {
                Console.WriteLine("Deck has been shuffled");
            } //once deck has been shuffled outputs message
            

            Console.WriteLine("Dealt {0}",FreshPack.deal());
            //deals a single card and prints the value of the card
            foreach (Card c in FreshPack.dealCard(2))
            { //deals 2 cards and prints the values of the cards
                Console.WriteLine("Dealt {0}", c);
            }

        }
    }
}