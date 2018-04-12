using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessControler
{
    public interface IUpdate
    {
        bool ExecuteQueries(string Query);
    }
}
