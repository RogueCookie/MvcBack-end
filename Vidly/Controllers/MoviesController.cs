using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };
            //create model object
            var viewModel = new RandomMovieViewModel
            {
                //initialise movie proporty
                Movie = movie,
                Customers = customers
            };


            //ViewData["Movie"] = movie; //viewdata dictionary-to pass movie to the view
            //ViewBag.Movie = movie; //

            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model;

            return View(viewModel); //this movie object passed here will be assign with property model
            //return new ViewResult();
            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult(); //there is nothing in result
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" }); //nsme of "action", "controller", new.. ass argumentto the target action
                            //result ://localhost:52105/?page=1&sortBy=name

        }
        /*
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

        //apply route attribute
        [Route("movies/released/{year}/{month:regqx(\\d{2}):range(1,12)}")]  //:regqx - appl regular expression
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year +"/"+ month);
        }
        */

    }
}