using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_02
{
    internal class Client
    {
        public String Cin {get;set;}
        public String Nom {get;set;}
        public String Prenom {get;set;}
        public String Tel { get;set;}

        public Client(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }

        public Client(string cin, string nom, string prenom, string tel)
        {
            Cin = cin;
            Nom = nom;
            Prenom = prenom;
            Tel = tel;
        }

        public void Afficher()
        {
            Console.WriteLine("CIN : " + Cin);
            Console.WriteLine("NOM : " + Nom);
            Console.WriteLine("Prénom : " + Prenom);
            Console.WriteLine("Tél : " + Tel);
        }
    }
}
