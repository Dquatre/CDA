using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_03_06
{
    class Program
    {
        static void Main(string[] args)
        {
            Double valeurA;
            Double valeurB;
            Double valeurC;
            Double valeurMin;

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
            Console.Write("Entrez un troisieme nombre : ");
            while (!Double.TryParse(Console.ReadLine(), out valeurC))
            {
                Console.WriteLine("Saisie invalide");
            }

            if (valeurA < valeurB)
            {
                valeurMin = valeurA;
            }
            else
            {
                valeurMin = valeurB;
            }
            if (valeurC < valeurMin)
            {
                valeurMin = valeurC;
            }
            Console.WriteLine("la plus petit valeur est " + valeurMin);

        }
    }
}