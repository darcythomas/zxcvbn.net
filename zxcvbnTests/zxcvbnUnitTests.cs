using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zxcvbn.net;

namespace zxcvbnTests
{
    [TestClass]
    public class zxcvbnUnitTests
    {
        const string LamePassword = "Passw0rd1!"; // 6 bits of entropy 


        [TestMethod]
        public void StartUpTest()
        {
            ZxcvbnInstance zxcvbn = new ZxcvbnInstance();

            const int zero = 0;
            int actual = zxcvbn.Score(LamePassword);
            Assert.AreEqual(zero, actual);
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

        [TestMethod]
        public void LongPassword()
        {

            String excessivelyLongPassword = "For once you have tasted flight you will walk the earth with your eyes turned skywards, for there you have been and there you will long to return. -- Leonardo da Vinci ";

            ZxcvbnInstance zxcvbn = new ZxcvbnInstance();
            zxcvbn.Score(excessivelyLongPassword);
        }
    }
}
