using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaFive0._2
{
    public interface IBaseService2<T> where T : class, new()
    {


        T Get(int id);

        List<T> GetAll();

        bool Save(T entity);

        bool Delete(int id);
    }

    public class Base<T> : IBaseService2<T> where T : class, new()
    {
        List<T> bd = new List<T>();



        public bool Delete(int id)
        {
            try
            {

                bd.RemoveAt(id);
                return true;
            }
            catch
            {
                Console.WriteLine("ERROR: can not delete an item");
                return false;
            }

        }

        public T Get(int id)
        {
            try
            {
                return bd[id];
            }
            catch
            {
                Console.WriteLine("ERROR: item search failed");
                return new T();
            }
        }

        public List<T> GetAll()
        {
            try
            {
                return bd;
            }
            catch
            {
                Console.WriteLine("ERROR: List not found");
                return new List<T>();
            }
        }

        public bool Save(T entity)
        {
            try
            {
                bd.Add(entity);
                return true;
            }
            catch
            {
                Console.WriteLine("ERROR: can not add item");
                return false;
            }
        }
    }
}
