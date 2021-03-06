﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyCollection<T>> GetAllAsync();

        Task<T> GetByIdAsync(object id);

        Task<IReadOnlyCollection<T>> WhereAsync(Expression<Func<T, bool>> predecate);

        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);
    }
}