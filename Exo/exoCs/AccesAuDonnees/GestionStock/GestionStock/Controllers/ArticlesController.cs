
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GestionStock.Models;
using GestionStock.Models.Data;
using GestionStock.Models.Dtos;
using GestionStock.Models.Profiles;
using GestionStock.Models.Services;

namespace GestionStock.Controller
{

    public class ArticlesController : ControllerBase
    {
        private readonly ArticlesServices _service;
        private readonly IMapper _mapper;

        public ArticlesController(GestionStockDbContext context)
        {
            _service = new ArticlesServices(context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ArticlesProfiles>();
            });
            _mapper = config.CreateMapper();
        }


        public IEnumerable<ArticlesDtoOut> GetAllArticles()
        {
            IEnumerable<Article> listeArticles = _service.GetAllArticles();
            return _mapper.Map<IEnumerable<ArticlesDtoOut>>(listeArticles);
        }



        public ArticlesDtoOut GetArticleById(int id)
        {
            var item = _service.GetArticleById(id);
            if (item != null)
            {
                return _mapper.Map<ArticlesDtoOut>(item);
            }
            return null;
        }


        public void CreateArticle(ArticlesDtoOut itemDto)
        {
            Article itemPOCO = _mapper.Map<Article>(itemDto);
            _service.AddArticles(itemPOCO);
        }


        public void UpdateArticle(int id, ArticlesDtoOut item)
        {
            var itemFromRepo = _service.GetArticleById(id);
            if (itemFromRepo != null)
            {
                _mapper.Map(item, itemFromRepo);
                _service.UpdateArticle(itemFromRepo);
            }

        }

        public void DeleteArticle(int id)
        {
            var itemFromRepo = _service.GetArticleById(id);
            if (itemFromRepo != null)
            {
                _service.DeleteArticle(itemFromRepo);
            }
        }
    }
}


