using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exo_05_07
{
    class Program
    {
        static void Main(string[] args)
        {
            String phrase;
            String pattern = "^([(]*\\d+[)]*[-/*+]?)+$";
            bool change = false,valide = true;
            int i = 0; 
            int ouvr = 0, ferm = 0;
            Match match;
            do
            {
                Console.Write("Entrez une expression : ");
                phrase = Console.ReadLine();
                match = Regex.Match(phrase, pattern);
            } while (!match.Success);
            while (i < phrase.Length && valide)
            {
                change = false;
                if (phrase[i] == '(')
                {
                    ouvr++;
                    change = true;
                }
                else if (phrase[i] == ')')
                {
                    ferm++;
                    change = true;
                }
                if (change && ferm > ouvr)
                {
                    valide = false;
                }
                i++;
            }
            if (valide && ouvr == ferm)
            {
                Console.WriteLine("la formule est bien parentese"); 
            }
            else
            {
                Console.WriteLine("la formule n'est pas bien parentese");
            }
        }
    }
}