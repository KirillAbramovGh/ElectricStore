using System.Collections.Generic;
using ElectricStore.Models;

namespace ElectricStore.Data
{
    public interface IArticleRepo
    {
        public List<Article> GetAllArticles();

        public Article GetArticleById(int articleId);

        public void CreateArticle(Article article);

        public void UpdateArticle(Article article);

        public void DeleteArticle(int articleId);

        bool SaveChanges();
    }
}