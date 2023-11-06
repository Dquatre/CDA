using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_05_05
{
    class Program
    {
        static void Main(string[] args)
        {
            String phrase, phrasePrime;
            Char carA, carB;

            Console.Write("Entrez une phrase : ");

            do
            {
                phrase = Console.ReadLine();
            } while (phrase == null);
            
            phrasePrime = phrase;
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

            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase[i] == carA)
                {
                    phrasePrime[i] = carB;
                }
            }
            Console.WriteLine(phrasePrime);
        }
    }
}