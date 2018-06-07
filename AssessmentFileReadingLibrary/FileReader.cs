using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileReadingLibrary
{
    //A user should be able to read a text file
    public static class FileReader
    {
        private enum SupportedFileExtensions { txt, xml, json };

        public static string ReadFile(string filepath)
        {
            SupportedFileExtensions fileExtension;

            try
            {
                SupportedFileExtensions.TryParse(Path.GetExtension(filepath).TrimStart('.'), true, out fileExtension);
            }
            catch (Exception)
            {
                Console.WriteLine("File fileExtension not supported");
                throw new ArgumentException($"File Extension not supported : {Path.GetFileName(filepath)}");
            }

            switch (fileExtension)
            {
                case SupportedFileExtensions.txt:
                    return ReadTextFile(filepath);
                case SupportedFileExtensions.xml:
                    return ReadXmlFile(filepath);
                case SupportedFileExtensions.json:
                    return ReadJsonFile(filepath);
                default:
                    throw new ArgumentOutOfRangeException();
            }

            throw new ArgumentException("An unknown error occured");
        }

        private static string ReadJsonFile(string filepath)
        {
            throw new NotImplementedException();
        }

        private static string ReadXmlFile(string filepath)
        {
            TextReader reader = new StreamReader(filepath);
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Flight>));
            var flights = serializer.Deserialize(reader) as List<Flight>;

            var sb = new StringBuilder();
            foreach (var flightAndIndex in flights.Select((flight, index) => new { flight, index }))
            {
                sb.AppendLine($"Flight #{flightAndIndex.index}");
                sb.AppendLine(flightAndIndex.flight.ToString());
            }

            return sb.ToString();
        }

        private static string ReadTextFile(string filepath)
        {
            return File.ReadAllText(filepath);
        }
    }
}
