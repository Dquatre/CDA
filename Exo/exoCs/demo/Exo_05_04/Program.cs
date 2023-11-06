using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_05_04
{
    class Program
    {
        static void Main(string[] args)
        {
            String phrase;
            String phrasePrime = "";
            Char carA, carB;

            Console.Write("Entrez une phrase : ");
            phrase = Console.ReadLine();
            Console.Write("Entrez une lettre : ");
            while (!Char.TryParse(Console.ReadLine(), out carA) || !phrase.Contains(carA))
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.Write("Entrez une autre lettre : ");
            while (!Char.TryParse(Console.ReadLine(), out carB))
            {
                Console.WriteLine("Saisie invalide");
            }

            phrasePrime = phrase.Replace(carA,carB);
            Console.WriteLine(phrasePrime);
        }
    }
}