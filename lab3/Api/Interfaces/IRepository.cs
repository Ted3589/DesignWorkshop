using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface IRepository<T>
    {
        T Create(T entity);
        IEnumerable<T> ReadAll();
        T Read(int id);        
        T Update(T entity);
        void Delete(T entity);
    }
}
