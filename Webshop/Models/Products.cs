using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Webshop.Models
{
    public class Products
    {
        public int ProductNr { set; get; } = 0;
        public string Name { set; get; } = "";
        public string Manufacturer { set; get; } = "";
        public int Stock { set; get; } = 0;
        public double Price { set; get; } = 0;

        public static List<Products> getAllProducts()
        {
            string conStr = "Server = 46.246.45.183; User = OscarEk; Port = 3306; Database = OscarEk_DB; Password = SGRYGJBK";

            List<Products> list = new List<Products>();
            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from Products", conn);

            conn.Open();

            MySqlDataReader reader = MyCom.ExecuteReader();

            while (reader.Read())
            {
                Products p = new Products();
                p.ProductNr = reader.GetInt32("ProductNr");
                p.Name = reader.GetString("Name");
                p.Manufacturer = reader.GetString("Manufacturer");
                p.Stock = reader.GetInt32("Stock");
                p.Price = reader.GetFloat("Price");
                list.Add(p);
            }

            MyCom.Dispose();
            conn.Close();

            return list;
        }
        public static List<Products> getAllOrderedProducts(string[] AllOrderedProductIds)
        {
            int i = 0;
            List<Products> list = new List<Products>();
            while (i < AllOrderedProductIds.Length)
            {
                list.Add(getOneProduct(Convert.ToInt32(AllOrderedProductIds[i])));
                i++;
            }
            return list;
        }

        public static Products getOneProduct(int productNr)
        {
            string conStr = "Server = 46.246.45.183; User = OscarEk; Port = 3306; Database = OscarEk_DB; Password = SGRYGJBK";

            Products p = new Products();
            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from Products WHERE ProductNr = @ProductNr", conn);
            MyCom.Parameters.AddWithValue("@ProductNr", productNr);

            conn.Open();

            MySqlDataReader reader = MyCom.ExecuteReader();

            if (reader.Read())
            {
                p.ProductNr = reader.GetInt32("ProductNr");
                p.Name = reader.GetString("Name");
                p.Manufacturer = reader.GetString("Manufacturer");
                p.Stock = reader.GetInt32("Stock");
                p.Price = reader.GetFloat("Price");
            }

            MyCom.Dispose();
            conn.Close();

            return p;
        }

        public static bool saveEditedProduct(Products p)
        {
            string conStr = "Server = 46.246.45.183; User = OscarEk; Port = 3306; Database = OscarEk_DB; Password = SGRYGJBK";

            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("UPDATE Products SET Name = @Name, Manufacturer = @Manufacturer, Stock = @Stock, Price = @Price WHERE ProductNr = @ProductNr", conn);
            MyCom.Parameters.AddWithValue("@ProductNr", p.ProductNr);
            MyCom.Parameters.AddWithValue("@Name", p.Name);
            MyCom.Parameters.AddWithValue("@Manufacturer", p.Manufacturer);
            MyCom.Parameters.AddWithValue("@Stock", p.Stock);
            MyCom.Parameters.AddWithValue("@Price", p.Price);

            conn.Open();

            int rows = MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rows == 0) return false; else return true;
        }

        public static bool saveNewProduct(Products p)
        {
            string conStr = "Server = 46.246.45.183; User = OscarEk; Port = 3306; Database = OscarEk_DB; Password = SGRYGJBK";

            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("INSERT INTO Products (Name, Manufacturer, Stock, Price) VALUES (@Name, @Manufacturer, @Stock, @Price)", conn);
            MyCom.Parameters.AddWithValue("@Name", p.Name);
            MyCom.Parameters.AddWithValue("@Manufacturer", p.Manufacturer);
            MyCom.Parameters.AddWithValue("@Stock", p.Stock);
            MyCom.Parameters.AddWithValue("@Price", p.Price);

            conn.Open();

            int rows = MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rows == 0) return false; else return true;
        }

        public static bool removeProduct(int productNr)
        {
            string conStr = "Server = 46.246.45.183; User = OscarEk; Port = 3306; Database = OscarEk_DB; Password = SGRYGJBK";

            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("DELETE FROM Products WHERE ProductNr = @ProductNr", conn);
            MyCom.Parameters.AddWithValue("@ProductNr", productNr);

            conn.Open();

            int rows = MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rows == 0) return false; else return true;
        }
    }
}
