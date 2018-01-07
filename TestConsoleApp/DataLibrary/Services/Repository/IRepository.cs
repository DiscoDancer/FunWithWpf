using System.Collections.Generic;

namespace DataLibrary.Services.Repository
{
    public interface IRepository<T> where T: class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
    }
}
