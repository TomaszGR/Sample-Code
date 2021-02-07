using System;
using System.Threading;

namespace EventHendlerDiveIn
{
   public class MailService
   {
      //MethodHendler
      public void OnVideoEncoded(object sender, VideoEventArgs e)
      {
         Console.WriteLine($"Video endoced. Sending an email with the movie title of {e.Video.Title}");
         for (int i = 0; i < 5; i++)
         {
            Console.Write($"*");
            Thread.Sleep(500);
         }
         Console.WriteLine();
         Console.WriteLine($"Video endoced. Email send!");
      }
   }
}
