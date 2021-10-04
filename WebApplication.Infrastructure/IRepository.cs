using System.Collections.Generic;

namespace WebApplication.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Create(T obj);
        List<T> Get();
        List<T> Get(int id);
        T GetOne(int id);
        void Edit(T obj);
        void Delete(T obj);
    }
}
