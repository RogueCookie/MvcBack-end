using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }
        
        [HttpPost]
        public IHttpActionResult CreateNewRenral(NewRentalDto newRental) //input
        {
            if (newRental.MovieId.Count == 0)
                return BadRequest("No Movies Ids have been given");

            //var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);//if set invalid custId this line get throe an exeption

            //this approach not for API, it's internal use

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("Invalid customer ID");

            
            
            var movies = _context.Movies.Where(m => newRental.MovieId.Contains(m.Id)).ToList();
            /* that's translate as a sql (сиквел) method like this:
            SELECT *
            FROM Movies
            WHERE Id (1,2,3)
            */

            if (movies.Count != newRental.MovieId.Count) //that means one or more movie are not loaded
                return BadRequest("One or more MovieId are invalid");

            foreach (var movie in movies) 
            {
                if (movie.NumbersAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumbersAvailable--;


                var rental = new Rentals //for each movie we create a rental object
                {
                    Customer = customer,
                    Movie = movie,
                    DataRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
