using System;
using System.Collections.Generic;

namespace StoreAndRetriveData45
{
   public static class Dumps
   {
      public static void dump(this object o)
      {
         Console.WriteLine($"{o}");
      }
   }
   public class Person
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public int Age { get; set; }
   }

   public class PersonCollection2 : Person
   {
      public void PrintName()
      {
         this.Name.dump();
      }
   }

   public class PersonCollection : List<Person>
   {
      public void PrintByIndex(int i)
      {
         this[0].Name.dump();
      }

      public void RemoveByAge(int age)
      {
         for (int index = this.Count - 1; index >= 0; index--)
         {
            if (this[index].Age == age)
            {
               this.RemoveAt(index);
            }
         }
      }

   }


   class Program
   {
      static void Main(string[] args)
      {

         PersonCollection pc = new PersonCollection();
         pc.Add(new Person() { Id = 1, Age = 23, Name = "bOB" });
         pc.Add(new Person() { Id = 1, Age = 26, Name = "kASIA" });
         pc.Add(new Person() { Id = 1, Age = 24, Name = "Ryś" });

         foreach (var item in pc)
         {
            item.Name.dump();
         }
         "xxxxxxxxxxxxxxx".dump();
         pc.RemoveByAge(23);

         foreach (var item in pc)
         {
            item.Name.dump();
         }

         pc.PrintByIndex(8);

         int[] inty = { 1, 2, 3, 4, 5, 6 };

         foreach (var item in inty)
         {
            item.dump();
         }

         List<string> ls = new List<string> { "b", "b", "b", "b", "b", "b", "a", "b", "c" };

         ls.Remove("b");
         ls.Remove("b");
         ls.Remove("b");

         foreach (var item in ls)
         {
            item.dump();
         }

         Dictionary<int, Person> dp = new Dictionary<int, Person>();
         dp.Add(1, new Person() { Id = 15, Name = "Bob" });
         dp.Add(2, new Person() { Id = 25, Name = "Rob" });
         dp.Add(5, new Person() { Id = 55, Name = "Anrzej" });
         dp.Add(4, new Person() { Id = 45, Name = "Halina" });

         Person res;
         if (!dp.TryGetValue(4, out res))
         {
            "brak osoby dla klucza 3!".dump();
            Console.ReadKey();
            return;
         }
         else
         {
            res.Id.dump();
            res.Name.dump();
         }

         HashSet<int> hsOdd = new HashSet<int>();
         HashSet<int> hsEven = new HashSet<int>();

         for (int i = 0; i < 15; i++)
         {
            if (i % 2 == 0)
            {
               hsEven.Add(i);
            }
            else
            {
               hsOdd.Add(i);
            }
         }

         hsEven.Add(2);
         hsEven.Add(2);
         hsEven.Add(2);
         hsEven.Add(2);
         hsEven.Add(2);
         hsEven.Add(2);
         foreach (var item in hsOdd)
         {
            $"odd: {item}".dump();
         }
         foreach (var item in hsEven)
         {
            $"even: {item}".dump();
         }
         hsEven.Add(2);

         Queue<string> qs = new Queue<string>(new List<string> { "aa", "vv", "gg", "//////////////////" });
         qs.Enqueue("gg");
         qs.Peek().dump();
         foreach (var item in qs)
         {
            item.dump();
         }

         Stack<string> ss = new Stack<string>(new List<string> { "aa", "vv", "gg", "/////////////////////" });
         ss.Peek().dump();
         foreach (var item in ss)
         {
            item.dump();
         }

         Console.ReadKey();
      }
   }
}
