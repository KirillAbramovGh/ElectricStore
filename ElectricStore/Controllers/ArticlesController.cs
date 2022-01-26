using System.Collections.Generic;
using ElectricStore.Data;
using ElectricStore.Dtos;
using ElectricStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ElectricStore.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepo _repo;
        // private readonly IMapper _mapper;

        public ArticlesController(IArticleRepo repo)
        {
            _repo = repo;
            //_mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Article>> GetAllArticles()
        {
            return Ok(_repo.GetAllArticles());
        }

        [HttpGet("{id}")]
        public ActionResult<Article> GetArticleById(int id)
        {
            Article article = _repo.GetArticleById(id);
            if (article != null)
            {
                return Ok(article);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Article> CreateArticle(Article article)
        {
            _repo.CreateArticle(article);
            _repo.SaveChanges();
            return Ok(article);
        }

        [HttpPut]
        public ActionResult UpdateArticle(int id, Article article)
        {
            var art = _repo.GetArticleById(id);
            if (art == null || article.Id != id)
            {
                return NotFound();
            }
            _repo.UpdateArticle(article);
            _repo.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteArticle(int id)
        {
            _repo.DeleteArticle(id);
            _repo.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialArticleUpdate(int id, JsonPatchDocument<Article> patchDoc)
        {
            var art = _repo.GetArticleById(id);
            if (art == null)
            {
                return NotFound();
            }
            patchDoc.ApplyTo(art, ModelState);
            if (!TryValidateModel(art))
            {
                return ValidationProblem(ModelState);
            }
            _repo.UpdateArticle(art);
            _repo.SaveChanges();
            return NoContent();
        }
    }
}