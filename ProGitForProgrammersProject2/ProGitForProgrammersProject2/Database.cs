using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using MySqlConnector;

namespace ProGitForProgrammersProject2
{
    internal class Database
    {
        
        public void mySQLlogin()
        {
            string connstring = "server=lochnagar.abertay.ac.uk; user=sql2301619; database=sql2301619; password=likely cook socks world;";
            MySqlConnection conn = new MySqlConnection(connstring);
            
            try
            { 
                conn.Open();

                string sqlQuery_Employees = "SELECT * FROM `employee`";

                MySqlCommand cmd = new MySqlCommand(sqlQuery_Employees, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                List<string> names = new List<string>();
               
                while (reader.Read())
                {
                    names.Add(reader["ename"].ToString());
                }
                var result = String.Join(", ", names.ToArray());

                var msg = new MessageDialog(result).ShowAsync();
            } catch(Exception ex)
            {
                var msg = new MessageDialog("Error: " +  ex.ToString()).ShowAsync();
                conn.Close();
            }

        }
        public void addEmployee()
        {

        }
    }
}
