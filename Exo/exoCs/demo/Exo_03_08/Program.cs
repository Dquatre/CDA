using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_03_08
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            int j;

            Console.Write("Entrez un nombre : ");
            while (!int.TryParse(Console.ReadLine(), out i)|| i < 1 || i > 8)
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.Write("Entrez un deuxieme nombre : ");
            while (!int.TryParse(Console.ReadLine(), out j) || j < 1 || j > 8)
            {
                Console.WriteLine("Saisie invalide");
            }
            if ((i+j)%2==0)
            {
                Console.WriteLine(i+" "+j+" est une case noir");
            }
            else
            {
                Console.WriteLine(i + " " + j + " est une case blanche");
            }

        }
    }
}