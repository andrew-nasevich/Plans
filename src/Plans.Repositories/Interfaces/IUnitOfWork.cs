using System.Threading.Tasks;

namespace Plans.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;

        Task SaveAsync();
    }
}