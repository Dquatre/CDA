using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_07_sousProgram
{
    class Program
    {
        
        /* Affiche le caractère c */
        public static void afficheCaractere(char c)
        {
            Console.Write(c);
        }
        /* ∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗ */
        /*
        Affiche n fois le caractère c, ne revient pas à la ligne après le dernier caractère.
        */
        public static void ligneSansReturn(int n, char c)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(c);
            }
            
        }
        /* ∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗ */
        /*
        Affiche n fois le caractère c, revient a la ligne après le dernier caractère.
        */
        public static void ligneAvecReturn(int n, char c)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }
        /* ∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗ */
        /* Affiche n espaces . */
        public static void espaces(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }
        }
        /* ∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗ */
        /* Affiche le caractère c a la colonne i, ne revient pas à la ligne après. */
        public static void unCaractereSansReturn(int i, char c)
        {
            espaces(i - 1);
            Console.Write(c);
        }
        /* ∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗ */
        /* Affiche le caractère c à la colonne i, revient a la ligne après. */
        public static void unCaractereAvecReturn(int i, char c)
        {
            espaces(i-1);
            Console.WriteLine(c);
        }
        /* ∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗ */
        /* Affiche le caractère c aux colonnes i et j, revient a la ligne après.
        */
        public static void deuxCaracteres(int i, int j, char c)
        {
            unCaractereSansReturn(i, c);
            unCaractereAvecReturn(j+2-i, c);

        }
        /* ∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗ */
        /*
        Affiche un carre de cote n .
        */
        public static void carre(int n)
        {
            ligneAvecReturn(n, '.');
            for (int i = 1; i < n - 1; i++)
            {
                afficheCaractere('.');
                unCaractereAvecReturn(n-1,'.');
            }
            ligneAvecReturn(n, '.');
        }
        /* ∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗ */
        /* Affiche un chapeau dont la pointe − non affichee – est sur la colonne centre , avec 
       les caractères c. */
        public static void chapeau(int centre, char c)
        {
            for (int i = 0; i < centre - 1; i++)
            {
                deuxCaracteres(centre - i, centre + i, c);
            }
        }
        /* ∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗ */
        /*
        Affiche un chapeau a l ’ envers avec des caracteres c,
        la pointe − non affichee − est à la colonne c entre
        */
        public static void chapeauInverse(int centre, char c)
        {
            for (int i = centre-2; i >= 0; i--)
            {
                deuxCaracteres(centre - i, centre + i, c);
            }
        }
        /* ∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗ */
        /*
        Affiche un losange de cote n .
        */
        public static void losange(int n)
        {
            unCaractereAvecReturn(n,'.');
            chapeau(n - 1, '.');
            afficheCaractere('.');
            unCaractereAvecReturn(n*2-2,'.');
            chapeauInverse(n - 1, '.');
            unCaractereAvecReturn(n, '.');
        }
        /* ∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗∗ */
        /*
        Affiche une croix de cote n
        */
        public static void croix(int n)
        {
            afficheCaractere('.');
            unCaractereAvecReturn(n * 2 - 2, '.');
            chapeauInverse(n - 1, '.');
            unCaractereAvecReturn(n, '.');
            chapeau(n - 1, '.');
            afficheCaractere('.');
            unCaractereAvecReturn(n * 2 - 2, '.');
        }

        public static int unites(int n)
        {
            return n%10;
        }
        public static int dizaines(int n)
        {
            return (n % 100 - unites(n))/10;
        }
        public static int extrait(int n, int p )
        {
            int ret;
            if (p > 0)
            {
                ret = n % (int)Math.Pow(10, p) - extrait(n, p - 1); 
            }
            else
            {
                return 0;
            }
            return ret / (int)Math.Pow(10, p - 1);
        }

        static void Main(string[] args)
        {
            /*
            int taille;
            Console.Write("Entrez un nombre : ");
            while (!int.TryParse(Console.ReadLine(), out taille) || taille < 0)
            {
                Console.WriteLine("Saisie invalide");
            }
            carre(taille);
            losange(taille);
            croix(taille);
            */
            int nb;
            int rd;
            Console.Write("Entrez un nombre : ");
            while (!int.TryParse(Console.ReadLine(), out nb) || nb < 0)
            {
                Console.WriteLine("Saisie invalide");
            }
            Console.Write("Entrez un nombre : ");
            while (!int.TryParse(Console.ReadLine(), out rd) || rd < 0 || rd > 10)
            {
                Console.WriteLine("Saisie invalide");
            }
            //Console.WriteLine(unites(nb));
            //Console.WriteLine(dizaines(nb));
            Console.WriteLine(extrait(nb, rd));
        }
    }
}
