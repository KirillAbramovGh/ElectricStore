using System.Collections.Generic;
using ElectricStore.Data;
using ElectricStore.Dtos;
using ElectricStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectricStore.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _repo;
        // private readonly IMapper _mapper;

        public ProductsController(IProductRepo repo)
        {
            _repo = repo;
            //_mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAllCompanies()
        {
            return Ok(_repo.GetAllProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _repo.GetProductById(id);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            _repo.CreateProduct(product);
            _repo.SaveChanges();
            return Ok(product);
        }
        
        [HttpPut]
        public ActionResult UpdateProduct(int id, Product product)
        {
            var art = _repo.GetProductById(id);
            if (art == null || product.Id != id)
            {
                return NotFound();
            }
            _repo.UpdateProduct(product);
            _repo.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            _repo.DeleteProduct(id);
            _repo.SaveChanges();
            return NoContent();
        }
    }
}