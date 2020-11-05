using Plans.DomainModel.Interfaces;

namespace Plans.Foundation.Interfaces
{
    public interface IUserFactory
    {
        IUser CreateUser(int id, string login, string name, string lastName);
    }
}