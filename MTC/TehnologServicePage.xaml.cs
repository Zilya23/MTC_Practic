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
    /// Логика взаимодействия для TehnologServicePage.xaml
    /// </summary>
    public partial class TehnologServicePage : Page
    {
        public static List<Service> services { get; set; }
        public TehnologServicePage()
        {
            InitializeComponent();
            services = Core.GetServices();
            this.DataContext = this;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddServiceWindow addService = new AddServiceWindow();
            addService.ShowDialog();
            Update();
        }

        private void btn_ClientReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TehnologPage());
        }

        public void Update()
        {
            lv_service.ItemsSource = Core.GetServices();
        }

        private void lv_service_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lv_service.SelectedItem != null)
            {
                Service service = (sender as ListView).SelectedItem as Service;
                RedServiceWindow redService = new RedServiceWindow(service);
                redService.ShowDialog();
                Update();
            }
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
