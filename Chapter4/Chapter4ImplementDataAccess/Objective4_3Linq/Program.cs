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

   public class Product
   {
      public string Description { get; set; }
      public decimal Price { get; set; }
   }
   public class OrderLine
   {
      public int Amount { get; set; }
      public Product Product { get; set; }
   }

   public class Response
   {
      public int? Id { get; set; }
      public Guid? OrgIdK { get; set; }
      public int? OrgNumK { get; set; }
      public Guid? OrgIdE { get; set; }
      public int? OrgNumE { get; set; }
      public string? Desc { get; set; }
   }
   public class Order
   {
      public List<OrderLine> OrderLines { get; set; }
   }

   public static class LinqExtensions
   {
      public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
      {
         foreach (TSource item in source)
         {
            if (predicate(item))
            {
               yield return item;
            }
         }
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

         Action<int> del2 = (int x) => (x * 2).Dump();

         Console.WriteLine($"{myDelegate(5)}");

         var tt = myDelegate(6);
         myDelegate(7).Dump();
         tt.Dump();
         del(4);
         del2(5);

         int[] intt = new int[] { 1, 2, 3, 4, 5, 6, 7 };

         var inttEven = from bb in intt
                        where bb % 2 == 0
                        select bb;
         foreach (var item in inttEven)
         {
            item.Dump();
         }

         var even2 = intt.Where(intt => intt % 2 == 0);

         foreach (var item in even2)
         {
            item.Dump();
         }
         "less".Dump();
         var less = from d in intt
                    where d > 5
                    select d;
         string.Join(",", less).Dump();

         List<Order> orders = new List<Order>()
         {
            new Order()
            {
               OrderLines = new List<OrderLine>()
               {
                  new OrderLine() { Amount = 2, Product = new Product() { Description = "PRoszek do pieczenia", Price = 33323 } },
                  new OrderLine() { Amount = 34, Product = new Product() { Description = "PRoszek do pieczenia", Price = 23453 } },
                  new OrderLine() { Amount = 4, Product = new Product() { Description = "PRoszek do pieczenia", Price = 239999 } },
                  new OrderLine() { Amount = 77, Product = new Product() { Description = "PRoszek do pieczenia", Price = 4523 } },
                  new OrderLine() { Amount = 6, Product = new Product() { Description = "PRoszek do pieczenia", Price = 211113 } }
               }
            },
            new Order()
            {
               OrderLines = new List<OrderLine>()
               {
                  new OrderLine() { Amount = 2, Product = new Product() { Description = "PRoszek do pieczenia", Price = 33323 } },
               }
            }
         };

         var avarage = orders.Average(x => x.OrderLines.Count);

         var projection = from o in orders
                          from ol in o.OrderLines
                          group ol by ol.Product into p
                          select new OrderLine
                          {
                             Product = p.Key,
                             Amount = p.Sum(x => x.Amount)
                          };

         var resp = new List<Response>() {
            new Response() { Id = 1, OrgIdE = Guid.NewGuid(), OrgNumE = 11, OrgIdK = null, OrgNumK = null } ,
            new Response() { Id = 1, OrgIdK = Guid.NewGuid(), OrgNumK = 22, OrgIdE = null, OrgNumE = null  }
         };

         var selResp = from r in resp
                       where r.OrgNumK != null
                       select new
                       {
                          aId = r.Id,
                          aOrgIdE = r.OrgIdE,
                          aOrgIdK = r.OrgIdK,
                          aOrgNumE = r.OrgNumE,
                          aOrgNumK = r.OrgNumK,
                          aDesc = r.Desc
                       };

         var single = selResp.FirstOrDefault();



         "end".Dump();

         Console.ReadLine();
      }
   }
}
