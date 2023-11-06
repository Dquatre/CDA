using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_03_09
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            int j;
            int iPrime;
            int jPrime;
            Console.Write("Entrez les coordonnees de depart : ");
            while (!int.TryParse(Console.ReadLine(), out i) || i < 1 || i > 8)
            {
                Console.WriteLine("Saisie invalide");
            }
            while (!int.TryParse(Console.ReadLine(), out j) || j < 1 || j > 8)
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.Write("Entrez les coordonnees d'arrivee : ");
            while (!int.TryParse(Console.ReadLine(), out iPrime) || iPrime < 1 || iPrime > 8)
            {
                Console.WriteLine("Saisie invalide");
            }
            while (!int.TryParse(Console.ReadLine(), out jPrime) || jPrime < 1 || jPrime > 8)
            {
                Console.WriteLine("Saisie invalide");
            }

            if (Math.Abs(i - iPrime) == 2 && Math.Abs(j - jPrime) == 1 || (Math.Abs(i - iPrime) == 1 && Math.Abs(j - jPrime) == 2))
            {
                Console.WriteLine("le deplacement de ("+i+","+j+") vers (" + iPrime + "," + jPrime + ") est correct");
            }
            else
            {
                Console.WriteLine("le deplacement de (" + i + "," + j + ") vers (" + iPrime + "," + jPrime + ") est impossible");
            }
        }
    }
}