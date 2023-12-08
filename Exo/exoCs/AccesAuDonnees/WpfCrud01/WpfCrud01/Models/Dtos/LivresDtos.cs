using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCrud01.Models.Dtos
{
    public class LivresDtoOut
    {
        public string TitreLivre { get; set; } = null!;

        public int NombrePage { get; set; }

        public string Auteur { get; set; } = null!;

        public string Editeur { get; set; } = null!;
    }
}
