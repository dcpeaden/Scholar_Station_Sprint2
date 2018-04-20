using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler
{
    public interface ICourse
    {
        IDataReader GetCourse(string selectedDepartment);

        IDataReader GetAllCourses();

        IDataReader GetCourseByProfessor(string email);
    }
}
