﻿using Andreys.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Andreys.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public ProductCategory Category { get; set; }

        public Gender Gender { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
