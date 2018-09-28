using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ADO.NET.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace ADO.NET.Repositories
{
    public class QuestRepository : BaseRepository<Quest>
    {
        public override Quest Get(int id)
        {
            Quest quest = new Quest();
            string sql = string.Format("SELECT * FROM Questions WHERE ID=@IdParam");
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
                        quest.ID = (int)dr["ID"];
                        quest.Description = dr["QuestDescription"].ToString();
                        quest.TestID = (int)dr["TestID"];
                    }
                }
            }
            return quest;
        }

        public override Quest Get(string desc)
        {
            Quest quest = new Quest();
            string sql = string.Format("SELECT * FROM Questions WHERE QuestDescription=@Desc");
            using (connect = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                connect.Open();
                command.Connection = connect;
                command.CommandText = sql;
                SqlParameter IdParam = new SqlParameter("@Desc",desc);
                command.Parameters.Add(IdParam);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        quest.ID = (int)dr["ID"];
                        quest.Description = dr["QuestDescription"].ToString();
                        quest.TestID = (int)dr["TestID"];
                    }
                }
            }
            return quest;
        }

        public string GetQuestionText(int questionId, int testId)
        {
            string sql = String.Format("select QuestDescription from Questions where ID=@QID and TestID=@TID");
            using (connect = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connect;
                command.CommandText = string.Format(sql);
                command.Parameters.Add("@QID", questionId);
                command.Parameters.Add("@TID", testId);
                connect.Open();
                SqlDataReader reader = command.ExecuteReader();
                string qText = string.Empty;
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    return Convert.ToString(values[0]);
                }
                connect.Close();
                return qText;

            }
        }

        public Quest GetQuestion(int testId, int questionId)
        {
            Quest q = new Quest();
            string sql = String.Format("select * from Questions where ID=@QID and TestID=@TID");
            using (connect = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connect;
                command.CommandText = string.Format(sql);
                command.Parameters.Add("@QID", questionId);
                command.Parameters.Add("@TID", testId);
                connect.Open();
                SqlDataReader reader = command.ExecuteReader();
                string qText = string.Empty;
                while (reader.Read())
                {
                    q.ID = (int)reader["ID"];
                    q.Description = reader["QuestDescription"].ToString();
                    q.TestID = (int)reader["TestID"];
                }
                return q;
            }
        }

        public List<Quest> GetQuestionList(int testId)
        {
            List<Quest> AllQuest = new List<Quest>();
            string sql = string.Format("SELECT * FROM Questions where TestID=@TID");
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                connect.Open();
                cmd.Parameters.Add("@TID", testId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Quest quest = new Quest();
                        quest.ID = (int)reader["ID"];
                        quest.Description = reader["QuestDescription"].ToString();
                        quest.TestID = (int)reader["TestID"];
                        AllQuest.Add(quest);
                    }
                }
                return AllQuest;
            }
        }

        public override List<Quest> GetAll()
        {
            List<Quest> AllQuest = new List<Quest>();
            string sql = string.Format("SELECT * FROM Questions");
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Quest quest = new Quest();
                        quest.ID = (int)reader["ID"];
                        quest.Description = reader["QuestDescription"].ToString();
                        quest.TestID = (int)reader["TestID"];
                        AllQuest.Add(quest);
                    }
                }
                return AllQuest;
            }
        }

        public override bool Save(Quest entity)
        {
            var query = string.Format("INSERT INTO Questions (ID,QuestDescription,TestID) VALUES (@ID,@Desc,@TID)");
            using (connect = new SqlConnection(connectionString/*ConfigurationManager.ConnectionStrings.ToString()*/))
            {
                SqlCommand cmd = new SqlCommand();
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@ID", entity.ID);
                cmd.Parameters.AddWithValue("@Desc", entity.Description);
                cmd.Parameters.AddWithValue("@TID", entity.TestID);
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
            string sql = string.Format("SELECT ID FROM Questions");
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