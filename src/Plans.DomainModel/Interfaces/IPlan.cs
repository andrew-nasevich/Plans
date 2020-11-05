using System;
using System.Collections.Generic;
using Plans.DomainModel.Users;

namespace Plans.DomainModel.Interfaces
{
    public interface IPlan
    {
        public int Id { get; set; }

        public IUser User { get; set; }

        public string Name { get; set; }

        public IReadOnlyCollection<IDaysInterval> DaysIntervals { get; set; }

        public float Percentage { get; set; }

        public DateTime CreatingTime { get; set; }

        public DateTime FinishingTime { get; set; }
    }
}