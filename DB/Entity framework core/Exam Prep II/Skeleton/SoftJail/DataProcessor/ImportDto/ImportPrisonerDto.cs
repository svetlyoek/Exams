﻿namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class ImportPrisonerDto
    {
        [Required]
        [MinLength(3), MaxLength(20)]
        public string FullName { get; set; }

        [RegularExpression(@"^The [A-Z]{1}[a-z]+$"), Required]
        public string Nickname { get; set; }

        [Required]
        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        [Range(typeof(decimal), "0.0", "79228162514264337593543950335")]
        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public ImportMailDto[] Mails { get; set; }

    }
}
