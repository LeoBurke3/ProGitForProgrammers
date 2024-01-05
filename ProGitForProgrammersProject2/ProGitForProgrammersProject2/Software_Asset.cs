using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.System.Profile;
using MySqlConnector;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

namespace ProGitForProgrammersProject2
{
    internal class Software_Asset
    {
        public int sid {  get; set; }
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

        public ObservableCollection<Software_Asset> viewAsset()
        {
            try
            {
                string sqlQuery_Employees = "SELECT * FROM `software_assets`";

                var assets = new ObservableCollection<Software_Asset>();

                MySqlCommand cmd = new MySqlCommand(sqlQuery_Employees, database.mySQLconnect());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var soft = new Software_Asset();
                    //employee.employeeID = reader.GetInt32(0);
                    soft.sid = reader.GetInt32(0);
                    soft.name = reader.GetString(1);
                    soft.version = reader.GetString(2);
                    soft.manufacturer = reader.GetString(3);
                   
                    
                    assets.Add(soft);
                }
                return assets;
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog(ex.Message);
                return null;
            }

        }

    }
}
