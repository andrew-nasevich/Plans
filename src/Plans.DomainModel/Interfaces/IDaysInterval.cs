using System;

namespace Plans.DomainModel.Interfaces
{
    public interface IDaysInterval
    {
        public int Id { get; set; }

        public DateTime StartDay { get; set; }

        public DateTime FinishDay { get; set; }

        public bool IsRepeated { get; set; }

        public bool StartOverEveryWeak { get; set; }

        public bool IncludeHolidays { get; set; }

        public int? DaysGap { get; set; }

        public DateTime? FinishDayOfRepetition { get; set; }

    }
}