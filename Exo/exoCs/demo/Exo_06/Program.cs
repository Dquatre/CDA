using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrer la largeur : ");
            string nbrSaisie = Console.ReadLine();
            float largeur = Convert.ToSingle(nbrSaisie);
            Console.WriteLine("Entrer la longueur : ");
            string nbrSaisie2 = Console.ReadLine();
            float longueur = Convert.ToSingle(nbrSaisie2);
            Console.WriteLine("surface : " + (largeur*longueur));
        }
    }
}
