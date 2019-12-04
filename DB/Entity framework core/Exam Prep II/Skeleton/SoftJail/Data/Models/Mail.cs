﻿namespace SoftJail.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Mail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [RegularExpression(@"^[a-zA-Z 0-9]+ str.$"), Required]
        public string Address { get; set; }

        [Required]
        public int PrisonerId { get; set; }

        public Prisoner Prisoner { get; set; }


    }
}
