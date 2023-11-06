using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_03_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Double valeur;
            Double franchise;

            Console.Write("Entrez le montant des dommages : ");

            while (!Double.TryParse(Console.ReadLine(), out valeur) || valeur < 0)
            {
                Console.WriteLine("Saisie invalide");
            }
            franchise = valeur * 0.1;
            if (franchise > 4000)
            {
                franchise = 4000;
            }
            Console.WriteLine("vous serait rembourse "+(Math.Round(valeur - franchise,2))+" euros, avec une franchise de "+ Math.Round(franchise, 2) +" euros");
        }
    }
}