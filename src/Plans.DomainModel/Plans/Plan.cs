using System;
using System.Collections.Generic;
using Plans.DomainModel.Interfaces;

namespace Plans.DomainModel.Plans
{
    public class Plan
        : IPlan
    {
        public int Id { get; set; }

        public IUser User { get; set; }

        public string Name { get; set; }

        public IPlanPeriod PlanPeriod { get; set; }

        public float Percentage { get; set; }

        public DateTime CreatingDateTime { get; set; }
    }
} 