using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
            Software_Asset soft = new Software_Asset();
            soft.autoSoftAsset();
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {

            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;
                switch (item.Tag.ToString()) 
                {
                    case "employees":
                        ContentFrame.Navigate(typeof(EmployeePage));
                        break;
                    case "assets":
                        ContentFrame.Navigate(typeof(AssetPage));
                        break;
                    case "software_assets":
                        ContentFrame.Navigate(typeof(SoftwareAssetPage));
                        break;
                    case "home":
                        ContentFrame.Navigate (typeof(HomePage));
                        break;

                }
            }
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(HomePage));
        }
    }
}
