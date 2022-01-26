using System.Collections.Generic;
using System.Linq;
using ElectricStore.Models;

namespace ElectricStore.Data
{
    public class SqlCustomerRepo : ICustomerRepo
    {
        private ElectricStoreContext _context;
        
        public SqlCustomerRepo(ElectricStoreContext context)
        {
            _context = context;
        }
        
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == customerId);
        }

        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            Customer customer = new Customer() { Id = customerId };
            _context.Customers.Attach(customer);
            _context.Customers.Remove(customer);
        }
        
        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}