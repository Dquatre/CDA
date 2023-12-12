using GestionStock.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Models.Dtos
{
    public class TypesproduitsDtos
    {
        public int IdTypeProduit { get; set; }

        public string LibelleTypeProduit { get; set; } = null!;

        public virtual ICollection<Category> ListCategories { get; set; } = new List<Category>();

        public TypesproduitsDtos(int idTypeProduit, string libelleTypeProduit, ICollection<Category> listCategories)
        {
            IdTypeProduit = idTypeProduit;
            LibelleTypeProduit = libelleTypeProduit;
            ListCategories = listCategories;
        }

        public TypesproduitsDtos()
        {
        }
    }
}
