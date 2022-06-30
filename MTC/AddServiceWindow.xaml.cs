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
    /// Логика взаимодействия для AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {
        public AddServiceWindow()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (tb_town.Text.Trim().Length != 0 && tb_coast.Text.Trim().Length != 0 && tb_saleCoast.Text.Trim().Length != 0)
            {
                string townName = tb_town.Text.Trim();
                decimal coast = Convert.ToDecimal(tb_coast.Text.Trim());
                decimal sale_coast = Convert.ToDecimal(tb_saleCoast.Text.Trim());
                if (townName.Length != 0)
                {
                    if (Core.AddService(townName, coast, sale_coast))
                    {
                        this.DialogResult = true;
                    }
                    else
                    {
                        MessageBox.Show("Запись с данным гороод уже имелась, запись отредактирована");
                        this.DialogResult = true;
                    }
                }
                else
                {
                    MessageBox.Show("Введите название города");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void tb_town_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void tb_coast_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && e.Text != ",")
            {
                e.Handled = true;
            }
        }
    }
}
