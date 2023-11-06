using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_03_12
{
    class Program
    {
        static void Main(string[] args)
        {
            int jour = 0;
            int mois, annee;
            int jourD = 0;
            int moisD = 0;
            int anneeD = 0;
            bool estInvalide = true;

            Console.Write("Entrez l'annee : ");
            while (!int.TryParse(Console.ReadLine(), out annee) || annee < 1)
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.Write("Entrez le mois : ");
            while (!int.TryParse(Console.ReadLine(), out mois) || mois < 1 || mois > 12)
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.Write("Entrez le jour : ");
            while (estInvalide)
            {
                int.TryParse(Console.ReadLine(), out jour);
                if (jour > 31 
                    ||((mois == 4 || mois == 6 || mois == 9 || mois == 11) && jour>30)
                    || (mois == 2 && annee % 4 == 0 && (annee % 100 != 0 || annee % 400 == 0) && jour > 29 )
                    || (mois == 2 && annee % 4 != 0 && jour > 28))
                {
                    Console.WriteLine("Saisie invalide");
                }
                else
                {
                    estInvalide = false;
                }
            }

            Console.WriteLine(String.Format("{0,2:D2}", jour) + " " + String.Format("{0,2:D2}", mois) + " " + String.Format("{0,2:D2}", annee));

            if (jour == 31 && mois == 12)
            {
                jourD = 1;
                moisD = 1;
                anneeD = annee+1;
            }else if (!(mois == 4 || mois == 6 || mois == 9 || mois == 11) && jour == 31
                    || ((mois == 4 || mois == 6 || mois == 9 || mois == 11) && jour == 30)
                    || (mois == 2 && annee % 4 == 0 && (annee % 100 != 0 || annee % 400 == 0) && jour == 29)
                    || (mois == 2 && annee % 4 != 0 && jour == 28))
            {
                jourD = 1;
                moisD = mois+1;
                anneeD = annee;
            }
            else
            {
                jourD = jour+1;
                moisD = mois;
                anneeD = annee;
            }


            Console.WriteLine(String.Format("{0,2:D2}", jourD) + " " + String.Format("{0,2:D2}", moisD) + " " + String.Format("{0,2:D2}", anneeD));
        }
    }
}