using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MTC.DataBase;

namespace MTC
{
    /// <summary>
    /// Логика взаимодействия для TehnologPage.xaml
    /// </summary>
    public partial class TehnologPage : Page
    {
        public List<Client> clientList { get; set; }
        public TehnologPage()
        {
            InitializeComponent();
            clientList = Core.GetClient();
            this.DataContext = this;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddClientWindow addClient = new AddClientWindow();
            addClient.ShowDialog();
            if(addClient.DialogResult == true)
            {
                Update();
            }
        }

        public void Update()
        {
            lv_client.ItemsSource = Core.GetClient();
        }

        private void btn_Service_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TehnologServicePage());
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
