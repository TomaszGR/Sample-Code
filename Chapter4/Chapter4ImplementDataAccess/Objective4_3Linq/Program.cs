using System;
using System.Collections.Generic;
using System.Linq;

namespace Objective4_3Linq
{
   public static class Dumps
   {
      public static void Dump(this object txt)
      {
         Console.WriteLine(txt);
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         Func<int, int> myDelegate =
            delegate (int x)
            {
               return x * 2;
            };

         Func<int, int> myDelegate2 = (int x) => x * 2;

         Action<int> del = delegate (int x)
         {
            x.Dump();
         };

         Action<int> del2 = (int x) => (x*2).Dump();

         Console.WriteLine($"{myDelegate(5)}");

         var tt = myDelegate(6);
         myDelegate(7).Dump();
         tt.Dump();
         del(4);
         del2(5);

         int[] intt = new int[] { 1,2,3,4,5,6,7 };

         var inttEven = from bb in intt
                        where bb % 2 == 0
                        select bb;
         foreach (var item in inttEven)
         {
            item.Dump();
         }

         var even2 = intt.Where( intt => intt % 2 == 0);
         
         foreach(var item in even2)
         {
            item.Dump();
         }

        Console.ReadLine();
      }
   }
}
