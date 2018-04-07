using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SQLHandler
{
    public interface ITutor
    {
        IDataReader GetTutor(string selectedTutor);

        IDataReader GetAllTutors();

    }
}
