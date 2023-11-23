using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_04
{
    internal class TriangleRectangle
    {
        public int BaseT { get; set; }
        public int Hauteur { get; set; }

        public TriangleRectangle(int baseT, int hauteur)
        {
            BaseT = baseT;
            Hauteur = hauteur;
        }

        public override string ToString()
        {
            return "Base : " + BaseT + " - Hauteur : " + Hauteur + " - Périmètre : " + Math.Round(Perimetre(),2) + " - Aire : " + Math.Round(Aire(), 2);
        }

        public Double Perimetre()
        {
            return BaseT + Hauteur + (Math.Sqrt(Math.Pow(BaseT,2)+ Math.Pow(BaseT, 2)));
        }
        public Double Aire()
        {
            return BaseT * Hauteur / 2;
        }
    

        public void AfficherTriangleRectangle()
        {
            Console.WriteLine(this);
        }


    }
}
