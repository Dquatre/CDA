using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_04
{
    internal class Sphere : Cercle
    {
        public Sphere(int diametre) : base(diametre)
        {
        }

        public override string ToString()
        {
            return "Diametre : " + Diametre + " - Périmètre : " + Math.Round(Perimetre(), 2) + " - Volume : " + Math.Round(Volume(), 2);
        }

        public Double Volume()
        {
            return 4/3*double.Pi * Math.Pow(Diametre / 2,3);
        }


        public void AfficherSphere()
        {
            Console.WriteLine(this);
        }
    }
}
