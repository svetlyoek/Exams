namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {

            var prisonersDto = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                    .Select(po => new
                    {
                        OfficerName = po.Officer.FullName,
                        Department = po.Officer.Department.Name
                    })
                    .OrderBy(po => po.OfficerName),
                    TotalOfficerSalary = Math.Round(p.PrisonerOfficers.Sum(o => o.Officer.Salary), 2)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var json = JsonConvert.SerializeObject(prisonersDto, Formatting.Indented);

            return json;

        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var splittedPrisoners = prisonersNames.Split(",").ToArray();

            var prisoners = context.Prisoners
                .Where(p => splittedPrisoners.Contains(p.FullName))
                .Select(p => new ExportPrisonersMailDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails
                    .Select(m => new ExportMailDto
                    {
                        Description = ReverseDescription(m.Description)
                    })
                    .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            var xmlSerializer = new XmlSerializer(typeof(ExportPrisonersMailDto[]), new XmlRootAttribute("Prisoners"));

            xmlSerializer.Serialize(new StringWriter(sb), prisoners, namespaces);

            return sb.ToString().TrimEnd();

        }

        private static string ReverseDescription(string description)
        {
            string reverseDescription = string.Empty;

            for (int i = description.Length - 1; i >= 0; i--)
            {
                reverseDescription += description[i];
            }

            return reverseDescription;
        }
    }
}