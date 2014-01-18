using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zxcvbn.net;

namespace zxcvbnTests
{
    [TestClass]
    public class UnitTests
    {

        const string LamePassword = "Passw0rd1!"; // 6 bits of entropy 

      
        [TestMethod]
        public void HelloCode()
        {
            Assert.IsTrue(true, "Hello world unit test");
        }

        /// <summary>
        /// This is a sanity check test to make sure that Jurassic js has loaded correctly 
        /// </summary>
        [TestMethod]
        public void CanSetAndGetGlobalVariable()
        {
            ZxcvbnInstance zxcvbn = new ZxcvbnInstance();

            zxcvbn.Engine.SetGlobalValue("GlobalVariable", LamePassword);
            string actual = zxcvbn.Engine.GetGlobalValue<string>("GlobalVariable");

            Assert.AreEqual(LamePassword, actual);
        }

        [TestMethod]
        public void ScoreIsZeroWithLamePassword()
        {
            ZxcvbnInstance zxcvbn = new ZxcvbnInstance();

            const int zero = 0;
            int actual = zxcvbn.Score(LamePassword);
            Assert.AreEqual(zero, actual);
        }

        [TestMethod]
        public void EntropyBasic()
        {
            ZxcvbnInstance zxcvbn = new ZxcvbnInstance();

            var actual = zxcvbn.Entropy(LamePassword);
            const double expected = 6.0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void PasswordTooLong()
        {
            const int maxLength = 4096;
            String excessivelyLongPassword = new string('x', maxLength + 1);

            ZxcvbnInstance zxcvbn = new ZxcvbnInstance();
            zxcvbn.Score(excessivelyLongPassword);
        }

    }
}
