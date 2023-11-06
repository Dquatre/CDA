using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrer un nombre : ");
            string nbrSaisie = Console.ReadLine();
            int nbr = Convert.ToInt32(nbrSaisie);
            Console.WriteLine(nbr);
        }
    }
}
