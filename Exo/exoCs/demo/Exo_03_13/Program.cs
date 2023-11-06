using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_03_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Double borneA, borneB , nbrX;

            Console.Write("Entrez la premiere borne : ");
            while (!Double.TryParse(Console.ReadLine(), out borneA) )
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.Write("Entrez la deuxieme borne : ");
            while (!Double.TryParse(Console.ReadLine(), out borneB) && borneB > borneA)
            {
                Console.WriteLine("Saisie invalide");
            }

            Console.Write("Entrez un nombre : ");
            while (!Double.TryParse(Console.ReadLine(), out nbrX))
            {
                Console.WriteLine("Saisie invalide");
            }
            if(nbrX <= borneA && nbrX >= borneB)
            {
                Console.WriteLine(nbrX + " est compris dans l'intervalle [" + borneA + "," + borneB + "]");
            }
            else
            {
                Console.WriteLine(nbrX + " n'est pas compris dans l'intervalle [" + borneA + "," + borneB + "]");
            }
        }
    }
}