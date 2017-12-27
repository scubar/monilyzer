using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monilyzer.API.Services;
using Monilyzer.Data;
using Monilyzer.Model;

namespace Monilyzer.API.Controllers
{
    /// <summary>
    /// Controller for interacting with Customer objects.
    /// </summary>
    [Authorize]
    [Route("api/v1/customers")]
    public class CustomerController : Controller
    {
        public CustomerController(MonilyzerContext monilyzerContext)
        {
            MonilyzerContext = monilyzerContext;
        }

        MonilyzerContext MonilyzerContext { get; set; }

        // GET api/v1/customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return new CustomerService(MonilyzerContext).GetCustomers(); 
        }

        // GET api/v1/customers/<Guid>
        [HttpGet("{guid}")]
        public Customer Get(Guid guid)
        {
            return new CustomerService(MonilyzerContext).GetCustomer(guid);
        }

        // POST api/v1/customers
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public Customer Post([FromBody]Customer customer)
        {
            return new CustomerService(MonilyzerContext).CreateCustomer(customer); 
        }

        // PUT api/v1/customers/<Guid>
        [Authorize(Roles = "Administrator")]
        [HttpPut("{guid}")]
        public Customer Put(Guid guid,[FromBody]Customer customer)
        {
            return new CustomerService(MonilyzerContext).UpdateCustomer(guid, customer); 
        }

        // DELETE api/v1/customers/<Guid>
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{guid}")]
        public void Delete(Guid guid)
        {
            new CustomerService(MonilyzerContext).DeleteCustomer(guid); 
        }
    }
}