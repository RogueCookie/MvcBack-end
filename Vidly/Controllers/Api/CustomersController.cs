using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //response: GET/api/customer
        public IEnumerable<Customer> GetCustomer()
        {
            return _context.Customers.ToList();
        }

        //GET/api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        //POST/api/customers
        [HttpPost] //because we create resource. to apply this attribute here this action will be only called is we sent httppost request
        //the alternative rename method public Customer CreateCustomer(Customer customer) to PostCustomer (Microsoft tutorials)
        public Customer CreateCustomer(Customer customer)//we post to customer collection
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        //PUT/api/customers/1
        //can return customer or void
        [HttpPut]
        public void Update(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //update customer
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
        }

        //DELETE/api/cuatomers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            //check is it exist or not
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

    }
}
