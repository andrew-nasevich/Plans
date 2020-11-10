using System;
using System.Collections.Generic;
using Plans.DomainModel.Users;

namespace Plans.DomainModel.Plans
{
    public class Plan
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string Name { get; set; }

        public ICollection<PlanPeriod> PlanPeriods { get; set; }

        public float Percentage { get; set; }

        public DateTime CreatingDateTime { get; set; }
    }
} 