using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TripLogEntryApp.Interfaces;
using TripLogEntryApp.ViewModels;
using Xamarin.Forms;

namespace TripLogEntryApp.Views
{
    public partial class NewEntryPage : ContentPage
    {
        NewEntryViewModel ViewModel =>
      BindingContext as NewEntryViewModel;
        public NewEntryPage()
        {
            InitializeComponent();
            BindingContextChanged += Page_BindingContextChanged;
            BindingContext = new NewEntryViewModel(DependencyService.Get<INavService>(),DependencyService.Get<ILocationService>());
        }
        void Page_BindingContextChanged(object sender, EventArgs e)
        {
            ViewModel.ErrorsChanged += ViewModel_ErrorsChanged;
        }

        private void ViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            var propHasErrors = (ViewModel.GetErrors(e.PropertyName)
    as List<string>)?.Any() == true;
            switch (e.PropertyName)
            {
                case nameof(ViewModel.Title):
                    title.LabelColor = propHasErrors
                        ? Color.Red : Color.Black;
                    break;
                case nameof(ViewModel.Rating):
                    rating.LabelColor = propHasErrors
                        ? Color.Red : Color.Black;
                    break;
                default:
                    break;
            }
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
        }

    }
}
