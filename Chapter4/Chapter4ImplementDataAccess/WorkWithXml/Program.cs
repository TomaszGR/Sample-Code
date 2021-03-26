using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace WorkWithXml
{
   public static class Dumps
   {
      public static void Dump(this object txt)
      {
         Console.WriteLine(txt);
      }
   }

   class Program
   {
      public static void Main()
      {
         //LINQ
         string path2 = @"Employees.xml";
         var gg = File.ReadAllText(path2, encoding: UTF8Encoding.UTF8);
         //XDocument xDocument = XDocument.Parse(gg);
         //var res = from x in xDocument.Descendants("Employee")
         //          select (string)x.Element("Name");
         //foreach (string item in res)
         //{
         //   item.Dump();
         //}

         XElement xElement = XElement.Parse(gg);
         foreach (XElement item in xElement.Descendants("Employee"))
         {
            string name = (string)item.Element("Name");
            item.Add(new XElement("Color", name.Contains("Sam")));
            item.Add(new XElement("Height", "123", name.Contains("Sam")));
         
         }


         Console.ReadKey();
      
      }
   }

         //class Program
         //{
         //   public static void Main()
         //   {
         //      string path2 = @"Employees.xml";
         //      var gg = File.ReadAllText(path2, encoding: UTF8Encoding.UTF8);
         //      using (StringReader stringReader = new StringReader(gg))
         //      {
         //         using (XmlReader xmlReader = XmlReader.Create(stringReader, new XmlReaderSettings() { IgnoreWhitespace = true }))
         //         {
         //            xmlReader.MoveToContent();
         //            xmlReader.ReadStartElement("Employees");
         //            xmlReader.GetAttribute("Name").Dump();
         //         }
         //      }
         //      "end1".Dump();
         //
         //      XmlDocument xmlDocument = new XmlDocument();
         //      xmlDocument.LoadXml(gg);
         //      XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName("Address");
         //      foreach (XmlNode item in xmlNodeList)
         //      {
         //         item.FirstChild.Name.Dump();
         //         item.FirstChild.InnerText.Dump();
         //      }
         //
         //      "end".Dump();
         //   }
         //}

         //class Program
         //{
         //   static void Main(string[] args)
         //   {
         //
         //      string path = @"e:\Systemy_TEST\PKO_VBBC\VbbcWsadKombajnShouldExportDataFromCacheAndOriginalReportForBikKi_20210311_133402\DATA_OUT\BIKKI_DD20210311_GD202103111334_1.xml.ZIP";
         //      //string path2 = @"xxx.xml";
         //      string xes = Unzip2(path);
         //      XElement xelMiz = XElement.Parse(xes);
         //
         //      XElement xelMiz2 = XElement.Load("xxx.xml");
         //
         //      //var address = from nm in xelement.Elements("Employee")
         //      //           select nm;
         //      //foreach (var ad in address)
         //      //{
         //      //   Console.WriteLine($"{ad.Name}");
         //      //   Console.WriteLine($"{ad.Element("Name").Value}");
         //      //   //ad.Element("EmpId").Value);
         //      //}
         //
         //      //int count = xelement.Descendants("EmpId").Count();
         //      //count.Dump();
         //      xelMiz.Elements().Count().Dump();
         //      foreach (var item in xelMiz.Elements().ToList())
         //      {
         //         item.Name.Dump();
         //      } 
         //
         //      XNamespace ns = "http://schemas.vsoft.pl/Connectors/2017/09/VBBC";
         //
         //      xelMiz.Descendants(ns + "WsadItems").Count().Dump();
         //      xelMiz.Descendants(ns + "WsadItem").Count().Dump();
         //      xelMiz.Descendants(ns + "Request").Count().Dump();
         //      xelMiz.Descendants(ns + "WsadBikKIFile").Count().Dump();
         //
         //      //int countRep = xelement.Descendants("WsadInfo").Count();
         //      //countRep.Dump();
         //      //
         //      //var aa = from ad in xelement.Descendants()
         //      //         where ad.Name == "EmpId"
         //      //         select ad.Name;
         //      //
         //      //foreach (var item in aa)
         //      //{
         //      //   item.LocalName.Dump();
         //      //}
         //      //
         //      //count.Dump();
         //
         //       Console.WriteLine("end");
         //   }
         //
         //
         //   public static XElement Unzip(string a_zipPath)
         //   {
         //      XElement purchaseOrderr;
         //      using FileStream stream = new FileStream(a_zipPath, FileMode.Open);
         //      using ZipArchive archive = new ZipArchive(stream);
         //      string entryName = Path.GetFileName(a_zipPath.Substring(0, a_zipPath.Length - 4));
         //      var tt = archive.GetEntry(entryName);
         //      using (StreamReader reader = new StreamReader(tt.Open()))
         //      {
         //         purchaseOrderr = XElement.Load(reader);
         //      }
         //      return purchaseOrderr;
         //
         //   }
         //
         //   public static string Unzip2(string a_zipPath)
         //   {
         //      using (FileStream stream = new FileStream(a_zipPath, FileMode.Open))
         //      using (ZipArchive archive = new ZipArchive(stream))
         //      {
         //         string entryName = Path.GetFileName(a_zipPath.Substring(0, a_zipPath.Length - 4));
         //         var tt = archive.GetEntry(entryName);
         //         ZipArchiveEntry entry = archive.GetEntry(entryName);
         //         if (entry == null)
         //            return null;
         //
         //         using (MemoryStream memStream = new MemoryStream())
         //         using (Stream entrySteam = entry.Open())
         //         {
         //            entrySteam.CopyTo(memStream);
         //            return Encoding.UTF8.GetString(memStream.ToArray());
         //         }
         //      }
         //   }
         //
         //
         //}
      }
