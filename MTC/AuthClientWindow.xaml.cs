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
    /// Логика взаимодействия для AuthClientWindow.xaml
    /// </summary>
    public partial class AuthClientWindow : Window
    {
        public AuthClientWindow()
        {
            InitializeComponent();
        }

        private void btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            Client client = Core.AuthClient(tb_num.Text);
            if (client != null)
            {
                AuthorizationPage.client = client;
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Клиент с данным номером не зарегистрирован в системе");
                this.DialogResult = false;
            }
        }

        private void tb_num_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
