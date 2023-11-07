using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_04
{
    internal class Rectangle
    {
        public int Longueur { get; set; }
        public int Largeur { get; set; }

        public Rectangle(int longueur, int largeur)
        {
            Longueur = longueur;
            Largeur = largeur;
        }

        public int Perimetre() 
        {
            return (Longueur+Largeur)*2;
        }
        public int Aire()
        {
            return Longueur * Largeur;
        }
        public bool EstCarre()
        {
            return Longueur == Largeur;
        }

        public String AfficherRectangle()
        {
            return "Longueur : " + Longueur + " - Largeur : " + Largeur + " - Périmètre : " + Perimetre() + " - Aire : " + Aire() + (EstCarre()? " - Il s’agit d’un carré": " - Il ne s’agit pas d’un carré");
        } 
    }
}
