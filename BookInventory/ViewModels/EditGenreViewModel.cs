using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookInventory.Models;
using System.Windows.Input;
using BookInventory.Helpers;
using Microsoft.EntityFrameworkCore;
using BookInventory.Contexts;
using System.Windows;

namespace BookInventory.ViewModels
{
    public class EditGenreViewModel : BaseViewModel
    {
        private Genre _genre;
        private string _genreName;
        private BookInventoryContexts _context;

        public EditGenreViewModel(Genre genre, BookInventoryContexts context)
        {
            _genre = genre;
            GenreID = genre.genre_id;
            GenreName = genre.name;
            SaveCommand = new RelayCommand(_ => Save());
            _context = context;
        }

        public int GenreID { get; set; }

        public string GenreName
        {
            get { return _genreName; }
            set
            {
                _genreName = value;
                OnPropertyChanged(nameof(GenreName));
            }
        }

        public ICommand SaveCommand { get; private set; }

        private void Save()
        {
            _genre.name = GenreName;
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
