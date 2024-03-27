using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookInventory.Helpers;
using BookInventory.Models;
using System.Windows.Input;
using System.Windows;

namespace BookInventory.ViewModels
{
     public class EditAuthorViewModel : BaseViewModel
    {
        private Author _author;
        private string _authorName;


        public EditAuthorViewModel(Author author)
        {
            _author = author;
            AuthorID = author.author_id;
            AuthorName = author.name;
            SaveCommand = new RelayCommand(_ => Save());
        }

        public int AuthorID { get; set; }

        public string AuthorName
        {
            get { return _authorName; }
            set
            {
                _authorName = value;
                OnPropertyChanged(nameof(AuthorName));
            }
        }

        public ICommand SaveCommand { get; private set; }

        private void Save()
        {
            _author.name = AuthorName;
            CloseWindow();
        }
        private void CloseWindow()
        {
            var currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.DataContext == this);
            currentWindow?.Close();
        }
    }
}
