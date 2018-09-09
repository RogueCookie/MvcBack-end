using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm");
        }

        [HttpPost]
        public ActionResult Save(Customer customer)  //that calls "model biding". EF binds viewModel to request data
       // public ActionResult Create(NewCustomerViewModel viewModel)
        {
            if(customer.Id == 0)//checked has customer Id or not. 0 means that's new customer/ otherwise we should update it
            //we relying on customer id
                _context.Customers.Add(customer);//for modify object
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //Mapper.Map(customer, customerInDb);

                //TryUpdateModel(customerInDb, "", new string[] { "Name", "Email" });
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _context.SaveChanges();

            //redirecket user back to the list of customer
            return RedirectToAction("Index", "Customer"); //index in customer controller
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);  //get customer from Id in db

            if (customer == null) //if we given customer exist in db 
                return HttpNotFound();

            //the model behind the view is NewCustomerViewModel.. thas we create it
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
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