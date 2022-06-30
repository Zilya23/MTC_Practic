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

namespace MTC
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            string name = tb_FIO.Text;
            string tel = tb_tel.Text;
            string addres = tb_addres.Text;
            if (tel.Length == 11)
            {
                if (Core.AddClient(name, tel, addres))
                {
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Пользователь с таким телефоном уже существует");
                }
            }
            else
            {
                MessageBox.Show("Введите верный номер");
            }
        }

        private void tb_tel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void tb_FIO_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
