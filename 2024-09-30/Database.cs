using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace _2024_09_30
{
    public static class Database
    {
        static MySqlConnection Connection;
        public static void OpenConnection()
        {
            string host = "localhost";
            string user = "root";
            string password = "";
            string connectionString = $"Server={host};User={user};Password={password}";
            Connection = new MySqlConnection(connectionString);
            try
            {
                Connection.Open();
                new MySqlCommand("CREATE DATABASE IF NOT EXISTS `cars`", Connection).ExecuteNonQuery();
                new MySqlCommand("USE `cars`", Connection).ExecuteNonQuery();
                new MySqlCommand("CREATE TABLE IF NOT EXISTS `cars` (`id` INT AUTO_INCREMENT PRIMARY KEY, `make` VARCHAR(50), `model` VARCHAR(50), `colour` VARCHAR(50), `year` INT, `power` INT)", Connection).ExecuteNonQuery();
            }
            catch (Exception e)
            {
                ShowError(e);
            }
        }
        public static void ShowError(Exception e)
        {
            MessageBox.Show(e.Message, "Database error");
        }
        public static List<Car> GetAllCars()
        {
            List<Car> list = new List<Car>();
            try
            {
                MySqlDataReader reader = new MySqlCommand("SELECT * FROM `cars`", Connection).ExecuteReader();
                while (reader.Read()) list.Add(new Car
                {
                    Id = reader.GetInt32("id"),
                    Make = reader.GetString("make"),
                    Model = reader.GetString("model"),
                    Colour = reader.GetString("colour"),
                    Year = reader.GetInt32("year"),
                    Power = reader.GetInt32("power")
                });
                reader.Close();
            }
            catch (Exception e)
            {
                ShowError(e);
            }
            return list;
        }
    }
}
