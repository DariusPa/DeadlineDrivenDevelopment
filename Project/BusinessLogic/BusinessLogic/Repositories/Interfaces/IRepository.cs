using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IList<T> Get();
        T GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
    }
}