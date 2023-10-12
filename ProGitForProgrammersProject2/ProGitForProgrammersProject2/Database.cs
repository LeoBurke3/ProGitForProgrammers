using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using Windows.UI.Popups;

namespace ProGitForProgrammersProject2
{
    internal class Database
    {
        
        public void mySQLlogin()
        {
            try
            {
                string connstring = "server=lochnagar.abertay.ac.uk;user=sql2301619;database=sql2301619;password=likely cook socks world";
                MySqlConnection conn = new MySqlConnection(connstring);

                conn.Open();

                string sqlQuery_Employees = "SELECT * FROM `employee`";

                MySqlCommand cmd = new MySqlCommand(sqlQuery_Employees, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var msg = new MessageDialog("Name " + reader["ename"]).ShowAsync();
                }
                conn.Close();
            } catch(MySqlException ex)
            {
                var msg = new MessageDialog("Error: " +  ex.Message);
            }

        }
    }
}
