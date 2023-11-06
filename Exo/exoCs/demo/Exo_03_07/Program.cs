using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_03_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Double valeurA;
            Double valeurB;
            Double result;
            Char operateur;

            Console.Write("Entrez un nombre : ");
            while (!Double.TryParse(Console.ReadLine(), out valeurA))
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.Write("Entrez un deuxieme nombre : ");
            while (!Double.TryParse(Console.ReadLine(), out valeurB))
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.Write("Entrez un operateur : ");
            while (!Char.TryParse(Console.ReadLine(), out operateur)||!(operateur == '+' || operateur == '-' || operateur == '*' || operateur == '/'))
            {
                Console.WriteLine("Saisie invalide");
            }
            switch (operateur)
            {
                case '+':
                    result = valeurA + valeurB;
                    break;
                case '-':
                    result = valeurA - valeurB;
                    break;
                case '*':
                    result = valeurA * valeurB;
                    break;
                case '/':
                    if (valeurB != 0)
                    {
                        result = valeurA / valeurB;
                    }
                    else
                    {
                        result = 0;
                        Console.WriteLine("pas de division par zero");
                    }
                    break;
                default:
                    result = 0;
                    break;
            }
            Console.WriteLine(result);
        }
    }
}