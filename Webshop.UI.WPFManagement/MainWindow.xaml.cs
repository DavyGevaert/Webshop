using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Webshop.Model;
using Webshop.Sdk;
using Webshop.Sdk.Abstractions;

namespace Webshop.UI.WPFManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IItemApi _api;

        public MainWindow(IItemApi api)
        {

            InitializeComponent();
            this._api = api;
        }

        public MainWindow()
        {
        }

        private async void LoadItems()
        {
            var list = await _api.FindAsync();
            lvItems.ItemsSource = list;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadItems();
        }
    }
}