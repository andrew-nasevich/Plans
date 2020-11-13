using Microsoft.EntityFrameworkCore;
using Plans.DomainModel.Plans;
using Repositories;
using System.Linq;

namespace Plans.Repositories.Repositories
{
    public class PlanRepository : Repository<Plan>
    {
        public PlanRepository(DbContext context)
           : base(context)
        {

        }

        protected override IQueryable<Plan> GetAllQuery()
        {
            return GetQuery(p => p.User);
        }
    }
}