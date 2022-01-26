using System.Collections.Generic;
using ElectricStore.Data;
using ElectricStore.Dtos;
using ElectricStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectricStore.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepo _repo;
        // private readonly IMapper _mapper;

        public CustomersController(ICustomerRepo repo)
        {
            _repo = repo;
            //_mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetAllCompanies()
        {
            return Ok(_repo.GetAllCustomers());
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _repo.GetCustomerById(id);
            if (customer != null)
            {
                return Ok(customer);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            _repo.CreateCustomer(customer);
            _repo.SaveChanges();
            return Ok(customer);
        }
        
        [HttpPut]
        public ActionResult UpdateCustomer(int id, Customer customer)
        {
            var art = _repo.GetCustomerById(id);
            if (art == null || customer.Id != id)
            {
                return NotFound();
            }
            _repo.UpdateCustomer(customer);
            _repo.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            _repo.DeleteCustomer(id);
            _repo.SaveChanges();
            return NoContent();
        }
    }
}