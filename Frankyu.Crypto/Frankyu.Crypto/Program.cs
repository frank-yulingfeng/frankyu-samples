using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frankyu.Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDES();
            Console.WriteLine("------------------------------");
            TestAES();
            Console.WriteLine("------------------------------");
            TestRijndael();

            Console.Read();
        }

        public static void TestDES()
        {
            DES des = new DES();
            string originText = "Today is Friday, I am so happy because tomorrow is weekend!";

            Console.WriteLine($"clean text is <{originText}>");

            var cipherText = des.Encrypt(originText);
            var cipherText1 = des.Encrypt1(originText);

            Console.WriteLine($"cipher text is <{cipherText}>");
            Console.WriteLine($"cipher text1 is <{cipherText1}>");

            var clearText = des.Decrypt(cipherText);
            var clearText1 = des.Decrypt1(cipherText);

            Console.WriteLine($"clear text is <{clearText}>");
            Console.WriteLine($"clear text1 is <{clearText1}>");
        }

        public static void TestAES()
        {
            AES aes = new AES();
            string originText = "Today is Friday, I am so happy because tomorrow is weekend!";

            Console.WriteLine($"clean text is <{originText}>");

            var cipherText = aes.Encrypt(originText);
            var cipherText1 = aes.Encrypt1(originText);

            Console.WriteLine($"cipher text is <{cipherText}>");
            Console.WriteLine($"cipher1 text is <{cipherText1}>");

            var clearText = aes.Decrypt(cipherText);
            var clearText1 = aes.Decrypt1(cipherText);

            Console.WriteLine($"clear text is <{clearText}>");
            Console.WriteLine($"clear text is <{clearText1}>");
        }

        public static void TestRijndael()
        {
            Rijndael rijndael = new Rijndael();
            string originText = "Today is Friday, I am so happy because tomorrow is weekend!";

            Console.WriteLine($"clean text is <{originText}>");

            var cipherText = rijndael.Encrypt(originText);
            var cipherText1 = rijndael.Encrypt1(originText);

            Console.WriteLine($"cipher text is <{cipherText}>");
            Console.WriteLine($"cipher text1 is <{cipherText1}>");

            var clearText = rijndael.Decrypt(cipherText);
            var clearText1 = rijndael.Decrypt1(cipherText);

            Console.WriteLine($"clear text is <{clearText}>");
            Console.WriteLine($"clear text1 is <{clearText1}>");

        }

    }
}
