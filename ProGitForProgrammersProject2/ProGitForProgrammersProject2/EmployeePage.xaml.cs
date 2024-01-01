using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProGitForProgrammersProject2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            this.InitializeComponent();
            Employee employee = new Employee();
            StaffList.ItemsSource = employee.viewEmployee();
        }
        public void Delete_Employee()
        {
            if(StaffList.SelectedItem != null)
            {
                try
                {
                    var selectedItem = StaffList.SelectedItem as Employee;
                    Employee employee = new Employee();
                    employee.deleteEmployee(selectedItem.employeeID);
                }
                catch (Exception ex)
                {
                    var txt = ex.Message;
                    var msg = new MessageDialog(txt).ShowAsync();
                }
            }
        }
    }
}
