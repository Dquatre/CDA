using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_03_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int valeur;

            Console.Write("Entrez une note : ");

            while (!int.TryParse(Console.ReadLine(), out valeur) || valeur < 0|| valeur > 20)
            {
                Console.WriteLine("Saisie invalide");
            }
            if (valeur > 10)
            {
                Console.WriteLine("admis");
            }
            else if(valeur > 7)
            {
                Console.WriteLine("rattrapage");
            }
            else
            {
                Console.WriteLine("ajourné");
            }

        }
    }
}