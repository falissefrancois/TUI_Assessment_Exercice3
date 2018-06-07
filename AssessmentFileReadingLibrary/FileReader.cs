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

        private static List<string> _adminRestrictedFiles = new List<string> {"SampleAdminXmlFile"};
        private static string _adminPassword = "12345password";

        public static string ReadFile(string filepath, bool isEncrypted=false, string userPassword=null)
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

            //Encryption
            var text = isEncrypted ? Decrypt(File.ReadAllText(filepath)) : File.ReadAllText(filepath);

            //Access Rights
            var isAdmin = !string.IsNullOrWhiteSpace(userPassword) && userPassword == _adminPassword;
            if (_adminRestrictedFiles.Contains(Path.GetFileNameWithoutExtension(filepath)) && !isAdmin)
                return "Insufficient permissions";

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
