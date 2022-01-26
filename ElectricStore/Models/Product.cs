using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricStore.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id{ get; set; }
        public int CustomerId{ get; set; }
        public string ImgPath{ get; set; }
        public string Description{ get; set; }
        public int Price{ get; set; }
        public string Name{ get; set; }
        public int CompanyId{ get; set; }
        public int OrderId { get; set; }
    }
}