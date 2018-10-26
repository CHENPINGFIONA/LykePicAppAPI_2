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
            using (var bal = new UserFollowerBAL())
            {
                bal.UnFollow(new Guid("1E03F4F2-33D9-E811-A447-B0C09099AD52"), new Guid("7FDB0DBA-82A2-4C03-A4A2-14F1F15241BE"));
            }
        }
    }
}
