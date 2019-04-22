using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Frankyu.Crypto
{
    public class RSA
    {
        /// <summary>
        /// 生成RSA密钥对
        /// </summary>
        /// <returns></returns>
        public RSAKey GenerateRSAKey()
        {
            RSAKey RSAKEY = new RSAKey();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSAKEY.PrivateKey = RSA.ToXmlString(true);    //生成私钥
            RSAKEY.PublicKey = RSA.ToXmlString(false);    //生成公钥
            RSA.Clear();

            return RSAKEY;
        }

        /// <summary>
        /// 创建加密RSA
        /// </summary>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        private RSACryptoServiceProvider CreateEncryptRSA(string publicKey)
        {
            try
            {
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.FromXmlString(publicKey);
                return RSA;
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 创建解密RSA
        /// </summary>
        /// <param name="privateKey">私钥</param>
        /// <returns></returns>
        private RSACryptoServiceProvider CreateDecryptRSA(string privateKey)
        {
            try
            {
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.FromXmlString(privateKey);
                return RSA;
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据安全证书创建加密RSA
        /// </summary>
        /// <param name="certfile">公钥文件</param>
        /// <returns></returns>
        private RSACryptoServiceProvider X509CertCreateEncryptRSA(string certfile)
        {
            try
            {
                X509Certificate2 x509Cert = new X509Certificate2(certfile);
                RSACryptoServiceProvider RSA = (RSACryptoServiceProvider)x509Cert.PublicKey.Key;
                return RSA;
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据私钥文件创建解密RSA
        /// </summary>
        /// <param name="keyfile">私钥文件</param>
        /// <param name="password">访问含私钥文件的密码</param>
        /// <returns></returns>
        private RSACryptoServiceProvider X509CertCreateDecryptRSA(string keyfile, string password)
        {
            try
            {
                X509Certificate2 x509Cert = new X509Certificate2(keyfile, password);
                RSACryptoServiceProvider RSA = (RSACryptoServiceProvider)x509Cert.PrivateKey;
                return RSA;
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
        }

        private string BytesToHexString(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
            //return BitConverter.ToString(bytes);
        }

        private byte[] HexStringToBytes(string hexString)
        {
            return Convert.FromBase64String(hexString);
            //return BitConverter.TO
        }

        #region 加解密

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="dataToEncrypt">待加密数据</param>
        /// <param name="publicKey">公钥</param>
        /// <returns></returns>
        public string Encrypt(string dataToEncrypt, string publicKey)
        {
            Encoding encoder = Encoding.UTF8;
            byte[] _dataToEncrypt = encoder.GetBytes(dataToEncrypt);
            return this.Encrypt(_dataToEncrypt, publicKey);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="dataToEncrypt">待加密数据</param>
        /// <param name="publicKey">公钥</param>
        /// <returns></returns>
        public string Encrypt(byte[] dataToEncrypt, string publicKey)
        {
            using (RSACryptoServiceProvider RSA = this.CreateEncryptRSA(publicKey))
            {
                byte[] encryptedData = RSA.Encrypt(dataToEncrypt, false);
                return this.BytesToHexString(encryptedData);
            }
        }

        /// <summary>
        /// 根据安全证书加密
        /// </summary>
        /// <param name="dataToEncrypt"></param>
        /// <param name="certfile"></param>
        /// <returns></returns>
        public string X509CertEncrypt(string dataToEncrypt, string certfile)
        {
            Encoding encoder = Encoding.UTF8;
            byte[] _dataToEncrypt = encoder.GetBytes(dataToEncrypt);
            return this.X509CertEncrypt(_dataToEncrypt, certfile);
        }

        /// <summary>
        /// 根据安全证书加密
        /// </summary>
        /// <param name="dataToEncrypt">待加密数据</param>
        /// <param name="certfile">安全证书</param>
        /// <returns></returns>
        public string X509CertEncrypt(byte[] dataToEncrypt, string certfile)
        {
            if (!File.Exists(certfile))
            {
                throw new ArgumentNullException(certfile, "加密证书未找到");
            }
            using (RSACryptoServiceProvider RSA = this.X509CertCreateEncryptRSA(certfile))
            {
                byte[] encryptedData = RSA.Encrypt(dataToEncrypt, false);
                return this.BytesToHexString(encryptedData);
            }
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="encryptedData">待解密数据</param>
        /// <param name="privateKey">私钥</param>
        /// <returns></returns>
        public string Decrypt(string encryptedData, string privateKey)
        {
            using (RSACryptoServiceProvider RSA = this.CreateDecryptRSA(privateKey))
            {
                Encoding encoder = Encoding.UTF8;
                byte[] _encryptedData = HexStringToBytes(encryptedData);
                byte[] decryptedData = RSA.Decrypt(_encryptedData, false);
                return encoder.GetString(decryptedData);
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="encryptedData">待解密数据</param>
        /// <param name="keyfile">私钥文件</param>
        /// <param name="password">访问私钥文件密码</param>
        /// <returns></returns>
        public string X509CertDecrypt(string encryptedData, string keyfile, string password)
        {
            if (!File.Exists(keyfile))
            {
                throw new ArgumentNullException(keyfile, "解密证书未找到");
            }
            using (RSACryptoServiceProvider RSA = this.X509CertCreateDecryptRSA(keyfile, password))
            {
                Encoding encoder = Encoding.UTF8;
                byte[] _encryptedData = HexStringToBytes(encryptedData);
                byte[] decryptedData = RSA.Decrypt(_encryptedData, false);
                return encoder.GetString(decryptedData);
            }
        }

        #endregion

        #region 签名

        #region 获取Hash描述表          
        /// <summary>  
        /// 获取Hash描述表  
        /// </summary>  
        /// <param name="strSource">待签名的字符串</param>  
        /// <param name="HashData">Hash描述</param>  
        /// <returns></returns>  
        public bool GetHash(string strSource, ref byte[] HashData)
        {
            try
            {
                byte[] Buffer;
                HashAlgorithm MD5 = HashAlgorithm.Create("MD5");
                Buffer = Encoding.GetEncoding("GB2312").GetBytes(strSource);
                HashData = MD5.ComputeHash(Buffer);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// 获取Hash描述表  
        /// </summary>  
        /// <param name="strSource">待签名的字符串</param>  
        /// <param name="strHashData">Hash描述</param>  
        /// <returns></returns>  
        public bool GetHash(string strSource, ref string strHashData)
        {
            try
            {
                //从字符串中取得Hash描述   
                byte[] Buffer;
                byte[] HashData;
                HashAlgorithm MD5 = HashAlgorithm.Create("MD5");
                Buffer = Encoding.GetEncoding("GB2312").GetBytes(strSource);
                HashData = MD5.ComputeHash(Buffer);
                strHashData = Convert.ToBase64String(HashData);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// 获取Hash描述表  
        /// </summary>  
        /// <param name="objFile">待签名的文件</param>  
        /// <param name="HashData">Hash描述</param>  
        /// <returns></returns>  
        public bool GetHash(FileStream objFile, ref byte[] HashData)
        {
            try
            {
                //从文件中取得Hash描述   
                HashAlgorithm MD5 = HashAlgorithm.Create("MD5");
                HashData = MD5.ComputeHash(objFile);
                objFile.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// 获取Hash描述表  
        /// </summary>  
        /// <param name="objFile">待签名的文件</param>  
        /// <param name="strHashData">Hash描述</param>  
        /// <returns></returns>  
        public bool GetHash(FileStream objFile, ref string strHashData)
        {
            try
            {
                //从文件中取得Hash描述   
                byte[] HashData;
                HashAlgorithm MD5 = HashAlgorithm.Create("MD5");
                HashData = MD5.ComputeHash(objFile);
                objFile.Close();
                strHashData = Convert.ToBase64String(HashData);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        
        /// <summary>  
        /// RSA签名  
        /// </summary>  
        /// <param name="strKeyPrivate">私钥</param>  
        /// <param name="HashbyteSignature">待签名Hash描述</param>  
        /// <param name="EncryptedSignatureData">签名后的结果</param>  
        /// <returns></returns>  
        public bool SignatureFormatter(string strKeyPrivate, byte[] HashbyteSignature, ref byte[] EncryptedSignatureData)
        {
            try
            {
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                RSA.FromXmlString(strKeyPrivate);
                RSAPKCS1SignatureFormatter RSAFormatter = new RSAPKCS1SignatureFormatter(RSA);
                //设置签名的算法为MD5   
                RSAFormatter.SetHashAlgorithm("MD5");
                //执行签名   
                EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// RSA签名  
        /// </summary>  
        /// <param name="strKeyPrivate">私钥</param>  
        /// <param name="HashbyteSignature">待签名Hash描述</param>  
        /// <param name="m_strEncryptedSignatureData">签名后的结果</param>  
        /// <returns></returns>  
        public bool SignatureFormatter(string strKeyPrivate, byte[] HashbyteSignature, ref string strEncryptedSignatureData)
        {
            try
            {
                byte[] EncryptedSignatureData;
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.FromXmlString(strKeyPrivate);
                RSAPKCS1SignatureFormatter RSAFormatter = new RSAPKCS1SignatureFormatter(RSA);
                //设置签名的算法为MD5   
                RSAFormatter.SetHashAlgorithm("MD5");
                //执行签名   
                EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);
                strEncryptedSignatureData = Convert.ToBase64String(EncryptedSignatureData);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// RSA签名  
        /// </summary>  
        /// <param name="strKeyPrivate">私钥</param>  
        /// <param name="strHashbyteSignature">待签名Hash描述</param>  
        /// <param name="EncryptedSignatureData">签名后的结果</param>  
        /// <returns></returns>  
        public bool SignatureFormatter(string strKeyPrivate, string strHashbyteSignature, ref byte[] EncryptedSignatureData)
        {
            try
            {
                byte[] HashbyteSignature;

                HashbyteSignature = Convert.FromBase64String(strHashbyteSignature);
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();


                RSA.FromXmlString(strKeyPrivate);
                RSAPKCS1SignatureFormatter RSAFormatter = new RSAPKCS1SignatureFormatter(RSA);
                //设置签名的算法为MD5   
                RSAFormatter.SetHashAlgorithm("MD5");
                //执行签名   
                EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// RSA签名  
        /// </summary>  
        /// <param name="strKeyPrivate">私钥</param>  
        /// <param name="strHashbyteSignature">待签名Hash描述</param>  
        /// <param name="strEncryptedSignatureData">签名后的结果</param>  
        /// <returns></returns>  
        public bool SignatureFormatter(string strKeyPrivate, string strHashbyteSignature, ref string strEncryptedSignatureData)
        {
            try
            {
                byte[] HashbyteSignature;
                byte[] EncryptedSignatureData;
                HashbyteSignature = Convert.FromBase64String(strHashbyteSignature);
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.FromXmlString(strKeyPrivate);
                RSAPKCS1SignatureFormatter RSAFormatter = new RSAPKCS1SignatureFormatter(RSA);
                //设置签名的算法为MD5   
                RSAFormatter.SetHashAlgorithm("MD5");
                //执行签名   
                EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);
                strEncryptedSignatureData = Convert.ToBase64String(EncryptedSignatureData);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region RSA 签名验证  
        /// <summary>  
        /// RSA签名验证  
        /// </summary>  
        /// <param name="strKeyPublic">公钥</param>  
        /// <param name="HashbyteDeformatter">Hash描述</param>  
        /// <param name="DeformatterData">签名后的结果</param>  
        /// <returns></returns>  
        public bool SignatureDeformatter(string strKeyPublic, byte[] HashbyteDeformatter, byte[] DeformatterData)
        {
            try
            {
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.FromXmlString(strKeyPublic);
                RSAPKCS1SignatureDeformatter RSADeformatter = new RSAPKCS1SignatureDeformatter(RSA);
                //指定解密的时候HASH算法为MD5   
                RSADeformatter.SetHashAlgorithm("MD5");
                if (RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>  
        /// RSA签名验证  
        /// </summary>  
        /// <param name="strKeyPublic">公钥</param>  
        /// <param name="strHashbyteDeformatter">Hash描述</param>  
        /// <param name="DeformatterData">签名后的结果</param>  
        /// <returns></returns>  
        public bool SignatureDeformatter(string strKeyPublic, string strHashbyteDeformatter, byte[] DeformatterData)
        {
            try
            {
                byte[] HashbyteDeformatter;
                HashbyteDeformatter = Convert.FromBase64String(strHashbyteDeformatter);
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.FromXmlString(strKeyPublic);
                RSAPKCS1SignatureDeformatter RSADeformatter = new RSAPKCS1SignatureDeformatter(RSA);
                //指定解密的时候HASH算法为MD5   
                RSADeformatter.SetHashAlgorithm("MD5");
                if (RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>  
        /// RSA签名验证  
        /// </summary>  
        /// <param name="strKeyPublic">公钥</param>  
        /// <param name="HashbyteDeformatter">Hash描述</param>  
        /// <param name="strDeformatterData">签名后的结果</param>  
        /// <returns></returns>  
        public bool SignatureDeformatter(string strKeyPublic, byte[] HashbyteDeformatter, string strDeformatterData)
        {
            try
            {
                byte[] DeformatterData;
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.FromXmlString(strKeyPublic);
                RSAPKCS1SignatureDeformatter RSADeformatter = new RSAPKCS1SignatureDeformatter(RSA);
                //指定解密的时候HASH算法为MD5   
                RSADeformatter.SetHashAlgorithm("MD5");
                DeformatterData = Convert.FromBase64String(strDeformatterData);
                if (RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>  
        /// RSA签名验证  
        /// </summary>  
        /// <param name="strKeyPublic">公钥</param>  
        /// <param name="strHashbyteDeformatter">Hash描述</param>  
        /// <param name="strDeformatterData">签名后的结果</param>  
        /// <returns></returns>  
        public bool SignatureDeformatter(string strKeyPublic, string strHashbyteDeformatter, string strDeformatterData)
        {
            try
            {
                byte[] DeformatterData;
                byte[] HashbyteDeformatter;
                HashbyteDeformatter = Convert.FromBase64String(strHashbyteDeformatter);
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.FromXmlString(strKeyPublic);
                RSAPKCS1SignatureDeformatter RSADeformatter = new RSAPKCS1SignatureDeformatter(RSA);
                //指定解密的时候HASH算法为MD5   
                RSADeformatter.SetHashAlgorithm("MD5");
                DeformatterData = Convert.FromBase64String(strDeformatterData);
                if (RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }

    public class RSAKey
    {
        public string PublicKey { get; set; }

        public string PrivateKey { get; set; }
    }  
}
