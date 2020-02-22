using System.Collections.Generic;

namespace BusinessLogic.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IList<T> Get();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
    }
}