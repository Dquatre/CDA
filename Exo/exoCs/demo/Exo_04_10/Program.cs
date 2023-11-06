using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_04_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Double valeurA;
            Double valeurB = 0;
            Char operateur;
            bool fini = false;
            Console.Write("Entrez un nombre : ");
            while (!Double.TryParse(Console.ReadLine(), out valeurA))
            {
                Console.WriteLine("Saisie invalide");
            }
            

            while (!fini) { 
                Console.Write("Entrez un operateur : ");
                while (!Char.TryParse(Console.ReadLine(), out operateur) || !(operateur == '+' || operateur == '-' || operateur == '*' || operateur == '/' || operateur == '=' || operateur == '$' || operateur == 'r' || operateur == '!'))
                {
                    Console.WriteLine("Saisie invalide");
                }
                if (operateur != '=' && operateur != 'r' && operateur != '!' )
                {
                    Console.Write("Entrez un deuxieme nombre : ");
                    while (!Double.TryParse(Console.ReadLine(), out valeurB))
                    {
                        Console.WriteLine("Saisie invalide");
                    }
                }

                switch (operateur)
                {
                    case '+':
                        valeurA = valeurA + valeurB;
                        break;
                    case '-':
                        valeurA = valeurA - valeurB;
                        break;
                    case '*':
                        valeurA = valeurA * valeurB;
                        break;
                    case '/':
                        if (valeurB != 0)
                        {
                            valeurA = valeurA / valeurB;
                        }
                        else
                        {
                            valeurA = 0;
                            Console.WriteLine("pas de division par zero");
                        }
                        break;
                    case '$':
                        valeurA = Math.Pow(valeurA , valeurB);
                        break;
                    case 'r':
                        valeurA = Math.Sqrt(valeurA) ;
                        break;
                    case '!':
                        if (valeurA % 1 == 0)
                        {
                            valeurA = Fact(valeurA);
                        }
                        else
                        {
                            Console.WriteLine("ce programe ne factorise que les entier");
                        }
                        break;
                    case '=':
                        fini = true;
                        break;
                    default:
                        
                        break;
                }
                Console.WriteLine(valeurA);
            }
        }
        static Double Fact(Double nbr)
        {
            return nbr <= 0 ? 1 : nbr * Fact(nbr - 1);
        }
    }
}