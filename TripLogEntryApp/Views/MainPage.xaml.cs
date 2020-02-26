
using System;
using System.Collections.Generic;
using TripLogEntryApp.Models;
using Xamarin.Forms;
using System.Linq;

namespace TripLogEntryApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var items = new List<TripLogEntry>
        {
            new TripLogEntry
            {
                Title = "Washington Monument",
                Notes = "Amazing!",
                Rating = 3,
                Date = new DateTime(2019, 2, 5),
                Latitude = 38.8895,
                Longitude = -77.0352
            },
            new TripLogEntry
            {
                Title = "Statue of Liberty",
                Notes = "Inspiring!",
                Rating = 4,
                Date = new DateTime(2019, 4, 13),
                Latitude = 40.6892,
                Longitude = -74.0444
            },
            new TripLogEntry
            {
                Title = "Golden Gate Bridge",
                Notes = "Foggy, but beautiful.",
                Rating = 5,
                Date = new DateTime(2019, 4, 26),
                Latitude = 37.8268,
                Longitude = -122.4798
            }
        };
            trips.ItemsSource = items;
        }

        void New_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewEntryPage());
        }

        async void trips_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var trip = (TripLogEntry)e.CurrentSelection.FirstOrDefault();
            if (trip!=null)
            {
                await Navigation.PushAsync(new DetailPage(trip));
            }

            trips.SelectedItem = null;
        }
    }
}
