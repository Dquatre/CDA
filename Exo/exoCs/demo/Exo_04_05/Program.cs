using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_04_05
{
    class Program
    {
        static void Main(string[] args)
        {
            int nbr;

            Console.Write("Entrez un nombre : ");
            while (!int.TryParse(Console.ReadLine(), out nbr))
            {
                Console.WriteLine("Saisie invalide");
            }
           
            Console.WriteLine(Factoriel(nbr));
            
        }
        private static int Factoriel(int nbr)
        {
            return nbr == 0 ? 1 : nbr*Factoriel(nbr-1);
        }
    }
}