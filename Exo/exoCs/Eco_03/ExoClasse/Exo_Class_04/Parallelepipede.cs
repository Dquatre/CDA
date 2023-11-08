using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_04
{
    internal class ParallelepipedeRectangle : Rectangle
    {
        public int Hauteur {  get; set; }

        public ParallelepipedeRectangle(int longueur, int largeur,int hauteur) : base(longueur, largeur)
        {
            Hauteur = hauteur;
        }

        public override string ToString()
        {
            return "Longueur : " + Longueur + " - Largeur : " + Largeur + " - Hauteur : " + Hauteur + " - Périmètre : " + Perimetre() +" - Volume : " + Volume();
        }

        public new int Perimetre()
        {
            return base.Perimetre()*2 + Hauteur * 4;
        }
        public int Volume()
        {
            return base.Aire() * Hauteur;
        }

        public void AfficherParallelepipedeRectangle()
        {
            Console.WriteLine(this);
        }
    }
}
