namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(m => m.Rating >= rating && m.Projections.Any(p => p.Tickets.Count >= 1))
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(ti => ti.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
               .Select(m => new
               {
                   MovieName = m.Title,
                   Rating = m.Rating.ToString("F2"),
                   TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                   Customers = m.Projections.SelectMany(t => t.Tickets).Select(c => new
                   {
                       FirstName = c.Customer.FirstName,
                       LastName = c.Customer.LastName,
                       Balance = c.Customer.Balance.ToString("F2")
                   })
                   .OrderByDescending(b => b.Balance)
                   .ThenBy(f => f.FirstName)
                   .ThenBy(l => l.LastName)
                   .ToArray()
               })
               .Take(10)
               .ToArray();

            var json = JsonConvert.SerializeObject(movies, Formatting.Indented);

            return json;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Where(c => c.Age >= age)
                .OrderByDescending(c => c.Tickets.Sum(t => t.Price))
                .Select(c => new ExportCustomerDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SpentMoney = c.Tickets.Sum(t => t.Price).ToString("F2"),
                    SpentTime = TimeSpan.FromSeconds(
                            c.Tickets.Sum(s => s.Projection.Movie.Duration.TotalSeconds))
                        .ToString(@"hh\:mm\:ss")
                })
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            var xmlSerializer = new XmlSerializer(typeof(ExportCustomerDto[]), new XmlRootAttribute("Customers"));

            xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}