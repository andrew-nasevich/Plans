using System;
using MySql.Data.MySqlClient;
using Plans.DB.DBContexts.Interfaces;
using Plans.DB.Interfaces;
using Plans.DomainModel.Interfaces;

namespace Plans.DB.DBManagers
{
    public class UserDBManager
        : IUserDBManager
    {
        private readonly IDBContext _DBContext;
        private readonly IUserFactory _userFactory;

        public UserDBManager(IDBContext DBContext, IUserFactory userFactory)
        {
            _DBContext = DBContext;
            _userFactory = userFactory;
        }

        public IUser CreateUser(IUser user, string passwordHash)
        {
            var connetionString = _DBContext.GetConnenctionString;
            var cnn = new MySqlConnection(connetionString);

            try
            {
                cnn.Open();

                string querry = 
                    $"INSERT INTO `user` (`login`, `pass_hash`, `name`, `last_name`) VALUES('{user.Login}', '{passwordHash}', '{user.Name}', '{user.LastName}');\n" +
                    "SELECT LAST_INSERTED_ID()";
                MySqlCommand cmd = new MySqlCommand(querry, cnn);

                var rdr = cmd.ExecuteReader();

                rdr.Read();
                user.Id = (Int32)rdr[0];
                rdr.Close();

                cnn.Close();
            }
            catch(Exception e)
            {
                return null;
            }

            return user;
        }

        public int? DeleteUser(int id)
        {
            var connetionString = _DBContext.GetConnenctionString;
            var cnn = new MySqlConnection(connetionString);

            try
            {
                cnn.Open();

                string querry =
                    $"DELETE FROM `user` WHERE `id` = {id}";
                MySqlCommand cmd = new MySqlCommand(querry, cnn);
                cmd.ExecuteNonQuery();

                cnn.Close();
            }
            catch
            {
                return null;
            }

            return id;
        }

        public IUser SelectUser(int id)
        {
            IUser user = null;
            var connetionString = _DBContext.GetConnenctionString;
            var cnn = new MySqlConnection(connetionString);

            try
            {
                cnn.Open();

                string querry =
                    $"SELECT * FROM `user` WHERE `id` = {id}";
                MySqlCommand cmd = new MySqlCommand(querry, cnn);
                
                var rdr = cmd.ExecuteReader();

                rdr.Read();

                var readId = (Int32)rdr[0];
                string login = (String)rdr[1];
                string name = (String)rdr[2];
                string lastName = (String)rdr[3];
                
                rdr.Close();

                cnn.Close();

                user = _userFactory.CreateUser(readId, login, name, lastName);
            }
            catch
            {

            }

            return user;
        }

        public IUser UpdateUser(IUser user)
        {
            var connetionString = _DBContext.GetConnenctionString;
            var cnn = new MySqlConnection(connetionString);

            try
            {
                cnn.Open();

                string querry =
                    $"UPDATE `user` SET `login` = '{user.Login}', " +
                                      $"`name` = '{user.Name}', " + 
                                      $" `last_name` = '{user.LastName}' "+
                    $"WHERE `id` = {user.Id}";
                MySqlCommand cmd = new MySqlCommand(querry, cnn);

                cmd.ExecuteNonQuery();

                cnn.Close();
            }
            catch
            {
                return null;
            }

            return user;
        }

        public string UpdateUserPasswordHash(int id, string newPasswordHash)
        {
            var connetionString = _DBContext.GetConnenctionString;
            var cnn = new MySqlConnection(connetionString);

            try
            {
                cnn.Open();

                string querry =
                    $"UPDATE `user` SET `pass_hash` = '{newPasswordHash}' " +
                    $"WHERE `id` = {id}";
                MySqlCommand cmd = new MySqlCommand(querry, cnn);

                cmd.ExecuteNonQuery();

                cnn.Close();
            }
            catch
            {
                return null;
            }

            return newPasswordHash;
        }
    }
}