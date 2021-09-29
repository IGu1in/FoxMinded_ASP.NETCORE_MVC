using System.Collections.Generic;

namespace WebApplication.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T obj);
        T Get();
        T Get(int id);
        void Edit(T obj);
        void Delete(T obj);
    }
}
