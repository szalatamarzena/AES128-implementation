using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorytmAES
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] key = new byte[] { 0x09, 0x15, 0x00, 0x97, 0x00, 0x12, 0x10, 0x13, 0x03, 0x02, 0x19, 0x02, 0x05, 0x00, 0x29, 0x80 };

            AES128 aes = new AES128(key);

            string text = "TestAES128string";
            if (args.Length > 0) {
                text = args[0];
            }

            byte[] plaintext = Encoding.UTF8.GetBytes(text);
            byte[] ciphertext = new byte[plaintext.Length];
            byte[] resultText = new byte[plaintext.Length];

            Console.WriteLine("Szyfrowany tekst: " + text);

            bool result = aes.Encrypt(plaintext, ref ciphertext);

            string encodedString = Convert.ToBase64String(ciphertext);

            Console.WriteLine("Zaszyfrowany tekst: " + encodedString);

            result = aes.Decrypt(ciphertext, ref resultText);

            string decodedStr = Encoding.UTF8.GetString(resultText);

            Console.WriteLine("Odszyfrowany tekst: " + decodedStr);
            Console.ReadKey();
        }
    }
}
