using GettingStartedClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedClient
{
   class Program
   {
      static void Main(string[] args)
      {
         //Step 1: Create an instance of the WCF proxy.
         MyServiceClient client = new MyServiceClient();

         string value1 = "aa";
         string value2 = "xx";
         var result = client.DoWork(value1, value2);
         Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);
      }
   }
}
