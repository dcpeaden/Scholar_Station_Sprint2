using ScholarStation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace SQLHandler
{
    public interface ISQLHandler 
    {
        IDataReader GetDepartment();

        IDataReader GetCourse(string selectedDepartment);

        IDataReader GetTutor(string selectedTutor);

        IDataReader GetAvailableSessions(string email);

        void JoinSession(string userEmail, string sessionID);

        void CreateSession(string email, string date, string time, string length, string classes);

        IList<string> getSessionsID(string email);

        void CancelSessions(string cancelSession);

        IDataReader ViewCurrentSession(string email);

        IDataReader ViewCurrentSessionStudent(string email);

        IDataReader ViewCurrentSessionByID(string id);

    }
}
