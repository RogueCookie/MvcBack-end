using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public Movie Movie { get; set; }

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