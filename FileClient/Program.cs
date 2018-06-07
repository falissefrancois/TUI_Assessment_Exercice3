using System;
using System.IO;
using FileReadingLibrary;

namespace FileReaderClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var textfilepath = Path.Combine(Directory.GetCurrentDirectory(), "SampleTextFile.txt");
            var xmlfilepath = Path.Combine(Directory.GetCurrentDirectory(), "SampleXmlFile.xml");
            var encryptedfilepath = Path.Combine(Directory.GetCurrentDirectory(), "SampleEncryptedTextFile.txt");
            var adminxmlfilepath = Path.Combine(Directory.GetCurrentDirectory(), "SampleAdminXmlFile.xml");

            //TEXT
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Reading file {Path.GetFileName(textfilepath)} :");
            Console.WriteLine(FileReader.ReadFile(textfilepath));

            //XML
            Console.WriteLine("\n\n------------------------------------------------");
            Console.WriteLine($"Reading file {Path.GetFileName(xmlfilepath)} :");
            Console.WriteLine(FileReader.ReadFile(xmlfilepath));

            //ENCRYPTED TEXT
            Console.WriteLine("\n\n------------------------------------------------");
            Console.WriteLine($"Reading file {Path.GetFileName(encryptedfilepath)} :");
            Console.WriteLine(FileReader.ReadFile(encryptedfilepath, true));

            //ADMINXML as ADMIN
            Console.WriteLine("\n\n------------------------------------------------");
            Console.WriteLine($"Reading file {Path.GetFileName(adminxmlfilepath)} as ADMIN :");
            Console.WriteLine(FileReader.ReadFile(adminxmlfilepath, userPassword:"12345password"));

            //ADMINXML not as ADMIN
            Console.WriteLine("\n\n------------------------------------------------");
            Console.WriteLine($"Reading file {Path.GetFileName(adminxmlfilepath)} as USER :");
            Console.WriteLine(FileReader.ReadFile(adminxmlfilepath, userPassword: "wrongPassword"));

            Console.WriteLine("\n\n\nPress any key to continue... ");
            Console.ReadLine();
        }
    }
}
