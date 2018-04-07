﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessControler;

namespace SQLHandler
{
    class QueryClass : ICourse
    {
        private IRead read;

        public QueryClass()
        {
            this.read = new ConnectionControler();
        }


        public IDataReader GetAllCourses()
        {
            string myCommand = "select course from course";
            SqlDataReader listOfCourses_dr = read.DataReader(myCommand);
            return listOfCourses_dr;
        }

        public IDataReader GetCourse(string selectedDepartment)
        {
            string myCommand = "select * from course where cr_dept_id = '" + selectedDepartment + "'";
            SqlDataReader listOfCourses_dr = read.DataReader(myCommand);
            return listOfCourses_dr;
        }
    }
}
