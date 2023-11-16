﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using MySqlX.XDevAPI.Relational;

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

        Database database = new Database();

        public void addAsset(Asset asset)
        {
            string sqlQuery_Employees = ($"INSERT INTO asset(sname, model, type, manufacturer,ip) VALUES" +
                $"('{asset.name}', '{asset.model}', '{asset.type}','{asset.manufacturer}','{asset.ipAddress}')");

            MySqlCommand cmd = new MySqlCommand(sqlQuery_Employees, database.mySQLconnect());
            cmd.ExecuteReader();
        }
        public ObservableCollection<Asset> viewAsset()
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
                asset.manufacturer = reader.GetString(3);
                asset.type = reader.GetString(4);
                asset.ipAddress = reader.GetString(5);
                assets.Add(asset);
            }
            return assets;

        }
    }

}
