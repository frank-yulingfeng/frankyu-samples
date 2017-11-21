using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Frankyu.Crypto
{
    public class DES
    {
        //Des加解密算法，Key和IV长度只有8个字节
        //真实使用时可以使用MD5算法先将KEY，IV计算，然后取前8位
        private const string KEY = "abcdefgh";
        private const string IV = "ijklmnop";

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string Encrypt(string clearText)
        {
            if (string.IsNullOrEmpty(clearText))
                return string.Empty;

            byte[] buffer = Encoding.UTF8.GetBytes(clearText);

            MemoryStream stream = new MemoryStream();
            DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();
            
            var encryptor = desProvider.CreateEncryptor(Encoding.UTF8.GetBytes(KEY), Encoding.UTF8.GetBytes(IV));

            CryptoStream cryptoStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(buffer, 0, buffer.Length);
            cryptoStream.FlushFinalBlock();

            return Convert.ToBase64String(stream.ToArray());
        }

        public string Encrypt1(string clearText)
        {
            if (string.IsNullOrEmpty(clearText))
                return string.Empty;

            byte[] buffer = Encoding.UTF8.GetBytes(clearText);

            DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();

            var encryptor = desProvider.CreateEncryptor(Encoding.UTF8.GetBytes(KEY), Encoding.UTF8.GetBytes(IV));

            //转换 也可以达到加密效果
            var cipherBytes = encryptor.TransformFinalBlock(buffer, 0, buffer.Length);

            return Convert.ToBase64String(cipherBytes);
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return string.Empty;

            byte[] buffer = Convert.FromBase64String(cipherText);

            MemoryStream stream = new MemoryStream();
            DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();

            var decryptor = desProvider.CreateDecryptor(Encoding.UTF8.GetBytes(KEY), Encoding.UTF8.GetBytes(IV));

            CryptoStream cryptoStream = new CryptoStream(stream, decryptor, CryptoStreamMode.Write);
            cryptoStream.Write(buffer, 0, buffer.Length);
            cryptoStream.FlushFinalBlock();

            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public string Decrypt1(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return string.Empty;

            byte[] buffer = Convert.FromBase64String(cipherText);
            
            DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();

            var decryptor = desProvider.CreateDecryptor(Encoding.UTF8.GetBytes(KEY), Encoding.UTF8.GetBytes(IV));

            var clearBytes = decryptor.TransformFinalBlock(buffer, 0, buffer.Length);

            return Encoding.UTF8.GetString(clearBytes);
        }
    }
}
