using GestionStock.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Models.Services
{
    public class ArticlesServices
    {

        private readonly GestionStockDbContext _context;
        public ArticlesServices(GestionStockDbContext context)
        {
            _context = context;
        }

        public void AddArticles(Article p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.Articles.Add(p);
            _context.SaveChanges();
        }

        public void DeleteArticle(Article p)
        {
            //si l'objet personne est null, on renvoi une exception
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            // on met à jour le context
            _context.Articles.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _context.Articles.ToList();
        }

        public Article GetArticleById(int id)
        {
            return _context.Articles.FirstOrDefault(p => p.IdArticle == id);
        }

        public void UpdateArticle(Article p)
        {
            _context.SaveChanges();
        }

    }
}
