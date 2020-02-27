using System;
using System.Threading.Tasks;
using TripLogEntryApp.Interfaces;
using TripLogEntryApp.Models;

namespace TripLogEntryApp.Droid.Services
{
    public class LocationService:ILocationService
    {
       

        async Task<GeoCoords> ILocationService.GetGeoCoordinatesAsync()
        {
            var location = await Xamarin.Essentials.Geolocation.GetLocationAsync();

            return new GeoCoords
            {
                Latitude = location.Latitude,
                Longitude = location.Longitude
            };
        }
    }
}
