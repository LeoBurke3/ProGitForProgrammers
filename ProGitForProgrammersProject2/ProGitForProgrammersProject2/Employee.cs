using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public int employeeID {  get; set; }
        public string firstName { get; set; }
        public string surname { get; set; }
        public string email { get; set; }

        Database database = new Database();
        
        public ObservableCollection<Employee> viewEmployee()
        {   
            string sqlQuery_Employees = "SELECT * FROM `employee`";

            var employees = new ObservableCollection<Employee>();

            MySqlCommand cmd = new MySqlCommand(sqlQuery_Employees, database.mySQLconnect());
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var employee = new Employee();
                employee.employeeID = reader.GetInt32(0);
                employee.firstName = reader.GetString(1);
                employee.surname = reader.GetString(2);
                employee.email = reader.GetString(3);
                employees.Add(employee);
            }
            return employees;

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
