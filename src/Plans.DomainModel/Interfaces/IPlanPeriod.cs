using System;

namespace Plans.DomainModel.Interfaces
{
    public interface IPlanPeriod
    {
        int Id { get; set; }

        DateTime StartDay { get; set; }

        int PeriodLength { get; set; }

        bool IsRepeated { get; set; }

        int? DaysGap { get; set; }

        bool? StartOverEveryWeak { get; set; }

        bool? IncludeWeekends { get; set; }

        DateTime? FinishDayOfRepetition { get; set; }

    }
}