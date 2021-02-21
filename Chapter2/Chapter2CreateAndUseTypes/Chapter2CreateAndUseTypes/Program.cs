using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Xunit;

namespace Chapter2CreateAndUseTypes
{
   public static class Print
   {
      public static void Dump(this object input)
      {
         Console.WriteLine(input);
      }
   }
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
   //interface IAnimal
   //{
   //   void Move();
   //}
   //class Dog : IAnimal
   //{
   //   public void Move() { }
   //   public void Bark() { }
   //   public void MoveAnimal(IAnimal animal)
   //   {
   //      Console.WriteLine("animal się rusza");
   //   }
   //}
   //
   //interface IExample
   //{
   //   string GetResult();
   //   public int Value { get; }
   //   event EventHandler ResultRestricted;
   //   int this[string index] { get; set; }
   //}
   //
   //class ExampleImplementation : IExample
   //{
   //   public ExampleImplementation() { }
   //   public ExampleImplementation(int value)
   //   {
   //      Value = value;
   //   }
   //
   //   public int this[string index] { get => 9; set => _ = 3; }
   //   public ExampleImplementation this[int index] { get => new ExampleImplementation(); set => _ = 3; }
   //
   //   public int Value { get => 7; set => _ = 3; }
   //
   //   public event EventHandler ResultRestricted;
   //
   //   public string GetResult()
   //   {
   //      Console.WriteLine($" GetResult Value: {Value}");
   //      return Value.ToString();
   //   }
   //}
   //class Program
   //{
   //   static void Main(string[] args)
   //   {
   //      ExampleImplementation exampleImplementation = new ExampleImplementation();
   //      exampleImplementation.GetResult();
   //      var dd = exampleImplementation["1"];
   //      var dd2 = exampleImplementation[4];
   //
   //      Console.WriteLine($" dd: {dd}");
   //      Console.WriteLine($" dd2: {dd2}");
   //      Console.WriteLine($" exampleImplementation.Value: {exampleImplementation.Value}");
   //
   //      IAnimal animal = new Dog();
   //      Dog animal2 = new Dog();
   //      Dog gg = (Dog)animal;
   //      gg.Bark();
   //      gg.MoveAnimal(animal);
   //
   //      Console.WriteLine($"end");
   //   }
   //}
   //
   #endregion
   #region Inherit from class
   //interface IEntity
   //{
   //   public int Id { get; set; }
   //}

   //class Repository<T> where T : IEntity
   //{
   //   protected IEnumerable<T> _elements;

   //   public Repository(IEnumerable<T> elements)
   //   {
   //      _elements = elements;
   //   }

   //   public T FinfById(int id)
   //   {
   //      return _elements.SingleOrDefault(x => x.Id == id);
   //   }
   //}

   //public class Order : IEntity
   //{
   //   public int Id { get => 2; set => _ = 2; }
   //   // any other implementation
   //   public int Amount { get; set; }
   //   public string Name { get; set; }

   //}

   //class OrderRepo : Repository<Order>
   //{
   //   public OrderRepo(IEnumerable<Order> elements) : base(elements)
   //   {
   //   }

   //   public void PrintNames()
   //   {
   //      Console.WriteLine($"nale of first element: {_elements.FirstOrDefault().Name}");
   //   }

   //}

   //class Program
   //{
   //   static void Main(string[] args)
   //   {

   //      var myclaslist = new List<Order>() { new Order() { Id = 2, Amount= 2345, Name = "aaName" } };
   //      Repository<Order> repository = new Repository<Order>(myclaslist);

   //      OrderRepo orderRepo = new OrderRepo(myclaslist);
   //      var tt = orderRepo.FinfById(2);


   //      Console.WriteLine($"result: {tt.Id},  {tt.Amount}, {tt.Name}");
   //      orderRepo.PrintNames();
   //      Console.WriteLine($"stop");

   //   }

