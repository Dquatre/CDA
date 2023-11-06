using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrer un nombre : ");
            string nbrSaisie = Console.ReadLine();
            int nbr = Convert.ToInt32(nbrSaisie);
            Console.WriteLine("Entrer un autre nombre : ");
            string nbrSaisie2 = Console.ReadLine();
            int nbr2 = Convert.ToInt32(nbrSaisie2);
            Console.WriteLine("somme : "+(nbr + nbr2));
            Console.WriteLine("quotient : " + (nbr * nbr2));
        }
    }
}
