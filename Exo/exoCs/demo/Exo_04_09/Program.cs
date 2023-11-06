using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_04_09
{
    class Program
    {
        static void Main(string[] args)
        {
            int nbr;

            Console.Write("Entrez un nombre : ");
            while (!int.TryParse(Console.ReadLine(), out nbr) && nbr >= 0)
            {
                Console.WriteLine("Saisie invalide");
            }
            for (int i = 1; i <= nbr; i++)
            {
                for (int j = 1; j <= nbr; j++)
                {
                    Console.Write("X ");
                }
                Console.WriteLine();
            }

        }

    }
}