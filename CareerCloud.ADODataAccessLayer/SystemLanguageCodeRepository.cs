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
    public class SystemLanguageCodeRepository : BaseADO, IDataRepository<SystemLanguageCodePoco>
    {
        public void Add(params SystemLanguageCodePoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                int rowEffected = 0;
                cmd.Connection = connection;
                foreach (SystemLanguageCodePoco item in items)
                {
                    cmd.CommandText =
                        @"INSERT INTO [dbo].[System_Language_Codes]
                        ([LanguageID],[Name],[Native_Name])
                        VALUES
                        (@LanguageID, @Name, @Native_Name)";

                    cmd.Parameters.AddWithValue("@LanguageID", item.LanguageID);
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    cmd.Parameters.AddWithValue("@Native_Name", item.NativeName);
                  
                    connection.Open();
                    rowEffected = cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            SystemLanguageCodePoco[] pocos = new SystemLanguageCodePoco[1000];
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * from System_Language_Codes";

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    SystemLanguageCodePoco poco = new SystemLanguageCodePoco();
                    poco.LanguageID = reader.GetString(0);
                    poco.Name = reader.GetString(1);
                    poco.NativeName = reader.GetString(2);

                    pocos[position] = poco;
                    position++;
                }
                connection.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<SystemLanguageCodePoco> GetList(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemLanguageCodePoco GetSingle(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemLanguageCodePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();

        }

        public void Remove(params SystemLanguageCodePoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (SystemLanguageCodePoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM System_Language_Codes
                WHERE LanguageID = @LanguageID";
                    cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageID);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }

        public void Update(params SystemLanguageCodePoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (SystemLanguageCodePoco poco in items)
                {
                    cmd.CommandText = @"UPDATE System_Language_Codes
                SET 
                Name = @Name,
                Native_Name = @Native_Name
                WHERE LanguageID =@LanguageId ";

                    cmd.Parameters.AddWithValue("@Name", poco.Name);
                    cmd.Parameters.AddWithValue("@Native_Name", poco.NativeName);
                    cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageID);

                    connection.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }
    }
}
