using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml.Linq;

namespace Webshop.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "Writ a password")]
        [Display(Name = "Your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Write a valid Emailadress")]
        [DataType(DataType.EmailAddress, ErrorMessage = "This Email's formatting is wrong")]
        [Display(Name = "Your Emailadress")]
        public string Email { get; set; }
        public string Role { get; set; }



        public static Employee GetEmployeeByEmail(string email)
        {
            string conStr = "Server = 46.246.45.183; User = OscarEk; Port = 3306; Database = OscarEk_DB; Password = SGRYGJBK";

            using (MySqlConnection connection = new MySqlConnection(conStr))
            {
                connection.Open();

                // Create a MySqlCommand object with the SELECT query to retrieve the employee data based on the email
                string query = "SELECT * FROM Employee WHERE Email = @Email";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                // Execute the SELECT query and get the results in a DataTable
                DataTable dataTable = new DataTable();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }

                // Check if any rows were returned from the SELECT query
                if (dataTable.Rows.Count > 0)
                {
                    // If yes, create a new Employee object and copy the data from the row into the object
                    DataRow row = dataTable.Rows[0];
                    Employee employee = new Employee()
                    {
                        Id = (int)row["Id"],
                        Name = row["Name"].ToString(),
                        Password = row["Password"].ToString(),
                        Email = row["Email"].ToString(),
                        Role = row["Role"].ToString()
                    };
                    return employee;

                    // Use the employee object as needed
                    // For example, you can access the employee's name using employee.Name
                }
                else
                {
                    Employee employee = new Employee();
                    return employee;
                }
            }
        }

    }
}
