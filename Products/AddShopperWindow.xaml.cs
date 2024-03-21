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
using Products.ViewModels;

namespace Products
{
    /// <summary>
    /// Логика взаимодействия для AddShopperWindow.xaml
    /// </summary>
    public partial class AddShopperWindow : Window
    {
        public AddShopperWindow()
        {
            InitializeComponent();
            DataContext = new ShopperViewModel();
        }

        private void AddShopper_Click(object sender, RoutedEventArgs e)
        {
            var newShopper = new Shopper
            {
                ShopperID = int.Parse(txtShopperID.Text),
                ShopperName = txtShopperName.Text,
                Male = radMale.IsChecked ?? false,
                ProductID = (int)cmbProduct.SelectedValue
            };

            var viewModel = DataContext as ShopperViewModel;

            viewModel?.AddShopper(newShopper);

            this.Close();
        }
    }
}
