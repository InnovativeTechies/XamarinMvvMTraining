using System;
using System.Threading.Tasks;
using TripLogEntryApp.Models;

namespace TripLogEntryApp.Interfaces
{
    public interface ILocationService
    {
        Task<GeoCoords> GetGeoCoordinatesAsync();
    }
}
