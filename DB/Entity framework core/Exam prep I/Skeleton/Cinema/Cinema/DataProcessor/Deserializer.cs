namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDto = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);


            StringBuilder sb = new StringBuilder();

            foreach (var movieDto in moviesDto)
            {
                if (context.Movies.Any(m => m.Title == movieDto.Title) || !IsValid(movieDto))
                {

                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var enumType = Enum.Parse<Genre>(movieDto.Genre);

                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Genre = enumType,
                    Duration = TimeSpan.Parse(movieDto.Duration),
                    Rating = movieDto.Rating,
                    Director = movieDto.Director

                };

                context.Movies.Add(movie);

                context.SaveChanges();

                var formattedRating = $"{movieDto.Rating:f2}";

                sb.AppendLine(string.Format(SuccessfulImportMovie, movieDto.Title, movieDto.Genre, formattedRating));

            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallSeatDtos = JsonConvert.DeserializeObject<ImportHallSeatsDto[]>(jsonString);
            var halls = new List<Hall>();

            var sb = new StringBuilder();

            foreach (var hallSeatDto in hallSeatDtos)
            {
                if (!IsValid(hallSeatDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallSeatDto.Name,
                    Is3D = hallSeatDto.Is3D,
                    Is4Dx = hallSeatDto.Is4Dx,
                };

                for (int i = 0; i < hallSeatDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                halls.Add(hall);

                string status = "";

                if (hall.Is4Dx)
                {
                    status = hall.Is3D ? "4Dx/3D" : "4Dx";
                }
                else if (hall.Is3D)
                {
                    status = "3D";
                }
                else
                {
                    status = "Normal";
                }

                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, status, hall.Seats.Count));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));

            var projectionsDto = (ImportProjectionDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();

            foreach (var projectionDto in projectionsDto)
            {
                var movie = context.Movies.Find(projectionDto.MovieId);

                var hall = context.Halls.Find(projectionDto.HallId);

                if (movie == null || hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = projectionDto.MovieId,
                    HallId = projectionDto.HallId,
                    DateTime = DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                context.Projections.Add(projection);

                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfulImportProjection, projection.Movie.Title, projection.DateTime
                    .ToString("MM/dd/yyyy")));
            }

            return sb.ToString().TrimEnd();

        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerTicketsDto[]), new XmlRootAttribute("Customers"));

            var customersDto = (ImportCustomerTicketsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();

            foreach (var customerDto in customersDto)
            {
                var projections = context.Projections.Select(p => p.Id).ToArray();

                var projectionExists = projections.Any(x => customerDto.Tickets.Any(s => s.ProjectionId != x));

                if (!IsValid(customerDto)
                    && customerDto.Tickets.All(IsValid)
                    && projectionExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance,

                };

                foreach (var ticketDto in customerDto.Tickets)
                {
                    customer.Tickets.Add(new Ticket
                    {
                        ProjectionId = ticketDto.ProjectionId,
                        Price = ticketDto.Price
                    });
                }

                context.Customers.Add(customer);

                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName,
                    customer.Tickets.Count));
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool IsValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return IsValid;
        }
    }
}