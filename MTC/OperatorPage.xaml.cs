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
    /// Логика взаимодействия для OperatorPage.xaml
    /// </summary>
    public partial class OperatorPage : Page
    {
        public List<Call> calls { get; set; }
        public OperatorPage()
        {
            InitializeComponent();
            calls = Core.GetCalls();
            this.DataContext = this;
            List<Call_Status> callss = bd_connection.connection.Call_Status.ToList();
            callss.Insert(0, new Call_Status() { ID = -1, Name = "Все" });
            cb_filtr.ItemsSource = callss;
            cb_filtr.DisplayMemberPath = "Name";
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddCallWindow addCall = new AddCallWindow();
            addCall.ShowDialog();
            Update();
        }

        private void lv_call_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lv_call.SelectedItem != null)
            {
                Call call = lv_call.SelectedItem as Call;
                if (call.ID_Status == 2)
                {
                    CallCheckWindow checkWindow = new CallCheckWindow(call);
                    checkWindow.ShowDialog();
                    Update();
                }
            }
        }

        public void Update()
        {
            lv_call.ItemsSource = Core.GetCalls();
        }

        private void cb_filtr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filtr = bd_connection.connection.Call.ToList();
            if (cb_filtr.SelectedItem != null)
            {
                var i = cb_filtr.SelectedItem as Call_Status;
                if (i.ID != -1)
                {
                    filtr = filtr.Where(x => x.ID_Status == i.ID).ToList();
                    lv_call.ItemsSource = filtr;
                }
                else
                {
                    filtr = bd_connection.connection.Call.ToList();
                    lv_call.ItemsSource = filtr;
                }
            }
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
