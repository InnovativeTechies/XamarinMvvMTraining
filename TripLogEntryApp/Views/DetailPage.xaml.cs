using System;
using System.Collections.Generic;
using TripLogEntryApp.Models;
using TripLogEntryApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TripLogEntryApp.Views
{
    public partial class DetailPage : ContentPage
    {
        DetailViewModel ViewModel => BindingContext as DetailViewModel;
        public DetailPage(TripLogEntry entry)
        {
            InitializeComponent();
            BindingContext = new DetailViewModel(entry);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(ViewModel.Entry.Latitude, ViewModel.Entry.Longitude), Distance.FromMiles(.5)));
            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = ViewModel.Entry.Title,
                Position = new Position(ViewModel.Entry.Latitude, ViewModel.Entry.Longitude)
            });

        }
    }
}
