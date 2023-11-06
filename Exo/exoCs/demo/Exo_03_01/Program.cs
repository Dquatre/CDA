using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_03_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int valeur;

            Console.Write("Entrez votre age : ");
            
            while (!int.TryParse(Console.ReadLine(), out valeur)||valeur<0)
            {
                Console.WriteLine("Saisie invalide");
            }
            if (valeur>18)
            {
                Console.WriteLine("vous etes majeur");
            }
            else
            {
                Console.WriteLine("vous etes mineur");
            }

        }
    }
}