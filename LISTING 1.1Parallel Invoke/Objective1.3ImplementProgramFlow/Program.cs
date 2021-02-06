using System;

namespace Objective1._3ImplementProgramFlow
{
   class Program
   {
      static void Main(string[] args)
      {
        //int[] collection = { 1,2,3,4,5,6};
        //int[] values = { 1,2,3,4,5,6};
        //
        //for (int i = 0; i < collection.Length; i++)
        //{
        //   Console.WriteLine($"{collection[i]}");
        //}
        //
        //Console.WriteLine($"stop");
        //
        //for (int x = 0, y = values.Length - 1;
        //((x < values.Length) && (y >= 0));
        //x++, y--)
        //{
        //   Console.Write(values[x]);
        //   Console.Write(values[y]);
        //}
        //Console.WriteLine($"/////////////////////");
        //
        //int index = 0;
        //while (index < collection.Length)
        //{
        //   Console.WriteLine($"{collection[index]}");
        //   index++;
        //}
        //Console.WriteLine($"stop");
        //
        //do
        //{
        //   Console.WriteLine("Executed once");
        //}
        //while (false);

         string SDIP_35310 = "01";
         string SDIP_35302 = "01";
         string Foo = "01";

         var Bar = SDIP_35302 == "01" ? null : "lol";

         Console.WriteLine($"bar {Bar}");



         Console.ReadKey();
      }
   }
}
