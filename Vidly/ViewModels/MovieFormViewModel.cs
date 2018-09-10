using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter movie's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }//navigation property

        [Display(Name = "Genre")]
        public byte GenreId { get; set; } //byte explicitly required //if  byte? - it will be optional (implicitly required)

        public DateTime DateAdded { get; set; }

        [Display(Name = "Date of Release")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte NumberInStock { get; set; }

        //public Movie Movie { get; set; }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
        /*or instead this use
        @model Vidly.ViewModels.MovieFormViewModel
        @{
        var title = (Model.Movie == null) ? "New Movie" : "Edit Movie";
                ViewBag.Title = @title;
        Layout = "~/Views/Shared/_Layout.cshtml";
        }
        <h2>@title</h2>*/





    }
}