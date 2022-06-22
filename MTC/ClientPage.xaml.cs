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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public List<Call> calls { get; set; } 
        public static Client client1 { get; set; }
        public ClientPage(Client client)
        {
            InitializeComponent();
            client1 = client;
            calls = Core.GetClietCall(client.ID);
            this.DataContext = this;
        }

        private void lv_call_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lv_call.SelectedItem != null)
            {
                Call call = lv_call.SelectedItem as Call;
                if(call.ID_Status == 1)
                {
                    PayCallWindow payCall = new PayCallWindow(call);
                    payCall.ShowDialog();
                    Update();
                }
            }
        }

        public void Update()
        {
            lv_call.ItemsSource = Core.GetClietCall(client1.ID);
        }
    }
}
