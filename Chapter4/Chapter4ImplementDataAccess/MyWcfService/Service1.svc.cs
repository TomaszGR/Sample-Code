using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyWcfService
{
   public class MyService : IMyService
   {
      public string DoWork(string left, string right)
      {
         return left + right;
      }
      public string GetData(int value)
      {
         return string.Format("You entered: {0}", value);
      }

   }
}
