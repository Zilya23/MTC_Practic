using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using MTC.DataBase;

namespace MTC
{
    /// <summary>
    /// Логика взаимодействия для PayCallWindow.xaml
    /// </summary>
    public partial class PayCallWindow : Window
    {
        public Call call1 { get; set; }
        public PayCallWindow(Call call)
        {
            InitializeComponent();
            call1 = call;
            tb_date.Text = call.Call_Date.ToString();
            tb_dur.Text = call.Duration.ToString();
            tb_num.Text = call.Client.Telephone_Number;
            tb_ser.Text = call.Service.Town_Name;
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.jpg|*.jpg|*.png|*.png"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                call1.Receipt = File.ReadAllBytes(openFile.FileName);
                img.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            call1.ID_Status = 2;
            bd_connection.connection.SaveChanges();
            this.DialogResult = true;
        }
    }
}
