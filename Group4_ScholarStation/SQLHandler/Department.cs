using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessControler
{
    class Department : IDepartment
    {
        private IDictionary<string, string> listOfDepartments;
        private IRead read;

        public Department()
        {
            this.listOfDepartments = new Dictionary<string, string>();
        }

        public IDictionary<string, string> GetDepartment()
        {
            string myCommand = "select * from department";
            SqlDataReader departmentList_dr = read.DataReader(myCommand);
            while (departmentList_dr.HasRows)
            {
                
                listOfDepartments.Add(departmentList_dr.GetValue(0).ToString(), departmentList_dr.GetValue(1).ToString());
            }
            return listOfDepartments;
        }
    }
}
