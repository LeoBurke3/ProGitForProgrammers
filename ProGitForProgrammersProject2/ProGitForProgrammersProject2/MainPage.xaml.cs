﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProGitForProgrammersProject2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();
            
            Asset asset = new Asset();
            asset.autoAsset();
            //Software_Asset soft = new Software_Asset();
            //soft.autoSoftAsset();
        }

        private void Add_Employee_Popup(object sender, RoutedEventArgs e)
        {
           Add_Employee_Form.IsOpen = true;
        }
        private void Add_Asset_Popup(object sender, RoutedEventArgs e)
        {
            Nav_Pop_Add_Asset.IsOpen = true;
            
        }

        private void Add_Asset_Click(object sender, RoutedEventArgs e)
        {
            Asset asset = new Asset
            {
                name = assetName.Text,
                model = assetModel.Text,
                manufacturer = assetManu.Text,
                type = assetType.Text,
                ipAddress = assetIP.Text
            };
            asset.addAsset(asset);
        }

        private void View_Employee_Popup(object sender, RoutedEventArgs e)
        {
            Nav_Pop_View_Employee.IsOpen = true;
            Employee employee = new Employee();
            StaffList.ItemsSource = employee.viewEmployee();

        }
        private void Add_Employee_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee
            {
                firstName = employeeFirstname.Text,
                surname = employeeSurname.Text,
                email = employeeEmail.Text
           
            };
            employee.addEmployee(employee);
        }
        private void View_Asset_Popup(object sender, RoutedEventArgs e)
        {
            Nav_Pop_View_Asset.IsOpen = true;
            Asset asset = new Asset();
            AssetList.ItemsSource = asset.viewAsset();
        }
    }
}
