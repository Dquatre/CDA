using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_07
{
    public class Techniciens : Employes
    {
        private static Double SALAIRE_DE_BASE = 40;
        public Techniciens(int age, string nom, string prenom) : base(age, nom, prenom)
        {
            Salaire = CalculSalaire();
        }
        public new Double CalculSalaire()
        {
            return SALAIRE_DE_BASE ;
        }

    }
}
