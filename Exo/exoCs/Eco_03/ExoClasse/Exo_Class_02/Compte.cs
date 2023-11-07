using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_02
{
    internal class Compte
    {
        private static int NnCompte {  get; set; }
        private int Code { get; set; }
        private Double Solde { get; set; }
        public Client Proprietaire { get; set; }

        public Compte( Client proprietaire)
        {
            Code = ++NnCompte;
            Solde = 0;
            Proprietaire = proprietaire;
        }

        public void Crediter(Double somme)
        {
            Solde += somme;
            Console.WriteLine("Opération bien effectuée");
        }
        public void Crediter(Double somme, Compte debiteur)
        {
            Solde += somme;
            debiteur.Debiter(somme);
            Console.WriteLine("Opération bien effectuée");
        }
        public void Debiter(Double somme)
        {
            Solde -= somme;
            Console.WriteLine("Opération bien effectuée");
        }
        public void Debiter(Double somme, Compte crediteur)
        {
            Solde -= somme;
            crediteur.Crediter(somme);
            Console.WriteLine("Opération bien effectuée");

        }

        public void Afficher()
        {
            Console.WriteLine("**************************");
            Console.WriteLine("Numéro de Compte : " + Code);
            Console.WriteLine("Solde de compte : " + Solde);
            Console.WriteLine("Propriétaire du compte : ");
            Proprietaire.Afficher();
            Console.WriteLine("**************************");
        }
        public static void AfficherNbCompte()
        {
            Console.WriteLine("Nombre de Compte : " + NnCompte);
        }
    }
}
