using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork, IDisposable
        where TContext : DbContext
    {
        protected bool disposed;

        protected readonly TContext Context;

        private readonly IDictionary<Type, object> _repositories;
        

        public UnitOfWork(TContext context) 
        {
            Context = context;
            _repositories = new Dictionary<Type, object>();
        }


        public IRepository<T> GetRepository<T>() where T : class
        {
            if(!_repositories.TryGetValue(typeof(T), out var repository))
            {
                repository = CreateRepository<T>();
                _repositories.Add(typeof(T), repository);
            }

            return (IRepository<T>)repository;
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        ~UnitOfWork() 
        {
            Dispose(false);
        }


        public void Dispose()
        {
            Dispose(true);
        }


        protected virtual void Dispose(bool disposing)
        {
            if(disposed)
            {
                return;
            }
            if(disposing)
            {
                Context.Dispose();
            }
            disposed = true;
        }

        protected virtual IRepository<T> CreateRepository<T>() where T : class
        {
            return new Repository<T>(Context);
        }
    }
}