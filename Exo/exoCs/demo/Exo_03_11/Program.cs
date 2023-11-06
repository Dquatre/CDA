using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_03_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int heureDep;
            int minDep;
            int heureFin;
            int minFin;
            int heureDiff;
            int minDiff;

            Console.Write("Entrez l'heure de depart : ");
            while (!int.TryParse(Console.ReadLine(), out heureDep) || heureDep < 0 || heureDep > 23)
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.Write("Entrez les minute : ");
            while (!int.TryParse(Console.ReadLine(), out minDep) || minDep < 0 || minDep > 59)
            {
                Console.WriteLine("Saisie invalide");
            }

            Console.Write("Entrez l'heure de fin : ");
            while (!int.TryParse(Console.ReadLine(), out heureFin) || heureFin < 0 || heureFin > 23)
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.Write("Entrez les minute : ");
            while (!int.TryParse(Console.ReadLine(), out minFin) || minFin < 0 || minFin > 59)
            {
                Console.WriteLine("Saisie invalide");
            }
            if (heureDep > heureFin || (heureDep == heureFin && minDep > minFin))
            {
                Console.WriteLine("la date de depart doit etre anterieur a la date de fin");
            }
            else
            {
                heureDiff = heureFin - heureDep;
                minDiff = minFin - minDep;
                if (minDiff < 0)
                {
                    heureDiff--;
                    minDiff += 60;
                }
                Console.WriteLine(String.Format("{0,2:D2}", heureDiff) + "h" + String.Format("{0,2:D2}", minDiff));
            }
        }
       
    }
}