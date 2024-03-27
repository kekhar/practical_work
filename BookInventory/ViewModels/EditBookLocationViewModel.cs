using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookInventory.Contexts;
using BookInventory.Helpers;
using BookInventory.Models;
using System.Windows.Input;
using System.Windows;

namespace BookInventory.ViewModels
{
    public class EditBookLocationViewModel : BaseViewModel
    {
        private BookLocation _bookLocation;
        private int _bookLocationID;
        private int _bookID;
        private int _locationID;
        private int _quantity;
        private BookInventoryContexts _context;

        public EditBookLocationViewModel(BookLocation bookLocation, BookInventoryContexts context)
        {
            _bookLocation = bookLocation;
            BookLocationID = bookLocation.book_location_id;
            BookID = bookLocation.book_id;
            LocationID = bookLocation.location_id;
            Quantity = bookLocation.quantity;
            _context = context;
            SaveCommand = new RelayCommand(_ => Save());
        }

        public int BookLocationID
        {
            get { return _bookLocationID; }
            set
            {
                _bookLocationID = value;
                OnPropertyChanged(nameof(BookLocationID));
            }
        }

        public int BookID
        {
            get { return _bookID; }
            set
            {
                _bookID = value;
                OnPropertyChanged(nameof(BookID));
            }
        }

        public int LocationID
        {
            get { return _locationID; }
            set
            {
                _locationID = value;
                OnPropertyChanged(nameof(LocationID));
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public ICommand SaveCommand { get; private set; }

        private void Save()
        {
            _bookLocation.book_id = BookID;
            _bookLocation.location_id = LocationID;
            _bookLocation.quantity = Quantity;
            _context.SaveChanges();
            CloseWindow();
        }

        private void CloseWindow()
        {
            var currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.DataContext == this);
            currentWindow?.Close();
        }
    }
}
