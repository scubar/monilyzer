using System;
using System.Collections.Generic;
using System.Linq;
using Monilyzer.Data;
using Monilyzer.Model;

namespace Monilyzer.API.Services
{
    public class CustomerService
    {
        private MonilyzerContext MonilyzerContext { get; set; }

        public CustomerService(MonilyzerContext monilyzerContext)
        {
            MonilyzerContext = monilyzerContext;
        }

        public Customer GetCustomer(Guid guid)
        {
            var customer = MonilyzerContext.Customers.FirstOrDefault(c => c.Guid == guid);

            if (customer == null) throw new NullReferenceException();

            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return MonilyzerContext.Customers.ToList(); 
        }

        public Customer CreateCustomer(Customer customer)
        {
            MonilyzerContext.Customers.Add(customer);

            MonilyzerContext.SaveChanges();

            return customer;
        }

        public Customer UpdateCustomer(Guid guid,Customer customer)
        {
            var Customer = GetCustomer(guid);

            Customer.Update(customer);

            MonilyzerContext.SaveChanges();

            return Customer;
        }

        public void DeleteCustomer(Guid guid)
        {
            var Customer = GetCustomer(guid);

            MonilyzerContext.Customers.Remove(Customer);

            MonilyzerContext.SaveChanges();
        }
    }
}
