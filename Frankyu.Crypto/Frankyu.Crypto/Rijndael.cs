using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Frankyu.Crypto
{
    public class Rijndael
    {
        /*AES和Rijndael加密法并不完全一样（虽然在实际应用中二者可以互换），
           因为Rijndael加密法可以支持更大范围的区块和密钥长度：AES的区块长度固定为128 比特，密钥长度则可以是128，192或256比特；
           而Rijndael使用的密钥和区块长度可以是32位的整数倍，以128位为下限，256比特为上限。
           加密过程中使用的密钥是由Rijndael密钥生成方案产生。*/
        /*Key默认是256位，IV默认是128位，如果要改变位数需要修改属性*/

        /*一个字符 8比特，32个字符就是256比特*/
        const string KEY = "ab9fd5db1710mic2073b93ba0bang040";//

        /*一个字符 8比特，16个字符就是128比特*/
        const string IV = "ed9fj5db2310dca2ed9fj5db2310dca2";//

        /// <summary>
        /// AES加密数据
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns></returns>
        public string Encrypt(string clearText)
        {
            if (string.IsNullOrEmpty(clearText))
                return string.Empty;

            byte[] buffer = Encoding.UTF8.GetBytes(clearText);

            MemoryStream stream = new MemoryStream();
            RijndaelManaged rijndael = new RijndaelManaged();
            
            rijndael.BlockSize = 256;
            rijndael.Key = Encoding.UTF8.GetBytes(KEY);
            rijndael.IV = Encoding.UTF8.GetBytes(IV);

            var encryptor = rijndael.CreateEncryptor();

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

            RijndaelManaged rijndael = new RijndaelManaged();
            rijndael.BlockSize = 256;
            rijndael.Key = Encoding.UTF8.GetBytes(KEY);
            rijndael.IV = Encoding.UTF8.GetBytes(IV);
            var encryptor = rijndael.CreateEncryptor();

            var cipherBytes = encryptor.TransformFinalBlock(buffer, 0, buffer.Length);

            return Convert.ToBase64String(cipherBytes);
        }

        /// <summary>
        /// AES解密数据
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return string.Empty;

            byte[] buffer = Convert.FromBase64String(cipherText);

            MemoryStream stream = new MemoryStream();
            RijndaelManaged rijndael = new RijndaelManaged();

            rijndael.BlockSize = 256;
            rijndael.Key = Encoding.UTF8.GetBytes(KEY);
            rijndael.IV = Encoding.UTF8.GetBytes(IV);

            var decryptor = rijndael.CreateDecryptor();

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

            RijndaelManaged rijndael = new RijndaelManaged();
            rijndael.BlockSize = 256;
            rijndael.Key = Encoding.UTF8.GetBytes(KEY);
            rijndael.IV = Encoding.UTF8.GetBytes(IV);
            var decryptor = rijndael.CreateDecryptor();

            var clearBytes = decryptor.TransformFinalBlock(buffer, 0, buffer.Length);

            return Encoding.UTF8.GetString(clearBytes);
        }
    }
}
