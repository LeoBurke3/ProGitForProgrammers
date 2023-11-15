using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using MySqlX.XDevAPI.Relational;

namespace ProGitForProgrammersProject2
{
    public class Asset
    {
        public string name { get; set; }
        public string model { get; set; }
        public string manufacturer { get; set; }
        public string type {  get; set; }
        public string ipAddress { get; set; }

        Database database = new Database();

        public void addAsset(Asset asset)
        {
            string sqlQuery_Employees = ($"INSERT INTO asset(sname, model, type, manufacturer,ip) VALUES" +
                $"('{asset.name}', '{asset.model}', '{asset.type}','{asset.manufacturer}','{asset.ipAddress}')");

            MySqlCommand cmd = new MySqlCommand(sqlQuery_Employees, database.mySQLconnect());
            cmd.ExecuteReader();
        }
    }

}
