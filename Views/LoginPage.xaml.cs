using StroiMaterials_03.ApplicationData;
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

namespace StroiMaterials_03.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = TradeEntities.GetContext().User.FirstOrDefault(x => x.UserLogin == TBLogin.Text && x.UserPassword == PBPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Введите верные данные чтобы войти!","Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.UserRole)
                    {
                        case 1:
                            MessageBox.Show("Успешный вход","Уведомление", MessageBoxButton.OK,MessageBoxImage.Information);
                            AppFrame.DostupRole = 1;
                            AppFrame.MainFrame.Navigate(new MainPage());
                            break;

                        case 2:
                            MessageBox.Show("Успешный вход","Уведомление", MessageBoxButton.OK,MessageBoxImage.Information);
                            AppFrame.DostupRole = 2;
                            AppFrame.MainFrame.Navigate(new MainPage());
                            break;
                        case 3:
                            MessageBox.Show("Успешный вход", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.DostupRole = 3;
                            AppFrame.MainFrame.Navigate(new MainPage());
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
