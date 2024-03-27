using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInventory.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MainViewModel : BaseViewModel
    {
        public AuthorViewModel AuthorVM { get; set; }
        public GenreViewModel GenreVM { get; set; }
        public LocationViewModel LocationVM { get; set; }
        public BookViewModel BookVM { get; set; }
        public BookLocationViewModel BookLocationVM { get; set; }

        public MainViewModel()
        {
            AuthorVM = new AuthorViewModel();
            GenreVM = new GenreViewModel();
            LocationVM = new LocationViewModel();
            BookVM = new BookViewModel();
            BookLocationVM = new BookLocationViewModel();
        }
    }
}
