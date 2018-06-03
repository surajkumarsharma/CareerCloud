using CareerCloud.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    class SecurityLoginLogRepository : IDataRepository<SecurityLoginLogPoco>
    {
        public void Add(params SecurityLoginLogPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginLogPoco> GetAll(params Expression<Func<SecurityLoginLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginLogPoco> GetList(Expression<Func<SecurityLoginLogPoco, bool>> where, params Expression<Func<SecurityLoginLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginLogPoco GetSingle(Expression<Func<SecurityLoginLogPoco, bool>> where, params Expression<Func<SecurityLoginLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params SecurityLoginLogPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params SecurityLoginLogPoco[] items)
        {
            throw new NotImplementedException();
        }
    }
}
