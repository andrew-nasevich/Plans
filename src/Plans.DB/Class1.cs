using System;

namespace Plans.DB
{
    public class Class1
    {
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
