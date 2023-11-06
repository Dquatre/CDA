using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_05_02
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
            Console.Write("Entrez un index de debut : ");
            while (!int.TryParse(Console.ReadLine(), out indexDebut) || indexDebut < 0 || indexDebut > phrase.Length)
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.Write("Entrez un index de fin : ");
            while (!int.TryParse(Console.ReadLine(), out indexFin) || indexFin < indexDebut || indexFin >= phrase.Length)
            {
                Console.WriteLine("Saisie invalide");
            }

            for (int i = indexDebut; i < indexFin + 1; i++)
            {
                phrasePrime += phrase[i];
            }
            Console.WriteLine(phrasePrime);
        }
    }
}