   //}
   #endregion
   #region Canging behavior
   //public class BaseClass
   //{
   //   public virtual void Execute()
   //   {
   //      Console.WriteLine($"Base class execute");
   //   }
   //
   //   public void ExecuteNew()
   //   {
   //      Console.WriteLine($"Base class executeNew");
   //   }
   //}
   //
   //public abstract class AbstractClass
   //{
   //   public virtual void Listening()
   //   {
   //      Console.WriteLine("music");
   //   }
   //   public int MyProperty { get; set; }
   //}
   //
   //class RealClass : AbstractClass
   //{
   //  //public override void Listening()
   //  //{
   //  //   base.Listening();
   //  //}
   //}
   //
   //
   //class Derived : BaseClass
   //{
   //   public override void Execute()
   //   {
   //      //Log("Before executing");
   //      //base.Execute();
   //      //Log("After executing");
   //      //base.Execute();
   //      Log("override execute");
   //      Console.WriteLine($"Override class execute");
   //   }
   //
   //   //NIE ZALECANE JEST UŻYCIE NEW PRZY DZIEDZICZENIU!!!
   //   public new void ExecuteNew()
   //   {
   //      Console.WriteLine($"Override class ExecuteNew");
   //   }
   //
   //   private void Log(string message) 
   //   {
   //      Console.WriteLine($"log: {message}");
   //   }
   //}
   //class Program
   //{
   //   static void Main(string[] args)
   //   {
   //      BaseClass baseClass = new BaseClass();
   //      baseClass.Execute();
   //      baseClass.ExecuteNew(); 
   //
   //      Derived derived = new Derived();
   //      derived.Execute();
   //      derived.ExecuteNew();
   //
   //      RealClass realClass = new RealClass();
   //
   //   }
   //}
   #endregion
   #region Implementing standard .NET Framework interfaces
   //class Order : IComparable
   //{
   //   public DateTime Created { get; set; }
   //   public int CompareTo(object obj)
   //   {
   //      if (obj == null)
   //      {
   //         return 1;
   //      }
   //      Order o = obj as Order;
   //      if (o == null)
   //      {
   //         throw new ArgumentException("object is null");
   //      }
   //      return this.Created.CompareTo(o.Created);
   //   }
   //}
   //
   //class Person
   //{
   //   public Person(string firstName, string lastName)
   //   {
   //      FirstName = firstName;
   //      LastName = lastName;
   //   }
   //   public string FirstName { get; set; }
   //   public string LastName { get; set; }
   //   public override string ToString()
   //   {
   //      return FirstName + " " + LastName;
   //   }
   //}
   //
   //class People : IEnumerable<Person>
   //{
   //   Person[] people;
   //   List<Person> peopleList;
   //   public People(Person[] people)
   //   {
   //      this.people = people;
   //   }
   //   public People()
   //   {
   //      this.people = FillPeople();
   //   }
   //
   //   public IEnumerator<Person> GetEnumerator()
   //   {
   //      for (int index = 0; index < people.Length; index++)
   //      {
   //         //słowo kluczowe yield pozwala na wyjście z iteracji kiedy wajakiś warunek jest słeniony
   //         //  w tym przypadku wychodzi z for kiedy nie ma więcej elementów
   //         yield return people[index];
   //      }
   //   }
   //   IEnumerator IEnumerable.GetEnumerator()
   //   {
   //      return GetEnumerator();
   //   }
   //
   //   public Person[] FillPeople()
   //   {
   //      return new Person[] {
   //         new Person( "aa","bb" ),
   //         new Person( "cc","ll" ),
   //         new Person( "dd","mm" ),
   //         new Person( "ff","nn" ),
   //         new Person( "gg","vv" ),
   //         new Person( "hh","zz" ),
   //      };
   //   }
   //}
   //class Program
   //{
   //   static IEnumerable<int> RunningTotal()
   //   {
   //      int runningTotal = 0;
   //      foreach (var item in MyList)
   //      {
   //         runningTotal += item;
   //         yield return runningTotal;
   //      }
   //      yield return runningTotal;
   //   }
   //   static void FillMyList()
   //   {
   //      MyList.Add(1);
   //      MyList.Add(2);
   //      MyList.Add(3);
   //      MyList.Add(4);
   //      MyList.Add(5);
   //   }
   //   static List<int> MyList = new List<int>();
   //   static void Main(string[] args)
   //   {
   //      List<Order> orderList = FillOrderList();
   //
   //      //bez implementacji interfejsu IComparable nie można sortować za pomoca Sort()
   //      orderList.Sort();
   //
   //      foreach (var item in orderList)
   //      {
   //         Console.WriteLine($"{item.Created}");
   //      }
   //
   //      List<int> numbers = new List<int> { 1, 345, 3, 876, 7, 9 };
   //      using (var enumerator = numbers.GetEnumerator())
   //      {
   //         while (enumerator.MoveNext())
   //         Console.WriteLine(enumerator.Current);
   //      }
   //
   //      People people = new People();
   //      //gdybym nie użył IEnumaerable to metoda GetEnumerator pozwalająca na użycie foreacha na 
   //      //  tablicy people była by niedostępna
   //      foreach (var item in people)
   //      {
   //         Console.WriteLine($"{item.FirstName}, {item.LastName}");
   //      }
   //
   //      Console.WriteLine($"///////////////////");
   //
   //      FillMyList();
   //      foreach (var item in RunningTotal())
   //      {
   //         Console.WriteLine(item);
   //      }
   //      Console.WriteLine($"end");
   //   }
   //
   //   private static List<Order> FillOrderList()
   //   {
   //      return new List<Order>() {
   //         new Order() { Created = new DateTime(2000,05,06) },
   //         new Order() { Created = new DateTime(2000,09,06) },
   //         new Order() { Created = new DateTime(2000,01,06) },
   //         new Order() { Created = new DateTime(2000,02,06) },
   //         new Order() { Created = new DateTime(2000,06,06) },
   //         new Order() { Created = new DateTime(2000,02,06) },
   //      };
   //   }
   //}
   #endregion
   #region Objective 2.5: Find, execute, and create types at runtime by using reflection
   //[Serializable]
   //class Person
   //{
   //   public string FirstName { get; set; }
   //   public string LastName { get; set; }
   //}

