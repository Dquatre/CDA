using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_04
{
    internal class Cercle
    {
        public int Diametre { get; set; }

        public Cercle(int diametre)
        {
            Diametre = diametre;
        }

        public override string ToString()
        {
            return "Diametre : " + Diametre + " - Périmètre : " + Math.Round(Perimetre(), 2) + " - Aire : " + Math.Round(Aire(), 2);
        }

        public Double Perimetre()
        {
            return double.Pi*Diametre;
        }
        public Double Aire()
        {
            return double.Pi*((Diametre/2) * (Diametre / 2));
        }


        public void AfficherCercle()
        {
            Console.WriteLine(this);
        }
    }
}
