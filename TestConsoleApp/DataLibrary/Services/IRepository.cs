using System.Collections.Generic;

namespace DataLibrary.Services
{
    public interface IRepository<T> where T: class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        List<T> GetAll();
    }
}
