using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityRoleRepository : BaseADO, IDataRepository<SecurityRolePoco>
    {
        public void Add(params SecurityRolePoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                int rowEffected = 0;
                cmd.Connection = connection;
                foreach (SecurityRolePoco item in items)
                {
                    cmd.CommandText =
                        @"INSERT INTO [dbo].[Security_Roles]
                        ([Id],[Role],[Is_Inactive])
                        VALUES
                        (@ID, @Role, @Is_Inactive)";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Role", item.Role);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);

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

        public IList<SecurityRolePoco> GetAll(params System.Linq.Expressions.Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            SecurityRolePoco[] pocos = new SecurityRolePoco[1000];
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * from Security_Roles";

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    SecurityRolePoco poco = new SecurityRolePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Role = reader.GetString(1);
                    poco.IsInactive = reader.GetBoolean(2);

                    pocos[position] = poco;
                    position++;
                }
                connection.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<SecurityRolePoco> GetList(System.Linq.Expressions.Expression<Func<SecurityRolePoco, bool>> where, params System.Linq.Expressions.Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityRolePoco GetSingle(System.Linq.Expressions.Expression<Func<SecurityRolePoco, bool>> where, params System.Linq.Expressions.Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityRolePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();

        }

        public void Remove(params SecurityRolePoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (SecurityRolePoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM Security_Roles
                WHERE ID = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Update(params SecurityRolePoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (SecurityRolePoco poco in items)
                {
                    cmd.CommandText = @"UPDATE Security_Roles
                SET 
                Role = @Role,
                Is_Inactive = @Is_Inactive
                WHERE Id =@Id ";

                    cmd.Parameters.AddWithValue("@Role", poco.Role);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    connection.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
