﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ADO.NET.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    { 
        public SqlConnection connect = null;
        public string thisName = typeof(T).Name;
        public string connectionString;
        public BaseRepository()
        {
            connectionString = "Data Source=ASUS\\IVANSQLSERVER;Initial Catalog=TestingBase;Integrated Security=True";//ConfigurationManager.ConnectionStrings.ToString();
            connect = new SqlConnection(connectionString);
        }

        public abstract T Get(int id);


        public abstract List<T> GetAll();


        abstract public bool Save(T entity);
        

        public bool Delete(int id)
        {
            string sqlExpression = string.Format("DELETE  FROM '{0}' WHERE ID='{1}'", thisName, id);
            using (connect = new SqlConnection(connectionString))//(SqlCommand cmd = new SqlCommand(sqlExpression, this.connect))
            {
                SqlCommand cmd = new SqlCommand();
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = sqlExpression;
                int numberOfUpdate = cmd.ExecuteNonQuery();
                if (numberOfUpdate > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        //public List<string> GetPropertiesNames(T model)
        //{
        //    List<string> listOfNames = new List<string>();
        //    foreach (var item in model.GetType().GetProperties())
        //    {
        //        if (item.Name != "ID")
        //            listOfNames.Add(item.Name);
        //    }
        //    return listOfNames;
        //}


        //public List<string> GetPropertiesValues(T model)
        //{
        //    List<string> listOfValues = new List<string>();
        //    foreach (var item in model.GetType().GetProperties())
        //    {
        //        if (item.Name != "ID")
        //        {
        //            listOfValues.Add(item.GetValue(model).ToString());
        //        }
        //    }
        //    return listOfValues;
        //}

        abstract public T Get(string login);
       
    }
}