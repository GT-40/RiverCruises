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

namespace Курсовой_проект_ТРЗБД
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RiverCruisesEntities DataBase = new RiverCruisesEntities();

        public MainWindow()
        {
            InitializeComponent();

            
        }


        private void BuyTicketMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuGrid.Visibility = Visibility.Hidden;
            BuyTicketGrid.Visibility = Visibility.Visible;
        }

        private void AuthoriseBackToMM_Click(object sender, RoutedEventArgs e)
        {
            AuthoriseGrid.Visibility = Visibility.Hidden;
            MenuGrid.Visibility = Visibility.Visible;
            LoginInputTB.Text = null;
            PasswordInputTB.Text = null;
        }

        private void AuthoriseStafMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuGrid.Visibility = Visibility.Hidden;
            AuthoriseGrid.Visibility = Visibility.Visible;
        }

        private void AuthoriseBTN_Click(object sender, RoutedEventArgs e)
        {
            var res = from Staff in DataBase.Staff where Staff.Login == LoginInputTB.Text && Staff.Password == PasswordInputTB.Text select Staff;

            if (res.Count()==1)
            {
                AuthoriseGrid.Visibility = Visibility.Hidden;
                ManageScreen.Visibility = Visibility.Visible;
                Greatings.Content += $"Добро пожаловать, {res.First().Surname} {res.First().Name}!";
            }
            else
            {
                MessageBox.Show("Указан неверный логин или пароль.", "Ошибка авторизации!", MessageBoxButton.OK);
            }

            

        }
    }
}
