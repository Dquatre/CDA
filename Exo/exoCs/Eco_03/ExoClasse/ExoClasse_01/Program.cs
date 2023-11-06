using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoClasse_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Voiture C4 = new Voiture("Citroen","C4",10000);
            Voiture RenKad = new Voiture(" Renault", "Kadjar","rouge");
            Console.WriteLine(C4.ToString());
            Console.WriteLine(RenKad
                .ToString());
        }
    }
    
}