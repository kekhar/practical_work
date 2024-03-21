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
using Products.Models;

namespace Products
{
    /// <summary>
    /// Логика взаимодействия для DeleteProductWindow.xaml
    /// </summary>
    public partial class DeleteProductWindow : Window
    {
        public event EventHandler<ProductEventArgs> ProductDeleted;

        private List<Product> _products;

        public DeleteProductWindow(IEnumerable<Product> products)
        {
            InitializeComponent();
            _products = products.ToList();
            ProductsListView.ItemsSource = _products;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = ProductsListView.SelectedItem as Product;
            if (selectedProduct != null)
            {
                _products.Remove(selectedProduct);
                ProductDeleted?.Invoke(this, new ProductEventArgs(selectedProduct));
            }
            else
            {
                MessageBox.Show("Выберите продукт для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
