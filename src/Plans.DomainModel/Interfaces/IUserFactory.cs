namespace Plans.DomainModel.Interfaces
{
    public interface IUserFactory
    {
        IUser CreateUser(int id, string login, string name, string lastName);
    }
}