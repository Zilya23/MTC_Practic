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
    }
}
