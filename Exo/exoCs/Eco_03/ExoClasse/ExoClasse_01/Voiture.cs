using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoClasse_01
{
    internal class Voiture
    {
        public String Couleur { get; set; }
        public String Marque { get; set; }
        public String Modele { get; set; }
        public int NbKilometre { get; set; }
        public String Motorisation { get; set; }


        public Voiture(string marque, string modele, string? couleur)
        {
            Couleur = couleur;
            Marque = marque;
            Modele = modele;
            
        }

        public Voiture(string marque, string modele, int nbKilometre)
        {
            
            Marque = marque;
            Modele = modele;
            NbKilometre = nbKilometre;
        }

        public Voiture( string marque, string modele, int? nbKilometre,string? couleur , string? motorisation)
        {
            Couleur = couleur;
            Marque = marque;
            Modele = modele;
            NbKilometre = (int)nbKilometre;
            Motorisation = motorisation;
        }

        public override String ToString()
        {
            return "Voiture : \n\tMarque : " + Marque + "\n\tModele : " + Modele + "\n\tCouleur : " + Couleur + "\n\tNbKilometre : " + NbKilometre + "\n\tMotorisation : " + Motorisation;
        }
    }
}
