using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleDataGrid
{
    public class Jeux
    {
        public int IdJeux { get; set; }
        public String Titre { get; set; }
        public String Developpeur { get; set; }
        public String Editeur { get; set; }
        public String Platforme { get; set; }

        public Jeux(int idJeux, string titre, string developpeur, string editeur, string platforme)
        {
            IdJeux = idJeux;
            Titre = titre;
            Developpeur = developpeur;
            Editeur = editeur;
            Platforme = platforme;
        }
    }
}
