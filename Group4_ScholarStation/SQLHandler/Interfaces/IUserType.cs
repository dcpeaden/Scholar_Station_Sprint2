using ScholarStation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler.Interfaces
{
    interface IUserType
    {
        IDataReader GetUserType(string email);
    }
}
