using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace ADO.NET.Repositories
{
    public class UserRepository : BaseRepository<UserModel>
    {
        public override UserModel Get(int id)
        {
            UserModel @User = new UserModel();
            string sql = string.Format("SELECT * FROM Users WHERE ID=@IdParam");
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
                        @User.UserId = (int)dr["ID"];
                        @User.UserLogin = dr["UserLogin"].ToString();
                        @User.UserPasswd = dr["UserPassWD"].ToString();
                        Role role = new Role();
                        role.Desc = dr["UserRole"].ToString();
                        @User.UserRole = role;
                    }
                }
            }
            return User;
        }

        public override UserModel Get(string login)
        {
            UserModel User = new UserModel();
            string sql = string.Format("SELECT * FROM Users WHERE UserLogin=@LoginParam", thisName);
            using (connect = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                connect.Open();
                command.Connection = connect;
                command.CommandText = sql;
                SqlParameter IdParam = new SqlParameter("@LoginParam", login);
                command.Parameters.Add(IdParam);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        User.UserId = (int)dr["ID"];
                        User.UserLogin = dr["UserLogin"].ToString();
                        User.UserPasswd = dr["UserPassWD"].ToString();
                        Role role = new Role();
                        role.Desc = dr["UserRole"].ToString();
                        User.UserRole = role;
                    }
                }
            }
            return User;
        }

        public override List<UserModel> GetAll()
        {
            List<UserModel> AllUsers = new List<UserModel>();
            string sql = string.Format("SELECT * FROM Users", thisName);
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
                        Role role = new Role();
                        role.Desc = reader["UserRole"].ToString();
                        User.UserRole = role;
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
                        Role role = new Role();
                        role.Desc = reader["UserRole"].ToString();
                        US.UserRole = role;
                        UsList.Add(US);
                    }
                }
            }
            return UsList;
        }

        public override bool Save(UserModel entity)
        {
            var query = string.Format("INSERT INTO Users (ID,UserLogin,UserPassWD,UserRole) VALUES (@UserID,@UserLogin,@UserPassWD,@UserRole)");
            using (connect = new SqlConnection(connectionString/*ConfigurationManager.ConnectionStrings.ToString()*/))
            {
                SqlCommand cmd = new SqlCommand();
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@UserID", entity.UserId);
                cmd.Parameters.AddWithValue("@UserLogin", entity.UserLogin);
                cmd.Parameters.AddWithValue("@UserPassWD", entity.UserPasswd);
                cmd.Parameters.AddWithValue("@UserRole", entity.UserRole.DescInt);
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
            string sql = string.Format("SELECT ID FROM Users");
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
