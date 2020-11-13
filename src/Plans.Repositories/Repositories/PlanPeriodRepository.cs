using Microsoft.EntityFrameworkCore;
using Plans.DomainModel.Plans;
using Repositories;
using System.Linq;

namespace Plans.Repositories.Repositories
{
    public class PlanPeriodRepository : Repository<PlanPeriod>
    {
        public PlanPeriodRepository(DbContext context)
           : base(context)
        {

        }

        protected override IQueryable<PlanPeriod> GetAllQuery()
        {
            return GetQuery(pp => pp.Plan);
        }
    }
}