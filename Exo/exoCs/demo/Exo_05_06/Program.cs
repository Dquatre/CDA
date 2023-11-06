using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_05_06
{
    class Program
    {
        static void Main(string[] args)
        {
            String pattern = "\w";
            String phrase,extention = ".";
            do
            {
                Console.Write("Entrez un nom de fichier : ");
                phrase = Console.ReadLine();
            } while (!phrase.Contains('.'));

            String[] div = phrase.Split('.');
            extention += div.Last();
            Console.WriteLine(extention);
        }
    }
}