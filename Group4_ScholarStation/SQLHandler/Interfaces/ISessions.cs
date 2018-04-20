using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler
{
    public interface ISessions
    {
        IDataReader GetAvailableSessions(string StudentEmail);
        IDataReader GetCompletedSessionsByCourse(string courseNum);
    }
}
