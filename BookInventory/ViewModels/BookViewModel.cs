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
    public class BookViewModel : BaseViewModel
    {
        private ObservableCollection<Book> _books;
        private Book _selectedBook;
        private string _newBookTitle;
        private readonly BookInventoryContexts _context;

        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        public string NewBookTitle
        {
            get { return _newBookTitle; }
            set
            {
                _newBookTitle = value;
                OnPropertyChanged(nameof(NewBookTitle));
            }
        }

        public ICommand AddBookCommand { get; private set; }
        public ICommand LoadBooksCommand { get; private set; }
        public ICommand EditBookCommand { get; private set; }
        public ICommand DeleteBookCommand { get; private set; }

        public BookViewModel()
        {
            _context = new BookInventoryContexts();
            LoadBooksCommand = new RelayCommand(_ => LoadBooks());
            EditBookCommand = new RelayCommand(_ => EditBook());
            DeleteBookCommand = new RelayCommand(_ => DeleteBook());
            OpenAddBookWindowCommand = new RelayCommand(_ => OpenAddBookWindow());
            LoadBooks();
        }

        public ICommand OpenAddBookWindowCommand { get; private set; }

        private void OpenAddBookWindow()
        {
            AddBookWindow addBookWindow = new AddBookWindow();
            AddBookViewModel addBookViewModel = new AddBookViewModel(_context);
            addBookWindow.DataContext = addBookViewModel;
            addBookWindow.ShowDialog();
            LoadBooks();
        }

        private void LoadBooks()
        {
            Books = new ObservableCollection<Book>(_context.Books.ToList());
        }

        private void EditBook()
        {
            if (SelectedBook != null)
            {
                EditBookViewModel viewModel = new EditBookViewModel(SelectedBook, _context);
                EditBookWindow window = new EditBookWindow(viewModel);
                window.Owner = App.Current.MainWindow;
                window.ShowDialog();
                LoadBooks();
            }
        }

        private void DeleteBook()
        {
            if (SelectedBook != null)
            {
                _context.Books.Remove(SelectedBook);
                _context.SaveChanges();
                LoadBooks();
            }
        }
    }
}
