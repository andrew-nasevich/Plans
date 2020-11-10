using Plans.DomainModel.Interfaces;

namespace Plans.DomainModel.Users
{
    public class User : IUser
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string PasswordHash { get; set; }
    }
}