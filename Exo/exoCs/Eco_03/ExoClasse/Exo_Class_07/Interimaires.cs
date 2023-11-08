using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_07 
{
    public class Interimaires : Techniciens
    {
        private static Double NB_IRIS_PAR_HEURE = 0.5;
        public int NbHeure { get; set; }
        public Interimaires(int age, string nom, string prenom, int nbHeure) : base(age, nom, prenom)
        {
            
            NbHeure = nbHeure;
            Salaire = CalculSalaire();
        }
        public new Double CalculSalaire()
        {
            return NB_IRIS_PAR_HEURE*NbHeure;
        }
    }
}
