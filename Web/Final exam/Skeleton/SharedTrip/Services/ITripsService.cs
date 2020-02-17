using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void CreateTrip(string startingPoint, string endPoint, string departureTime, string imageUrl, int seats, string description);

        ICollection<Trip> GetAllTrips();

        TripDetailsViewModel GetTripById(string id);

        bool AddUserToTrip(string tripId, string userId);
    }
}
