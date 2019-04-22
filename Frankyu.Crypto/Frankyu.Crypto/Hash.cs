
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
        #region MD5

        public string MD5ComputeHash(string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);

            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();

            var hash = md5Provider.ComputeHash(buffer);

            //return Convert.ToBase64String(hash);
            return BitConverter.ToString(hash);
        }

        public string MD5ComputeHash1(string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(buffer);
            return BitConverter.ToString(hash);
        }

        public string MD5ComputeHash2(string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            HashAlgorithm md5 = HashAlgorithm.Create("MD5");
            var hash = md5.ComputeHash(buffer);
            return BitConverter.ToString(hash);
        }

        #endregion


        #region Sha1

        public string Sha1ComputeHash(string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            SHA1CryptoServiceProvider sha1Provider = new SHA1CryptoServiceProvider();
            var hash = sha1Provider.ComputeHash(buffer);
            return BitConverter.ToString(hash);
        }

        public string Sha1ComputeHash1(string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            SHA1 sha1 = SHA1.Create();
            var hash = sha1.ComputeHash(buffer);
            return BitConverter.ToString(hash);
        }

        public string Sha1ComputeHash2(string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
            var hash = sha1.ComputeHash(buffer);
            return BitConverter.ToString(hash);
        }

        #endregion


        #region SHA256

        public string Sha256ComputeHash(string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            SHA256CryptoServiceProvider sha256Provider = new SHA256CryptoServiceProvider();
            var hash = sha256Provider.ComputeHash(buffer);
            return BitConverter.ToString(hash);
        }

        public string Sha256ComputeHash1(string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            SHA256 sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(buffer);
            return BitConverter.ToString(hash);
        }

        public string Sha256ComputeHash2(string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            HashAlgorithm sha256 = HashAlgorithm.Create("SHA256");
            var hash = sha256.ComputeHash(buffer);
            return BitConverter.ToString(hash);
        }

        #endregion
    }
}
