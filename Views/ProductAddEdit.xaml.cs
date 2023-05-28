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
    /// Логика взаимодействия для ProductAddEdit.xaml
    /// </summary>
    public partial class ProductAddEdit : Page
    {
        private Product _current = new Product();

        public ProductAddEdit(Product selected)
        {
            InitializeComponent();
            if (selected != null)
                _current = selected;

            DataContext = _current;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_current.ProductArticleNumber))
                errors.AppendLine("Введите артикуль");
            if (string.IsNullOrWhiteSpace(_current.ProductName))
                errors.AppendLine("Введите наименование");
            if (string.IsNullOrWhiteSpace(_current.ProductDescription))
                errors.AppendLine("Введите описание");
            if (string.IsNullOrWhiteSpace(_current.ProductCategory))
                errors.AppendLine("Введите категорию");
            if (string.IsNullOrWhiteSpace(_current.ProductManufacturer))
                errors.AppendLine("Введите производителя");
            if (_current.ProductCost<=0 || TBCost.Text.Any(Char.IsLetter))
                errors.AppendLine("Введите цену");
            if (_current.ProductDiscountAmount < 0 || TBDiscountAmount.Text.Any(Char.IsLetter) || TBDiscountAmount.Text.Length >=3)
                errors.AppendLine("Введите скидку (не более 99)");
            if (_current.ProductQuantityInStock < 0 || TBQuantityInStock.Text.Any(Char.IsLetter))
                errors.AppendLine("Введите Количество");


            if (errors.Length >0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_current.ProductArticleNumber == null)
                TradeEntities.GetContext().Product.Add(_current);

            try
            {
                TradeEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
