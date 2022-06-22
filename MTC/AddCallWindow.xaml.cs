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
    /// Логика взаимодействия для AddCallWindow.xaml
    /// </summary>
    public partial class AddCallWindow : Window
    {
        public List<Client> clients { get; set; }
        public List<Service> services { get; set; }
        public AddCallWindow()
        {
            InitializeComponent();
            clients = Core.GetClient();
            services = Core.GetServices();
            cb_num.ItemsSource = clients;
            cb_num.DisplayMemberPath = "Telephone_Number";
            cb_ser.ItemsSource = services;
            cb_ser.DisplayMemberPath = "Town_Name";
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int idClient = (cb_num.SelectedItem as Client).ID;
                int idSer = (cb_ser.SelectedItem as Service).ID;
                DateTime date = (DateTime)dp_date.SelectedDate;
                int dur = Convert.ToInt32(tb_dur.Text);
                Core.AddCall(idClient, idSer, date, dur);
                this.DialogResult = true;
            }
            catch
            {

            }
        }
    }
}
