using System.Collections.Generic;
using System.Linq;
using ElectricStore.Models;

namespace ElectricStore.Data
{
    public class SqlProductRepo : IProductRepo
    {
        private ElectricStoreContext _context;
        
        public SqlProductRepo(ElectricStoreContext context)
        {
            _context = context;
        }
        
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.FirstOrDefault(p => p.Id == productId);
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void DeleteProduct(int productId)
        {
            Product product = new Product() { Id = productId };
            _context.Products.Attach(product);
            _context.Products.Add(product);
        }
        
        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}