using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FileReadingLibrary
{
    public static class FileReader
    {
        private enum SupportedFileExtensions { txt, xml, json };

        public static string ReadFile(string filepath, bool isEncrypted=false)
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

            var text = isEncrypted ? Decrypt(File.ReadAllText(filepath)) : File.ReadAllText(filepath);

            switch (fileExtension)
            {
                case SupportedFileExtensions.txt:
                    return text;
                case SupportedFileExtensions.xml:
                    return ReadXml(text);
                case SupportedFileExtensions.json:
                    return ReadJson(text);
                default:
                    throw new ArgumentOutOfRangeException();
            }

            throw new ArgumentException("An unknown error occured");
        }

        private static string ReadJson(string text)
        {
            throw new NotImplementedException();
        }

        private static string ReadXml(string text)
        {
            TextReader reader = new StringReader(text);
            var serializer = new XmlSerializer(typeof(List<Flight>));
            var flights = serializer.Deserialize(reader) as List<Flight>;

            var sb = new StringBuilder();
            foreach (var flightAndIndex in flights.Select((flight, index) => new { flight, index }))
            {
                sb.AppendLine($"Flight #{flightAndIndex.index}");
                sb.AppendLine(flightAndIndex.flight.ToString());
            }

            return sb.ToString();
        }

        public static string Decrypt(string text)
        {
            return FileEncrypterDecrypter.DecryptText(text);
        }
    }
}
