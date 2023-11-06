using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrer un nombre : ");
            string nbrSaisie = Console.ReadLine();
            float nbr = Convert.ToSingle(nbrSaisie);
            Console.WriteLine("valeur : " + (nbr));
        }
    }
}
