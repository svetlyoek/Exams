using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext context;

        public TripsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void CreateTrip(string startingPoint, string endPoint, string departureDate, string imageUrl, int seats, string description)
        {
            DateTime parsedDepartureDate =
            DateTime.ParseExact(departureDate, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            var trip = new Trip
            {
                StartPoint = startingPoint,
                EndPoint = endPoint,
                DepartureDate = parsedDepartureDate,
                ImagePath = imageUrl,
                Seats = seats,
                Description = description
            };

            this.context.Trips.Add(trip);

            this.context.SaveChanges();

        }

        public ICollection<Trip> GetAllTrips()
        {
            var allTrips = this.context.Trips.ToList();

            return allTrips;
        }

        public TripDetailsViewModel GetTripById(string id)
        {
            var trip = this.context.Trips.Where(t => t.Id == id)
                .Select(t => new TripDetailsViewModel
                {
                    Id = t.Id,
                    ImagePath = t.ImagePath,
                    DepartureTime = t.DepartureDate,
                    Description = t.Description,
                    EndPoint = t.EndPoint,
                    Seats = t.Seats,
                    StartPoint = t.StartPoint
                }).FirstOrDefault();

            return trip;

        }
        public bool AddUserToTrip(string tripId, string userId)
        {
            var targetTrip = this.context.Trips.FirstOrDefault(x => x.Id == tripId);
            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId
            };

            if (!this.context.UserTrips.Any(x => x.TripId == userTrip.TripId && x.UserId == userTrip.UserId) && targetTrip.Seats > 0)
            {
                targetTrip.Seats -= 1;
                targetTrip.UserTrips.Add(userTrip);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
