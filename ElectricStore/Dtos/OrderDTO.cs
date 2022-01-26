using System.Collections.Generic;

namespace ElectricStore.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<int> ProductsIds { get; set; }
    }
}