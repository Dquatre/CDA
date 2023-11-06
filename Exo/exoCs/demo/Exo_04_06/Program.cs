using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_04_06
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

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(nbr + " X "+(i+1)+" = "+(nbr*(i + 1)));
            }

        }
        
    }
}