using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SIS.HTTP;
using SIS.MvcFramework;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripCreateInputViewModel inputModel)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(inputModel.StartPoint))
            {
                return this.View();
            }
            if (string.IsNullOrWhiteSpace(inputModel.EndPoint))
            {
                return this.View();
            }

            if (string.IsNullOrWhiteSpace(inputModel.DepartureTime))
            {
                return this.View();
            }

            if (inputModel.Seats < 2 || inputModel.Seats > 6)
            {
                return this.View();
            }
            if (inputModel.Description.Length > 80)
            {
                return this.View();
            }

            if (string.IsNullOrWhiteSpace(inputModel.Description))
            {
                return this.View();
            }
            if (string.IsNullOrWhiteSpace(inputModel.ImagePath))
            {
                return this.View();
            }

            this.tripsService.CreateTrip(inputModel.StartPoint, inputModel.EndPoint,
                inputModel.DepartureTime, inputModel.ImagePath,
                inputModel.Seats, inputModel.Description);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var allTrips = this.tripsService.GetAllTrips()
                  .Select(t => new TripHomePageDetailsViewModel
                  {
                      Id = t.Id,
                      StartPoint = t.StartPoint,
                      EndPoint = t.EndPoint,
                      DepartureTime = t.DepartureDate,
                      Seats = t.Seats
                  })
                 .ToArray();

            return this.View(allTrips);
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var tripDetails = this.tripsService.GetTripById(id);

            return this.View(tripDetails);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.User;
            var isAdded = this.tripsService.AddUserToTrip(tripId, userId);

            if (isAdded)
            {
                return this.Redirect("/Trips/All");
            }

            return this.Redirect($"/Trips/Details?id={tripId}");
        }
    }
}
