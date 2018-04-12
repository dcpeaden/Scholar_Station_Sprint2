using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessControler;

namespace DataControlerUnitTest
{
    [TestClass]
    public class DBConnectionClosedTEST
    {
        [TestMethod]
        public void ConnectionClosedTEST()
        {
            //Arange
            IConnection da = new ConnectionControler();
            da.openConnection();
            //Act
            bool disconnected = da.closeConnection();

            //Assert
            Assert.IsTrue(disconnected);
        }
    }
}
