using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Repositories
{
    public interface IBaseRepository<T> : IDisposable where T : class, new()
    {
        T Get(int id);

        T Get(string login);

        List<T> GetAll();

        bool Save(T entity);

        bool Delete(int id);
    }
}
