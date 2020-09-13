using Plans.DB.DBContexts.Interfaces;

namespace Plans.DB
{
    public class DBContext
        : IDBContext
    {
        public string GetConnenctionString => "server=localhost;database=plans;uid=root;pwd=;";
    }
}