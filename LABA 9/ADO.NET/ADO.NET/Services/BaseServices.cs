using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.Repositories;

namespace ADO.NET.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : class, new()
    {
        public abstract bool Delete(int id);

        public abstract T Get(int id);

        public abstract List<T> GetAll();

        public abstract bool Save(T entity);
    }
}
