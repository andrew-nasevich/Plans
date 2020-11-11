namespace Plans.DomainModel.Users
{
    public class ClientUser
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
    }
}