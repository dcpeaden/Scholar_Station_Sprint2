using System;
using EmailControler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EmailUnitTest
{
    [TestClass]
    public class EmailUnitTest
    {
        [TestMethod]
        public void TestEmailSending()
        {
            //Arrange
            var mockTest1 = new Mock<IMailControler>();
            mockTest1.Setup(x => x.SendEmail("ryansknaggs@gmail.com" , "Subject" , "body")).Returns("Message Sent Successfully");

            //Act
            string resultFalse = mockTest1.Object.SendEmail("ryansknaggs@gmail.com", "Subject", "body");

            //Assert
            Assert.AreEqual("Message Sent Successfully", resultFalse);

        }

        [TestMethod]
        public void TestEmailTypeToSend()
        {
            //Arrange
            var mockTest1 = new Mock<ISelectedEmailType>();
            mockTest1.Setup(x => x.SelectedEmailType("ryansknaggs@gmail.com", "1987621")).Returns("Message Sent Successfully");

            //Act
            string resultFalse = mockTest1.Object.SelectedEmailType("ryansknaggs@gmail.com", "1987621");

            //Assert
            Assert.AreEqual("Message Sent Successfully", resultFalse);

        }

        [TestMethod]
        public void TestEmailHandlerCancelSession()
        {
            //Arrange
            var mockTest1 = new Mock<IMailHandler>();
            mockTest1.Setup(x => x.CancleSession("ryansknaggs@gmail.com", "1987621")).Returns("Message Sent Successfully");

            //Act
            string resultFalse = mockTest1.Object.CancleSession("ryansknaggs@gmail.com", "1987621");

            //Assert
            Assert.AreEqual("Message Sent Successfully", resultFalse);

        }

        [TestMethod]
        public void TestEmailHandlerJoinSession()
        {
            //Arrange
            var mockTest1 = new Mock<IMailHandler>();
            mockTest1.Setup(x => x.JoinSession("ryansknaggs@gmail.com", "1987621")).Returns("Message Sent Successfully");

            //Act
            string resultFalse = mockTest1.Object.JoinSession("ryansknaggs@gmail.com", "1987621");

            //Assert
            Assert.AreEqual("Message Sent Successfully", resultFalse);

        }

        [TestMethod]
        public void TestEmailHandlerCloseSession()
        {
            //Arrange
            var mockTest1 = new Mock<IMailHandler>();
            mockTest1.Setup(x => x.CloseSession("ryansknaggs@gmail.com", "1987621")).Returns("Message Sent Successfully");

            //Act
            string resultFalse = mockTest1.Object.CloseSession("ryansknaggs@gmail.com", "1987621");

            //Assert
            Assert.AreEqual("Message Sent Successfully", resultFalse);

        }
    }
}
