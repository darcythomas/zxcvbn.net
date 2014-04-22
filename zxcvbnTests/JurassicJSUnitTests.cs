using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zxcvbn.net;

namespace zxcvbnTests
{
    [TestClass]
    public class JurassicJSEngineUnitTests
    {
        const string LamePassword = "Passw0rd1!"; // 6 bits of entropy 


        [TestMethod]
        public void JurassicJS_HelloCode()
        {
            Assert.IsTrue(true, "Hello world unit test");
        }

        /// <summary>
        /// This is a sanity check test to make sure that Jurassic js has loaded correctly 
        /// </summary>
        [TestMethod]
        public void JurassicJS_CanSetAndGetGlobalVariable()
        {
            ZxcvbnInstance zxcvbn = new ZxcvbnInstance();

            zxcvbn.Engine.SetGlobalValue("GlobalVariable", LamePassword);
            string actual = zxcvbn.Engine.GetGlobalValue<string>("GlobalVariable");

            Assert.AreEqual(LamePassword, actual);
        }
    }
}
