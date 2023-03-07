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
            Pack FreshPack = new Pack();
            if (FreshPack.ShuffleCardPack(1))
            {
                Console.WriteLine("Deck has been shuffled");
            }
            

            Console.WriteLine("Dealt {0}",FreshPack.deal());

            foreach (Card c in FreshPack.dealCard(2))
            {
                Console.WriteLine("Dealt {0}", c);
            }

        }
    }
}