using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileReadingLibrary
{
    internal class FileEncrypterDecrypter
    {
        public static string DecryptText(string encryptedText)
        {
            return ReverseString(encryptedText);
        }

        public static string EncryptText(string text)
        {
            return ReverseString(text);
        }

        public static string ReverseString(string str)
        {
            var chars = str.ToCharArray();

            for (int i=0, j=str.Length-1; i<j; i++, j--)
            {
                var c = chars[i];
                chars[i] = chars[j];
                chars[j] = c;
            }

            return new string(chars);
        }
    }
}
