using BookInventory.Contexts;
using BookInventory.Helpers;
using BookInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace BookInventory.ViewModels
{
    public class EditLocationViewModel : BaseViewModel
    {
        private Location _location;
        private string _locationName;
        private BookInventoryContexts _context;

        public EditLocationViewModel(Location location, BookInventoryContexts context)
        {
            _location = location;
            _locationName = location.name;
            _context = context;
            SaveCommand = new RelayCommand(_ => Save());
        }

        private int _locationID;
        public int LocationID
        {
            get { return _locationID; }
            set
            {
                _locationID = value;
                OnPropertyChanged(nameof(LocationID));
            }
        }

        public string LocationName
        {
            get { return _locationName; }
            set
            {
                _locationName = value;
                OnPropertyChanged(nameof(LocationName));
            }
        }

        public ICommand SaveCommand { get; private set; }

        private void Save()
        {
            _location.name = LocationName;
            _context.SaveChanges();
            CloseWindow();
        }

        private void CloseWindow()
        {
            var currentWindow = System.Windows.Application.Current.Windows.OfType<System.Windows.Window>().FirstOrDefault(w => w.DataContext == this);
            currentWindow?.Close();
        }
    }
}
