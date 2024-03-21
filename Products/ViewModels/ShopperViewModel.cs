using Products.Contexts;
using Products.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Products.ViewModels
{
    public class ShopperViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Shopper> _shoppers;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Shopper> Shoppers
        {
            get { return _shoppers; }
            set
            {
                _shoppers = value;
                OnPropertyChanged(nameof(Shoppers));
            }
        }

        public ShopperViewModel()
        {
            LoadShoppers();
        }

        private void LoadShoppers()
        {
            using (var context = new ProductContext())
            {
                Shoppers = new ObservableCollection<Shopper>(context.Shoppers.ToList());
            }
        }

        public void AddShopper(Shopper newShopper)
        {
            using (var context = new ProductContext())
            {
                context.Shoppers.Add(newShopper);
                context.SaveChanges();
                Shoppers.Add(newShopper);
            }
        }
    }
}
