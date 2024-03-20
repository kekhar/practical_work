using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Products.Contexts;
using Products.Models;

namespace Products.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MainViewModel()
        {
            using (var context = new ProductContext())
            {
                Products = context.Products.ToList();
            }
        }


        private IEnumerable<Product> _Products;
        public IEnumerable<Product> Products
        {
            get
            {
                return _Products;
            }
            set
            {
                _Products = value;
                OnPropertyChanged();
            }
        }
    }
}