   //[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
   //public class UnitTest2Attribute : CategoryAttribute
   //{
   //   public string Description { get; set; }

   //   public UnitTest2Attribute(string description) : base("UnitTest2")
   //   {
   //      Description = description;
   //   }
   //}

   //class Program
   //{
   //   static void Main(string[] args)
   //   {
   //      Console.WriteLine($"end");
   //   }

   //   [Fact]
   //   [UnitTest2("desctiptionPassedToAtributeContructor")]
   //   public void MySecondUnitTest()
   //   { }
   //}
   #endregion
   #region reflections
   //class Program
   //{
   //   public int MyProperty { get; set; }
   //   private int Foo { get; set; }
   //   private int MyProperty2 { get; set; }
   //   static void GetNonPublicFields(object obj)
   //   {
   //      var o = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
   //      foreach (var item in o)
   //      {
   //         item.GetValue(obj).Dump();
   //         item.Name.Dump();
   //      }
   //   }
   //
   //   static void Main()
   //   {
   //      Program program = new Program();
   //      int i = 234;
   //      i.GetType().Dump();
   //      GetNonPublicFields(program);
   //
   //      CodeCompileUnit compileUnit = new CodeCompileUnit();
   //      CodeNamespace myNamespace = new CodeNamespace("MyNamespace");
   //      myNamespace.Imports.Add(new CodeNamespaceImport("System"));
   //      CodeTypeDeclaration myClass = new CodeTypeDeclaration("MyClass");
   //      CodeEntryPointMethod start = new CodeEntryPointMethod();
   //      CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
   //      new CodeTypeReferenceExpression("Console"),
   //      "WriteLine", new CodePrimitiveExpression("Hello World!"));
   //      compileUnit.Namespaces.Add(myNamespace);
   //      myNamespace.Types.Add(myClass);
   //      myClass.Members.Add(start);
   //      start.Statements.Add(cs1);
   //
   //      CSharpCodeProvider provider = new CSharpCodeProvider();
   //      using (StreamWriter sw = new StreamWriter("HelloWorld.cs", false))
   //      {
   //         IndentedTextWriter tw = new IndentedTextWriter(sw, " ");
   //         provider.GenerateCodeFromCompileUnit(compileUnit, tw,
   //         new CodeGeneratorOptions());
   //         tw.Close();
   //      }
   //
   //      BlockExpression blockExpr = Expression.Block(
   //      Expression.Call(
   //      null,
   //      typeof(Console).GetMethod("Write", new Type[] { typeof(String) }),
   //      Expression.Constant("Hello")
   //      ),
   //      Expression.Call(
   //      null,
   //      typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
   //      Expression.Constant("World!") )
   //      );
   //      Expression.Lambda<Action>(blockExpr).Compile()();
   //
   //      Console.WriteLine($"end");
   //   }
   //}
   #endregion
   #region Manage memory
   //class Program
   //{
   //   static void Main()
   //   {
   //      // obiekty dziedziczące po IDisposable powinny być opakowane we wrapper USING
   //      using (StreamWriter streamWriter = File.CreateText("temp.dat"))
   //      {
   //         streamWriter.Write("some text");
   //      }
   //      File.Delete("temp.dat");
   //
   //      "end".Dump();
   //      123.Dump();
   //      new DateTime().Dump();
   //      Console.WriteLine($"end");
   //   }
   //}

