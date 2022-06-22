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
    /// Логика взаимодействия для CallCheckWindow.xaml
    /// </summary>
    public partial class CallCheckWindow : Window
    {
        public static Call call1 { get; set; }
        public CallCheckWindow(Call call)
        {
            InitializeComponent();
            call1 = call;
            tb_date.Text = call.Call_Date.ToString();
            tb_dur.Text = call.Duration.ToString();
            tb_num.Text = call.Client.Telephone_Number;
            tb_ser.Text = call.Service.Town_Name;
            this.DataContext = this;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            Core.CallOk(call1);
            this.DialogResult = true;
        }

        private void btn_nook_Click(object sender, RoutedEventArgs e)
        {
            Core.CallNoOk(call1);
            this.DialogResult = true;
        }
    }
}
