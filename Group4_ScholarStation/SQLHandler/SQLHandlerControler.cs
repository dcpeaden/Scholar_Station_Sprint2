using System;
using System.Collections.Generic;
using System.Data;
using ScholarStation;
using SQLHandler.Interfaces;
using SQLHandler.QueryClasses;

namespace SQLHandler
{
    public class SQLHandlerControler : ISQLHandler
    {

        private ISessions session;
        private ICourse course;
        private ITutor tutor;
        private IDepartment department;
        private IJoinSession joinSession;
        private ICreateSession creteNewSession;
        private ISessionID sessionIDs;
        private IViewCurrentSessions viewSessions;
        private ICancelSession cancelSession;
        private IUserType userType;
        private ILeaveSessionFeedback feedback;
        private ICreateUser createUser;

        public SQLHandlerControler()
        {
            this.session = new QuerySessions();
            this.course = new QueryClass();
            this.tutor = new QueryTutor();
            this.department = new QueryDepartment();
            this.joinSession = new JoinSessions();
            this.creteNewSession = new CreateSession();
            this.sessionIDs = new SessionID();
            this.viewSessions = new ViewCurrentSessions();
            this.cancelSession = new CancelSessions();
            this.userType = new QueryUserType();
            this.feedback = new AddSessionFeedback();
            this.createUser = new CreateUser();
        }

        public IDataReader GetAllCourses()
        {
            return course.GetAllCourses();
        }


        public IDataReader GetAvailableSessions(string email)
        {
            return session.GetAvailableSessions(email);
        }

        public IDataReader GetCompletedSessionsByCourse(string courseNum)
        {
            return session.GetCompletedSessionsByCourse(courseNum);
        }

        public IDataReader GetCourse(string selectedDepartment)
        {
            return course.GetCourse(selectedDepartment);
        }

        public IDataReader GetCourse()
        {
            throw new NotImplementedException();
        }

        public IDataReader GetCourseByProfessor(string email)
        {
            return course.GetCourseByProfessor(email);
        }

        public IDataReader GetDepartment()
        {
            return department.GetDepartment();
        }

        public IDataReader GetTutor(string selectedClass)
        {
            return tutor.GetTutor(selectedClass);
        }

        public IDataReader GetAllTutors()
        {
            return tutor.GetAllTutors();
        }

        public void JoinSession(string userEmail, string sessionID)
        {
            joinSession.JoinSession(userEmail, sessionID);
        }

        public void CreateSession(string email, string date, string time, string length, string classes)
        {
            creteNewSession.AddNewSession(email, date, time, length, classes);
        }

        public IList<string> getSessionsID(string email)
        {
           return sessionIDs.GetSessionID(email);
        }

        public void CancelSessions(string cancel)
        {
            cancelSession.CancelSession(cancel);
        }

        public IDataReader ViewCurrentSession(string email)
        {
            return viewSessions.ViewCurrentSession(email);
        }

        public IDataReader ViewCurrentSessionStudent(string email)
        {
            return viewSessions.ViewCurrentSessionStudent(email);
        }

        public IDataReader ViewCurrentSessionByID(string id)
        {
            return viewSessions.ViewCurrentSessionByID(id);
        }

        public IDataReader GetUserType(string email, string password)
        {
            return userType.GetUserType(email, password);
        }

        public void LeaveSessionFeedback(string email, string sessionID, string feedBack)
        {
            feedback.LeaveFeedback(email, sessionID, feedBack);
        }

        public bool CreateAccout(string firstName, string lastName, string email, string password)
        {
            return createUser.Create_User(firstName, lastName, email, password);
        }
    }
}
