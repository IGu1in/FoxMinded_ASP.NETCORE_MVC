﻿using System.Collections.Generic;

namespace WebApplication.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T obj);
        List<T> Get();
        void Edit(T obj);
        void Delete(T obj);
    }
}
