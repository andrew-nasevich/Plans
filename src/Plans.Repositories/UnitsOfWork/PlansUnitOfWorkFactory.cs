using Microsoft.Extensions.Configuration;
using Plans.Repositories.DbContexts;
using Repositories.Interfaces;

namespace Plans.Repositories.UnitsOfWork
{
    public class PlansUnitOfWorkFactory
    {
        public IUnitOfWork CreateSchoolScheduleUnitOfWork(IConfiguration configuration)
        {
            var context = new PlansDbContext(configuration);

            return new PlansUnitOfWork(context);
        }
    }
}