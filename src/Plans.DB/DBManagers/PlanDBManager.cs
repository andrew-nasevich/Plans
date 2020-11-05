using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.Sig;
using Plans.DB.DBContexts.Interfaces;
using Plans.DB.Interfaces;
using Plans.DomainModel.Interfaces;
using Plans.DomainModel.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plans.DB.DBManagers
{
    public class PlanDBManager
        : IPlanDBManager
    {
        private readonly IDBContext _DBContext;
        private readonly IDBDatetimeConverter _DBDateConverter;

        public PlanDBManager(IDBContext DBContext, IDBDatetimeConverter DBDateConverter) 
        {
            _DBContext = DBContext;
            _DBDateConverter = DBDateConverter;
        }


        public IDaysInterval CreateDaysInterval(IDaysInterval daysInterval, int planId)
        {
            throw new NotImplementedException();
        }

        public IPlan CreatePlan(IPlan plan, int user_id)
        {
            var connetionString = _DBContext.GetConnenctionString;
            var cnn = new MySqlConnection(connetionString);

            try
            {
                cnn.Open();

                var querry =
                    "INSERT INTO `plan` (`name`, `percentage`, `creating_time`, `finishing_time`, `user_id`) " +
                    $"VALUES('{plan.Name}', " + 
                        $"'{plan.Percentage}', " +
                        $"'{_DBDateConverter.ConvertToString(plan.CreatingTime)}', " +
                        $"'{_DBDateConverter.ConvertToString(plan.FinishingTime)}', " + 
                        $"'{user_id}'); " + 
                    "SELECT LAST_INSERT_ID()";
                MySqlCommand cmd = new MySqlCommand(querry, cnn);
                var rdr = cmd.ExecuteReader();
                rdr.Read();
                plan.Id = Convert.ToInt32(rdr[0]);
                rdr.Close();
                cmd.Clone();

                     querry =
                        $"INSERT INTO `days_interval` (`start_day`, `finish_day`, `is_repeated`, `start_over_every_week`, `include_holidays`, `days_gap`, `plan_id`, `finish_day_of_repetition`) VALUES";
                foreach(var interval in plan.DaysIntervals)
                {
                    querry += $"('{_DBDateConverter.ConvertToString(interval.StartDay)}', " +
                              $"'{_DBDateConverter.ConvertToString(interval.FinishDay)}', " +
                              $"'{(interval.IsRepeated ? 1 : 0)}', " +
                              $"'{(interval.StartOverEveryWeak ? 1 : 0)}', " +
                              $"'{(interval.IncludeHolidays ? 1 : 0)}', " +
                              $"'{interval.DaysGap}', " +
                              $"'{plan.Id}', ";
                    if(interval.FinishDayOfRepetition.HasValue)
                    {
                        querry += $"'{_DBDateConverter.ConvertToString(interval.FinishDayOfRepetition.Value)}') "; 
                    }
                    else
                    {
                        querry += "'null') ";
                    }
                    //TODO: add logic of selecting ids of inserted days intervals
                }
                if (plan.DaysIntervals != null && plan.DaysIntervals.Count > 0)
                {
                    cmd = new MySqlCommand(querry, cnn);
                    cmd.ExecuteNonQuery();
                }

                cnn.Close();
            }
            catch(Exception e)
            {
                return null;
            }

            return plan;
        }

        public int? DeleteDaysInterval(int idDaysInterval)
        {
            throw new NotImplementedException();
        }

        public int? DeletePlan(int id)
        {
            throw new NotImplementedException();
        }

        public IPlan SelectPlan(int id)
        {
            throw new NotImplementedException();
        }

        public IDaysInterval UpdateDaysInterval(IDaysInterval daysInterval)
        {
            throw new NotImplementedException();
        }

        public IPlan UpdatePlan(IPlan plan)
        {
            throw new NotImplementedException();
        }
    }
}