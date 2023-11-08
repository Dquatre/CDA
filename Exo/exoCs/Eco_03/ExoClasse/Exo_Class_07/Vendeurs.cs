using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_07
{
    public class Vendeurs : Commerciaux
    {
        private static Double NB_IRIS_PAR_PRIME = 2;
        private static Double SALAIRE_DE_BASE = 50;

        public Vendeurs(int age, string nom, string prenom, int nbDeplacement, int nbPrime) : base(age, nom, prenom, nbDeplacement, nbPrime)
        {
            Salaire = CalculSalaire();
        }

        public new Double CalculSalaire()
        {
            return SALAIRE_DE_BASE + NB_IRIS_PAR_PRIME * NbPrime;
        }

        public override String ToString()
        {
            return base.ToString() + " dont Salaire de " + SALAIRE_DE_BASE + " + " + NbPrime + " prime " + NB_IRIS_PAR_PRIME ;
        }
    }
}
