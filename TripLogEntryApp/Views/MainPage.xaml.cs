
using System;
using System.Collections.Generic;
using TripLogEntryApp.Models;
using Xamarin.Forms;
using System.Linq;
using TripLogEntryApp.ViewModels;

namespace TripLogEntryApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
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
