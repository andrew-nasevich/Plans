using Plans.DomainModel.Plans;
using Plans.Repositories.DbContexts;
using Plans.Repositories.Repositories;
using Repositories;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace Plans.Repositories.UnitsOfWork
{
    public class PlansUnitOfWork: UnitOfWork<PlansDbContext>
    {
        private readonly IDictionary<Type, Type> _repositoriesMapping;


        public PlansUnitOfWork(PlansDbContext context)
            :base(context)
        {
            _repositoriesMapping = new Dictionary<Type, Type>()
            {
                { typeof(Plan), typeof(PlanRepository) },
                { typeof(PlanPeriod), typeof(PlanPeriodRepository) }
            };
        }


        protected override IRepository<T> CreateRepository<T>()
        {
            if(_repositoriesMapping.TryGetValue(typeof(T), out var repositoryType))
            {
                return (IRepository<T>) Activator.CreateInstance(repositoryType, Context);
            }

            return base.CreateRepository<T>();
        }
    }
}