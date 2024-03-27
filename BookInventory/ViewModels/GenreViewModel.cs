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
    public class GenreViewModel : BaseViewModel
    {
        private ObservableCollection<Genre> _genres;
        private Genre _selectedGenre;
        private BookInventoryContexts _context;
        private string _newGenreName;

        public ObservableCollection<Genre> Genres
        {
            get { return _genres; }
            set
            {
                _genres = value;
                OnPropertyChanged(nameof(Genres));
            }
        }

        public Genre SelectedGenre
        {
            get { return _selectedGenre; }
            set
            {
                _selectedGenre = value;
                OnPropertyChanged(nameof(SelectedGenre));
            }
        }

        public string NewGenreName
        {
            get { return _newGenreName; }
            set
            {
                _newGenreName = value;
                OnPropertyChanged(nameof(NewGenreName));
            }
        }

        public GenreViewModel()
        {
            _context = new BookInventoryContexts();
            AddGenreCommand = new RelayCommand(_ => AddGenre());
            LoadGenresCommand = new RelayCommand(_ => LoadGenres());
            EditGenreCommand = new RelayCommand(_ => EditGenre());
            DeleteGenreCommand = new RelayCommand(_ => DeleteGenre());
            LoadGenres();
        }

        private void LoadGenres()
        {
            Genres = new ObservableCollection<Genre>(_context.Genres.ToList());
        }

        public ICommand AddGenreCommand { get; private set; }
        public ICommand LoadGenresCommand { get; private set; }
        public ICommand EditGenreCommand { get; private set; }
        public ICommand DeleteGenreCommand { get; private set; }

        private void AddGenre()
        {
            Genre newGenre = new Genre { name = NewGenreName };
            _context.Genres.Add(newGenre);
            _context.SaveChanges();
            LoadGenres();
            NewGenreName = string.Empty;
        }

        private void EditGenre()
        {
            if (SelectedGenre != null)
            {
                EditGenreViewModel viewModel = new EditGenreViewModel(SelectedGenre, _context);
                EditGenreWindow window = new EditGenreWindow(viewModel);
                window.Owner = App.Current.MainWindow;
                window.ShowDialog();
                LoadGenres();
            }
        }

        private void DeleteGenre()
        {
            if (SelectedGenre != null)
            {
                _context.Genres.Remove(SelectedGenre);
                _context.SaveChanges();
                LoadGenres();
            }
        }
    }
}
