using System;

namespace Plans.DomainModel.Plans
{
    public class PlanPeriod
    {
        public int Id { get; set; }

        public int PlanId { get; set; }

        public Plan Plan { get; set; }

        public DateTime StartDay { get; set; }

        public int PeriodLength { get; set; }

        public bool IsRepeated { get; set; }

        public int? DaysGap { get; set; }

        public bool? StartOverEveryWeak { get; set; }
        
        public bool? IncludeWeekends { get; set; }
        
        public DateTime? FinishDayOfRepetition { get; set; }

    }
}