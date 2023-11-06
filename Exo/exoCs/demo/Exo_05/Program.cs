using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrer un nombre : ");
            string nbrSaisie = Console.ReadLine();
            float nbr = Convert.ToSingle(nbrSaisie);
            Console.WriteLine("Entrer un nombre : ");
            string nbrSaisie2 = Console.ReadLine();
            float nbr2 = Convert.ToSingle(nbrSaisie2);
            Console.WriteLine("Entrer un nombre : ");
            string nbrSaisie3 = Console.ReadLine();
            float nbr3 = Convert.ToSingle(nbrSaisie3);
            Console.WriteLine("moyenne : " + ((nbr+nbr2+nbr3)/3));
        }
    }
}
