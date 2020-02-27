using System;
using Ninject.Modules;
using TripLogEntryApp.ViewModels;

namespace TripLogEntryApp.Modules
{
    public class TripLogCoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<MainViewModel>().ToSelf();
            Bind<DetailViewModel>().ToSelf();
            Bind<NewEntryViewModel>().ToSelf();
        }
    }
}
