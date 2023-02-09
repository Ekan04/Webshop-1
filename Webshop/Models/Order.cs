using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Webshop.Models
{
    public class Order
    {
        public int OrderNr { set; get; } = 0;
        public DateTime TimeOfOrder { set; get; }
        public string Status { set; get; } = "";
        public Kund Customer { set; get; }
        public List<Products> OrderedProducts { set; get; }

        public static List<Order> getAllOrders()
        {
            string conStr = "Server = 46.246.45.183; User = OscarEk; Port = 3306; Database = OscarEk_DB; Password = SGRYGJBK";
            string[] ProductIds;

            List<Order> list = new List<Order>();
            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from Orders", conn);

            conn.Open();

            MySqlDataReader reader = MyCom.ExecuteReader();

            while (reader.Read())
            {
                Order o = new Order();
                o.OrderNr = reader.GetInt32("OrderNr");
                o.TimeOfOrder = reader.GetDateTime("OrderDate");
                o.Status = reader.GetString("Status");
                o.Customer = Kund.getOneCustomer(reader.GetInt32("CustomerNr"));
                ProductIds = reader.GetString("ProductNumbers").Split(',');

                foreach (string pr in ProductIds)
                {
                    o.OrderedProducts.Add(Products.getOneProduct(int.Parse(pr)));
                }
                
                list.Add(o);
            }

            MyCom.Dispose();
            conn.Close();

            return list;
        }
    }
}
