using Plans.DomainModel.Interfaces;

namespace Plans.DB.Interfaces
{
    public interface IUserDBManager
    {
        IUser CreateUser(IUser user, string passwordHash);

        IUser SelectUser(int id);

        IUser UpdateUser(IUser user);

        int? DeleteUser(int id);

        string UpdateUserPasswordHash(int id, string newPasswordHash);
    }
}