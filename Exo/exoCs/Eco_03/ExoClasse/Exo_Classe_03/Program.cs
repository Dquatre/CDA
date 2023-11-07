
using Exo_Classe_03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExoClasse_03
{
    class Program
    {
        static void Main(string[] args)
        {

            Agence ag = new Agence("SSSG", "58 rue de la boustifaille", "36457", "Sarin-Somin-sous-Gorgerin", "restaurant d’entreprise");
            Agence ag1 = new Agence("Berleu", "2 rue du 30 fevrier", "98532", "Berleu", "tickets restaurants");
            DateTime[] enf = { new DateTime(2017, 2, 5) };
            DateTime[] enf2 = { new DateTime(2012, 3, 6), new DateTime(2019, 6, 14) };
            DateTime[] enf3 = { new DateTime(2010, 7, 1) };
            DateTime[] enf4 = { new DateTime(2007, 9, 25) };
       

            List<Employe> effectif = new List<Employe>();
            effectif.Add(new Employe("Berthier","Gontran",Convert.ToDateTime("2014-03-25"),"Directeur",529320,"Direction", ag, enf));
            effectif.Add(new Employe("Danblar", "Flavian",Convert.ToDateTime("2016-08-26"),"Ouvrier",25045,"Atelier", ag, enf2));
            effectif.Add(new Employe("Bernard","Bernard",Convert.ToDateTime("2022-01-25"), "Ouvrier", 25045, "Atelier", ag1, enf3));
            effectif.Add(new Employe("Dre","Andre",Convert.ToDateTime("2018-05-23"),"ingegnieur",35420,"R&D", ag, enf4));
            effectif.Add(new Employe("Platre", "Paco",Convert.ToDateTime("2023-01-28"),"Sous Directeur",252655,"Direction", ag1, null));
            /*
            foreach (var item in effectif)
            {
                item.GenerOrdrePrime();
            }*/
            //Console.WriteLine(effectif.Count());
            
            foreach (var item in effectif)
            {
                Console.WriteLine(item.ToString());
            }
            /*
            
            foreach (var item in effectif.OrderBy(o => o.Prenom).OrderBy(o=>o.Nom))
            {
                Console.WriteLine(item.ToString());
            }
            
            foreach (var item in effectif.OrderBy(o => o.Prenom).OrderBy(o => o.Nom).OrderBy(o => o.Service))
            {
                Console.WriteLine(item.ToString());
            }
            */
            //Console.WriteLine(Math.Round(effectif.Sum(o => o.Salaire + o.CalcPrime())));

        }
    }
}