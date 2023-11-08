using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_07
{
    internal class Vendeurs : Commerciaux
    {
        private static Double NB_IRIS_PAR_PRIME = 2;
        private static Double SALAIRE_DE_BASE = 50;

        public Vendeurs(int age, string nom, string prenom, double salaire, int nbDeplacement, int nbPrime) : base(age, nom, prenom, salaire, nbDeplacement, nbPrime)
        {

        }

        public new Double CalculSalaire()
        {
            return SALAIRE_DE_BASE + NB_IRIS_PAR_PRIME * NbPrime;
        }
    }
}
