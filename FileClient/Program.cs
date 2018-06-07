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

            //TEXT
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Reading file {Path.GetFileName(textfilepath)} :");
            Console.WriteLine(FileReader.ReadFile(textfilepath));

            //XML
            Console.WriteLine("\n\n------------------------------------------------");
            Console.WriteLine($"Reading file {Path.GetFileName(xmlfilepath)} :");
            Console.WriteLine(FileReader.ReadFile(xmlfilepath));

            Console.WriteLine("\n\n\nPress any key to continue... ");
            Console.ReadLine();
        }
    }
}
