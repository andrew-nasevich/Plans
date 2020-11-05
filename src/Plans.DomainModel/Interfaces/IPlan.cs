using System;


namespace Plans.DomainModel.Interfaces
{
    public interface IPlan
    {
        public int Id { get; set; }

        public IUser User { get; set; }

        public string Name { get; set; }

        public IPlanPeriod PlanPeriod { get; set; }

        public float Percentage { get; set; }

        public DateTime CreatingDateTime { get; set; }

    }
}