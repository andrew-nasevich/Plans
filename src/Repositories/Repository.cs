using Microsoft.EntityFrameworkCore;
using Plans.Repositories.DbContexts;
using Plans.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PlansDbContext _dbContext;
        private readonly DbSet<T> _entities;


        public Repository(PlansDbContext dbContext) 
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<T>();
        }


        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _entities.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _entities.Attach(entity);
            _entities.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<IReadOnlyCollection<T>> WhereAsync(Expression<Func<T, bool>> predecate)
        {
            return await _entities.Where(predecate).ToListAsync();
        }
    }
}