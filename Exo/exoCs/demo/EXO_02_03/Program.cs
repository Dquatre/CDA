using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXO_02_03
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Double poidsCarton;
            Double poidsMaxCam;
            int nbrCarton;

            Console.WriteLine("Entrer le poids des cartons : ");
            poidsCarton = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Entrer le poids max du camion : ");
            poidsMaxCam = Convert.ToDouble(Console.ReadLine());
            nbrCarton = (int)(poidsMaxCam / poidsCarton);
            Console.WriteLine("le camion peut transporte "+nbrCarton+" carton");
        }
    }
}
