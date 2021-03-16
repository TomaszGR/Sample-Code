using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Chapter4ImplementDataAccess
{
   public static class Dumps
   {
      public static void Dump(this object txt)
      {
         Console.WriteLine(txt);
      }
   }

   //class People
   //{
   //   public int Id { get; set; }
   //   public string FirstName { get; set; }
   //   public string MiddleName { get; set; }
   //   public string LastName { get; set; }
   //}
   //
   //class PeopleContext : DbContext
   //{
   //   /// <summary>
   //   /// Option2 configuring access to db in contructor, and pass the oprions from outside, for example dependency injedction or directrly from tethot whatever
   //   /// </summary>
   //   /// <param name="dbContextOptions"></param>
   //   public PeopleContext(DbContextOptions<PeopleContext> dbContextOptions) : base(dbContextOptions)
   //   {
   //
   //   }
   //
   //   /// <summary>
   //   ///Option 1configure access to database by overriding OnConfiguring method
   //   /// </summary>
   //   //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   //   //{
   //   //   optionsBuilder.UseSqlServer(connectionString: @"Data Source = TGRZADZIEL\MSSQL2017; Initial Catalog = AdventureWorksLT2008R2; Integrated Security = True");
   //   //}
   //
   //   public DbSet<People> People { get; set; }
   //
   //}

   class Program
   {
      #region Directory and File
      //
      // static void Main(string[] args)
      // {
      //    DriveInfo[] driveInfo = DriveInfo.GetDrives();
      //
      //    foreach (var drive in driveInfo)
      //    {
      //       Console.WriteLine($"{drive.Name}, {drive.DriveType}, {drive.VolumeLabel} , {drive.TotalSize}");
      //    }
      //
      //    DirectoryInfo directoryInfo = new DirectoryInfo("NewDirec");
      //    directoryInfo.Create();
      //
      //    DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
      //    directorySecurity.AddAccessRule(
      //    new FileSystemAccessRule("wszyscy",
      //    FileSystemRights.ReadAndExecute,
      //    AccessControlType.Allow));
      //    directoryInfo.SetAccessControl(directorySecurity);
      //
      //    //if (directory.Exists)
      //    //{
      //    //   directory.Delete();
      //    //}
      //
      //    DirectoryInfo directoryInfo2 = new DirectoryInfo(@"c:\Users\tomasz.grzadziel\repos\Sample-Code\Chapter4\");
      //    ListDirectories(directoryInfo2, "*",5,0);
      //
      //    foreach (var file in Directory.GetFiles(@"c:\Users\tomasz.grzadziel\repos\Sample-Code\Chapter4\Chapter4ImplementDataAccess\Chapter4ImplementDataAccess\"))
      //    {
      //       Console.WriteLine($"{file}");
      //    }
      //    DirectoryInfo directoryInfo1 = new DirectoryInfo($@"c:\Users\tomasz.grzadziel\repos\Sample-Code\Chapter4\Chapter4ImplementDataAccess\Chapter4ImplementDataAccess\");
      //    foreach (FileInfo di1 in directoryInfo1.GetFiles())
      //    {
      //       Console.WriteLine($"{di1.FullName}");
      //    }
      //    //////////////////////////////////
      //
      //    string path = @"e:\temp\temp.txt";
      //    string pathDest = @"e:\temp\tempDest.txt";
      //
      //    //File.CreateText(path).Close();
      //    //File.Move(path, pathDest);
      //
      //    FileInfo fileInfo = new FileInfo(path);
      //    //fileInfo.CopyTo(pathDest, true);
      //
      //    if (File.Exists(path))
      //    {
      //       File.Delete(path);
      //    }
      //    Console.WriteLine("==============================================");
      //    string path2 = @"c:\Users\tomasz.grzadziel\repos\Sample-Code\Chapter4\Chapter4ImplementDataAccess\Chapter4ImplementDataAccess\Program.cs";
      //    Console.WriteLine(Path.GetDirectoryName(path2)); // Displays C:\temp\subdir
      //    Console.WriteLine(Path.GetExtension(path2)); // Displays .txt
      //    Console.WriteLine(Path.GetFileName(path2)); // Displays file.txt
      //    Console.WriteLine(Path.GetPathRoot(path2)); // Displays C:\
      //
      //    Console.WriteLine(Path.GetRandomFileName()); // Displays C:\
      //    Console.WriteLine(Path.GetTempFileName()); // Displays C:\
      //
      //    Console.WriteLine("end");
      // }
      //
      // public static void ListDirectories(DirectoryInfo directory, string pattern, int maxLevel, int currentLevel)
      // {
      //    if (currentLevel >= maxLevel)
      //    {
      //       return;
      //    }
      //
      //    string ident = new string('-', currentLevel);
      //
      //    try
      //    {
      //       DirectoryInfo[] subDirectories = directory.GetDirectories(pattern);
      //       foreach (var dir in subDirectories)
      //       {
      //          Console.WriteLine($"{ident}");
      //          Console.WriteLine($"{dir.FullName}");
      //          ListDirectories(dir, pattern, maxLevel, currentLevel + 1);
      //       }
      //    }
      //    catch (UnauthorizedAccessException)
      //    {
      //       Console.WriteLine("niepowazniony dostep");
      //       return;
      //    }
      //    catch (DirectoryNotFoundException)
      //    {
      //       Console.WriteLine("Cannot find");
      //       return;
      //    }
      // }
      #endregion
      #region Filestream
      //public static void Main()
      //{
      //   string path = @"e:\temp\temp.dat";

      //   using (FileStream fileStream = File.Create(path))
      //   {
      //      string myVal = "asd";
      //      byte[] data = Encoding.UTF8.GetBytes(myVal);
      //      fileStream.Write(data);
      //   }

      //   using (StreamWriter streamWriter = File.CreateText(path))
      //   {
      //      streamWriter.Write("foo bar");
      //   }

      //   using (StreamReader streamReader = File.OpenText(path))
      //   {
      //      Console.WriteLine(streamReader.ReadToEnd());
      //      streamReader.ReadToEnd().Dump();
      //   }

      //   string folder = @"e:\temp";
      //   string unFile = Path.Combine(folder, "uncompressed.dat");
      //   string comFile = Path.Combine(folder, "compressed.zip");
      //   byte[] data1 = Enumerable.Repeat((byte)'a', 1024 * 1024).ToArray();

      //   using (FileStream ufs = File.Create(unFile))
      //   {
      //      ufs.Write(data1,0,data1.Length);
      //   }

      //   using (FileStream cfs = File.Create(comFile))
      //   {
      //      using (GZipStream gzs = new GZipStream(cfs, CompressionMode.Compress))
      //      {
      //         gzs.Write(data1, 0, data1.Length);
      //      }
      //   }

      //   FileInfo ufi = new FileInfo(unFile);
      //   FileInfo cfi = new FileInfo(comFile);

      //   string path3 = @"e:\temp\tempxxxxxxxxxxx.dat";

      //   try
      //   {
      //      File.ReadAllText(path3);
      //   }
      //   catch (DirectoryNotFoundException)
      //   {
      //      "DirectoryNotFoundException".Dump();
      //   }
      //   catch (FileNotFoundException)
      //   {
      //      "FileNotFoundException".Dump();
      //   }


      //   Console.WriteLine("end");
      // }
      #endregion
      #region Async
      //public static void Main()
      //{
      //   WebRequest webRequest = WebRequest.Create(@"http://wp.pl");
      //   WebResponse webResponse = webRequest.GetResponse();
      //
      //   StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
      //   var stremTxt = streamReader.ReadToEnd();
      //   //stremTxt.Dump();
      //   webResponse.Close();
      //   Task dd = NewMethod();
      //   var dd2 = NewMethod2();
      //   //dd2.Result.Dump();
      //   RunTaskInParallel1().Result.Dump();
      //   "end".Dump();
      //}
      //
      //private static async Task NewMethod()
      //{
      //   using (FileStream stream = new FileStream("test.dat", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
      //   {
      //      byte[] vs = new byte[1050000];
      //      new Random().NextBytes(vs);
      //      await stream.WriteAsync(vs, 0, vs.Length);
      //   }
      //}
      //
      //private static async Task<string> NewMethod2()
      //{
      //   HttpClient client = new HttpClient();
      //   var res = await client.GetStringAsync(@"http://wp.pl");
      //   return res;
      //}
      //
      //public static async Task<string> RunTaskInParallel1()
      //{
      //
      //   HttpClient http = new HttpClient();
      //   Task wp = http.GetStringAsync("http://wp.pl");
      //   Task<string> interia = http.GetStringAsync("http://interia.pl");
      //   Task onet = http.GetStringAsync("http://onet.pl");
      //   DateTime.Now.Dump();
      //   await Task.WhenAll(wp, interia, onet);
      //   DateTime.Now.Dump();
      //   return interia.Result;
      //}
      //
      #endregion
      #region ADO.NET data access
      //public static async Task Main()
      //{
      //   await SelectDataFromTable();
      //   //await UpdateRows();
      //   //InsertScopeRows();
      //
      //   DbContextOptionsBuilder<PeopleContext> builder = new DbContextOptionsBuilder<PeopleContext>();
      //   builder.UseSqlServer(connectionString: @"Data Source = TGRZADZIEL\MSSQL2017; Initial Catalog = AdventureWorksLT2008R2; Integrated Security = True");
      //
      //   using (PeopleContext context = new PeopleContext(builder.Options))
      //   {
      //      context.People.Add(new People() { FirstName = "Barabara", LastName = "Kasia", MiddleName = "von" });
      //      context.SaveChanges();
      //   }
      //   "end".Dump();
      //}
      //
      //public static async Task SelectDataFromTable()
      //{
      //   using (SqlConnection connection = new SqlConnection(@"Data Source=TGRZADZIEL\MSSQL2017;Initial Catalog=AdventureWorksLT2008R2;Integrated Security=True"))
      //   {
      //      SqlCommand command = new SqlCommand("SELECT * FROM People", connection);
      //      await connection.OpenAsync();
      //      SqlDataReader dataReader = await command.ExecuteReaderAsync();
      //      while (await dataReader.ReadAsync())
      //      {
      //         string formatStringWithMiddleName = "Person({0}) is named {1} {2} {3}";
      //         string formatStringWithoutMiddleName = "Person({0}) is named {1} {3}";
      //         if ((dataReader["middlename"] == null))
      //         {
      //            Console.WriteLine(formatStringWithoutMiddleName,
      //            dataReader["id"],
      //            dataReader["firstname"],
      //            dataReader["lastname"]);
      //         }
      //         else
      //         {
      //            Console.WriteLine(formatStringWithMiddleName,
      //            dataReader["id"],
      //            dataReader["firstname"],
      //            dataReader["middlename"],
      //            dataReader["lastname"]);
      //         }
      //      }
      //      dataReader.Close();
      //   }
      //}
      //public static async Task UpdateRows()
      //{
      //   using SqlConnection connection = new SqlConnection(@"Data Source=TGRZADZIEL\MSSQL2017;Initial Catalog=AdventureWorksLT2008R2;Integrated Security=True");
      //   SqlCommand command = new SqlCommand("UPDATE People SET FirstName ='John'", connection);
      //   await connection.OpenAsync();
      //   int numberOfUpdatedRows = await command.ExecuteNonQueryAsync();
      //   Console.WriteLine("Updated {0} rows", numberOfUpdatedRows);
      //}
      //public static async Task InsertRows()
      //{
      //   using SqlConnection connection = new SqlConnection(@"Data Source=TGRZADZIEL\MSSQL2017;Initial Catalog=AdventureWorksLT2008R2;Integrated Security=True");
      //   SqlCommand command = new SqlCommand("INSERT into People([FirstName], [MiddleName], [LastName]) Values (@" +
      //      "firstName, @middleName, @lastName)", connection);
      //   await connection.OpenAsync();
      //   command.Parameters.AddWithValue("@firstName", "John");
      //   command.Parameters.AddWithValue("@middleName", "Peter");
      //   command.Parameters.AddWithValue("@lastName", "Orkan");
      //   int numberOfUpdatedRows = await command.ExecuteNonQueryAsync();
      //   Console.WriteLine("Inserted {0} rows", numberOfUpdatedRows);
      //}
      //public static void InsertScopeRows()
      //{
      //   using (TransactionScope transaction = new TransactionScope())
      //   {
      //      using (SqlConnection connection = new SqlConnection(@"Data Source=TGRZADZIEL\MSSQL2017;Initial Catalog=AdventureWorksLT2008R2;Integrated Security=True"))
      //      {
      //         connection.OpenAsync();
      //
      //         SqlCommand command = new SqlCommand("INSERT into People([FirstName], [MiddleName], [LastName]) Values (@" +
      //            "firstName, @middleName, @lastName)", connection);
      //         command.Parameters.AddWithValue("@firstName", "John11");
      //         command.Parameters.AddWithValue("@middleName", "Peter11");
      //         command.Parameters.AddWithValue("@lastName", "Orkan11");
      //
      //         SqlCommand command2 = new SqlCommand("INSERT into People([FirstName], [MiddleName], [LastName]) Values (@" +
      //            "firstName, @middleName, @lastName)", connection);
      //         command2.Parameters.AddWithValue("@firstName", "John21");
      //         command2.Parameters.AddWithValue("@middleName", "Peter21");
      //         command2.Parameters.AddWithValue("@lastName", "Orkan21");
      //
      //         command.ExecuteNonQuery();
      //         command2.ExecuteNonQuery();
      //      }
      //
      //      transaction.Complete();
      //   }
      //}
      #endregion
      #region web Services
      public static void Main()
      {

      }



      #endregion
   }
}
