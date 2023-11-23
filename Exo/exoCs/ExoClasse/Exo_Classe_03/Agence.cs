using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Classe_03
{
    internal class Agence
    {
        public String Nom { get; set; }
        public String Adresse { get; set;}
        public String CodePostal { get; set; }
        public String Ville { get; set; }
        public String ModeRestauration { get; set; }

        public Agence(string nom, string adresse, string codePostal, string ville, string modeRestauration)
        {
            Nom = nom;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
            ModeRestauration = modeRestauration;        
        }
        public override String ToString()
        {
            return Nom + "\n" + Adresse + " " + CodePostal + " " + Ville + "\nMode de restaurateur : " + ModeRestauration;
        }
    }
}
