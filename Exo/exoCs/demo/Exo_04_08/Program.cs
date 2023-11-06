using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_04_08
{
    class Program
    {
        static void Main(string[] args)
        {
            int nbr;
            int exposant;

            Console.Write("Entrez un nombre : ");
            while (!int.TryParse(Console.ReadLine(), out nbr) && nbr >= 0)
            {
                Console.WriteLine("Saisie invalide");
            }

            Console.Write("Entrez un nombre : ");
            while (!int.TryParse(Console.ReadLine(), out exposant) && exposant >= 0)
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.WriteLine(Math.Pow(nbr,exposant));
        }

    }
}