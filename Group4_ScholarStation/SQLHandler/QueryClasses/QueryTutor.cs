using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessControler;

namespace SQLHandler
{
    class QueryTutor : ITutor
    {
        private IRead read;

        public QueryTutor()
        {
            this.read = new ConnectionControler();
        }

        public IDataReader GetAllTutors()
        {
            string myCommand = "select * from tutors";
            SqlDataReader tutorList_dr = read.DataReader(myCommand);
            return tutorList_dr;
        }

        public IDataReader GetTutor(string selectedClass)
        {
            string myCommand = "select * from tutors where tutor_cr_num = '" + selectedClass + "'";
            SqlDataReader tutorList_dr = read.DataReader(myCommand);
            return tutorList_dr;
        }
    }
}
