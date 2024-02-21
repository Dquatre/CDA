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

        public String LibelleTypeProduit { get; set; }


        public CategoriesDtoOut(int idCategorie, string libelleCategorie, int idTypeProduit)
        {
            IdCategorie = idCategorie;
            LibelleCategorie = libelleCategorie;
            IdTypeProduit = idTypeProduit;
        }

        public CategoriesDtoOut()
        {
        }
    }
}
