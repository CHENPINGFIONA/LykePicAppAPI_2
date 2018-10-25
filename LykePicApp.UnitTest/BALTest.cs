using System;
using LykePicApp.BAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LykePicApp.UnitTest
{
    [TestClass]
    public class BALTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var bal = new UserBAL())
            {
                var user = bal.GetUserByName("t3pt");
            }
        }
    }
}
