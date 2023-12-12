using GestionStock.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Models.Dtos
{
    public class CategoriesDtoOut
    {
        public int IdCategorie { get; set; }

        public string LibelleCategorie { get; set; } = null!;

        public int IdTypeProduit { get; set; }

        public virtual ICollection<Article> ListArticles { get; set; } = new List<Article>();

        public virtual Typesproduit TheTypesproduit { get; set; } = null!;

        public CategoriesDtoOut(int idCategorie, string libelleCategorie, int idTypeProduit, ICollection<Article> listArticles, Typesproduit theTypesproduit)
        {
            IdCategorie = idCategorie;
            LibelleCategorie = libelleCategorie;
            IdTypeProduit = idTypeProduit;
            ListArticles = listArticles;
            TheTypesproduit = theTypesproduit;
        }

        public CategoriesDtoOut()
        {
        }
    }
}
