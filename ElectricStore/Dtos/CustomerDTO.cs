namespace ElectricStore.Models
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public double Money{ get; set; }
        public string Name{ get; set; }
        public string Surname{ get; set; }
        public string Email{ get; set; }
        public string Login{ get; set; }
        public string Password{ get; set; }
        public int OrderId{ get; set; }
    }
}