using System.Collections.Generic;
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

        /// <summary>
        /// To test the below querys, the database must contain the information that
        /// is being queryed. If things change and the test fail, then repopulate the 
        /// database with the queryed information to produce TRUE results.
        /// </summary>

        [TestMethod]
        public void TestStudentFeedbackQuery()
        {
            //Arrange
            IGetSessionFeedback feedback = new GetSessionFeedback();

            //Act
            IDataReader returnedResults = feedback.GetStudentFeedback("0");

            //Assert
            Assert.AreEqual("True" , returnedResults.Read().ToString());

        }

        [TestMethod]
        public void TestTutorFeedbackQuery()
        {
            //Arrange
            IGetSessionFeedback feedback = new GetSessionFeedback();

            //Act
            IDataReader returnedResults = feedback.GetTutorFeedback("0");

            //Assert
            Assert.AreEqual("True", returnedResults.Read().ToString());

        }

        [TestMethod]
        public void TestGetCourseQuery()
        {
            //Arrange
            ICourse course = new QueryClass();

            //Act
            IDataReader returnedResults = course.GetCourse("BUS");

            //Assert
            Assert.AreEqual("True", returnedResults.Read().ToString());

        }

        [TestMethod]
        public void TestGetAllCourseQuery()
        {
            //Arrange
            ICourse course = new QueryClass();
            //Act
            IDataReader returnedResults = course.GetAllCourses();
       
            //Assert
            Assert.AreEqual("True", returnedResults.Read().ToString());

        }

        [TestMethod]
        public void TestCourseByProfessorQuery()
        {
            //Arrange
            ICourse course = new QueryClass();

            //Act
            IDataReader returnedResults = course.GetCourseByProfessor("test");

            //Assert
            Assert.AreEqual("True", returnedResults.Read().ToString());

        }

        [TestMethod]
        public void TestGetDepartmentQuery()
        {
            //Arrange
            IDepartment department = new QueryDepartment();

            //Act
            IDataReader returnedResults = department.GetDepartment();

            //Assert
            Assert.AreEqual("True", returnedResults.Read().ToString());

        }

        [TestMethod]
        public void TestAvaliableSessionsQuery()
        {
            //Arrange
            ISessions avaliableSession = new QuerySessions();

            //Act
            IDataReader returnedResults = avaliableSession.GetAvailableSessions("testData");

            //Assert
            Assert.AreEqual("True", returnedResults.Read().ToString());

        }

        [TestMethod]
        public void TestGetTutorQuery()
        {
            //Arrange
            ITutor getTutor = new QueryTutor();

            //Act
            IDataReader returnedResults = getTutor.GetTutor("test");

            //Assert
            Assert.AreEqual("True", returnedResults.Read().ToString());

        }

        [TestMethod]
        public void TestGetAllTutorsQuery()
        {
            //Arrange
            ITutor getTutor = new QueryTutor();

            //Act
            IDataReader returnedResults = getTutor.GetAllTutors();

            //Assert
            Assert.AreEqual("True", returnedResults.Read().ToString());
        }

        [TestMethod]
        public void TestGetUserTypeQuery()
        {
            //Arrange
            IUserType getUserType = new QueryUserType();

            //Act
            IDataReader returnedResults = getUserType.GetUserType("testData", "testData");

            //Assert
            Assert.AreEqual("True", returnedResults.Read().ToString());
        }

        [TestMethod]
        public void TestSessionIDQuery()
        {
            //Arrange
            ISessionID getSessionId = new SessionID();

            //Act
            IList<string> returnedResults = getSessionId.GetSessionID("testData");

            //Assert
            Assert.AreEqual("0", returnedResults[0].ToString());
        }

        [TestMethod]
        public void TestCurrentSessionQuery()
        {
            //Arrange
            ViewCurrentSessions getCurrentSession = new ViewCurrentSessions();

            //Act
            IDataReader returnedResults = getCurrentSession.ViewCurrentSession("testData");

            //Assert
            Assert.AreEqual("True", returnedResults.Read().ToString());
        }

        [TestMethod]
        public void TestCurrentSessionStudentQuery()
        {
            //Arrange
            ViewCurrentSessions getCurrentSessionStudent = new ViewCurrentSessions();

            //Act
            IDataReader returnedResults = getCurrentSessionStudent.ViewCurrentSessionStudent("testData");

            //Assert
            Assert.AreEqual("True", returnedResults.Read().ToString());
        }

        [TestMethod]
        public void TestCurrentSessionStudentIDQuery()
        {
            //Arrange
            ViewCurrentSessions getCurrentSession = new ViewCurrentSessions();

            //Act
            IDataReader returnedResults = getCurrentSession.ViewCurrentSessionByID("0000");

            //Assert
            Assert.AreEqual("True", returnedResults.Read().ToString());
        }

    }
}
