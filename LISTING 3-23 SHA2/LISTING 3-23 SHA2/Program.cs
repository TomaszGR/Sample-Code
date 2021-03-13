using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LISTING_3_23_SHA2
{
   class Program
   {
      static byte[] calculateHash(string source)
      {
         // This will convert our input string into bytes and back
         ASCIIEncoding converter = new ASCIIEncoding();
         byte[] sourceBytes = converter.GetBytes(source);
         HashAlgorithm hasher = SHA256.Create();
         byte[] hash = hasher.ComputeHash(sourceBytes);
         return hash;
      }

      static void showHash(string source)
      {
         Console.Write("Hash for {0} is: ", source);
         byte[] hash = calculateHash(source);
         foreach (byte b in hash)
         {
            Console.Write("{0:X} ", b);
         }
         Console.WriteLine();
      }

      static void Main(string[] args)
      {
         showHash("Hello world");
         showHash("world Hello");
         showHash("Hemmm world");
         showHash("asdfg");
         showHash("asdfgg");

         Console.WriteLine("equal or not: " + calculateHash("asdfgg").SequenceEqual(calculateHash("asdfg")).ToString());

         Console.ReadKey();
      }
   }
}
