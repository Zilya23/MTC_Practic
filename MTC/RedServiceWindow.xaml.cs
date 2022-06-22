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
using System.Windows.Shapes;
using MTC.DataBase;

namespace MTC
{
    /// <summary>
    /// Логика взаимодействия для RedServiceWindow.xaml
    /// </summary>
    public partial class RedServiceWindow : Window
    {
        public static Service service1;
        public RedServiceWindow(Service service)
        {
            InitializeComponent();
            tb_town.Text = service.Town_Name;
            service1 = service;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            string town_name = tb_town.Text;
            decimal coast = Convert.ToDecimal(tb_coast.Text.Trim());
            decimal sale_coast = Convert.ToDecimal(tb_saleCoast.Text.Trim());
            Core.RedactServices(town_name, coast, sale_coast, service1);
            this.DialogResult = true;
        }

        private void img_del_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Core.DeleteService(service1);
            this.DialogResult = true;
        }
    }
}
