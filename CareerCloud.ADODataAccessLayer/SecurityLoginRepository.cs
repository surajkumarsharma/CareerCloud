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
    public class SecurityLoginRepository : BaseADO, IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                int rowEffected = 0;
                cmd.Connection = connection;
                foreach (SecurityLoginPoco item in items)
                {
                    cmd.CommandText =
                        @"INSERT INTO [dbo].[Security_Logins]
                        ([Id], [Login], [Password], [Created_Date], [Password_Update_Date], [Agreement_Accepted_Date], [Is_Locked], 
                        [Is_Inactive], [Email_Address], [Phone_Number], [Full_Name], [Force_Change_Password], [Prefferred_Language])
                       
                        VALUES
                        (@Id, @Login, @Password, @Created_Date, @Password_Update_Date, @Agreement_Accepted_Date, @Is_Locked, 
                        @Is_Inactive, @Email_Address, @Phone_Number, @Full_Name, @Force_Change_Password, @Prefferred_Language)";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Password", item.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", item.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);

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

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            SecurityLoginPoco[] pocos = new SecurityLoginPoco[1000];
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * from Security_Logins";

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    SecurityLoginPoco poco = new SecurityLoginPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Login = reader.GetString(1);
                    poco.Password = reader.GetString(2);
                    poco.Created = reader.GetDateTime(3);
                    poco.PasswordUpdate = (reader[4] == DBNull.Value) ? (DateTime?)null: reader.GetDateTime(4);
                    poco.AgreementAccepted = (reader[5] == DBNull.Value) ? (DateTime?)null : reader.GetDateTime(5);
                    poco.IsLocked = reader.GetBoolean(6);                    
                    poco.IsInactive = (bool)reader[7];
                    poco.EmailAddress = reader.GetString(8);
                    poco.PhoneNumber = (reader[9] == DBNull.Value) ? null: reader.GetString(9);
                    poco.FullName = (reader[10] == DBNull.Value) ? null : reader.GetString(10);
                    poco.ForceChangePassword = reader.GetBoolean(11);
                    poco.PrefferredLanguage = (reader[12] == DBNull.Value)? null: reader.GetString(12);
                    poco.TimeStamp = (byte[])reader[13];

                    pocos[position] = poco;
                    position++;
                }
                connection.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (SecurityLoginPoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM Security_Logins
                WHERE ID = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }

        public void Update(params SecurityLoginPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (SecurityLoginPoco poco in items)
                {
                    cmd.CommandText = @"UPDATE Security_Logins
                SET 
                Login = @Login,
                Password = @Password,
                Created_Date = @Created_Date,
                Password_Update_Date = @Password_Update_Date,
                Agreement_Accepted_Date = @Agreement_Accepted_Date,
                Is_Locked = @Is_Locked,
                Is_Inactive = @Is_Inactive,
                Email_Address = @Email_Address,
                Phone_Number = @Phone_Number,
                Full_Name = @Full_Name,
                Force_Change_Password = @Force_Change_Password,
                Prefferred_Language = @Prefferred_Language
                WHERE Id =@Id ";

                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Password", poco.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", poco.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", poco.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", poco.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", poco.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    connection.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
