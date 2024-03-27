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
using Microsoft.EntityFrameworkCore;
using BookInventory.Xaml;

namespace BookInventory.ViewModels
{
    public class AuthorViewModel : BaseViewModel
    {
        private ObservableCollection<Author> _authors;
        private Author _selectedAuthor;
        private BookInventoryContexts _context;
        private string _newAuthorName;

        public ObservableCollection<Author> Authors
        {
            get { return _authors; }
            set
            {
                _authors = value;
                OnPropertyChanged(nameof(Authors));
            }
        }

        public Author SelectedAuthor
        {
            get { return _selectedAuthor; }
            set
            {
                _selectedAuthor = value;
                OnPropertyChanged(nameof(SelectedAuthor));
            }
        }

        public string NewAuthorName
        {
            get { return _newAuthorName; }
            set
            {
                _newAuthorName = value;
                OnPropertyChanged(nameof(NewAuthorName));
            }
        }

        public ICommand LoadAuthorsCommand { get; private set; }
        public ICommand AddAuthorCommand { get; private set; }
        public ICommand UpdateAuthorCommand { get; private set; }
        public ICommand DeleteAuthorCommand { get; private set; }
        public ICommand EditAuthorCommand { get; private set; }

        public AuthorViewModel()
        {
            _context = new BookInventoryContexts();
            LoadAuthorsCommand = new RelayCommand(_ => LoadAuthors());
            AddAuthorCommand = new RelayCommand(_ => AddAuthor());
            UpdateAuthorCommand = new RelayCommand(_ => UpdateAuthor());
            DeleteAuthorCommand = new RelayCommand(_ => DeleteAuthor());
            EditAuthorCommand = new RelayCommand(_ => EditAuthor());
            LoadAuthors();
        }

        private void LoadAuthors()
        {
            Authors = new ObservableCollection<Author>(_context.Authors.ToList());
        }

        private void AddAuthor()
        {
                Author newAuthor = new Author { name = NewAuthorName };
                _context.Authors.Add(newAuthor);
                _context.SaveChanges();
                LoadAuthors();
                NewAuthorName = string.Empty;
        }

        private void UpdateAuthor()
        {
            if (SelectedAuthor != null)
            {
                _context.Entry(SelectedAuthor).State = EntityState.Modified;
                _context.SaveChanges();
                LoadAuthors();
            }
        }

        private void DeleteAuthor()
        {
            if (SelectedAuthor != null)
            {
                _context.Authors.Remove(SelectedAuthor);
                _context.SaveChanges();
                LoadAuthors();
            }
        }
        private void EditAuthor()
        {
            if (SelectedAuthor != null)
            {
                EditAuthorViewModel viewModel = new EditAuthorViewModel(SelectedAuthor);
                EditAuthorWindow window = new EditAuthorWindow(viewModel);

                window.Owner = App.Current.MainWindow;

                window.ShowDialog();
                LoadAuthors();
            }
        }
    }
}