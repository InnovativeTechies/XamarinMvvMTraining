using System;
using System.Threading.Tasks;
using TripLogEntryApp.Interfaces;
using TripLogEntryApp.Models;
using Xamarin.Forms;

namespace TripLogEntryApp.ViewModels
{
    public class NewEntryViewModel:BaseValidationViewModel
    {
        readonly ILocationService _locationService;
        string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                Validate(() => !string.IsNullOrWhiteSpace(_title),
    "Title must be provided.");
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }
        double _latitude;
        public double Latitude
        {
            get => _latitude;
            set
            {
                _latitude = value;
                OnPropertyChanged();
            }
        }
        double _longitude;
        public double Longitude
        {
            get => _longitude;
            set
            {
                _longitude = value;
                OnPropertyChanged();
            }
        }
        DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }
        int _rating;
        public int Rating
        {
            get => _rating;
            set
            {
                _rating = value;
                Validate(() => _rating >= 1 && _rating <= 5,
    "Rating must be between 1 and 5.");
                OnPropertyChanged();
            }
        }
        string _notes;
        public string Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        Command _saveCommand;
        public Command SaveCommand =>
        _saveCommand ?? (_saveCommand = new Command(async () => await Save(), CanSave));

        private bool CanSave(object arg)
        {
            return !string.IsNullOrWhiteSpace(Title)&&!HasErrors;
        }

        private bool CanSave() => !string.IsNullOrWhiteSpace(Title);

        private async Task Save()
        {
            if (IsBusy) return;
            IsBusy = true;
            try
            {
                var newItem = new TripLogEntry
                {
                    Title = Title,
                    Latitude = Latitude,
                    Longitude = Longitude,
                    Date = Date,
                    Rating = Rating,
                    Notes = Notes
                };
                await Task.Delay(3000);
                await NavService.GoBack();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsBusy = false;
            }

            
        }

        public NewEntryViewModel(INavService navService,ILocationService locationService) : base(navService)
        {
            Date = DateTime.Today;
            Rating = 1;
            _locationService = locationService;
        }

        public override async void Init()
        {
            try
            {
                    
                var coords = await _locationService.GetGeoCoordinatesAsync();
                Latitude = coords.Latitude;
                Longitude = coords.Longitude;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
