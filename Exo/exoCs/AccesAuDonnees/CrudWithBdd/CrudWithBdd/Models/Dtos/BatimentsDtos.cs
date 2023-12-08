using CrudWithBdd.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWithBdd.Models.Dtos
{
    public class BatimentsDtoOut
    {
        public int IdBatiment { get; set; }

        public string NomBatiment { get; set; } = null!;

        public virtual ICollection<Salle> Salles { get; set; } = new List<Salle>();
    }
}
