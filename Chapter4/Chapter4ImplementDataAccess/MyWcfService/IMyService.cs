using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyWcfService
{
   [ServiceContract]
   public interface IMyService
   {

      [OperationContract]
      string GetData(int value);

      [OperationContract]
      string DoWork(string left, string right);

   }

   [DataContract]
   public class CompositeType
   {
      bool boolValue = true;
      string stringValue = "Hello ";

      [DataMember]
      public bool BoolValue
      {
         get { return boolValue; }
         set { boolValue = value; }
      }

      [DataMember]
      public string StringValue
      {
         get { return stringValue; }
         set { stringValue = value; }
      }
   }
}
