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
            Console.WriteLine("------------------------------");
            TestHash();
            Console.WriteLine("------------------------------");
            TestPasswordHash();

            Console.Read();
        }

        public static void TestDES()
        {
            DES des = new DES();
            string originText = "Today is Friday, I am so happy because tomorrow is weekend!";

            Console.WriteLine("clean text: " + originText);

            var cipherText = des.Encrypt(originText);
            var cipherText1 = des.Encrypt1(originText);

            Console.WriteLine("cipher text: " + cipherText);
            Console.WriteLine("cipher text1: " + cipherText1);

            var clearText = des.Decrypt(cipherText);
            var clearText1 = des.Decrypt1(cipherText);

            Console.WriteLine("clear text: " + clearText);
            Console.WriteLine("clear text1: " + clearText1);
        }

        public static void TestAES()
        {
            AES aes = new AES();
            string originText = "Today is Friday, I am so happy because tomorrow is weekend!";

            Console.WriteLine("clean text: " + originText);

            var cipherText = aes.Encrypt(originText);
            var cipherText1 = aes.Encrypt1(originText);

            Console.WriteLine("cipher text: " + cipherText);
            Console.WriteLine("cipher text1: " + cipherText1);

            var clearText = aes.Decrypt(cipherText);
            var clearText1 = aes.Decrypt1(cipherText);

            Console.WriteLine("clear text: " + clearText);
            Console.WriteLine("clear text1: " + clearText1);
        }

        public static void TestRijndael()
        {
            Rijndael rijndael = new Rijndael();
            string originText = "Today is Friday, I am so happy because tomorrow is weekend!";

            Console.WriteLine("clean text: " + originText);

            var cipherText = rijndael.Encrypt(originText);
            var cipherText1 = rijndael.Encrypt1(originText);

            Console.WriteLine("cipher text: " + cipherText);
            Console.WriteLine("cipher text1: " + cipherText1);

            var clearText = rijndael.Decrypt(cipherText);
            var clearText1 = rijndael.Decrypt1(cipherText);

            Console.WriteLine("clear text: " + clearText);
            Console.WriteLine("clear text1: " + clearText1);

        }

        public static void TestHash()
        {

            var originText = "what is this, what is md5, i don't know";

            Hash hash = new Hash();
            var md5Str = hash.MD5Encrypt(originText);

            var sha1Str = hash.Sha1Encrypt(originText);
            var sha256Str = hash.Sha256Encrypt(originText);

            Console.WriteLine("origin text: " + originText);
            Console.WriteLine("MD5 text: " + md5Str);
            Console.WriteLine("Sha1 text: " + sha1Str);
            Console.WriteLine("Sha256 text: " + sha256Str);
        }

        public static void TestPasswordHash()
        {
            string password="ThisIsaPassword";
            var passwordHash = PasswordHash.CreateHash(password);

            Console.WriteLine("passwordHash: " + passwordHash);
        }
    }
}
