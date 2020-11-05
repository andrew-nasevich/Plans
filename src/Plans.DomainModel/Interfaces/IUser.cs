namespace Plans.DomainModel.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }

        string Login { get; set; }

        string Name { get; set; }

        string LastName { get; set; }
    }
}