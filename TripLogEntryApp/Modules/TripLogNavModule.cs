using System;
using Ninject.Modules;
using TripLogEntryApp.Interfaces;
using TripLogEntryApp.Services;
using TripLogEntryApp.ViewModels;
using TripLogEntryApp.Views;

namespace TripLogEntryApp.Modules
{
    public class TripLogNavModule : NinjectModule
    {
        public override void Load()
        {
            var navService = new XamarinFormsNavService();
            // Register view mappings 
            navService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));
            navService.RegisterViewMapping(typeof(DetailViewModel), typeof(DetailPage));
            navService.RegisterViewMapping(typeof(NewEntryViewModel), typeof(NewEntryPage));
            Bind<INavService>()
                 .ToMethod(x => navService)
                 .InSingletonScope();
        }
    }
}
