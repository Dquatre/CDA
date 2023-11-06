using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_03_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int choixPiece;
            int i;
            int j;
            int iPrime;
            int jPrime;
            String nomPiece = "";
            bool estCorrect = false;

            Console.Write("Quelle pièce souhaitez-vous déplacer ? ");
            while (!int.TryParse(Console.ReadLine(), out choixPiece) || choixPiece < 0 || choixPiece > 4)
            {
                Console.WriteLine("Saisie invalide");
            }

            switch (choixPiece)
            {
                case 0:
                    nomPiece = "Chevalier"; 
                    break;
                case 1:
                    nomPiece = "Tour";
                    break;
                case 2:
                    nomPiece = "Fou";
                    break;
                case 3:
                    nomPiece = "Dame";
                    break;
                case 4:
                    nomPiece = "Roi";
                    break;
            }

            Console.Write("Entrez les coordonnees de depart : ");
            while (!int.TryParse(Console.ReadLine(), out i) || i < 1 || i > 8)
            {
                Console.WriteLine("Saisie invalide");
            }
            while (!int.TryParse(Console.ReadLine(), out j) || j < 1 || j > 8)
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.Write("Entrez les coordonnees d'arrivee : ");
            while (!int.TryParse(Console.ReadLine(), out iPrime) || iPrime < 1 || iPrime > 8)
            {
                Console.WriteLine("Saisie invalide");
            }
            while (!int.TryParse(Console.ReadLine(), out jPrime) || jPrime < 1 || jPrime > 8)
            {
                Console.WriteLine("Saisie invalide");
            }

            if (choixPiece == 0 && (Math.Abs(i - iPrime ) == 2 && Math.Abs(j - jPrime) == 1 || (Math.Abs(i - iPrime) == 1 && Math.Abs(j - jPrime) == 2)))
            {
                estCorrect = true;
            }
            else if(choixPiece == 1 && (j == jPrime ^ i == iPrime))
            {
                estCorrect = true;
            }
            else if (choixPiece == 2 && (Math.Abs(i - iPrime) == Math.Abs(j - jPrime)))
            {
                estCorrect = true;
            }
            else if (choixPiece == 3 && ((j == jPrime ^ i == iPrime) ^ (Math.Abs(i - iPrime) == Math.Abs(j - jPrime))))
            {
                estCorrect = true;
            }
            else if (choixPiece == 4 && ((j == jPrime ^ i == iPrime) ^ (Math.Abs(i - iPrime) == 1 && Math.Abs(j - jPrime) == 1 )))
            {
                estCorrect = true;
            }

            Console.WriteLine("le deplacement du " + nomPiece + " de (" + i + "," + j + ") vers (" + iPrime + "," + jPrime + ") est "+(estCorrect?"correcte":"impossible"));
            
        }
    }
}