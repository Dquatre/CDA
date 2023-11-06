using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_05_03
{
    class Program
    {
        static void Main(string[] args)
        {
            String phrase;
            String phrasePrime = "";
            int indexDebut, indexFin;

            Console.Write("Entrez une phrase : ");
            phrase = Console.ReadLine();
            while (!int.TryParse(Console.ReadLine(), out indexDebut) || indexDebut < 0 || indexDebut > phrase.Length)
            {
                Console.WriteLine("Saisie invalide");
            }
            phrasePrime = phrase.Insert(indexDebut, phrase);
            Console.WriteLine(phrasePrime);
        }
    }
}