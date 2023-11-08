using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class Space
    {
        public int NbLignes { get; set; }
        public int NbColonnes { get; set; }
        public Object[][] Grille { get; set; }
        public Canon Canon { get; set;}
        public Space(int nbLignes, int nbColonnes)
        {
            NbLignes = nbLignes;
            NbColonnes = nbColonnes;
            Canon = new Canon();
            Grille = new Object[NbLignes][];
            Grille[0] = new Object[NbColonnes];
            
            for (int j = 0; j < NbColonnes; j++)
            {
                Grille[0][j] = new Invader();
            }
            for (int i = 1; i < NbLignes; i++)
            {
                Grille[i] = new Object[NbColonnes];
                for (int j = 0; j < NbColonnes; j++)
                {
                    Grille[i][j] = ' ';
                }
            }
            Grille[NbLignes - 1][Canon.Position] = Canon;
        }

        public void Tirer()
        {
            Grille[NbLignes - 2][Canon.Position] = '^';
            Console.Clear();
            Console.WriteLine(this);
            Thread.Sleep(500);
            for (int i = NbLignes - 3; i > 0; i--)
            {
                Grille[i+1][Canon.Position] = ' ';
                Grille[i][Canon.Position] = '^';
                Console.Clear();
                Console.WriteLine(this);
                Thread.Sleep(500);
            }
            Grille[1][Canon.Position] = ' ';
            Grille[0][Canon.Position] = '@';
            Console.Clear();
            Console.WriteLine(this);
            Thread.Sleep(200);
            Grille[0][Canon.Position] = ' ';
            Console.Clear();
            Console.WriteLine(this);
        }



        public override string ToString()
        {
            String ligne = DessineLigne(NbColonnes);
            String ret = "┌"+ ligne + "┐\n";

            for (int i = 0; i < Grille.Length; i++)
            {
                ret += "|";
                for (int j = 0; j < Grille[i].Length; j++)
                {
                    ret += Grille[i][j];
                }
                ret += "|\n";
            }

            return ret + "└" + ligne + "┘";
        }
        private string DessineLigne(int taille)
        {
            String ret = "";
            for (int i = 0; i < taille; i++)
            {
                ret += "─";
            }
            return ret;
        }
    }
}
