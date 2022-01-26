using System;
using System.Collections.Generic;
using System.Linq;
using ElectricStore.Models;

namespace ElectricStore.Data
{
    public class SqlArticlesRepo : IArticleRepo
    {
        private ElectricStoreContext _context;
        
        public SqlArticlesRepo(ElectricStoreContext context)
        {
            _context = context;
        }
        public List<Article> GetAllArticles()
        {
            return _context.Articles.ToList();
        }

        public Article GetArticleById(int articleId)
        {
            return _context.Articles.FirstOrDefault(p => p.Id == articleId);
        }

        public void CreateArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentException("Передана пустая статья");
            }
            _context.Articles.Add(article);
        }

        public void UpdateArticle(Article article)
        {
            _context.Articles.Update(article);
        }

        public void DeleteArticle(int articleId)
        {
            Article article = new Article() { Id = articleId };
            _context.Articles.Attach(article);
            _context.Articles.Remove(article);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}