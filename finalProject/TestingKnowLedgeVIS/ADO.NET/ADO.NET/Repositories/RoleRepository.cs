using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADO.NET.Models;
using System.Data.SqlClient;

namespace ADO.NET.Repositories
{
    public class RoleRepository : BaseRepository<Role>
    {
        public override Role Get(int id)
        {
            Role role = new Role();
            string str = String.Format("select RoleDescription from {1} where RoleID = @IdParam", thisName);
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

        public override List<Role> GetAll()
        {
            List<Role> AllRoles = new List<Role>();
            string sql = string.Format("SELECT * FROM {0}s", thisName);
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
    }
}