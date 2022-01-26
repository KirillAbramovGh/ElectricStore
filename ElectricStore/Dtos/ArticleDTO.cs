using System.ComponentModel.DataAnnotations;

namespace ElectricStore.Dtos
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}