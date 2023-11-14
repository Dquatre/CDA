using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_07
{
    public abstract class Employes
    {
        public int Age { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public Double Salaire { get; set; }

        protected Employes(int age, string nom, string prenom, Double salaire)
        {
            Age = age;
            Nom = nom;
            Prenom = prenom;
            Salaire = salaire;
        }

        public void Afficher() 
        {
            Console.WriteLine(this);
        }

        public abstract Double CalculSalaire();

        public override String ToString()
        {
            return base.ToString()+ "\tNom : " + Nom + "\tPrenom : " + Prenom + "\tAge : " + Age + "\tSalaire : " + CalculSalaire();
        }
    }
}
