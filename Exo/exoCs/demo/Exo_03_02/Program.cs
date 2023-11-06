using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_03_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Double valeur;

            Console.Write("Entrez une valeur : ");

            while (!Double.TryParse(Console.ReadLine(), out valeur))
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.WriteLine("Valeur absolu : "+Math.Abs(valeur));

        }
    }
}