using Plans.DomainModel.Interfaces;

namespace Plans.DB.Interfaces
{
    public interface IPlanDBManager
    {
        IPlan CreatePlan(IPlan plan);

        IPlan SelectPlan(int id);

        IPlan UpdatePlan(IPlan plan);

        int? DeletePlan(int id);

        IDaysInterval CreateDaysInterval(int planId, IDaysInterval daysInterval);

        int? DeleteDaysInterval(int idDaysInterval);

        IDaysInterval UpdateDaysInterval(IDaysInterval daysInterval);
    }
}