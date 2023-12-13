using GestionStock.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Models.Dtos
{
    public class TypesproduitsDtoOut
    {
        public int IdTypeProduit { get; set; }

        public string LibelleTypeProduit { get; set; } = null!;

        public virtual ICollection<CategoriesDtoOut> ListCategories { get; set; } = new List<CategoriesDtoOut>();

        public TypesproduitsDtoOut(int idTypeProduit, string libelleTypeProduit)
        {
            IdTypeProduit = idTypeProduit;
            LibelleTypeProduit = libelleTypeProduit;
        }

        public TypesproduitsDtoOut()
        {
        }
    }
}
