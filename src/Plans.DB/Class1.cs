using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Plans.DB.DBManagers;
using Plans.DomainModel.Users;

namespace Plans.DB
{
    public class Class1
    {
        public void connect() 
        {
            var connetionString = "server=localhost;database=plans;uid=root;pwd=;";
            var cnn = new MySqlConnection(connetionString);

            var context = new DBContext();
            var userFactory = new UserFactory();

            var userManager = new UserDBManager(context, userFactory);

            var user = new User 
            {
                Id = 3,
                Login = "Andrey1",
                Name = "Andrey",
                LastName = "Nasevich"
            };

            
            var u = userManager.CreateUser(user, "123");

            /*try
            {
                cnn.Open();

                string querry = "select login from `user`";
                mysqlcommand cmd = new mysqlcommand(querry, cnn);
                mysqldatareader rdr = cmd.executereader();

                var logins = new List<object>();
                while (rdr.Read())
                {
                    logins.Add(rdr[0]);
                    Console.WriteLine(rdr[0]);
                }
                rdr.Close();

                cnn.Close();
            }
            catch
            {

            }*/

        }
        /*
      CREATE TABLE `plans`.`user` (
      `id` INT NOT NULL AUTO_INCREMENT,
      `login` VARCHAR(40) NULL,
      `pass_hash` VARCHAR(40) NULL,
      `name` VARCHAR(100) NULL,
      `last_name` VARCHAR(100) NULL,
      PRIMARY KEY (`id`),
      UNIQUE INDEX `login_UNIQUE` (`login` ASC) VISIBLE);




      CREATE TABLE `plans`.`plan` (
      `id` INT NOT NULL AUTO_INCREMENT,
      `name` VARCHAR(100) NOT NULL,
      `percentage` FLOAT NOT NULL,
      `creating_time` DATETIME NULL,
      `finishing_time` DATETIME NULL,
      `user` VARCHAR(45) NOT NULL,
      PRIMARY KEY (`id`),
      INDEX `user_idx` (`user` ASC) VISIBLE,
      CONSTRAINT `user`
      FOREIGN KEY (`user`)
      REFERENCES `plans`.`user` (`login`)
      ON DELETE RESTRICT
      ON UPDATE RESTRICT);

      CREATE TABLE `plans`.`days_interval` (
      `id` INT NOT NULL AUTO_INCREMENT,
      `start_day` DATE NOT NULL,
      `finish_day` DATE NOT NULL,
      `is_repeated` TINYINT NOT NULL,
      `start_over_every_weak` TINYINT NOT NULL,
      `include_holidays` TINYINT NOT NULL,
      `days_gap` INT NOT NULL,
      `finish_day_of_repetition` VARCHAR(45) NULL,
      `plan` INT NOT NULL,
      PRIMARY KEY (`id`),
      INDEX `plan_idx` (`plan` ASC) VISIBLE,
      CONSTRAINT `plan`
      FOREIGN KEY (`plan`)
      REFERENCES `plans`.`plan` (`id`)
      ON DELETE RESTRICT
      ON UPDATE RESTRICT);

      */
    }
}
