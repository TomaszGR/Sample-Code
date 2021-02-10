using System;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization;

namespace Objective1._5ImplementExceptionHandling
{
   #region Exeption handling

   //class Program
   //{
   //   static void Main(string[] args)
   //   {
   //
   //      Console.WriteLine("put something");
   //      while (true)
   //      {
   //         string line = Console.ReadLine();
   //
   //         //if (string.IsNullOrWhiteSpace(line))
   //         //{
   //         //   break;
   //         //}
   //         //else
   //         //{
   //            try
   //            {
   //               int i = int.Parse(line);
   //               Console.WriteLine($"Parse string to number pass, number is: {i}");
   //            }
   //            catch (ArgumentNullException)
   //            {
   //               Console.WriteLine("You need to enter a value");
   //            }
   //            catch (FormatException fe)
   //            {
   //               Console.WriteLine($"FormatExeption occure {fe.GetType()} {fe.Message}");
   //               Console.WriteLine($"Enter correct number:");
   //            }
   //            catch (Exception e)
   //            {
   //               Console.WriteLine($"Other exeption occure: {e.GetType()} message:{e.Message}");
   //            }
   //            finally
   //            {
   //               Console.WriteLine("End of TryCatch");
   //            }
   //         //}
   //      }
   //
   //      Console.WriteLine("stop");
   //   }
   //}
   #endregion
   #region throwing exeptions 
   //class Program
   //{
   //   public static void Main()
   //   {
   //      ExceptionDispatchInfo possibleException = null;
   //      try
   //      {
   //         string s = Console.ReadLine();
   //         int.Parse(s);
   //      }
   //      catch (FormatException ex)
   //      {
   //         //throw new FormatException("new ex");
   //         possibleException = ExceptionDispatchInfo.Capture(ex);
   //      }
   //      if (possibleException != null)
   //      {
   //         possibleException.Throw();
   //      }
   //   }
   //}
   #endregion

   #region throwing custom exeptions 
   class Program
   {
      public static void Main()
      {
         Console.WriteLine($"start");

          throw new OrderProcessingException(3,"orderEx", new Exception("base"));
      
         Console.WriteLine($"stop");
      }
   }

   [Serializable]
   public class OrderProcessingException : Exception, ISerializable
   {
      public OrderProcessingException(int orderId)
      {
         OrderId = orderId;
         this.HelpLink = "http://www.mydomain.com/infoaboutexception";
      }
      public OrderProcessingException(int orderId, string message) : base(message)
      {
         OrderId = orderId;
         this.HelpLink = "http://www.mydomain.com/infoaboutexception";
      }
      public OrderProcessingException(int orderId, string message, Exception innerException) : base(message, innerException)
      {
         OrderId = orderId;
         this.HelpLink = "http://www.mydomain.com/infoaboutexception";
      }
      protected OrderProcessingException(SerializationInfo info, StreamingContext context)
      {
         OrderId = (int)info.GetValue("OrderId", typeof(int));
      }
      public int OrderId { get; private set; }
      public void GetObjectData(SerializationInfo info, StreamingContext context)
      {
         info.AddValue("OrderId", OrderId, typeof(int));
      }
   }
   #endregion
}
