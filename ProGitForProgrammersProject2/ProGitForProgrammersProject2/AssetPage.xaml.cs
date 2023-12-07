using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    /// 

    // Code to use
    //var asset = AssetList.SelectedItem as Asset;
    //var msg = new MessageDialog("Item Clicked" + asset.aid).ShowAsync();
    public sealed partial class AssetPage : Page
    {
        
        public AssetPage()
        {
            this.InitializeComponent();
            Asset asset = new Asset();
            AssetList.ItemsSource = asset.viewAsset();
            
        }

        private void LinkButton_Click(object sender, RoutedEventArgs e)
        {
            if (AssetList.SelectedValue != null && employeeID_Input.Text != "") 
            {
                try
                {
                    var asset1 = AssetList.SelectedItem as Asset;
                    Asset asset = new Asset();
                    asset.linkAsset(asset1.aid, employeeID_Input.Text);

                    var msg4 = new MessageDialog("Asset linked!").ShowAsync();
                } catch(Exception ex)
                {
                    var msg3 = new Exception(ex.Message);
                }
            } else
            {
                var msg2 = new MessageDialog("Missing input.").ShowAsync();
            }
        }

        private void AssetList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void AssetList_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
