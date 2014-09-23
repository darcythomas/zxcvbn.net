using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zxcvbn.net;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        const string LamePassword = "Passw0rd1!"; // 6 bits of entropy 

        [TestMethod]
        public void HelloCode()
        {
            Assert.IsTrue(true, "Hello world unit test");
        }
        [TestMethod]
        public void JurassicJS_HelloCode()
        {
            ZxcvbnInstance zxcvbn = new ZxcvbnInstance();

            zxcvbn.Engine.SetGlobalValue("GlobalVariable", LamePassword);
            string actual = zxcvbn.Engine.GetGlobalValue<string>("GlobalVariable");

            Assert.AreEqual(LamePassword, actual);
        }
    }
}
