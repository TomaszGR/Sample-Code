using System;
using System.Threading;

namespace ĘventHendlerDiveIn
{
   public class VideoEncoder
   {
      //1 delegate
      //2 event
      //3 raise event

      public delegate void VideoEncodedEventHendler(object sender, EventArgs e);

      //by convention, past time and sufix ...EventHendler
      public event VideoEncodedEventHendler VideoEncoded;

      public void VideoEncode(Video video)
      {
         Console.WriteLine($"Nagrywanie...");
         Thread.Sleep(3000);

         OnVideoEncoded();
      }
   
      //virtual methoc can be overwritten
      //by convention method shoud be protected and prefix On
      protected virtual void OnVideoEncoded()
      {
         VideoEncoded?.Invoke(this, EventArgs.Empty);


      }
   
   
   }
}
