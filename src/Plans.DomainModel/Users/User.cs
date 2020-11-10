using Plans.DomainModel.Plans;
using System.Collections.Generic;

namespace Plans.DomainModel.Users
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string PasswordHash { get; set; }

        public ICollection<Plan> Plans { get; set; }
    }
}