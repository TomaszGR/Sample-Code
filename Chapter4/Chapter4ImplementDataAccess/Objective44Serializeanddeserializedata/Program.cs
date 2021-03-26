using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Security.Permissions;
using System.Xml.Serialization;

namespace Objective44Serializeanddeserializedata
{
   public static class Dumps
   {
      public static void Dump(this object txt)
      {
         Console.WriteLine(txt);
      }
   }
   [Serializable]
   public class Person
   {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int Age { get; set; }
      [NonSerialized]
      private bool isDirty = false;

      [OnSerializing()]
      internal void OnSerializingMethod(StreamingContext context)
      {
         Console.WriteLine("OnSerializing.");
      }
      [OnSerialized()]
      internal void OnSerializedMethod(StreamingContext context)
      {
         Console.WriteLine("OnSerialized.");
      }
      [OnDeserializing()]
      internal void OnDeserializingMethod(StreamingContext context)
      {
         Console.WriteLine("OnDeserializing.");
      }
      [OnDeserialized()]
      internal void OnDeserializedMethod(StreamingContext context)
      {
         Console.WriteLine("OnSerialized.");
      }
   }

   [Serializable]
   public class PersonComplex : ISerializable
   {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int Age { get; set; }
      private bool isDirty = false;
      public bool isTall = false;
      public int Id = 44;

      [System.Security.Permissions.SecurityPermission(SecurityAction.Demand,SerializationFormatter = false)]
      public void GetObjectData(SerializationInfo info, StreamingContext context)
      {
         info.AddValue("Value1", FirstName);
         info.AddValue("Value2", LastName);
         info.AddValue("Value3", Age);
         info.AddValue("Value65", isDirty);
      }
   }

   [Serializable]
   public class Order
   {
      [XmlAttribute]
      public int Id { get; set; }
      public bool IsBig { get; set; }

      [XmlArray("Lines")]
      [XmlArrayItem("OrderLine")]
      public List<OrderLine> OrderLines { get; set; }
   }

   [Serializable]
   public class OrderLine
   {
      [XmlAttribute]
      public int Id { get; set; }
      [XmlAttribute]
      public int Amount { get; set; }
   }

   [DataContract]
   public class PersonDataContract
   {
      [DataMember]
      public int Id { get; set; }
      [DataMember]
      public string Name { get; set; }
      public bool MyPropertyBool { get; set; }
   }
   class Program
   {
      static void Main(string[] args)
      {
         PersonDataContract personDataContract = new PersonDataContract() {Id = 4, MyPropertyBool = true, Name = "Tmkdk" };
         using (Stream stream1 = new FileStream("dataPersonContrakt.xml", FileMode.Create))
         {
            DataContractSerializer dataContractSerializerq = new DataContractSerializer(typeof(PersonDataContract));
            dataContractSerializerq.WriteObject(stream1, personDataContract);
         }

         using (Stream stream2 = new FileStream("dataPersonContrakt.json", FileMode.Create))
         {
            DataContractJsonSerializer dataContractSerializerq = new DataContractJsonSerializer(typeof(PersonDataContract));
            dataContractSerializerq.WriteObject(stream2, personDataContract);

            stream2.Position = 0;
            StreamReader streamReader = new StreamReader(stream2);
            streamReader.ReadToEnd().Dump();
         
         }



         XmlSerializer xmlSeralizer = new XmlSerializer(typeof(Person));
         string xml;
         using (StringWriter writer = new StringWriter())
         {
            Person person = new Person()
            {
               Age = 13,
               FirstName = "Jan",
               LastName = "Kan"
            };
            xmlSeralizer.Serialize(writer, person);
            xml = writer.ToString();
         }

         xml.Dump();

         using (StringReader stringReader = new StringReader(xml))
         {
            Person p = (Person)xmlSeralizer.Deserialize(stringReader);
            p.Age.Dump();
            p.FirstName.Dump();
            p.LastName.Dump();
         }

         Order o = new Order() { Id = 1, IsBig = true, OrderLines = new List<OrderLine>() { new OrderLine() { Id = 3, Amount = 34 }, new OrderLine() { Id = 6, Amount = 99 } } };

         XmlSerializer os = new XmlSerializer(typeof(Order), new Type[] { typeof(OrderLine) });
         string xmlO;
         using (StringWriter sw = new StringWriter())
         {
            os.Serialize(sw, o);
            xmlO = sw.ToString();
         }
         xmlO.Dump();

         Person person2 = new Person()
         {
            Age = 13,
            FirstName = "Jan",
            LastName = "Kan"
         };

         IFormatter formatter = new BinaryFormatter();
         using (Stream streem = new FileStream("data.bin", FileMode.Create))
         {
            formatter.Serialize(streem, person2);
         }

         using (Stream stream = new FileStream("data.bin", FileMode.Open))
         {
            Person per = (Person)formatter.Deserialize(stream);
            per.Age.Dump();
         }

         "///////////////complexPerson".Dump();
         PersonComplex person3 = new PersonComplex()
         {
            Age = 133,
            FirstName = "Janina",
            LastName = "Kasina",
         };

         XmlSerializer xmlSeralizer2 = new XmlSerializer(typeof(PersonComplex));
         string xml2;
         using (StringWriter writer2 = new StringWriter())
         {

            xmlSeralizer2.Serialize(writer2, person3);
            xml2 = writer2.ToString();
         }

         xml2.Dump();

         Console.WriteLine("end!");
      }

   }

}
