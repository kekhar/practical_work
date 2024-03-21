using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Products.Contexts;
using Products.Models;

namespace Products.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            LoadProducts();
        }

        public void LoadProducts()
        {
            using (var context = new ProductContext())
            {
                Products = new ObservableCollection<Product>(context.Products.ToList());
            }
        }

        public void AddProduct(Product newProduct)
        {
            using (var context = new ProductContext())
            {
                context.Products.Add(newProduct);
                context.SaveChanges();
                Products.Add(newProduct);
            }
        }

        public void DeleteProduct(Product product)
        {
            using (var context = new ProductContext())
            {
                var productToDelete = context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (productToDelete != null)
                {
                    context.Products.Remove(productToDelete);
                    context.SaveChanges();
                    Products.Remove(product);
                }
            }
        }
    }
}
