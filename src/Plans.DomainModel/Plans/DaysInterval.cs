using System;

namespace Plans.DomainModel.Plans
{
    public class DaysInterval
    {
        public int Id { get; set; }

        public DateTime StartDay { get; set; }

        public DateTime FinishDay { get; set; }

        public bool IsRepeated { get; set; }

        public bool StartOverEveryWeak { get; set; }
        
        public bool Includeolidays { get; set; }

        public int? DaysGap { get; set; }
        
        public DateTime? FinishDayOfRepetition { get; set; }

    }
}