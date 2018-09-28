using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ADO.NET.Models;
using System.Data.SqlClient;

namespace ADO.NET.Repositories
{
    public class AnswerRepository : BaseRepository<Answer>
    {
        public override Answer Get(int id)
        {
            Answer answer = new Answer();
            string sql = string.Format("SELECT * FROM Answers WHERE QuestID=@IdParam");
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
                        answer.ID = (int)dr["ID"];
                        answer.Description = dr["AnswerDescription"].ToString();
                        answer.Correct = (int)dr["Correct"];
                        answer.QuestID = (int)dr["QuestID"];
                    }
                }
            }
            return answer;
        }

        public override Answer Get(string desc)
        {
            Answer answer = new Answer();
            string sql = string.Format("SELECT * FROM Answers WHERE ID=@desc");
            using (connect = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                connect.Open();
                command.Connection = connect;
                command.CommandText = sql;
                SqlParameter IdParam = new SqlParameter("@desc", desc);
                command.Parameters.Add(IdParam);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        answer.ID = (int)dr["ID"];
                        answer.Description = dr["AnswerDescription"].ToString();
                        answer.Correct = (int)dr["Correct"];
                        answer.QuestID = (int)dr["QuestID"];
                    }
                }
            }
            return answer;
        }

        public List<Answer> GetAllWithQ(int QID)
        {
            List<Answer> AllAnswers = new List<Answer>();
            string sql = string.Format("SELECT * FROM Answers where QuestID=@QID");
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                connect.Open();
                cmd.Parameters.Add("@QID", QID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Answer answer = new Answer();
                        answer.ID = (int)reader["ID"];
                        answer.Description = reader["AnswerDescription"].ToString();
                        answer.Correct = (int)reader["Correct"];
                        answer.QuestID = (int)reader["QuestID"];
                        AllAnswers.Add(answer);
                    }
                }
            }
            return AllAnswers;
        }

        public override List<Answer> GetAll()
        {
            List<Answer> AllAnswers = new List<Answer>();
            string sql = string.Format("SELECT * FROM Answers");
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Answer answer = new Answer();
                        answer.ID = (int)reader["ID"];
                        answer.Description = reader["AnswerDescription"].ToString();
                        answer.Correct = (int)reader["Correct"];
                        answer.QuestID = (int)reader["QuestID"];
                        AllAnswers.Add(answer);
                    }
                }
                return AllAnswers;
            }
        }

        public override bool Save(Answer entity)
        {
            var query = string.Format("INSERT INTO Answers (ID,AnswerDescription,Correct,QuestID) VALUES (@ID,@Desc,@Correct,@QID)");
            using (connect = new SqlConnection(connectionString/*ConfigurationManager.ConnectionStrings.ToString()*/))
            {
                SqlCommand cmd = new SqlCommand();
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@ID", entity.ID);
                cmd.Parameters.AddWithValue("@Desc", entity.Description);
                cmd.Parameters.AddWithValue("@Correct", entity.Correct);
                cmd.Parameters.AddWithValue("@QID", entity.QuestID);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Error: can not create record", ex);
                    return false;
                }
                return true;
            }
        }

        public int GetCount()
        {
            string sql = string.Format("SELECT ID FROM Answers");
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
                return i;
            }
        
        }
    }
}