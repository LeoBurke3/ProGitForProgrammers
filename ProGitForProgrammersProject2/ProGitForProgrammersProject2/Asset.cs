using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using MySqlX.XDevAPI.Relational;
using System.Net.Sockets;
using System.Net;
using System.Management;
using Windows.Devices.Enumeration;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.ApplicationModel;
using Windows.System.Profile;
using Windows.UI.Popups;

namespace ProGitForProgrammersProject2
{
    public class Asset
    {
        public int aid { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public string manufacturer { get; set; }
        public string type {  get; set; }
        public string ipAddress { get; set; }
        public int employeeID{ get; set; }

        Database database = new Database();

        public void autoAsset()
        {
            //Asset name
            Asset asset1 = new Asset();
            asset1.name = System.Environment.MachineName;

            //Asset Manufacturer & Model
            EasClientDeviceInformation eas = new EasClientDeviceInformation();
            asset1.manufacturer = eas.SystemManufacturer;
            asset1.model = eas.SystemProductName;


            // Asset ip
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    asset1.ipAddress = ip.ToString();
                }
            }

            addAsset(asset1);
        }
        public void addAsset(Asset asset)
        {
            string sqlQuery_Employees = ($"INSERT INTO asset(sname, model, type, manufacturer,ip) VALUES" +
                $"('{asset.name}', '{asset.model}', '{asset.type}','{asset.manufacturer}','{asset.ipAddress}')");

            MySqlCommand cmd = new MySqlCommand(sqlQuery_Employees, database.mySQLconnect());
            cmd.ExecuteReader();
        }
        public ObservableCollection<Asset> viewAsset()
        {
            try
            {
                string sqlQuery_Employees = "SELECT * FROM `asset`";

                var assets = new ObservableCollection<Asset>();

                MySqlCommand cmd = new MySqlCommand(sqlQuery_Employees, database.mySQLconnect());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var asset = new Asset();
                    //employee.employeeID = reader.GetInt32(0);
                    asset.aid = reader.GetInt32(0);
                    asset.name = reader.GetString(1);
                    asset.model = reader.GetString(2);
                    asset.type = reader.GetString(3);
                    asset.manufacturer = reader.GetString(4);
                    asset.ipAddress = reader.GetString(5);
                    //Checking for null employee ID, if present send it store it
                    if (reader.IsDBNull(6))
                    {}
                    else
                    {
                        asset.employeeID = reader.GetInt32(6);
                    }
                    assets.Add(asset);
                }
                return assets;
            }
            catch(Exception ex)
            {
                var msg = new MessageDialog(ex.Message);
                return null;
            }

        }

        public void linkAsset(int asset_id, string employee_id)
        {
            try
            {
                string sqlQuery = ($"UPDATE asset\r\nSET employee_id = {employee_id}\r\nWHERE aid = {asset_id};\r\n");
                MySqlCommand cmd = new MySqlCommand(sqlQuery, database.mySQLconnect());
                cmd.ExecuteNonQuery();
                

            } catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        public void deleteAsset(int asset_id)
        {
            try
            {
                string sqlQuery = ($"DELETE FROM asset WHERE aid = {asset_id};");
                MySqlCommand cmd = new MySqlCommand( sqlQuery, database.mySQLconnect());
                cmd.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                var txt = ex.Message;
                var msg2 = new MessageDialog(txt).ShowAsync();
            }
        }
    }

}
