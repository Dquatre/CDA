using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_04
{
    internal class Prisme : TriangleRectangle
    {
        

        public int Profondeur { get; set; }

        public Prisme(int baseT, int hauteur,int profondeur) : base(baseT, hauteur)
        {
            Profondeur = profondeur;
        }

        public override string ToString()
        {
            return "Base : " + BaseT + " - Hauteur : " + Hauteur + " - Profondeur : " + Profondeur + " - Périmètre : " + Math.Round(Perimetre(), 2) + " - Volume : " + Math.Round(Volume(), 2);
        }

        public new Double Perimetre()
        {
            return base.Perimetre()*2+Profondeur*3;
        }
        public Double Volume()
        {
            return base.Aire() * Profondeur;
        }


        public void AfficherPrisme()
        {
            Console.WriteLine(this);
        }

    }
}
