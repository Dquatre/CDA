using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_07
{
    internal abstract class Employes
    {
        public int Age { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public Double Salaire { get; set; }

        protected Employes(int age, string nom, string prenom)
        {
            Age = age;
            Nom = nom;
            Prenom = prenom;
            Salaire = CalculSalaire();
        }

        protected void Afficher() 
        {
            Console.WriteLine(this);
        }

        protected Double CalculSalaire()
        {
            return 0;
        }

        public override String ToString()
        {
            return base.ToString()+ "\tNom : " + Nom + "\tPrenom : " + Prenom + "\tAge : " + Age + "\tSalaire : " + Salaire;
        }
    }
}
