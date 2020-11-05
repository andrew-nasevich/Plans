using Plans.DomainModel.Interfaces;

namespace Plans.DB.Interfaces
{
    public interface IPlanDBManager
    {
        IPlan CreatePlan(IPlan plan, int user_id);

        IPlan SelectPlan(int id);

        IPlan UpdatePlan(IPlan plan);

        int? DeletePlan(int id);

        IDaysInterval CreateDaysInterval(IDaysInterval daysInterval, int planId);

        int? DeleteDaysInterval(int idDaysInterval);

        IDaysInterval UpdateDaysInterval(IDaysInterval daysInterval);
    }
}