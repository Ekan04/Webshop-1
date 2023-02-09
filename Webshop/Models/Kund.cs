using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace Webshop.Models
{
    public class Kund
    {
        public int CustomerNr { set; get; } = 0;
        public string Name { set; get; } = "";
        public string Username { set; get; } = "";
        public string City { set; get; } = "";
        public string Adress { set; get; } = "";
        public string PhoneNr { set; get; } = "";

        public static List<Kund> getAllCustomers()
        {
            string conStr = "Server = 46.246.45.183; User = OscarEk; Port = 3306; Database = OscarEk_DB; Password = SGRYGJBK";

            List<Kund> list = new List<Kund>();
            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from Kund", conn);

            conn.Open();

            MySqlDataReader reader = MyCom.ExecuteReader();

            while (reader.Read())
            {
                Kund k = new Kund();
                k.CustomerNr = reader.GetInt32("CustomerNr");
                k.Name = reader.GetString("Name");
                k.Username = reader.GetString("Username");
                k.City = reader.GetString("City");
                k.Adress = reader.GetString("Adress");
                k.PhoneNr = reader.GetString("PhoneNr");
                list.Add(k);
            }

            MyCom.Dispose();
            conn.Close();

            return list;
        }

        public static Kund getOneCustomer(int customerNr)
        {
            string conStr = "Server = 46.246.45.183; User = OscarEk; Port = 3306; Database = OscarEk_DB; Password = SGRYGJBK";

            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from Kund where CustomerNr = @CustomerNr", conn);
            MyCom.Parameters.AddWithValue("@CustomerNr", Convert.ToInt32(customerNr));

            conn.Open();

            MySqlDataReader reader = MyCom.ExecuteReader();
                
            Kund k = new Kund();
            if (reader.Read())
            {
                k.CustomerNr = reader.GetInt32("CustomerNr");
                k.Name = reader.GetString("Name");
                k.Username = reader.GetString("Username");
                k.City = reader.GetString("City");
                k.Adress = reader.GetString("Adress");
                k.PhoneNr = reader.GetString("PhoneNr");
            }

            MyCom.Dispose();
            conn.Close();

            return k;
        }

        public static bool saveEditedCustomer(Kund k)
        {
            string conStr = "Server = 46.246.45.183; User = OscarEk; Port = 3306; Database = OscarEk_DB; Password = SGRYGJBK";

            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("UPDATE Kund set Name = @Name, Username = @Username, City = @City, Adress = @Adress, PhoneNr = @PhoneNr WHERE CustomerNr = @CustomerNr", conn);
            MyCom.Parameters.AddWithValue("@CustomerNr", k.CustomerNr);
            MyCom.Parameters.AddWithValue("@Name", k.Name);
            MyCom.Parameters.AddWithValue("@Username", k.Username);
            MyCom.Parameters.AddWithValue("@City", k.City);
            MyCom.Parameters.AddWithValue("@Adress", k.Adress);
            MyCom.Parameters.AddWithValue("@PhoneNr", k.PhoneNr);

            conn.Open();

            int rows = MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rows == 0) return false; else return true;
        }

        public static bool saveNewCustomer(Kund k){
            string conStr = "Server = 46.246.45.183; User = OscarEk; Port = 3306; Database = OscarEk_DB; Password = SGRYGJBK";

            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("INSERT INTO Kund (Name, Username, City, Adress, PhoneNr) VALUES (@Name, @Username, @City, @Adress, @PhoneNr)", conn);
            MyCom.Parameters.AddWithValue("@Name", k.Name);
            MyCom.Parameters.AddWithValue("@Username", k.Username);
            MyCom.Parameters.AddWithValue("@City", k.City);
            MyCom.Parameters.AddWithValue("@Adress", k.Adress);
            MyCom.Parameters.AddWithValue("@PhoneNr", k.PhoneNr);

            conn.Open();

            int rows = MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rows == 0) return false; else return true;
        }

        public static bool removeCustomer(int customerNr)
        {
            string conStr = "Server = 46.246.45.183; User = OscarEk; Port = 3306; Database = OscarEk_DB; Password = SGRYGJBK";

            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("DELETE FROM Kund WHERE CustomerNr = @CustomerNr", conn);
            MyCom.Parameters.AddWithValue("@CustomerNr", customerNr);

            conn.Open();

            int rows = MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rows == 0) return false; else return true;
        }
    }
}

 