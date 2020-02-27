using System;
using TripLogEntryApp.Models;
using Xamarin.Forms;

namespace TripLogEntryApp.ViewModels
{
    public class NewEntryViewModel:BaseValidationViewModel
    {
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
        public Command SaveCommand => _saveCommand ?? (_saveCommand = new Command(Save,CanSave));

        private bool CanSave(object arg)
        {
            return !string.IsNullOrWhiteSpace(Title)&&!HasErrors;
        }

        private bool CanSave() => !string.IsNullOrWhiteSpace(Title);

        private void Save(object obj)
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

        }

        public NewEntryViewModel()
        {
            Date = DateTime.Today;
            Rating = 1;
        }
    }
}
