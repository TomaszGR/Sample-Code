using System;
using System.Threading;

namespace EventHendlerDiveIn
{
   // klasa która przekazuje referencje do Video musi dziedziczyć po klasie EventArgs 
   public class VideoEventArgs : EventArgs
   {
      public Video Video { get; set; }
   }

   //publisher
   //rozwiązanie z wykorzystaniem EventHendlerem powoduje że ta klasa nie musi być
   // przebudowania re-deployowana, nie wie nic o subscriberach
   public class VideoEncoder
   {
      //1 delegate
      //2 event
      //3 raise event

      //żeby przekazać konkretny tym zamiast EventArgs w delegacie przekszujemy jakaś klasę która dziedziczy po
      // klasie EventArgs 
      //public delegate void VideoEncodedEventHendler(object sender, VideoEventArgs e);

      // zamiast przekazywania powyższej delegaty c# ma wbudowaną delegatę 
      // EventHendler i EventHendler<TEventArgs>
      // dzięki temu wystarczy deklaracja eventu generycznego z typem VideoEventArgs
      public event EventHandler<VideoEventArgs> VideoEncoded;

      //by convention, past time and sufix ...EventHendler
      //public event VideoEncodedEventHendler VideoEncoded;

      public void VideoEncode(Video video)
      {
         Console.WriteLine($"Nagrywanie...");
         Thread.Sleep(2000);

         OnVideoEncoded(video);
      }

      //virtual methoc can be overwritten
      //by convention method shoud be protected and prefix On
      protected virtual void OnVideoEncoded(Video video)
      {
         VideoEncoded?.Invoke(this, new VideoEventArgs() { Video = video });
      }
   }
}
