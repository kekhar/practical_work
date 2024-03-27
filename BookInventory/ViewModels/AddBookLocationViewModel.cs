using BookInventory.Contexts;
using BookInventory.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using BookInventory.Models;

namespace BookInventory.ViewModels
{
    public class AddBookLocationViewModel : BaseViewModel
    {
        private readonly BookInventoryContexts _context;
        private int _bookID;
        private int _locationID;
        private int _quantity;

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

        public AddBookLocationViewModel(BookInventoryContexts context)
        {
            _context = context;
            SaveCommand = new RelayCommand(_ => Save());
        }

        private void Save()
        {
            BookLocation newBookLocation = new BookLocation
            {
                book_id = BookID,
                location_id = LocationID,
                quantity = Quantity
            };
            _context.BookLocations.Add(newBookLocation);
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
