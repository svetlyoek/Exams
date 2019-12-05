namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writerSDto = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);

            var sb = new StringBuilder();

            foreach (var writerDto in writerSDto)
            {
                if (!IsValid(writerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };

                context.Writers.Add(writer);
                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDto = JsonConvert.DeserializeObject<ImportProducersAlbumsDto[]>(jsonString);

            var sb = new StringBuilder();

            foreach (var producerDto in producersDto)
            {
                if (!IsValid(producerDto) || producerDto.Albums.Any(a => !IsValid(a)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer
                {
                    Name = producerDto.Name,
                    Pseudonym = producerDto.Pseudonym,
                    PhoneNumber = producerDto.PhoneNumber,
                    Albums = producerDto.Albums
                    .Select(a => new Album
                    {
                        Name = a.Name,
                        ReleaseDate = DateTime.ParseExact(a.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    })
                    .ToArray()
                };


                context.Producers.Add(producer);

                context.SaveChanges();

                if (producer.PhoneNumber == null)
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count));
                }
                else
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber,
                        producer.Albums.Count));
                }

            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongDto[]), new XmlRootAttribute("Songs"));

            var songsDto = (ImportSongDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            foreach (var songDto in songsDto)
            {
                var songType = Enum.TryParse(songDto.Genre, out Genre genre);
                var writer = context.Writers.Any(w => songDto.WriterId == w.Id);
                var album = context.Albums.Any(a => songDto.AlbumId == a.Id);

                if (!IsValid(songDto) || !writer || !album || !songType)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song
                {
                    Name = songDto.Name,
                    Duration = TimeSpan.ParseExact(songDto.Duration, "c", CultureInfo.InvariantCulture),
                    CreatedOn = DateTime.ParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = genre,
                    AlbumId = songDto.AlbumId,
                    WriterId = songDto.WriterId

                };

                context.Songs.Add(song);

                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre.ToString(), song.Duration
                    .ToString()));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongPerformersDto[]), new XmlRootAttribute("Performers"));

            var performersDto = (ImportSongPerformersDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            foreach (var performerDto in performersDto)
            {
                var validSong = true;

                foreach (var song in performerDto.PerformersSongs)
                {
                    if (!context.Songs.Any(s => s.Id == song.Id))
                    {
                        validSong = false;
                        break;
                    }
                }

                if (!IsValid(performerDto) || !validSong)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var performer = new Performer
                {
                    FirstName = performerDto.FirstName,
                    LastName = performerDto.LastName,
                    Age = performerDto.Age,
                    NetWorth = performerDto.NetWorth,
                    PerformerSongs = performerDto.PerformersSongs
                    .Select(ps => new SongPerformer
                    {
                        SongId = ps.Id
                    })
                    .ToArray()

                };

                context.Performers.Add(performer);

                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName, performer.PerformerSongs
                    .Count));
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