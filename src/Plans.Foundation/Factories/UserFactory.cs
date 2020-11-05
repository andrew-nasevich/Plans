using Plans.DomainModel.Interfaces;
using Plans.DomainModel.Users;
using Plans.Foundation.Interfaces;

namespace Plans.Foundation.Factories
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