using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_07
{
    public abstract class Commerciaux : Employes
    {
        public int NbDeplacement { get; set; }
        public int NbPrime { get; set; }
        public Commerciaux(int age, string nom, string prenom, int nbDeplacement, int nbPrime) : base(age, nom, prenom)
        {
            NbDeplacement = nbDeplacement;
            NbPrime = nbPrime;
        }
    }
}
