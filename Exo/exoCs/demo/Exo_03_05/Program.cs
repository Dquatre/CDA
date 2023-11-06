using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_03_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Double valeurA;
            Double valeurB;
            int nbValDistinct = 1;

            Console.Write("Entrez un nombre : ");
            while (!Double.TryParse(Console.ReadLine(), out valeurA))
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.Write("Entrez un deuxieme nombre : ");
            while (!Double.TryParse(Console.ReadLine(), out valeurB))
            {
                Console.WriteLine("Saisie invalide");
            }
            if (valeurB != valeurA)
            {
                nbValDistinct++;
            }
            Console.WriteLine("il y a "+nbValDistinct+" valeur distinct");

        }
    }
}