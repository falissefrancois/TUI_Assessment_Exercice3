using System;
using System.IO;

namespace FileReadingLibrary
{
    //A user should be able to read a text file
    public static class TextFileReader
    {
        public static string ReadFile(string filepath)
        {
            return File.ReadAllText(filepath);
        }
    }
}
