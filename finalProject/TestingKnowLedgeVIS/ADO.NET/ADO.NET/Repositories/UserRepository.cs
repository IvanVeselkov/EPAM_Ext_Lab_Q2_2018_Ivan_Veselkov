using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.Models;
using System.Data.SqlClient;

namespace ADO.NET.Repositories
{
    public class UserRepository : BaseRepository<UserModel>
    {
        public override UserModel Get(int id)
        {
            UserModel User = new UserModel();
            string sql = string.Format("SELECT * FROM {0} WHERE Id=@IdParam", thisName);
            using (connect = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                connect.Open();
                command.Connection = connect;
                command.CommandText = sql;
                SqlParameter IdParam = new SqlParameter("@IdParam", id);
                command.Parameters.Add(IdParam);
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    User.UserId = (int)dr["ID"];
                    User.UserLogin = dr["UserLogin"].ToString();
                    User.UserPasswd = dr["UserPassWD"].ToString();
                    User.UserRole.Desc = dr["UserRole"].ToString();
                }
            }
            return User;
        }



        public override List<UserModel> GetAll()
        {
            List<UserModel> AllUsers = new List<UserModel>();
            string sql = string.Format("SELECT * FROM {0}s", thisName);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserModel User = new UserModel();
                        User.UserId = (int)reader["ID"];
                        User.UserLogin = reader["UserLogin"].ToString();
                        User.UserPasswd = reader["UserPassWD"].ToString();
                        User.UserRole.Desc = reader["UserRole"].ToString();
                        AllUsers.Add(User);
                    }
                }
                return AllUsers;
            }
        }

        public List<UserModel> GetAllUsers(int count)
        {
            List<UserModel> UsList = new List<UserModel>();
            using (connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetAllUsers";
                SqlParameter p = new SqlParameter("@k", count);
                cmd.Parameters.Add(p);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        UserModel US = new UserModel();
                        US.UserId = (int)reader["ID"];
                        US.UserLogin = reader["UserLogin"].ToString();
                        US.UserPasswd = reader["UserPassWD"].ToString();
                        US.UserRole.Desc = reader["UserRole"].ToString();
                        UsList.Add(US);
                    }
                }
            }
            return UsList;
        }
    }
}
