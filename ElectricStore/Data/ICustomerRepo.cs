using System.Collections.Generic;
using ElectricStore.Models;

namespace ElectricStore.Data
{
    public interface ICustomerRepo
    {
        
        public List<Customer> GetAllCustomers();

        public Customer GetCustomerById(int customerId);

        public void CreateCustomer(Customer customer);

        public void UpdateCustomer(Customer customer);

        public void DeleteCustomer(int customerId);
        
        bool SaveChanges();
    }
}