using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SQLHandler;
using SQLHandler.Interfaces;
using SQLHandler.QueryClasses;

namespace SQLHandlerUnitTest
{
    [TestClass]
    public class SQLUnitTest
    {
        [TestMethod]
        public void TestCancleSessionQuery()
        {
            //Arrange
            var mockTest1 = new Mock<ICreateSession>();
            mockTest1.Setup(x => x.IsSessionIDUnique(1234)).Returns(1234);

            //Act
            int sessionId = mockTest1.Object.IsSessionIDUnique(1234);

            //Assert
            Assert.AreEqual(1234, sessionId);
        }

        [TestMethod]
        public void TestCreateQuery()
        {
            //Arrange
            var mockTest1 = new Mock<ICreateUser>();
            mockTest1.Setup(x => x.Create_User("Ryan", "Knaggs", "ryansknaggs@gmail.com", "password")).Returns(true);

            //Act
            bool userCreated = mockTest1.Object.Create_User("Ryan", "Knaggs", "ryansknaggs@gmail.com", "password");

            //Assert
            Assert.AreEqual(true, userCreated);
        }

        [TestMethod]
        public void TestStudentFeedbackQuery()
        {
            //Arrange
            IGetSessionFeedback feedback = new GetSessionFeedback();

            //Act
            IDataReader returnedResults = feedback.GetStudentFeedback("7193");

            //Assert
            Assert.AreEqual("True" , returnedResults.Read().ToString());

        }

        public void TestTutorFeedbackQuery()
        {
            //Arrange
            IGetSessionFeedback feedback = new GetSessionFeedback();

            //Act
            IDataReader returnedResults = feedback.GetTutorFeedback("5101");

            //Assert
            Assert.AreEqual("True", returnedResults.Read().ToString());

        }

        public void TestGetCourseQuery()
        {
            //Arrange
            ICourse course = new QueryClass();

            //Act
            IDataReader returnedResults = course.GetCourse("MAT101");

            //Assert
            Assert.AreEqual("True", returnedResults.Read().ToString());

        }

        public void TestGetAllCourseQuery()
        {
            //Arrange
            ICourse course = new QueryClass();

            //Act
            IDataReader returnedResults = course.GetCourse("MAT101");

            //Assert
            Assert.AreEqual("True", returnedResults.Read().ToString());

        }

        public void TestCourseByProfessorQuery()
        {
            //Arrange
            ICourse course = new QueryClass();

            //Act
            IDataReader returnedResults = course.GetCourse("MAT101");

            //Assert
            Assert.AreEqual("True", returnedResults.Read().ToString());

        }

    }
}
