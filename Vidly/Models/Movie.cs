﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public Genre Genre { get; set; }
        [Display(Name ="Genre")]
        [Required]
        public byte? GenreId { get; set; } //forgin key for the database
        public DateTime DateAdded { get; set; }
        [Required]
        [Display(Name="Release Date")]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1,20)] 
        public byte? NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }
    }
}