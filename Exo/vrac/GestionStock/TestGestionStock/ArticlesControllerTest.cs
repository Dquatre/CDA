using GestionStock;
using GestionStock.Controller;
using GestionStock.Models;
using GestionStock.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace TestGestionStock
{
    public class ArticlesControllerTest
    {
        private ArticlesController controller;

        [SetUp]
        public void Setup()
        {
            GestionStockDbContext context = new GestionStockDbContext();
            controller = new ArticlesController(context);
        }

        [Test]
        public void GetAllArticles_NotEmpty()
        {
            List<ArticlesDtoOut> listArticle = (List<ArticlesDtoOut>)controller.GetAllArticles();
            Assert.IsNotEmpty(listArticle);
        }
    }
}