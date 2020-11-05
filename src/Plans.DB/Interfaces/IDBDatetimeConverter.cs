using System;

namespace Plans.DB.Interfaces
{
    public interface IDBDatetimeConverter
    {
        DateTime ConvertToDateTime(string date);

        string ConvertToString(DateTime date);
    }
}