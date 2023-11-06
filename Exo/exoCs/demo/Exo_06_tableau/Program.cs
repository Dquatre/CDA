using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exo_06_tableau
{
    class Program
    {
        static void Main(string[] args)
        {
            //exo 4
            /*
            int[] T = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (var item in T)
            {
                Console.WriteLine(item);
            }
            */

            //exo 5
            /*
            int[] T = new int[10];
            for (int i = 0; i < T.Length; i++)
            {
                T[i] = i+1;
            }
            foreach (var item in T)
            {
                Console.WriteLine(item);
            }
            */

            //exo 6
            /*
            int[] T = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine(T.Sum());
            */

            //exo 7
            /*
            int[] T = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int chercher;
            Console.Write("Entrez un nombre : ");
            while (!int.TryParse(Console.ReadLine(), out chercher))
            {
                Console.WriteLine("Saisie invalide");
            }
            if (T.Contains(chercher))
            {
                Console.WriteLine("le tableau contient "+chercher);
            }
            else
            {
                Console.WriteLine("le tableau ne contient pas " + chercher);
            }
            */

            //exo 8
            /*
            int[] T = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] permuter = new int[T.Length];
            for (int i = 1; i < T.Length; i++)
            {
                permuter[i] = T[i-1];
            }
            permuter[0] = T[T.Length - 1];

            foreach (var item in T)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            foreach (var item in permuter)
            {
                Console.Write(item + " ");
            }
            */

            //exo 9
            /*
            int[] T = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int temp = T[T.Length-1];

            foreach (var item in T)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            for (int i = T.Length - 1; i > 0  ; i--)
            {
                T[i] = T[i-1];
            }
            T[0] = temp;

            foreach (var item in T)
            {
                Console.Write(item + " ");
            }
            */

            //exo 10
            /*
            int[] T = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int temp = 0;
            foreach (var item in T)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < T.Length/2; i++)
            {
                temp = T[T.Length - i - 1];
                T[T.Length - i - 1] = T[i];
                T[i] = temp;
            }

            foreach (var item in T)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            */

            //exo 11
            /*
            Double[] T = new Double[20];

            for (int i = 0; i < T.Length; i++)
            {
                T[i] = Math.Pow(i,2)%17;
            }
            foreach (var item in T)
            {
                Console.WriteLine(item + " ");
            }
            */

            //exo 12
            /*
            Double[] T = new Double[20];

            for (int i = 0; i < T.Length; i++)
            {
                T[i] = Math.Pow(i,2)%17;
            }

            Console.WriteLine(T.Min());
            Console.WriteLine(T.Max());
            */

            //exo 13
            /*
            Double[] T = new Double[20];
            List<Double> indexes = new List<Double>();
            Double chercher;
            for (int i = 0; i < T.Length; i++)
            {
                T[i] = Math.Pow(i, 2) % 17;
            }

            Console.Write("Entrez un nombre : ");
            while (!Double.TryParse(Console.ReadLine(), out chercher))
            {
                Console.WriteLine("Saisie invalide");
            }
            for (int i = 0; i < T.Length; i++)
            {
                if (T[i]==chercher)
                {
                    indexes.Add(i);
                }
            }

            foreach (var item in indexes)
            {
                Console.WriteLine(item);
            }
            */

            //exo 14
            /*
            Double[] T = new Double[20];
            List<Double> indexes = new List<Double>();
            Double chercher;
            for (int i = 0; i < T.Length; i++)
            {
                T[i] = Math.Pow(i, 2) % 17;
            }

            Console.Write("Entrez un nombre : ");
            while (!Double.TryParse(Console.ReadLine(), out chercher))
            {
                Console.WriteLine("Saisie invalide");
            }
            for (int i = 0; i < T.Length; i++)
            {
                if (T[i] == chercher)
                {
                    indexes.Add(i);
                }
            }
            if (indexes == null)
            {
                Console.WriteLine("la valeur "+ chercher + " n'est pas dans T");
            }
            else
            {
                foreach (var item in indexes)
                {
                    Console.WriteLine(item);
                }
            }

            */
            //exo 15
            /*
            Double du = 0;
            String saisie = "";
            Double[] valeurPiece = {0.5,0.2,0.1,0.05,0.02,0.01};
            int[] nbPiece = new int[valeurPiece.Length];
            Console.WriteLine("Vous devez : ");

            while (!Double.TryParse(Console.ReadLine(), out du))
            {
                Console.WriteLine("Saisie invalide");
            }
        
            for (int i = 0; i < valeurPiece.Length; i++)
            {
                while (Math.Round(du,2) >= Math.Round(valeurPiece[i],2))
                {
                    nbPiece[i]++;
                    du -= Math.Round(valeurPiece[i],2);
                }
                if(nbPiece[i] > 0)
                    Console.WriteLine(nbPiece[i] + " pièce de "+ valeurPiece[i] + " centime");
            }
            */

            Random rnd = new Random();
            int[] T = new int[20];
            int min =0;
            int temp = 0;
            int trancheI , trancheJ , trancheImin = 0, trancheJmin = 0;

            Console.Write("Entrez la premiere borne : ");
            while (!int.TryParse(Console.ReadLine(), out trancheI))
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.Write("Entrez la second borne : ");
            while (!int.TryParse(Console.ReadLine(), out trancheJ))
            {
                Console.WriteLine("Saisie invalide");
            }



            for (int i = 0; i < T.Length; i++)
            {
                T[i] = rnd.Next(-99,99);
            }
            for (int ip = 0; ip < trancheJ - trancheI; ip++)
            {
                min += T[0 + ip];
            }

            for (int j = 1; j < T.Length - 2; j++)
            {
                for (int k = 0; k < trancheJ - trancheI; k++)
                {
                    temp += T[j+k];
                }
                
                if (temp < min)
                {
                    min = temp;
                    trancheImin = j;
                    trancheJmin = j + 2;
                }
            }
            Console.WriteLine("la plus petite tranche de "+ trancheImin + ",...,"+ trancheJmin);
        }
    }
}