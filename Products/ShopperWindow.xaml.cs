using Products.ViewModels;
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
    /// Логика взаимодействия для ShopperWindow.xaml
    /// </summary>
    public partial class ShopperWindow : Window
    {
        private readonly ShopperViewModel viewModel;

        public ShopperWindow()
        {
            InitializeComponent();
            viewModel = new ShopperViewModel();
            DataContext = viewModel;
        }

        private void OpenAddShopperWindow_Click(object sender, RoutedEventArgs e)
        {
            AddShopperWindow addShopperWindow = new AddShopperWindow();
            addShopperWindow.ShowDialog();
        }
        private void ReturnToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
