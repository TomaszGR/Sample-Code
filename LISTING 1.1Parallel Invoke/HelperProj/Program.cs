using System;

namespace HelperProj
{
   class Program
   {
      static void Main(string[] args)
      {

         int no = 1; // trzeba inicjować 
         int noOut; // nie trzeba inicjować
         string str = "aa";
         int numerRef1 = 1;
         ref int numerRef2 = ref numerRef1;
         numerRef2 = 2;

         PassByValue(no);
         PassByValueString(str);
         PassByReference(ref no); // to trzeba zainicjować zmienną
         PassByOut(out noOut);
         PassByOut(out int numberOut);

         Console.WriteLine($"After the invocation of {nameof(PassByValue)} method, {nameof(no)} = {no}");
         Console.WriteLine($"After the invocation of {nameof(PassByReference)} method, {nameof(no)} = {no}");
         Console.WriteLine($"After the invocation of {nameof(PassByOut)} method, {nameof(noOut)} = {noOut}");
         Console.WriteLine($"After the invocation of {nameof(PassByOut)} method, {nameof(numberOut)} = {numberOut}");
         Console.WriteLine($"After the invocation of {nameof(PassByValueString)} method, {nameof(str)} = {str}");
         Console.WriteLine($"local ref variable {nameof(numerRef1)} after assign {nameof(numerRef1)}, ref1 = {numerRef1} variable ref2= {numerRef2}");
         Console.WriteLine($"///////////////////////////////////////////////");

         Program p = new Program();
         int[] x = { 2, 4, 62, 54, 33, 55, 66, 71, 92 };

         for (int i = 0; i < x.Length; i++)
         {
            Console.Write($"{x[i]}\t");
         }
         Console.WriteLine($"//////////////////////");

         ref int oddNum = ref p.GetFirstOddNumber(x); //storing as reference  
         int oddNum2 = p.GetFirstOddNumber(x); 
         Console.WriteLine($"\t\t{oddNum}");
         Console.WriteLine($"\t\t{oddNum2}");

         oddNum = 35;
         for (int i = 0; i < x.Length; i++)
         {
            Console.Write($"{x[i]}\t");
         }
         Console.WriteLine($"//////////////////////");

         oddNum2 = 35;
         for (int i = 0; i < x.Length; i++)
         {
            Console.Write($"{x[i]}\t");
         }

         Console.WriteLine("Press any key to Exit.");
         Console.ReadLine();
      }

      public int GetFirstOddNumber2(int[] numbers)
      {
         for (int i = 0; i < numbers.Length; i++)
         {
            if (numbers[i] % 2 == 1)
            {
               return numbers[i]; //returning as reference  
            }
         }
         throw new Exception("odd number not found");
      }

      public ref int GetFirstOddNumber(int[] numbers)
      {
         for (int i = 0; i < numbers.Length; i++)
         {
            if (numbers[i] % 2 == 1)
            {
               return ref numbers[i]; //returning as reference  
            }
         }
         throw new Exception("odd number not found");
      }

      private static void PassByOut(out int x)
      {
         x = 8;
      }

      private static void PassByReference(ref int x)
      {
         x = 7;
      }

      private static void PassByValueString(string str)
      {
         str = "ffffffffffff";
      }

      static void PassByValue(int x)
      {
         x = 2;
      }
   }
}
