namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentCellsDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var depDto in departmentsDto)
            {
                if (!IsValid(depDto) || depDto.Cells.Any(c => IsValid(c) == false))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = depDto.Name,
                };

                foreach (var cell in depDto.Cells)
                {
                    department.Cells.Add(new Cell
                    {
                        HasWindow = cell.HasWindow,
                        CellNumber = cell.CellNumber,
                        DepartmentId = department.Id
                    });
                }

                context.Departments.Add(department);

                context.SaveChanges();

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDto = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var prisonerDto in prisonersDto)
            {
                if (!IsValid(prisonerDto) || prisonerDto.Mails.Any(m => IsValid(m) == false))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? releaseDate = null;

                if (prisonerDto.ReleaseDate != null)
                {
                    releaseDate = DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                }

                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId

                };

                foreach (var mail in prisonerDto.Mails)
                {
                    prisoner.Mails.Add(new Mail
                    {
                        Description = mail.Description,
                        Sender = mail.Sender,
                        Address = mail.Address,
                        PrisonerId = prisoner.Id
                    });
                }

                context.Prisoners.Add(prisoner);

                context.SaveChanges();

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            return sb.ToString().TrimEnd();

        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportOfficersPrisonersDto[]), new XmlRootAttribute("Officers"));

            var officersDto = (ImportOfficersPrisonersDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();

            foreach (var officerDto in officersDto)
            {
                var validPosition = Enum.TryParse(officerDto.Position, out Position position);

                var validWeapon = Enum.TryParse(officerDto.Weapon, out Weapon weapon);

                if (!IsValid(officersDto) || !validPosition || !validWeapon)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officerDto.DepartmentId,

                };

                foreach (var prisoner in officerDto.Prisoners)
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner
                    {
                        OfficerId = officer.Id,
                        PrisonerId = prisoner.Id
                    });

                }

                context.Officers.Add(officer);

                context.SaveChanges();

                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
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