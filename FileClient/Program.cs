using System;
using System.IO;
using FileReadingLibrary;

namespace FileReaderClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "SampleTextFile.txt");
            Console.WriteLine($"Reading file {Path.GetFileName(filepath)} :");
            Console.WriteLine(TextFileReader.ReadFile(filepath));

            Console.WriteLine("\n\n\n\n\nPress any key to continue... ");
            Console.ReadLine();
        }
    }
}
