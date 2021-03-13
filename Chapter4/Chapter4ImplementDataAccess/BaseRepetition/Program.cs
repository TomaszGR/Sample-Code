using System;

namespace BaseRepetition
{
   class BaseClass
   {
      public BaseClass(int myBaseInt)
      {
         MyBaseInt = myBaseInt;
      }

      public int MyBaseInt { get; set; }
      public void PrintBaseInt()
      {
         Console.WriteLine($"base: {MyBaseInt +1}");
      }
   }

   class DerivedClass : BaseClass
   {
      public DerivedClass(int myBaseInt) : base(myBaseInt)
      {

      }

      public DerivedClass(int myDerInt, int baseInt) : base(myBaseInt: baseInt)
      {
         MyDerInt = myDerInt;
      }

      public int MyDerInt { get; set; }

      public void PrintDerivedInt()
      {
         Console.WriteLine($"derived: {MyDerInt + 3}");
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         DerivedClass derivedClass = new DerivedClass(5,5);
         derivedClass.PrintBaseInt();
         derivedClass.PrintDerivedInt();


        /// Console.WriteLine($"{}");
         Console.WriteLine("Hello World!");
      }
   }
}
