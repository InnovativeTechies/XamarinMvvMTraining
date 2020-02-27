using System;
using System.Threading.Tasks;
using TripLogEntryApp.Interfaces;
using TripLogEntryApp.Models;

namespace TripLogEntryApp.iOS.Services
{
    public class LocationService : ILocationService
    {
        public async Task<GeoCoords> GetGeoCoordinatesAsync()
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
