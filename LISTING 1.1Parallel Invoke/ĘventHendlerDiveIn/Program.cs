using System;

namespace EventHendlerDiveIn
{
   class Program
   {
      static void Main(string[] args)
      {
         var v = new Video() { Title = "Titanic" };
         var ve = new VideoEncoder(); // publisher
         var ms = new MailService(); //subscriber
         var mes = new MessegeService(); //subscriber
         ve.VideoEncoded += ms.OnVideoEncoded;
         ve.VideoEncoded += mes.OnVieoEncoded;
         ve.VideoEncode(v);

         Console.WriteLine("end!");
         Console.ReadKey();
      }
   }

}
