using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using MySqlX.XDevAPI.Relational;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;

namespace ProGitForProgrammersProject2
{
    public class Employee
    {
        public string firstName { get; set; }
        public string surname { get; set; }
        public string email { get; set; }

        Database database = new Database();
        
        public void viewEmployee()
        {   
            string sqlQuery_Employees = "SELECT * FROM `employee`";

            MySqlCommand cmd = new MySqlCommand(sqlQuery_Employees, database.mySQLconnect());
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);


        }
        public void addEmployee(Employee employee)
        {
            string sqlQuery_Employees = ($"INSERT INTO employee(firstname, surname, email) VALUES" +
                $"('{employee.firstName}', '{employee.surname}', '{employee.email}')");

            MySqlCommand cmd = new MySqlCommand(sqlQuery_Employees, database.mySQLconnect());
            cmd.ExecuteReader();
        }

    }


}
