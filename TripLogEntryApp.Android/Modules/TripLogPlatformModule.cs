using System;
using Ninject.Modules;
using TripLogEntryApp.Droid.Services;
using TripLogEntryApp.Interfaces;

namespace TripLogEntryApp.Droid.Modules
{
    public class TripLogPlatformModule: NinjectModule
    {
        public override void Load()
        {
            Bind<ILocationService>()
                .To<LocationService>()
                .InSingletonScope();
        }
    }
}
