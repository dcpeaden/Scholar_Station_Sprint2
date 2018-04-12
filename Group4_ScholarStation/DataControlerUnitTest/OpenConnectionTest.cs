using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessControler;

namespace DataControlerUnitTest
{
    [TestClass]
    public class OpenConnectionTest
    {
        [TestMethod]
        public void TestOpeningConnection()
        {
            //Arange
            IConnection da = new ConnectionControler();

            //Act
            bool disconnected = da.openConnection();

            //Assert
            Assert.IsTrue(disconnected);
        }
    }
}
