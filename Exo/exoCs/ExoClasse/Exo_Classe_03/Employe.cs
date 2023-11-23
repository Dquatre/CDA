using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Classe_03
{
    internal class Employe
    {
        public String Nom {  get; set; }    
        public String Prenom {  get; set; }    
        public DateTime DateEmbauche {  get; set; }    
        public String Poste {  get; set; }    
        public Double Salaire {  get; set; }
        public String Service { get; set; }
        public Agence Agence_Emp {  get; set; }
        public DateTime[] Enfants { get; set; }    

        public Employe(string nom, string prenom, DateTime dateEmbauche, string poste, double salaire, string service, Agence agence_Emp, DateTime[] enfants)
        {
            Nom = nom;
            Prenom = prenom;
            DateEmbauche = dateEmbauche;
            Poste = poste;
            Salaire = salaire;
            Service = service;
            Agence_Emp = agence_Emp;
            Enfants = enfants;
        }

        public int CalcAnneeAnciennete()
        {
            return (int)DateAndTime.DateDiff (DateInterval.Year, DateEmbauche,DateTime.Now );
        }

        public int CalcAge(DateTime dateNaissance)
        {
            return (int)DateAndTime.DateDiff(DateInterval.Year, dateNaissance, DateTime.Now);
        }

        public Double CalcPrime()
        {
            return Math.Round(Salaire * 0.05 + Salaire * 0.02 * CalcAnneeAnciennete(),2);
        }

        public void GenerOrdrePrime()
        {
            Console.WriteLine("Envoy de la somme de "+ CalcPrime() + " a de M/Mm " + Nom + " " + Prenom); 
        }

        public bool EstEligibleChequeVacance()
        {
            return CalcAnneeAnciennete() >= 1 ;
        }

        public String AfficheSommeChequeNoel()
        {
            String ret = "";
            int[] nbCheque = new int[3];
            for (int i = 0; i < Enfants.Length; i++)
            {
                if (CalcAge(Enfants[i]) < 11)
                {
                    nbCheque[0]++;
                }
                else if ((CalcAge(Enfants[i]) < 16))
                {
                    nbCheque[1]++;
                }
                else if ((CalcAge(Enfants[i]) < 19))
                {
                    nbCheque[2]++;
                }
            }
            if(nbCheque[0] > 0) ret += "\n" + nbCheque[0]+" Cheque de 20 euros";
            if(nbCheque[1] > 0) ret += "\n" + nbCheque[1]+" Cheque de 30 euros";
            if(nbCheque[2] > 0) ret += "\n" + nbCheque[2]+" Cheque de 50 euros";
            return ret;
        }

        public override string ToString()
        {
            return Nom + " " + Prenom + 
                "\nDate d'embauche : " + DateEmbauche + 
                "\nService : " + Service + 
                "\nPoste : " + Poste + 
                "\nSalaire annuel: " + Salaire + 
                "\nAgence : " + Agence_Emp.ToString() + 
                (EstEligibleChequeVacance()? "\ndispose de chèques vacances" : "\nne dispose pas de chèques vacances")+
                ((Enfants == null) ? "\nn'as pas droit a des cheque noel" : "\nas le droit a des cheque noel : "+ AfficheSommeChequeNoel());
        }
    }
}
