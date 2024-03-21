using Products.Models;
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

namespace Products
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public event EventHandler<ProductEventArgs> ProductAdded;

        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            Product newProduct = new Product
            {
                ProductID = int.Parse(ProductIDTextBox.Text),
                ProductName = ProductNameTextBox.Text,
                Category = CategoryTextBox.Text,
                Price = decimal.Parse(PriceTextBox.Text),
                ArrivalDate = ArrivalDatePicker.SelectedDate ?? DateTime.Now.Date
            };

            ProductAdded?.Invoke(this, new ProductEventArgs(newProduct));
            this.Close();
        }
    }
}
