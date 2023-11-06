using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_04_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int nbr;
            int nbrAffiche ;
            Console.Write("Entrez un nombre : ");
            while (!int.TryParse(Console.ReadLine(), out nbr))
            {
                Console.WriteLine("Saisie invalide");
            }
            nbrAffiche = nbr;
            for (int i = 0; i <= nbr; i++)
            {
                Console.WriteLine(nbrAffiche--);
            }
        }
    }
}