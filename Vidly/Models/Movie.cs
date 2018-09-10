using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter movie's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }//navigation property

        [Display(Name ="Genre")]
        [Required]
        public byte GenreId { get; set; } //byte explicitly required //if  byte? - it will be optional (implicitly required)

        public DateTime DateAdded { get; set; }

        [Display(Name ="Date of Release")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name ="Number in Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}