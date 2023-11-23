using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Class_07
{
    public class Entreprises
    {
        public List<Commerciaux> ListCommerciaux { get; set; }
        public List<Techniciens> ListTechniciens { get; set; }
        public String Nom {  get; set; }

        public Entreprises(String nom)
        {
            ListCommerciaux = new List<Commerciaux>();
            ListTechniciens = new List<Techniciens>();
            Nom = nom;
        }

        public Double MasseSalariale()
        {
            return ListCommerciaux.Sum(o => o.CalculSalaire()) + ListTechniciens.Sum(o => o.CalculSalaire());
        }

        public override string ToString()
        {
            String ret = "COMMERCIAUX";
            foreach (var item in ListCommerciaux)
            {
                ret += "\n\t"+item.ToString();
            }
            ret += "\nTECHNICIENS";

            foreach (var item in ListTechniciens)
            {
                ret += "\n\t" + item.ToString();
            }
            ret += "\nsoit un total de " + MasseSalariale();
            return ret;
        }
    }
}
