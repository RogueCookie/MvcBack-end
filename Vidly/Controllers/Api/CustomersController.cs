﻿using AutoMapper;
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
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //response: GET/api/customer
        public IEnumerable<CustomerDto> GetCustomer()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>); //parentheses remove - we dont call this method here. it's reference to this method
                                                               //<source, target types>
        }

        //GET/api/customers/1
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerDto> (customer);
        }

        //POST/api/customers
        [HttpPost] //because we create resource. to apply this attribute here this action will be only called is we sent httppost request
        //the alternative rename method public Customer CreateCustomer(Customer customer) to PostCustomer (Microsoft tutorials)
        public CustomerDto CreateCustomer(CustomerDto customerDto)//we post to customer collection
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            //for mapp this dto back to domain object
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            //this cusmomer has id that generated by the db so we add this id in dto and return to the client
            customerDto.Id = customer.Id;

            return customerDto;
        }

        //PUT/api/customers/1
        //can return customer or void
        [HttpPut]
        public void Update(int id, CustomerDto customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDTO, customerInDb); //(source object, target object)
            /*
            //update customer
            customerInDb.Name = customerDTO.Name;
            customerInDb.Birthdate = customerDTO.Birthdate;
            customerInDb.IsSubscribedToNewsLetter = customerDTO.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customerDTO.MembershipTypeId;
            */
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
