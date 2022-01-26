using System.Collections.Generic;
using ElectricStore.Data;
using ElectricStore.Dtos;
using ElectricStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectricStore.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepo _repo;
        // private readonly IMapper _mapper;

        public OrdersController(IOrderRepo repo)
        {
            _repo = repo;
            //_mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Order>> GetAllCompanies()
        {
            return Ok(_repo.GetAllOrders());
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = _repo.GetOrderById(id);
            if (order != null)
            {
                return Ok(order);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            _repo.CreateOrder(order);
            _repo.SaveChanges();
            return Ok(order);
        }
        
        [HttpPut]
        public ActionResult UpdateOrder(int id, Order order)
        {
            var art = _repo.GetOrderById(id);
            if (art == null || order.Id != id)
            {
                return NotFound();
            }
            _repo.UpdateOrder(order);
            _repo.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            _repo.DeleteOrder(id);
            _repo.SaveChanges();
            return NoContent();
        }
    }
}