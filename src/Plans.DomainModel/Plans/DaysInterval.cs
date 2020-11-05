using Plans.DomainModel.Interfaces;
using System;

namespace Plans.DomainModel.Plans
{
    public class PlanPeriod
        : IPlanPeriod
    {
        public int Id { get; set; }

        public DateTime StartDay { get; set; }

        public int PeriodLength { get; set; }

        public bool IsRepeated { get; set; }

        public int? DaysGap { get; set; }

        public bool? StartOverEveryWeak { get; set; }
        
        public bool? IncludeWeekends { get; set; }
        
        public DateTime? FinishDayOfRepetition { get; set; }

    }
}