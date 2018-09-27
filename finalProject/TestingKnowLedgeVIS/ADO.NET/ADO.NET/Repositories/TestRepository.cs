using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.Models;
using System.Data.SqlClient;


namespace ADO.NET.Repositories
{
    public class TestRepository : BaseRepository<Test>
    {
        public override Test Get(int id)
        {
            Test test = new Test();
            string sql = string.Format("SELECT * FROM Tests WHERE ID=@IdParam");
            using (connect = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                connect.Open();
                command.Connection = connect;
                command.CommandText = sql;
                SqlParameter IdParam = new SqlParameter("@IdParam", id);
                command.Parameters.Add(IdParam);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        test.ID = (int)dr["ID"];
                        test.Description = dr["TestDescription"].ToString();
                        test.Subject = dr["TestSubject"].ToString();
                        //test.Complexity = (int)dr["TestComplexity"];
                    }
                }
                connect.Close();
            }
            return test;
        }

        public override Test Get(string Description)
        {
            Test test = new Test();
            string sql = string.Format("SELECT * FROM Tests WHERE TestDescription=@Description");
            using (connect = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                connect.Open();
                command.Connection = connect;
                command.CommandText = sql;
                SqlParameter IdParam = new SqlParameter("@Description", Description);
                command.Parameters.Add(IdParam);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        test.ID = (int)dr["ID"];
                        test.Description = dr["TestDescription"].ToString();
                        test.Subject = dr["TestSubject"].ToString();
                        //test.Complexity = (int)dr["TestComplexity"];
                    }
                }
                connect.Close();
            }
            return test;
        }

        public override List<Test> GetAll()
        {
            List<Test> AllTests = new List<Test>();
            string sql = string.Format("SELECT * FROM Tests", thisName);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Test test = new Test();
                        test.ID = (int)reader["ID"];
                        test.Description = reader["TestDescription"].ToString();
                        test.Subject = reader["TestSubject"].ToString();
                        //test.Complexity = (int)reader["TestComplexity"];
                        AllTests.Add(test);
                    }
                }
                connect.Close();
                return AllTests;
            }
        }

        public override bool Save(Test entity)
        {
            var query = string.Format("INSERT INTO Tests (ID,TestDescription,TestSubject,TestComplexity) VALUES (@ID,@Desc,@Subj,@Compl)");
            using (connect = new SqlConnection(connectionString/*ConfigurationManager.ConnectionStrings.ToString()*/))
            {
                SqlCommand cmd = new SqlCommand();
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@ID", entity.ID);
                cmd.Parameters.AddWithValue("@Desc", entity.Description);
                cmd.Parameters.AddWithValue("@Subj", entity.Subject);
                //cmd.Parameters.AddWithValue("@Compl", entity.Complexity);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Error: can not create record", ex);
                    return false;
                }
                connect.Close();
                return true;
            }
        }

        public int GetCount()
        {
            string sql = string.Format("SELECT ID FROM Tests");
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                connect.Open();
                int i = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        i++;
                    }
                }
                connect.Close();
                return i;
            }
        }
        


    }
}
