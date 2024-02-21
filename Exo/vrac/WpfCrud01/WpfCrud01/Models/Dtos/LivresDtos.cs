using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCrud01.Models.Dtos
{
    public class LivresDtoOut
    {
        public int IdLivre { get; set; }
        public string TitreLivre { get; set; } = null!;

        public int NombrePage { get; set; }

        public string Auteur { get; set; } = null!;

        public string Editeur { get; set; } = null!;

        public LivresDtoOut(int idLivre, string titreLivre, int nombrePage, string auteur, string editeur)
        {
            IdLivre = idLivre;
            TitreLivre = titreLivre;
            NombrePage = nombrePage;
            Auteur = auteur;
            Editeur = editeur;
        }

        public LivresDtoOut()
        {
        }
    }
}
