using System;

namespace EventHendlerDiveIn
{
   public class MessegeService
   {
      public void OnVieoEncoded(object sender, VideoEventArgs e)
      {
         Console.WriteLine($"Sending Message with movie of title {e.Video.Title}");
      }


   }

}
