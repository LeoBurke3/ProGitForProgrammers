using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using MySqlConnector;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Utilities.Collections;

namespace ProGitForProgrammersProject2
{
    internal class Database
    {
        
        public MySqlConnection mySQLconnect()
        {
            string connstring = "server=lochnagar.abertay.ac.uk; user=sql2301619; database=sql2301619; password=likely cook socks world;";
            MySqlConnection conn = new MySqlConnection(connstring);
            
            try
            { 
                conn.Open();

            } catch(Exception ex)
            {
                var msg = new MessageDialog("Error: " +  ex.ToString()).ShowAsync();
                conn.Close();
            }
            return conn;
        }
        
        public void addAsset(Asset asset)
        {
             //MySqlConnection conn = mySQLconnect();
            string sqlQuery_Employees = ($"INSERT INTO asset(sname, model, type, manufacturer,ip) VALUES" +
                $"('{asset.name}', '{asset.model}', '{asset.type}','{asset.manufacturer}','{asset.ipAddress}')");

            MySqlCommand cmd = new MySqlCommand(sqlQuery_Employees, mySQLconnect());
            MySqlDataReader reader = cmd.ExecuteReader();
            // conn.Close();
        }
        
    }
}
