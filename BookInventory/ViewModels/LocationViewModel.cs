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
    public class LocationViewModel : BaseViewModel
    {
        private ObservableCollection<Location> _locations;
        private Location _selectedLocation;
        private BookInventoryContexts _context;
        private string _newLocationName;

        public ObservableCollection<Location> Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                OnPropertyChanged(nameof(Locations));
            }
        }

        public Location SelectedLocation
        {
            get { return _selectedLocation; }
            set
            {
                _selectedLocation = value;
                OnPropertyChanged(nameof(SelectedLocation));
            }
        }

        public string NewLocationName
        {
            get { return _newLocationName; }
            set
            {
                _newLocationName = value;
                OnPropertyChanged(nameof(NewLocationName));
            }
        }

        public ICommand LoadLocationsCommand { get; private set; }
        public ICommand AddLocationCommand { get; private set; }
        public ICommand UpdateLocationCommand { get; private set; }
        public ICommand DeleteLocationCommand { get; private set; }
        public ICommand EditLocationCommand { get; private set; }

        public LocationViewModel()
        {
            _context = new BookInventoryContexts();
            LoadLocationsCommand = new RelayCommand(_ => LoadLocations());
            AddLocationCommand = new RelayCommand(_ => AddLocation());
            UpdateLocationCommand = new RelayCommand(_ => UpdateLocation());
            DeleteLocationCommand = new RelayCommand(_ => DeleteLocation());
            EditLocationCommand = new RelayCommand(_ => EditLocation());
            LoadLocations();
        }

        private void LoadLocations()
        {
            Locations = new ObservableCollection<Location>(_context.Locations.ToList());
        }

        private void AddLocation()
        {
            Location newLocation = new Location { name = NewLocationName };
            _context.Locations.Add(newLocation);
            _context.SaveChanges();
            LoadLocations();
            NewLocationName = string.Empty;
        }

        private void UpdateLocation()
        {
            if (SelectedLocation != null)
            {
                _context.Entry(SelectedLocation).State = EntityState.Modified;
                _context.SaveChanges();
                LoadLocations();
            }
        }

        private void DeleteLocation()
        {
            if (SelectedLocation != null)
            {
                _context.Locations.Remove(SelectedLocation);
                _context.SaveChanges();
                LoadLocations();
            }
        }

        private void EditLocation()
        {
            if (SelectedLocation != null)
            {
                EditLocationViewModel viewModel = new EditLocationViewModel(SelectedLocation, _context);
                viewModel.LocationID = SelectedLocation.location_id;
                EditLocationWindow window = new EditLocationWindow(viewModel);
                window.Owner = App.Current.MainWindow;
                window.ShowDialog();
                LoadLocations();
            }
        }
    }
}
