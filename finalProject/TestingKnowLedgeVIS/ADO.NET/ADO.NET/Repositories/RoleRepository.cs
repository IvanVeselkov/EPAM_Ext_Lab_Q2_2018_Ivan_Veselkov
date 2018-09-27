using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADO.NET.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace ADO.NET.Repositories
{
    public class RoleRepository : BaseRepository<Role>
    {
        public override Role Get(int id)
        {
            Role role = new Role();
            string str = String.Format("select RoleDescription from Roles where ID = @IdParam");
            using (connect = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                connect.Open();
                command.Connection = connect;
                command.CommandText = str;
                SqlParameter IdParam = new SqlParameter("@IdParam", id);
                command.Parameters.Add(IdParam);
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    role.Desc = dr["RoleDescription"].ToString();
                }
            }
            return role;
        }

        public override Role Get(string login)
        {
            throw new NotImplementedException();
        }

        public override List<Role> GetAll()
        {
            List<Role> AllRoles = new List<Role>();
            string sql = string.Format("SELECT * FROM Roles");
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Role role = new Role();
                        role.Desc = reader["RoleDescription"].ToString();
                        AllRoles.Add(role);
                    }
                }
            }
            return AllRoles;
        }

        public override bool Save(Role entity)
        {
            var query = string.Format("INSERT INTO ROles (ID,RoleDescription) VALUES (@ID,@Desc)");
            using (connect = new SqlConnection(ConfigurationManager.ConnectionStrings.ToString()))
            {
                SqlCommand cmd = new SqlCommand();
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@ID", entity.ID);
                cmd.Parameters.AddWithValue("@Desc", entity.Desc);
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
            string sql = string.Format("SELECT ID FROM Roles");
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                connect.Open();
                int i = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    i++;
                }
                return i;
            }
        }
    }
}