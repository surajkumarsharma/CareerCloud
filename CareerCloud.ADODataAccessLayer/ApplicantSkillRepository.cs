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
    public class ApplicantSkillRepository : BaseADO, IDataRepository<ApplicantSkillPoco>
    {
        public void Add(params ApplicantSkillPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                int rowEffected = 0;
                cmd.Connection = connection;
                foreach (ApplicantSkillPoco item in items)
                {
                    cmd.CommandText =
                    @"INSERT INTO [dbo].[Applicant_Skills]
                        ([Id],[Applicant],[Skill],[Skill_Level],[Start_Month],[Start_Year],[End_Month],[End_Year])
                        VALUES
                        (@ID, @Applicant, @Skill, @Skill_Level, @Start_Month, @Start_Year, @End_Month, @End_Year)";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Skill", item.Skill);
                    cmd.Parameters.AddWithValue("@Skill_Level", item.SkillLevel);
                    cmd.Parameters.AddWithValue("@Start_Month", item.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", item.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", item.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", item.EndYear);

                    connection.Open();
                    rowEffected += cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            ApplicantSkillPoco[] pocos = new ApplicantSkillPoco[1000];
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * from Applicant_Skills";

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    ApplicantSkillPoco poco = new ApplicantSkillPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Skill = reader.GetString(2);
                    poco.SkillLevel = reader.GetString(3);
                    poco.StartMonth = (byte)reader[4];
                    poco.StartYear = reader.GetInt32(5);
                    poco.EndMonth = (byte)reader[6];
                    poco.EndYear = reader.GetInt32(7);
                    poco.TimeStamp = (byte[])reader[8];

                    pocos[position] = poco;
                    position++;
                }
                connection.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<ApplicantSkillPoco> GetList(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantSkillPoco GetSingle(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantSkillPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantSkillPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (ApplicantSkillPoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM Applicant_Skills
                WHERE ID = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Update(params ApplicantSkillPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (ApplicantSkillPoco poco in items)
                {
                    cmd.CommandText = @"UPDATE Applicant_SkillS
                SET 
                Applicant = @Applicant,
                Skill = @Skill,
                Skill_Level = @Skill_Level,
                Start_Month = @Start_Month,
                Start_Year = @Start_Year,
                End_Month = @End_Month,
                End_Year = @End_Year
                WHERE Id =@Id ";

                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Skill", poco.Skill);
                    cmd.Parameters.AddWithValue("@Skill_Level", poco.SkillLevel);
                    cmd.Parameters.AddWithValue("@Start_Month", poco.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", poco.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", poco.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", poco.EndYear);
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    connection.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}

