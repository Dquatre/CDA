﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_07
{
    public class Representants : Commerciaux
    {
        public int NbDeplacement { get; set; }
        private static Double NB_IRIS_PAR_DEPLACEMENT = 1;
        private static Double NB_IRIS_PAR_PRIME = 5;
        private static Double SALAIRE_DE_BASE = 50;
        public Representants(int age, string nom, string prenom, int nbPrime, int nbDeplacement) : base(age, nom, prenom, SALAIRE_DE_BASE, nbPrime)
        {
            NbDeplacement = nbDeplacement;
            Salaire = CalculSalaire();
        }
        public override Double CalculSalaire()
        {
            return SALAIRE_DE_BASE + NB_IRIS_PAR_PRIME * NbPrime + NB_IRIS_PAR_DEPLACEMENT* NbDeplacement;
        }

        public override String ToString()
        {
            return base.ToString() + " dont Salaire de " + SALAIRE_DE_BASE + " + " + NbPrime + " prime à " + NB_IRIS_PAR_PRIME + " + " + NbDeplacement + " déplacement à " + NB_IRIS_PAR_DEPLACEMENT;
        }
    }
}
