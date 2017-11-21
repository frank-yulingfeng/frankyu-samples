
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Frankyu.Crypto
{
    public class Hash
    {
        public string MD5Encrypt(string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);

            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();

            var hash = md5Provider.ComputeHash(buffer);

            //return Convert.ToBase64String(hash);
            return BitConverter.ToString(hash);
        }

        public string Sha1Encrypt(string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);

            SHA1CryptoServiceProvider sha1Provider = new SHA1CryptoServiceProvider();

            var hash = sha1Provider.ComputeHash(buffer);

            return BitConverter.ToString(hash);
        }

        public string Sha256Encrypt(string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);

            SHA256CryptoServiceProvider sha256Provider = new SHA256CryptoServiceProvider();
            var hash = sha256Provider.ComputeHash(buffer);

            return BitConverter.ToString(hash);
        }
    }
}
