using System;
using Ninject.Modules;
using TripLogEntryApp.Interfaces;
using TripLogEntryApp.Services;

namespace TripLogEntryApp.Modules
{
    public class TripLogPlatformModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILocationService>()
            .To<LocationService>()
            .InSingletonScope();
        }
    }
}
