using Exo_Class_02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExoClasse_02
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            String cin;
            String nom;
            String prenom;
            String tel;
            */
            Double somme;

            /*
            do
            {
                Console.Write("Donner Le CIN : ");
                cin = Console.ReadLine();
            }
            while (!Regex.IsMatch(cin, "^\\w{2}\\d{6}$"));
            do
            {
                Console.Write("Donner Le Nom : ");
                nom = Console.ReadLine();
            }
            while (!Regex.IsMatch(nom, "^\\w{2,}$"));
            do
            {
                Console.Write("Donner Le Prenom : ");
                prenom = Console.ReadLine();
            }
            while (!Regex.IsMatch(prenom, "^\\w{2,}$"));
            do
            {
                Console.Write("Donner Le numéro de télephone : ");
                tel = Console.ReadLine();
            }
            while (!Regex.IsMatch(tel, "^0[1-8]\\d{8}$"));
            */
            Client c1 = new Client("EE519143", "Bertier", "Gontran", "0615264859");
            Compte cp = new Compte(c1);
            cp.Afficher();
            /*
            do
            {
                Console.Write("Donner Le numéro de télephone : ") ;
            }
            while (!Double.TryParse(Console.ReadLine(), out somme));
            */
            //cp.Crediter(somme);
            cp.Crediter(5000);
            cp.Afficher();
            cp.Debiter(1000);
            Client c2 = new Client("EE694123", "Danblar", "Flavien", "0652309801");
            Compte cp2 = new Compte(c2);
            cp2.Afficher();
            cp2.Crediter(3000);
            cp.Debiter(1000, cp2);
            cp.Afficher();
            cp2.Afficher();
            Compte.AfficherNbCompte();
        }
    }
}