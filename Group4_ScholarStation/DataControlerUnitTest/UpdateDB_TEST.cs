using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessControler;
using Moq;

namespace DataControlerUnitTest
{
    [TestClass]
    public class UpdateDB_TEST
    {
        [TestMethod]
        public void UpdateDBTest()
        {
            //Arrange
            var mockTest1 = new Mock<IUpdate>();
            string query = "FalseQuery";
            mockTest1.Setup(x => x.ExecuteQueries(It.IsAny<string>())).Returns(false);

            //Act
            bool resultFalse = mockTest1.Object.ExecuteQueries(query);

            //Assert
            Assert.IsFalse(resultFalse);

            //Arrange
            var mockTest2 = new Mock<IUpdate>();
            string query2 = "TrueQuery";
            mockTest2.Setup(x => x.ExecuteQueries(It.IsAny<string>())).Returns(true);

            //Act
            bool resultTrue = mockTest2.Object.ExecuteQueries(query2);

            //Assert
            Assert.IsTrue(resultTrue);
        }
    }
}
