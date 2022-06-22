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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static User user;
        public static Client client { get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btn_auth_Click(object sender, RoutedEventArgs e)
        {
            string login = tb_login.Text.Trim();
            string password = tb_pass.Password.Trim();
            user = Core.AuthorizationUser(login, password);
            if(user != null)
            {
                if(user.ID_Post == 1)
                {
                    NavigationService.Navigate(new TehnologPage());
                }
                else if(user.ID_Post == 2)
                {
                    NavigationService.Navigate(new OperatorPage());
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_reg_Click(object sender, RoutedEventArgs e)
        {
            AuthClientWindow authClientWindow = new AuthClientWindow();
            authClientWindow.ShowDialog();
            if(authClientWindow.DialogResult == true)
            {
                NavigationService.Navigate(new ClientPage(client));
            }
            else
            {

            }
        }
    }
}
