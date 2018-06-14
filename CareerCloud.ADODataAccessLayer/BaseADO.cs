using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public abstract class BaseADO 
    {
        protected readonly string _connectionString;
        public BaseADO()
            {
            _connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            }

    }
}
