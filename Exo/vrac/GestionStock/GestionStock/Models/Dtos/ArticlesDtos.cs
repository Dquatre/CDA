using GestionStock.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Models.Dtos
{
    public class ArticlesDtoOut
    {
        public int IdArticle { get; set; }

        public string LibelleArticle { get; set; } = null!;

        public int QuantiteStockee { get; set; }

        public int IdCategorie { get; set; }

        public String LibelleCategorie { get; set; }

       

        public ArticlesDtoOut()
        {
        }

        public ArticlesDtoOut(int idArticle, string libelleArticle, int quantiteStockee, int idCategorie)
        {
            IdArticle = idArticle;
            LibelleArticle = libelleArticle;
            QuantiteStockee = quantiteStockee;
            IdCategorie = idCategorie;
        }
    }

}
