using System;
using Plans.DB.Interfaces;

namespace Plans.DB.Converters
{
    public class DatetimeConverter
        : IDBDatetimeConverter
    {
        private const string DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
        public DateTime ConvertToDateTime(string date)
        {
            
            if (date == null)
            { 
                throw new ArgumentNullException(nameof(date));
            }

            try
            {
                return DateTime.Parse(date);
            }
            catch
            {
                throw new ArgumentException("'date' argument has an anexpected format. THe expected format is " + DATETIME_FORMAT, nameof(date));
            }
        }

        public string ConvertToString(DateTime date)
        {
            return date.ToString(DATETIME_FORMAT);
        }
    }
}