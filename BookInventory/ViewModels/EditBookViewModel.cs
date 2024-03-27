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
    public class EditBookViewModel : BaseViewModel
    {
        private Book _book;
        private string _title;
        private int _authorID;
        private int _genreID;
        private int _quantity;
        private BookInventoryContexts _context;

        public EditBookViewModel(Book book, BookInventoryContexts context)
        {
            _book = book;
            BookID = book.book_id;
            _title = book.title;
            _authorID = book.author_id;
            _genreID = book.genre_id;
            _quantity = book.quantity;
            _context = context;
            SaveCommand = new RelayCommand(_ => Save());
        }

        public int BookID { get; set; }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public int AuthorID
        {
            get { return _authorID; }
            set
            {
                _authorID = value;
                OnPropertyChanged(nameof(AuthorID));
            }
        }

        public int GenreID
        {
            get { return _genreID; }
            set
            {
                _genreID = value;
                OnPropertyChanged(nameof(GenreID));
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
            _book.title = Title;
            _book.author_id = AuthorID;
            _book.genre_id = GenreID;
            _book.quantity = Quantity;
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