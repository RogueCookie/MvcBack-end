using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;  //dbcontext to access db and initialize it in constructor

        public CustomersController()
        {
            _context = new ApplicationDbContext();  //disposable object
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); //get all customers in db// that call "deferred executions"
                                        //for immidiatly executed query by calling ToList()
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);//can either use foreach or lamda expression as stated
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        /*private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Marry Williams" }
            };
        }*/
    }
}