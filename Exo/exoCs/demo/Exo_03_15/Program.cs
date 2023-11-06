using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_03_15
{
    class Program
    {
        static void Main(string[] args)
        {
            Double xHautGauche, yHautGauche, xBasDroite, yBasDroite, xPoint, yPoint;

            Console.Write("Entrez l'abscisse du point en haut a gauche du rectangle R : ");
            while (!Double.TryParse(Console.ReadLine(), out xHautGauche))
            {
                Console.WriteLine("Saisie invalide");
            }

            Console.Write("Entrez l'ordonnee du point en haut a gauche du rectangle R : ");
            while (!Double.TryParse(Console.ReadLine(), out yHautGauche))
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.Write("Entrez l'abscisse du point en bas a droite du rectangle R : ");
            while (!Double.TryParse(Console.ReadLine(), out xBasDroite) && xBasDroite > xHautGauche)
            {
                Console.WriteLine("Saisie invalide");
            }

            Console.Write("Entrez l'ordonnee du point en bas a droite du rectangle R : ");
            while (!Double.TryParse(Console.ReadLine(), out yBasDroite) && yBasDroite < yHautGauche)
            {
                Console.WriteLine("Saisie invalide");
            }

            Console.Write("Entrez l'abscisse du point X : ");
            while (!Double.TryParse(Console.ReadLine(), out xPoint))
            {
                Console.WriteLine("Saisie invalide");
            }

            Console.Write("Entrez l'ordonnee du point X : ");
            while (!Double.TryParse(Console.ReadLine(), out yPoint))
            {
                Console.WriteLine("Saisie invalide");
            }
            if (xPoint >= xHautGauche && xPoint <= xBasDroite && yPoint <= yHautGauche && yPoint >= yBasDroite)
            {
                Console.WriteLine("Le point X de coordonnee (" + xPoint + "," + yPoint + ") appartient au rectangle R");
            }
            else
            {
                Console.WriteLine("Le point X de coordonnee (" + xPoint + "," + yPoint + ") n'appartient pas au rectangle R");
            }
        }
    }
}