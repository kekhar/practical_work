using BookInventory.Contexts;
using BookInventory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BookInventory.Helpers;
using BookInventory.Xaml;

namespace BookInventory.ViewModels
{
    public class BookLocationViewModel : BaseViewModel
    {
        private ObservableCollection<BookLocation> _bookLocations;
        private BookLocation _selectedBookLocation;
        private readonly BookInventoryContexts _context;

        public ObservableCollection<BookLocation> BookLocations
        {
            get { return _bookLocations; }
            set
            {
                _bookLocations = value;
                OnPropertyChanged(nameof(BookLocations));
            }
        }

        public BookLocation SelectedBookLocation
        {
            get { return _selectedBookLocation; }
            set
            {
                _selectedBookLocation = value;
                OnPropertyChanged(nameof(SelectedBookLocation));
            }
        }

        public ICommand OpenAddBookLocationWindowCommand { get; private set; }
        public ICommand LoadBookLocationsCommand { get; private set; }
        public ICommand EditBookLocationCommand { get; private set; }
        public ICommand DeleteBookLocationCommand { get; private set; }

        public BookLocationViewModel()
        {
            _context = new BookInventoryContexts();
            LoadBookLocationsCommand = new RelayCommand(_ => LoadBookLocations());
            EditBookLocationCommand = new RelayCommand(_ => EditBookLocation());
            DeleteBookLocationCommand = new RelayCommand(_ => DeleteBookLocation());
            OpenAddBookLocationWindowCommand = new RelayCommand(_ => AddBookLocationWindow());
            LoadBookLocations();
        }

        private void LoadBookLocations()
        {
            BookLocations = new ObservableCollection<BookLocation>(_context.BookLocations.ToList());
        }

        private void EditBookLocation()
        {
            if (SelectedBookLocation != null)
            {
                EditBookLocationViewModel viewModel = new EditBookLocationViewModel(SelectedBookLocation, _context);
                EditBookLocationWindow window = new EditBookLocationWindow(viewModel);
                window.Owner = App.Current.MainWindow;
                window.ShowDialog();
                LoadBookLocations();
            }
        }

        private void DeleteBookLocation()
        {
            if (SelectedBookLocation != null)
            {
                _context.BookLocations.Remove(SelectedBookLocation);
                _context.SaveChanges();
                LoadBookLocations();
            }
        }

        private void AddBookLocationWindow()
        {
            AddBookLocationWindow addBookLocationWindow = new AddBookLocationWindow();
            AddBookLocationViewModel addBookLocationViewModel = new AddBookLocationViewModel(_context);
            addBookLocationWindow.DataContext = addBookLocationViewModel;
            addBookLocationWindow.ShowDialog();
            LoadBookLocations();
        }

    }
}
