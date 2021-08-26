using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.DataAccess.Queries
{
    public interface IGenericQueries<T> where T : class
    {
        Task Add(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetOne(int id);
    }
}