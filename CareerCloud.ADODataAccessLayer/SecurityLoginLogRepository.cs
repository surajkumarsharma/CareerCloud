using CareerCloud.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    class SecurityLoginLogRepository : IDataRepository<SecurityLoginLogRepository>
    {
        public void Add(params SecurityLoginLogRepository[] items)
        {
            throw new NotImplementedException();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginLogRepository> GetAll(params Expression<Func<SecurityLoginLogRepository, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginLogRepository> GetList(Expression<Func<SecurityLoginLogRepository, bool>> where, params Expression<Func<SecurityLoginLogRepository, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginLogRepository GetSingle(Expression<Func<SecurityLoginLogRepository, bool>> where, params Expression<Func<SecurityLoginLogRepository, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params SecurityLoginLogRepository[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params SecurityLoginLogRepository[] items)
        {
            throw new NotImplementedException();
        }
    }
}
