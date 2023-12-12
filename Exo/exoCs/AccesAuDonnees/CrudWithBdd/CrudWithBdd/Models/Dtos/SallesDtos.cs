using CrudWithBdd.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWithBdd.Models.Dtos
{
    public class SallesDtoOut
    {

        public string CodeSalle { get; set; } = null!;

        public int Surface { get; set; }

        public int NombrePlace { get; set; }

        public int IdBatimentSalle { get; set; }

        public virtual Salle IdBatimentNavigation { get; set; } = null!;
    }
}
