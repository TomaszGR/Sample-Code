using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Dynamic;
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
   //
   //static class MyExtensions
   //{
   //   public static decimal Discount(this Product product)
   //   {
   //      return product.Price * .9M;
   //   }
   //}
   //class Product
   //{
   //   public decimal Price { get; set; }
   //
   //   public virtual int MyVistualMethod()
   //   {
   //      return 100;
   //   }
   //}
   //class Program : Product
   //{
   //   class MyClass<T> where T : class, new()
   //   {
   //      public MyClass()
   //      {
   //         MyProperty = new T();
   //      }
   //
   //      public T MyProperty { get; set; }
   //
   //   }
   //
   //   public decimal CalculateDiscount(Product p)
   //   {
   //      return p.Discount();
   //   }
   //
   //   public override int MyVistualMethod()
   //   {
   //      return base.MyVistualMethod() * 10;
   //   }
   //
   //   static void Main(string[] args)
   //   {
   //      var prog = new Program();
   //      var prod = new Product() { Price=100 };
   //      Console.WriteLine($"calculate result: {prog.CalculateDiscount(prod)}");
   //      Console.WriteLine($"override methd result: {prog.MyVistualMethod()}");
   // 
   //      Console.WriteLine($"stop");
   //
   //   }
   //}
   #endregion
   #region Using types
   //
   //class Program
   //{
   //   static void Main(string[] args)
   //   {
   //
   //      var tt = string.Concat("foo",34,true);
   //      var gg = new Object();
   //
   //      gg = "asd";
   //
   //      //boxing
   //      int i = 123;
   //      object boxing = i;
   //      //unboxing
   //      int unboxing = (int)boxing;
   //      Console.WriteLine($"tt: {tt}");
   //      Console.WriteLine($"boxing: {boxing}");
   //      Console.WriteLine($"unboxing: {unboxing}");
   //
   //      var mon = new Money(1234.55M);
   //      mon.GetType();
   //      Console.WriteLine($"1234.55: {mon.Amount.GetType()}");
   //      int ggg = (int)mon;
   //      decimal de = mon;
   //
   //      var strOver = StrOver.ToString("1");
   //      Console.WriteLine($"strOver: {strOver}");
   //
   //      Console.WriteLine($"stop");
   //   }
   //}
   //
   //public static class StrOver
   //{
   //   public static string ToString(this string s)
   //   {
   //      return s + "a";
   //   }
   //}
   //
   //class Money
   //{
   //   public Money(decimal amount)
   //   {
   //      Amount = amount;
   //   }
   //   public decimal Amount { get; set; }
   //
   //   public static implicit operator decimal(Money money)
   //   {
   //      return money.Amount;
   //   }
   //
   //   public static explicit operator int(Money money)
   //   {
   //      return (int)money.Amount;
   //   }
   //
   //}
   #endregion
   #region dynamic types
   //
   //class SampleObject : DynamicObject
   //{
   //   public string MyProperty = "aa";
   //   public override bool TryGetMember(GetMemberBinder binder, out object result)
   //   {
   //      result = binder.Name;
   //      return true;
   //   }
   //}
   //class Program
   //{
   //   static void Main(string[] args)
   //   {
   //      dynamic so = new SampleObject();
   //
   //      Console.WriteLine($"{so}");
   //      Console.WriteLine($"{so.MyProperty}");
   //      Console.WriteLine($"{so.SomeProperty}");
   //
   //   }
   //}
   #endregion
   #region Pros and Cons of non generic collections
   //class Program
   //{
   //   static void Main(string[] args)
   //   {
   //      // The collection classes belong to System.Collections namespace operates on the object data type.The object data type in 
   //      // C# is a reference data type. So the value that we storing into the collection are converted to reference type. 
   //      // So in our example, the value 100 and 200 are boxed and converted into the reference type. In our example, we just stored two values. 
   //      // Consider a scenario where we need to store 1000 integers values. Then all the 1000 integers are boxed
   //      // , meaning they are converted into reference types and then stored into the collection.
   //      var stringsArrayList = new ArrayList(3);
   //      stringsArrayList.Add("asd");
   //
   //      var Numbers = new ArrayList(3);
   //      // Boxing happens - Converting Value type (1, 2) to reference type
   //      // Means Integer to object type
   //      Numbers.Add(1);
   //      Numbers.Add(2);
   //      Numbers.Add(3);
   //      Numbers.Add(4);
   //      Numbers.Add(5);
   //      // Unboxing happens - 1 and 2 stored as object type
   //      // now conveted to Integer type
   //      foreach (int item in Numbers)
   //      {
   //         Console.Write(item + " ");
   //      }
   //
   //      //Array - Type safe
   //      // Array ma stały rozmiar, chyba że się Zrobi Concat ale to łączenie...
   //      int[] NumbersA = new int[4] { 10, 20, 30, 40 };
   //      NumbersA = NumbersA.Concat(new int[] { 2 }).ToArray();
   //      NumbersA = NumbersA.Concat(new int[] { 2 }).ToArray();
   //      NumbersA = NumbersA.Concat(new int[] { 2 }).ToArray();
   //      foreach (var item in NumbersA)
   //      {
   //         Console.WriteLine($"{item}");
   //      }
   //
   //      //Array: Type - safe but fixed length
   //      //Collections: Auto Resizing but not type - safe
   //      //Generic Collections: Typesafe and auto - resizing
   //
   //      Console.ReadKey();
   //      Console.WriteLine($"stop");
   //
   //   }
   //}
   #endregion
   #region Generic types
   //public class ClsCalculator
   //{
   //   public static bool AreEqual<T>(T value1, T value2)
   //   {
   //      return value1.Equals(value2);
   //   }
   //   public static bool AreEqual<T, R>(T value1, R value2)
   //   {
   //      return value1.Equals(value2);
   //   }
   //}
   //
   //class MyClassGen<T, R>
   //{
   //   public MyClassGen(T myProperty, R myProperty2)
   //   {
   //      MyProperty = myProperty;
   //      MyProperty2 = myProperty2;
   //   }
   //
   //   public T MyProperty { get; set; }
   //   public R MyProperty2 { get; set; }
   //}
   //class MyGenericClass<T>
   //{
   //   //Generic variable
   //   //The data type is generic
   //   private T genericMemberVariable;
   //   //Generic Constructor
   //   //Constructor accepts one parameter of Generic type
   //   public MyGenericClass(T value)
   //   {
   //      genericMemberVariable = value;
   //   }
   //   //Generic Method
   //   //Method accepts one Generic type Parameter
   //   //Method return type also Generic
   //   public T genericMethod(T genericParameter)
   //   {
   //      Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T).ToString(), genericParameter);
   //      Console.WriteLine("Return type: {0}, value: {1}", typeof(T).ToString(), genericMemberVariable);
   //      return genericMemberVariable;
   //   }
   //   //Generic Property
   //   //The data type is generic
   //   public T genericProperty { get; set; }
   //}
   //class Program
   //{
   //   static void Main(string[] args)
   //   {
   //      // the most important point that you need to remember is while creating the objects of Generic Collection classes, 
   //      // you need to explicitly provide the type of values that you are going to store into the collection.
   //
   //      bool IsEqual = ClsCalculator.AreEqual("5", 5);
   //      if (IsEqual)
   //      {
   //         Console.WriteLine("Both are Equal");
   //      }
   //      else
   //      {
   //         Console.WriteLine("Both are Not Equal");
   //      }
   //
   //      var gen = new MyGenericClass<int>(5);
   //      var res = gen.genericMethod(555555555);
   //
   //      Console.WriteLine($"res: {res}");
   //      var hh = new MyClassGen<int, string>(3, "asd");
   //
   //      var jj = new MyGenericClass<string>("stringValue");
   //      jj.genericMethod("stringPassedToMEthod");
   //
   //      Console.WriteLine("end");
   //      Console.ReadKey();
   //   }
   //}
   #endregion
   #region 2.3 Access modifiers, Using explicit interface implementations

   //public class Accessibility
   //{
   //   // initialization code and error checking omitted
   //   private string[] _myField;
   //
   //   public Accessibility()
   //   {
   //      _myField = new string[1];
   //   }
   //
   //   public string MyProperty
   //   {
   //      get { return _myField[0]; }
   //      set { _myField[0] = value; }
   //   }
   //}
   //
   //public interface IObjectContextAdapter
   //{
   //   ObjectContext ObjectContextTG { get; }
   //}
   //
   //interface ILeft
   //{
   //   void Move();
   //   public void Move(int i);
   //}
   //interface IRight
   //{
   //   void Move();
   //   public void Move(string i);
   //}
   //class MoveableOject : ILeft, IRight
   //{
   //   public void Move(int i){}
   //
   //   public void Move(string i)
   //   {
   //      throw new NotImplementedException();
   //   }
   //
   //   void ILeft.Move() { }
   //   void IRight.Move() { }
   //}
   //interface IInterfaceA
   //{
   //   void MyMethod(); // dzięki temu że nie ma ptu PUBLIC użytkownicy nie zobaczą tej metody w klasie która implementuje tej intrfejs
   //   // czyli uzywamy tylko jako stalenie kontraktu
   //}
   //class Implementation : IInterfaceA
   //{
   //   void IInterfaceA.MyMethod() { }
   //}
   //class Program
   //{
   //   static void Main(string[] args)
   //   {
   //      var acess = new Accessibility();
   //      acess.MyProperty = "aa";
   //      Console.WriteLine($"access: {acess.MyProperty}");
   //
   //      DbContext ctx = new DbContext("");
   //      //ObjectContext context1 = ctx.ObjectContextTG; to nie zadziała 
   //      ObjectContext context = ((IObjectContextAdapter)ctx).ObjectContextTG;
   //
   //      Implementation implementation = new Implementation();
   //
   //      Console.WriteLine($"end");
   //
   //   }
   //}
   //
   #endregion
   #region 2.4 Class hierarchy
   interface IAnimal
   {
      void Move();
   }
   class Dog : IAnimal
   {
      public void Move() { }
      public void Bark() { }
      public void MoveAnimal(IAnimal animal)
      {
         Console.WriteLine("animal się rusza");
      }
   }

   interface IExample
   {
      string GetResult();
      public int Value { get; }
      event EventHandler ResultRestricted;
      int this[string index] { get; set; }
   }

   class ExampleImplementation : IExample
   {
      public ExampleImplementation() {}
      public ExampleImplementation(int value)
      {
         Value = value;
      }

      public int this[string index] { get => 9; set => _ = 3; }
      public ExampleImplementation this[int index] { get => new ExampleImplementation(); set => _ = 3; }

      public int Value { get => 7; set => _ = 3; }

      public event EventHandler ResultRestricted;

      public string GetResult()
      {
         Console.WriteLine($" GetResult Value: {Value}");
         return Value.ToString();
      }
   }
   class Program
   {
      static void Main(string[] args)
      {
         ExampleImplementation exampleImplementation = new ExampleImplementation();
         exampleImplementation.GetResult();
         var dd = exampleImplementation["1"];
         var dd2 = exampleImplementation[4];
   
         Console.WriteLine($" dd: {dd}");
         Console.WriteLine($" dd2: {dd2}");
         Console.WriteLine($" exampleImplementation.Value: {exampleImplementation.Value}");

         IAnimal animal = new Dog();
         Dog animal2 = new Dog();
         Dog gg = (Dog)animal;
         gg.Bark();
         gg.MoveAnimal(animal);
         
         Console.WriteLine($"end");
      }
   }
   
   #endregion
}