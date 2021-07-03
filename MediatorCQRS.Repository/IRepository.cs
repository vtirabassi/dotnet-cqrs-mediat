
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MediatorCQRS.Repository
{
    public interface IRepository<T>
    {       
         Task<IEnumerable<T>> GetAll();

         Task<T> GetById(int id);

         Task Add(T item);

         Task Update(T item);

         Task Delete(int id);
    }
}