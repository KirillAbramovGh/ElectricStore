using System.Collections.Generic;
using ElectricStore.Models;

namespace ElectricStore.Data
{
    public interface IProductRepo
    {
        public List<Product> GetAllProducts();

        public Product GetProductById(int productId);

        public void UpdateProduct(Product product);

        public void CreateProduct(Product product);

        public void DeleteProduct(int productId);
        
        bool SaveChanges();
    }
}