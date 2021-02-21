using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Schema;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Chapter3DebugApplicationsAndImplementingSecurity
{
   public static class Print
   {
      public static void Dump(this object str)
      {
         Console.WriteLine(str);
      }
   }

   #region validate data
   //  public class Customer
   //   {
   //      public int Id { get; set; }
   //      [Required, MaxLength(20)]
   //      public string FirstName { get; set; }
   //      [Required, MaxLength(20)]
   //      public string LastName { get; set; }
   //      [Required]
   //      public Address ShippingAddress { get; set; }
   //      [Required]
   //      public Address BillingAddress { get; set; }
   //   }
   //
   //  public class Address
   //  {
   //     public int Id { get; set; }
   //     [StringLength(60, MinimumLength = 3)]
   //     [Required]
   //     public string AddressLine1 { get; set; }
   //     [Required, MaxLength(20)]
   //     public string AddressLine2 { get; set; }
   //     [Range(1, 100)]
   //     [DataType(DataType.Currency)]
   //     [Column(TypeName = "decimal(18, 2)")]
   //     [Required]
   //     public decimal Price { get; set; }
   //     [Required, MaxLength(20)]
   //     public string City { get; set; }
   //     [RegularExpression(@"^[1 - 9][0 - 9]{3}\s?[a - zA - Z]{2}$")]
   //     public string ZipCode { get; set; }
   //     [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
   //     [Required]
   //     [StringLength(30)]
   //     public string Genre { get; set; }
   //     [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
   //     [StringLength(5)]
   //     [Required]
   //     public string Rating { get; set; }
   //  }
   //  public class ShopContext : DbContext
   //{
   //   public ShopContext(DbContextOptions<ShopContext> optionsBuilder) : base(optionsBuilder) { }
   //
   //   public DbSet<Customer> Customers { get; set; }
   //
   //   protected override void OnModelCreating(ModelBuilder modelBuilder)
   //     {
   //        modelBuilder.Entity<Customer>()
   //           .HasOne(bm => bm.BillingAddress)
   //           .WithMany()
   //           .OnDelete(DeleteBehavior.SetNull);
   //     }
   //
   //}
   //
   //  public static class GenericValidator<T>
   //  {
   //     public static IList<ValidationResult> Validate(T entity)
   //   {
   //      var results = new List<ValidationResult>();
   //      var context = new ValidationContext(entity, null, null);
   //      Validator.TryValidateObject(entity, context, results);
   //      return results;
   //   }
   //  }
   //  class Program
   //  {
   //     static void Main(string[] args)
   //     {
   //
   //        var options = new DbContextOptionsBuilder<ShopContext>()
   //           .UseInMemoryDatabase(databaseName: "Test")
   //           .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
   //           .Options;
   //
   //        using (ShopContext context = new ShopContext(options))
   //      {
   //         Address a = new Address
   //         {
   //            AddressLine1 = "Somewhere 1",
   //            AddressLine2 = "At some floor",
   //            City = "SomeCity",
   //            ZipCode = "1111AA"
   //         };
   //         Customer c = new Customer()
   //         {
   //            FirstName = "John",
   //            LastName = "Doe",
   //            BillingAddress = a,
   //            ShippingAddress = a,
   //         };
   //         context.Customers.Add(c);
   //         context.SaveChanges();
   //      }
   //
   //        Address g = new Address
   //        {
   //           //AddressLine1 = "Somewhere 1",
   //           AddressLine2 = "At some ",
   //           City = "SomeCity",
   //           ZipCode = "3fh#",
   //           Genre = "d",
   //           Price = 111111111111111111.122222222222222222M,
   //        };
   //
   //        var err = GenericValidator<Address>.Validate(g);
   //
   //        string dt = "2020-02-02";
   //        DateTime dt2;
   //        string value = "true";
   //        bool bval = bool.Parse(value);
   //        DateTime dtp = DateTime.Parse(dt);
   //        DateTime.TryParse("2020-05-065" , out dt2);
   //
   //        var sdwerf = Convert.ToDateTime("");
   //        var sdf = Convert.ToDateTime("2020-05-06s");
   //
   //
   //        dt2.Dump();
   //        dtp.Dump();
   //        bval.Dump();
   //        "lol".Dump();
   //        Console.ReadLine();
   //     }
   //  }
   #endregion
   #region regex, json, xml
   //class Program2
   //{
   //   public static void Main()
   //   {
   //
   //      static bool ValidateZipCodeRegEx(string zipCode)
   //      {
   //         Match match = Regex.Match(zipCode, @"^[1-9][0-9]{3}\s?[a-zA-Z]{2}$", RegexOptions.IgnoreCase);
   //         return match.Success;
   //      }
   //
   //      ValidateZipCodeRegEx("23200").Dump();
   //
   //      var serializer = new JsonSerializer();
   //      string json = JsonConvert.SerializeObject(new { MyUser = "foo", MyId = "bar" });
   //      var res = JsonConvert.DeserializeObject(json);
   //      res.Dump();
   //
   //      ValidateXML();
   //   }
   //
   //   public static void ValidateXML()
   //   {
   //      string xsdPath = "person.xsd";
   //      string xmlPath = "person.xml";
   //      XmlReader reader = XmlReader.Create(xmlPath);
   //      XmlDocument document = new XmlDocument();
   //      document.Schemas.Add("", xsdPath);
   //      document.Load(reader);
   //      ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);
   //      document.Validate(eventHandler);
   //   }
   //   static void ValidationEventHandler(object sender,
   //   ValidationEventArgs e)
   //   {
   //      switch (e.Severity)
   //      {
   //         case XmlSeverityType.Error:
   //            Console.WriteLine("Error: {0}", e.Message);
   //            break;
   //         case XmlSeverityType.Warning:
   //            Console.WriteLine("Warning {0}", e.Message);
   //            break;
   //      }
   //   }
   //}
   #endregion
   #region Cryptography
   class Set<T>
   {
      private List<T>[] buckets = new List<T>[100];
   




}

   class Program2
   {
      public static void Main()
      {
         EncryptSomeText();
         RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
         string publicKeyXML = rsa.ToXmlString(false);
         string privateKeyXML = rsa.ToXmlString(true);
         Console.WriteLine(publicKeyXML);
         "///////////////////////////////////////////////////////////".Dump();
         Console.WriteLine(privateKeyXML);

         UnicodeEncoding ByteConverter = new UnicodeEncoding();
         byte[] dataToEncrypt = ByteConverter.GetBytes("My Secret Data!");
         byte[] encryptedData;
         using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
         {
            RSA.FromXmlString(publicKeyXML);
            encryptedData = RSA.Encrypt(dataToEncrypt, false);
         }
         byte[] decryptedData;
         using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
         {
            RSA.FromXmlString(privateKeyXML);
            decryptedData = RSA.Decrypt(encryptedData, false);
         }
         string decryptedString = ByteConverter.GetString(decryptedData);
         Console.WriteLine(decryptedString); // Displays: My Secret Data!
         //////////////////////////////////////////////////////////////
         ///
         string containerName = "secret Container";
         CspParameters cspParameters = new CspParameters() { KeyContainerName = "Secret Container" };

         using (RSACryptoServiceProvider rsacsp = new RSACryptoServiceProvider(cspParameters))
         {
            encryptedData = rsacsp.Encrypt(dataToEncrypt, false);
         }
         Encoding.UTF8.GetString(encryptedData).Dump(); ;

         // kyeword check return exeption when it present, unchecked not
         byte x = 150;
         byte y = 12;
         "unchecked ".Dump();
         unchecked((byte)(x * y)).Dump();
         checked((byte)(x * y)).Dump();

         try
         {
            unchecked((byte)(x * y)).Dump();
         }
         catch (OverflowException)
         {
            Console.WriteLine("Przepełnienie");
         }
         ////////////////////////////////////////////////













         "end".Dump();
      }

      public static void EncryptSomeText()
      {
         string original = "My secret data!";
         using (SymmetricAlgorithm symmetricAlgorithm = new AesManaged())
         {
            byte[] encrypted = Encrypt(symmetricAlgorithm, original);
            string roundtrip = Decrypt(symmetricAlgorithm, encrypted);
            Console.WriteLine("Original: {0}", original);
            Console.WriteLine("Round Trip: {0}", roundtrip);
         }
      }
      static byte[] Encrypt(SymmetricAlgorithm aesAlg, string plainText)
      {
         ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
         using (MemoryStream msEncrypt = new MemoryStream())
         {
            using (CryptoStream csEncrypt =
            new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
               using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
               {
                  swEncrypt.Write(plainText);
               }
               return msEncrypt.ToArray();
            }
         }
      }
      static string Decrypt(SymmetricAlgorithm aesAlg, byte[] cipherText)
      {
         ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
         using (MemoryStream msDecrypt = new MemoryStream(cipherText))
         {
            using (CryptoStream csDecrypt =
            new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
               using (StreamReader srDecrypt = new StreamReader(csDecrypt))
               {
                  return srDecrypt.ReadToEnd();
               }
            }
         }
      }
   }
   #endregion
}
