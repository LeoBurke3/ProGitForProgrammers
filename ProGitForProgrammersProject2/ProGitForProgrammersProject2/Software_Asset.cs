using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.System.Profile;
using MySqlConnector;

namespace ProGitForProgrammersProject2
{
    internal class Software_Asset
    {
        public string name { get; set; }
        public string version { get; set; }
        public string manufacturer { get; set; }

        Database database = new Database();

        public void autoSoftAsset()
        {
            Software_Asset software = new Software_Asset();
            software.version = System.Environment.OSVersion.Version.ToString();
            software.name = AnalyticsInfo.VersionInfo.ProductName.ToString();

            addAsset(software);

        }
        public void addAsset(Software_Asset software)
        {
            string sqlQuery_Employees = ($"INSERT INTO software_assets(sname, version, manufacturer) VALUES" +
                $"('{software.name}', '{software.version}', '{software.manufacturer}')");

            MySqlCommand cmd = new MySqlCommand(sqlQuery_Employees, database.mySQLconnect());
            cmd.ExecuteReader();
        }
    }
}
