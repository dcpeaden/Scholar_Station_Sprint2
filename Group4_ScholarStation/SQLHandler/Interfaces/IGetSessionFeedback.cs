using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler.Interfaces
{
    public interface IGetSessionFeedback
    {
        IDataReader GetTutorFeedback(string sessionID);
        IDataReader GetStudentFeedback(string sessionID);
    }
}
