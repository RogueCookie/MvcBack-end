using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        //public ViewResult Random() //good practice specially when in cames for unit test
        public ActionResult Random()
        {
            //an instance of movie model
            var movie = new Movie() { Name = "Shrek!" };

            return View(movie);
            //return new ViewResult();
            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult(); //there is nothing in result
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" }); //nsme of "action", "controller", new.. ass argumentto the target action
                            //result ://localhost:52105/?page=1&sortBy=name

        }

        public ActionResult Edit(int Id)
        {
            return Content("id =" + Id);
        }

        //will be noviganes when we call movies
        public ActionResult Index(int? pageIndex, string sortBy)  //?-null-able
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(string.Format($"pageIndex = {pageIndex}, sortBy = {sortBy}"));
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year +"/"+ month);
        }
    }
}