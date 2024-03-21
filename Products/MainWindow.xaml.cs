using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Products;
using Products.Models;
using Products.ViewModels;

namespace Products
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _mainViewModel = new MainViewModel();
            DataContext = _mainViewModel;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.ProductAdded += AddProductWindow_ProductAdded;
            addProductWindow.ShowDialog();
        }

        private void AddProductWindow_ProductAdded(object sender, ProductEventArgs e)
        {
            _mainViewModel.AddProduct(e.NewProduct);
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            DeleteProductWindow deleteProductWindow = new DeleteProductWindow(_mainViewModel.Products);
            deleteProductWindow.ProductDeleted += DeleteProductWindow_ProductDeleted;
            deleteProductWindow.ShowDialog();
        }

        private void DeleteProductWindow_ProductDeleted(object sender, ProductEventArgs e)
        {
            _mainViewModel.DeleteProduct(e.NewProduct);
        }
        private void OpenShopperWindow_Click(object sender, RoutedEventArgs e)
        {
            ShopperWindow shopperWindow = new ShopperWindow();
            shopperWindow.Show();
            this.Close();
        }
    }
}