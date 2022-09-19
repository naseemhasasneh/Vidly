using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _Context;
        public CustomersController()
        {
            _Context = new ApplicationDbContext();
        }
        //get  api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _Context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }
        // get(single customer) api/customers/id 
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _Context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }
        //post api/customers
        [HttpPost] 
        public IHttpActionResult CreateCustomer(CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerdto);
            _Context.Customers.Add(customer);
            _Context.SaveChanges();
            customerdto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerdto); 
        }
        //put api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id,CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerindb = _Context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerindb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            //update customer
             Mapper.Map(customerdto, customerindb); 
          
            _Context.SaveChanges(); 

        }
        //delete api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
           var customerindb = _Context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerindb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _Context.Customers.Remove(customerindb);
            _Context.SaveChanges();
        }
    }
}
