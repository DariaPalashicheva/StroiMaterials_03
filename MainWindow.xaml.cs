using StroiMaterials_03.ApplicationData;
using StroiMaterials_03.Views;
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

namespace StroiMaterials_03
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage());
            AppFrame.MainFrame = MainFrame;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if(MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
                BtnProduct.Visibility = Visibility.Hidden;
                return;
            }

            if (AppFrame.DostupRole == 1)
            {
                BtnProduct.Visibility = Visibility.Visible;
            }
            if (AppFrame.DostupRole == 2)
            {
                BtnProduct.Visibility = Visibility.Visible;
            }
            if (AppFrame.DostupRole == 3)
            {
                BtnProduct.Visibility = Visibility.Hidden;
            }
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductPage());
        }
    }
}