   #endregion

   #region stringi
   class Program
   {
      static void Main()
      {
         StringBuilder sb = new StringBuilder(string.Empty);
         for (int i = 0; i < 1000; i++)
         {
            sb.Append("x");
         }
         new String('c', 50).Dump();
         sb.Dump();



         var stringWriter = new StringWriter();
         using (XmlWriter writer = XmlWriter.Create(stringWriter))
         {
            writer.WriteStartElement("book");
            writer.WriteElementString("price", "19.95");
            writer.WriteEndElement();
            writer.Flush();
         }
         string xml = stringWriter.ToString();
         xml.Dump();


         var stringReader = new StringReader(xml);
         using (XmlReader reader = XmlReader.Create(stringReader))
         {
            reader.ReadToFollowing("price");
            decimal price = decimal.Parse(reader.ReadInnerXml(),
            new CultureInfo("en-US")); // Make sure that you read the decimal part correctly
         }
         stringReader.Dump();

         //////regex
         string pattern = "(Mr\\.? | Mrs\\.? | Miss | Ms\\.? )";
         string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels", "Abraham Adams", "Ms. Nicole Norris" };
         foreach (string name in names)
            Console.WriteLine(Regex.Replace(name, pattern, string.Empty));

         foreach (string word in "My sentence separated by spaces".Split(' ')) { }

         string ff = "asd asdasd 098098 asdasd 0a9s8d asd -9";
         foreach (string word in ff.Split('0'))
         {
            word.Dump();
         }

         new Person("Tom", "Jerry").Dump();


         "end".Dump();
      }
   }
   class Person : IFormattable
   {
      public Person(string name, string surname)
      {
         Name = name;
         Surname = surname;
      }

      public string Name { get; set; }
      public string Surname { get; set; }

      public override string ToString()
      {
         return Name + ' ' + Surname;
      }

      public string ToString(string format)
      {
         if (string.IsNullOrWhiteSpace(format) || format == "G")
         {
            format = "FL";
         }

         switch (format)
         {
            case "FL":
               return Name + Surname;
            case "LF":
               return "sdfzsdf";
            default:
               throw new FormatException(String.Format(
    "The '{0}' format string is not supported.", format));
         }
      }

      public string ToString(string format, IFormatProvider formatProvider)
      {
         throw new NotImplementedException();
      }
   }

   #endregion

}