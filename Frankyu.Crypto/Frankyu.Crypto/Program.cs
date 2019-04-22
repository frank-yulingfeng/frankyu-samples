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
            Console.WriteLine("------------------------------");
            TestRSA();
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
            Console.WriteLine("origin text: " + originText);

            Hash hash = new Hash();

            var md5Str = hash.MD5ComputeHash(originText);
            var md5Str1 = hash.MD5ComputeHash1(originText);
            var md5Str2 = hash.MD5ComputeHash2(originText);
            Console.WriteLine("MD5 text : " + md5Str);
            Console.WriteLine("MD5 text1: " + md5Str1);
            Console.WriteLine("MD5 text2: " + md5Str2);

            var sha1Str = hash.Sha1ComputeHash(originText);
            var sha1Str1 = hash.Sha1ComputeHash1(originText);
            var sha1Str2 = hash.Sha1ComputeHash2(originText);
            Console.WriteLine("sha1Str text : " + sha1Str);
            Console.WriteLine("sha1Str text1: " + sha1Str1);
            Console.WriteLine("sha1Str text2: " + sha1Str2);

            var sha256Str = hash.Sha256ComputeHash(originText);
            var sha256Str1 = hash.Sha256ComputeHash1(originText);
            var sha256Str2 = hash.Sha256ComputeHash2(originText);
            Console.WriteLine("sha256Str text : " + sha256Str);
            Console.WriteLine("sha256Str text1: " + sha256Str1);
            Console.WriteLine("sha256Str text2: " + sha256Str2);
        }

        public static void TestPasswordHash()
        {
            string password="ThisIsaPassword";
            var passwordHash = PasswordHash.CreateHash(password);

            Console.WriteLine("passwordHash: " + passwordHash);
        }

        public static void TestRSA()
        {
            RSA rsa = new RSA();
            var key = rsa.GenerateRSAKey();
            string originText = "This is a RSA test text. Frank";
            Console.WriteLine("originText：" + originText);
            var encryptedText = rsa.Encrypt(originText, key.PublicKey);
            Console.WriteLine("encryptedText：" + encryptedText);

            originText = rsa.Decrypt(encryptedText, key.PrivateKey);
            Console.WriteLine("originText：" + originText);

        }
    }
}
