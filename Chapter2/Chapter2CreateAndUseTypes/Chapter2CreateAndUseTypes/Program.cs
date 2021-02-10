using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter2CreateAndUseTypes
{
   #region Construct types
   //
   //public struct Point
   //{
   //   public int x, y;
   //   public Point(int p1, int p2)
   //   {
   //      x = p1;
   //      y = p2;
   //   }
   //}
   //
   //public class MyClass
   //{
   //   public void MyMethod(int firstArgument, string secondArgument = "default value", bool thirdArgument = false) { }
   //}
   //
   //public class Card
   //{
   //   public string Name { get; set; }
   //}
   //
   //public class Deck
   //{
   //   public Deck()
   //   {
   //   }
   //
   //   public Deck(int maximumNumberOfCards)
   //   {
   //      _maximumNumberOfCards = maximumNumberOfCards;
   //      Cards = new List<Card>(); // pamiętać zawsze o inicjalizacji listy !!!!!
   //   }
   //
   //   public int _maximumNumberOfCards { get; set; }
   //
   //   public ICollection<Card> Cards { get; set; }
   //
   //   public Card this[int cardIndex]
   //   {
   //      get { return Cards.ElementAt(cardIndex); }
   //   }
   //}
   //
   //public class MyClass2
   //{
   //   public MyClass2() : this(3) 
   //   {
   //   }
   //
   //   public MyClass2(int p)
   //   {
   //      _p = p;
   //   }
   //
   //   public int _p { get; set; }
   //
   //}
   //
   //class NamedIntArray
   //{
   //   // Create an array to store the values
   //   private int[] array = new int[100];
   //
   //   // Decleare an indexer property
   //   public int this[string name]
   //   {
   //      get
   //      {
   //         switch (name)
   //         {
   //            case "zero":
   //               return array[0];
   //            case "one":
   //               return array[1];
   //            default:
   //               return -1;
   //         }
   //      }
   //      set
   //      {
   //         switch (name)
   //         {
   //            case "zero":
   //               array[0] = value;
   //               break;
   //            case "one":
   //               array[1] = value;
   //               break;
   //         }
   //      }
   //   }
   //}
   //
   //class Program
   //{
   //   static void Main(string[] args)
   //   {
   //      var p = new Point(3, 4);
   //
   //      Console.WriteLine($"point x: {p.x}  y: {p.y}");
   //
   //      var mv = new MyClass();
   //      mv.MyMethod(2, thirdArgument: true);
   //
   //      var c1 = new Card() { Name = "1" };
   //      var c2 = new Card() { Name = "2" };
   //      var c3 = new Card() { Name = "3" };
   //      var d = new Deck() { Cards = new List<Card>() { c1, c2, c3 } };
   //      var insexProperty = d[1].Name;
   //
   //      NamedIntArray x = new NamedIntArray();
   //      x["zero"] = 55;
   //      Console.WriteLine(x["zero"]);
   //      Console.WriteLine($"index property: {insexProperty}");
   //
   //      var deckD = new Deck(55);
   //      Console.WriteLine("stop");
   //   }
   //}
   #endregion
   #region Using generic types, Extending existing types

   static class MyExtensions
   {
      public static decimal Discount(this Product product)
      {
         return product.Price * .9M;
      }
   }
   class Product
   {
      public decimal Price { get; set; }

      public virtual int MyVistualMethod()
      {
         return 100;
      }
   }
   class Program : Product
   {
      class MyClass<T> where T : class, new()
      {
         public MyClass()
         {
            MyProperty = new T();
         }

         public T MyProperty { get; set; }

      }

      public decimal CalculateDiscount(Product p)
      {
         return p.Discount();
      }

      public override int MyVistualMethod()
      {
         return base.MyVistualMethod() * 10;
      }

      static void Main(string[] args)
      {
         var prog = new Program();
         var prod = new Product() { Price=100 };
         Console.WriteLine($"calculate result: {prog.CalculateDiscount(prod)}");
         Console.WriteLine($"override methd result: {prog.MyVistualMethod()}");
    
         Console.WriteLine($"stop");

      }
   }
   #endregion

}
