using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exo_Class_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Entreprises iris = new Entreprises("Promo IRIS");
            iris.ListCommerciaux.Add(new Vendeurs(25,"Atreid","Paul",10));
            iris.ListCommerciaux.Add(new Vendeurs(33,"Poljak","Pierre",5));
            iris.ListCommerciaux.Add(new Vendeurs(42,"Kartier","Jacque",1));
            iris.ListCommerciaux.Add(new Representants(36,"Glu","Giselle",3,10));
            iris.ListCommerciaux.Add(new Representants(40,"Delajungle","Georges",2,8));
            iris.ListTechniciens.Add(new Techniciens(38, "Perdeu","Robert"));
            iris.ListTechniciens.Add(new Techniciens(29, "Poumon","Raymond"));
            iris.ListTechniciens.Add(new Interimaires(22, "Bus","Jean-Claude",75));
            iris.ListTechniciens.Add(new Interimaires(26, "Saaaatre", "Jean-Paul", 50));
            iris.ListTechniciens.Add(new Interimaires(25, "Lepeingne","Jean-Marie",50));
            iris.ListTechniciens.Add(new Interimaires(27, "Jeanjean","Jean-Jean",0));
            Console.WriteLine(iris);
        }
    }
}