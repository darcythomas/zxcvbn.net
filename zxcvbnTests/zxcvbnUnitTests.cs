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
        const string LamePassword = "Password1"; // 6 bits of entropy 
        const string ReasonablePassword = "Life is wasted on the living. -- Douglas Adams";


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
        public void CrackTimeBasic()
        {
            ZxcvbnInstance zxcvbn = new ZxcvbnInstance();

            var actual = zxcvbn.crack_time(LamePassword);
            const double expected = 0.0379;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CrackTimeReasonablePassword()
        {
            ZxcvbnInstance zxcvbn = new ZxcvbnInstance();

            var actual = zxcvbn.crack_time(ReasonablePassword);
            const double expected = 9.269586128742398E+32;
            Assert.AreEqual(expected, actual, "actual: " + actual);
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




       // [TestMethod]
       
        public void PasswordTooLongx()
        {
            const int maxLength = 4096;
            String excessivelyLongPassword = new string('x', maxLength - 1);

            ZxcvbnInstance zxcvbn = new ZxcvbnInstance();
          var q =  zxcvbn.calculation_time(excessivelyLongPassword);

          Assert.IsTrue(false, "Score: " + q);
        }






        [TestMethod]
        public void LongPassword()
        {

            String excessivelyLongPassword = "For once you have tasted flight you will walk the earth with your eyes turned skywards, for there you have been and there you will long to return. -- Leonardo da Vinci ";

            ZxcvbnInstance zxcvbn = new ZxcvbnInstance();
            zxcvbn.Score(excessivelyLongPassword);
        }

        //[TestMethod]
        //public void TimesOutAfter300ms()
        //{
        //    int maxMilliseconds = 300;
        //    Stopwatch sw = new Stopwatch();
        //    String excessivelyLongPassword = "For once you have tasted flight you will walk the earth with your eyes turned skywards, for there you have been and there you will long to return. -- Leonardo da Vinci ";

            
        //    ZxcvbnInstance zxcvbn = new ZxcvbnInstance();
        //    zxcvbn.Score(LamePassword); //Incase this is the first test to be run we need to warm up (initlise the singlton) first.

        //    sw.Start();
        //    zxcvbn.Score(excessivelyLongPassword);
        //    sw.Stop();

        //    Assert.IsTrue(sw.ElapsedMilliseconds <= maxMilliseconds);
        //}
    }
}
