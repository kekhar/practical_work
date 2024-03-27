using BookInventory.Contexts;
using BookInventory.Helpers;
using BookInventory.Models;
using BookInventory.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace BookInventory.ViewModels
{
    public class AddBookViewModel : BaseViewModel
    {
        private readonly BookInventoryContexts _context;
        private string _title;
        private int _authorID;
        private int _genreID;
        private int _quantity;

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

        public AddBookViewModel(BookInventoryContexts context)
        {
            _context = context;
            SaveCommand = new RelayCommand(_ => Save());
        }

        private void Save()
        {
            Book newBook = new Book
            {
                title = Title,
                author_id = AuthorID,
                genre_id = GenreID,
                quantity = Quantity
            };
            _context.Books.Add(newBook);
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
