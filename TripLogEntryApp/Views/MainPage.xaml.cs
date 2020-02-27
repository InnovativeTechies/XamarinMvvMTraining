
using System;
using System.Collections.Generic;
using TripLogEntryApp.Models;
using Xamarin.Forms;
using System.Linq;
using TripLogEntryApp.ViewModels;
using TripLogEntryApp.Interfaces;

namespace TripLogEntryApp.Views
{
    public partial class MainPage : ContentPage
    {
        MainViewModel ViewModel => BindingContext as MainViewModel;
        public MainPage()
        {
            InitializeComponent();
 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel?.Init();
        }
    }
}
