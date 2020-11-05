using Plans.DomainModel.Interfaces;

namespace Plans.DomainModel.Users
{
    public class UserFactory
        : IUserFactory
    {
        public IUser CreateUser(int id, string login, string name, string lastName)
        {
            return new User 
            {
                Id = id,
                Login = login,
                Name = name,
                LastName = lastName
            };
        }
    }
}