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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            // Вывод списка из БД
            DGrid.ItemsSource = TradeEntities.GetContext().Product.ToList();
            
            if (AppFrame.DostupRole == 1)
            {
                BtnAdd.Visibility = Visibility.Visible;
                BtnDelete.Visibility = Visibility.Visible;
                ColumnEdit.Visibility = Visibility.Visible;
            }
            if (AppFrame.DostupRole == 2)
            {
                BtnAdd.Visibility = Visibility.Hidden;
                BtnDelete.Visibility = Visibility.Hidden;
                ColumnEdit.Visibility = Visibility.Hidden;
            }
            if (AppFrame.DostupRole == 3)
            {
                BtnAdd.Visibility = Visibility.Hidden;
                BtnDelete.Visibility = Visibility.Hidden;
                ColumnEdit.Visibility = Visibility.Hidden;
            }
        }
        // Обновление данных списка
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                TradeEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid.ItemsSource = TradeEntities.GetContext().Product.ToList();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = DGrid.SelectedItems.Cast<Product>().ToList();

            if (MessageBox.Show($"Вы действительно хотите удалить следующие {ForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TradeEntities.GetContext().Product.RemoveRange(ForRemoving);
                    TradeEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGrid.ItemsSource = TradeEntities.GetContext().Product.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new ProductAddEdit(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new ProductAddEdit((sender as Button).DataContext as Product));
        }
    }
}
