using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    class ApplicantJobApplicationRepository : BaseADO, IDataRepository<ApplicantJobApplicationRepository>
    {
        public void Add(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantJobApplicationPoco item in items)
                    {
                    cmd.CommandText = @"INSERT INTO"[dbo].[Applicant_Job_Applications];
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantJobApplicationRepository> GetAll(params Expression<Func<ApplicantJobApplicationRepository, object>>[] navigationProperties)
        {
            using (_connection) 
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "select * from Applicant_Educations";

                _connection.open();
                sqlDataReader reader = cmd.ExecuteReader();
                ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[1000];

                while (reader.Read())
                {
                    //check video 1.49
                }
            }
           
        }

        public IList<ApplicantJobApplicationRepository> GetList(Expression<Func<ApplicantJobApplicationRepository, bool>> where, params Expression<Func<ApplicantJobApplicationRepository, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantJobApplicationRepository GetSingle(Expression<Func<ApplicantJobApplicationRepository, bool>> where, params Expression<Func<ApplicantJobApplicationRepository, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params ApplicantJobApplicationRepository[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params ApplicantJobApplicationRepository[] items)
        {
            throw new NotImplementedException();
        }
    }
}
