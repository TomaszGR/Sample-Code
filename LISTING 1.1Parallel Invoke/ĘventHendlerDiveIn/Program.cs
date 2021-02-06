using System;

namespace ĘventHendlerDiveIn
{
   class Program
   {
      static void Main(string[] args)
      {
         var v = new Video() { Title = "Titanic" };
         var ve = new VideoEncoder();
         var ms = new MailService();
         ve.VideoEncoded += ms.OnVideoEncoded;
         ve.VideoEncode(v);

         Console.WriteLine("end!");
         Console.ReadKey();
      }
   }

   public class MailService
   {
      //MethodHendler

      public void OnVideoEncoded(object sender, EventArgs e)
      {
         Console.WriteLine($"Video endoced. Sending ane email...");
      }



   } 



}
