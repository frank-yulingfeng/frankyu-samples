using Microsoft.VisualStudio.TestTools.UnitTesting;
using Frankyu.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frankyu.Crypto.Tests
{
    [TestClass()]
    public class DESTests
    {
        [TestMethod()]
        public void EncryptTest()
        {
            DES des = new DES();

            var originText = "hello world";
            var cipherText = des.Encrypt(originText);
            var clearTetxt = des.Decrypt(cipherText);

            Assert.AreEqual(originText, clearTetxt);
        }
    }
}