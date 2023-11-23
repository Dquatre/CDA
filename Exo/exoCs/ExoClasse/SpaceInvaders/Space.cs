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
        public int Score { get; set; } = 0;
        public int NbInvader { get; set; } = 0;

        public Space(int nbLignes, int nbColonnes)
        {
            NbLignes = nbLignes;
            NbColonnes = nbColonnes;
            Canon = new Canon(nbColonnes/2);
            Grille = new Object[NbLignes][];
            Grille[0] = new Object[NbColonnes];
            
            
            for (int i = 0; i < NbLignes; i++)
            {
                Grille[i] = new Object[NbColonnes];
                for (int j = 0; j < NbColonnes; j++)
                {
                    Grille[i][j] = ' ';
                }
            }
            for (int j = 2; j < NbColonnes-2; j += 2)
            {
                Grille[0][j] = new Invader();
                NbInvader++;
            }
            Grille[NbLignes - 1][Canon.Position] = Canon;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Tirer()
        {
            int position = Canon.Position;
            Grille[NbLignes - 2][position] = '^';
            Console.Clear();
            Console.WriteLine(this);
            Thread.Sleep(200);
            //for (int i = NbLignes - 3; i > 0; i--)
            //{
            //    Grille[i+1][position] = ' ';
            //    Grille[i][position] = '^';
            //    Console.Clear();
            //    Console.WriteLine(this);
            //    Thread.Sleep(200);
            //}
            int i = NbLignes - 3;
            while (i > 0 && !Grille[i][position].GetType().Equals(typeof(Invader)))
            {
                Grille[i + 1][position] = ' ';
                Grille[i][position] = '^';
                Console.Clear();
                Console.WriteLine(this);
                Thread.Sleep(200);
                i--;
            }
            Grille[i + 1][position] = ' ';
            if(Grille[i][position].GetType().Equals(typeof(Invader)))
            {
                Grille[i][position] = '@';
                DetruitInvader();
            }
            else
            {
                Grille[i][position] = '^';
                
            }
            Console.Clear();
            Console.WriteLine(this);
            Thread.Sleep(200);

            Grille[i][position] = ' ';
            Console.Clear();
            Console.WriteLine(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeplaceCanonDroite()
        {
            if (Canon.Position < NbColonnes)
            {
                Grille[NbLignes - 1][Canon.Position] = ' ';
                Canon.Position++;
                Grille[NbLignes - 1][Canon.Position] = Canon;
                Console.Clear();
                Console.WriteLine(this);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void DeplaceCanonGauche()
        {
            if (Canon.Position > 0 )
            {
                Grille[NbLignes - 1][Canon.Position] = ' ';
                Canon.Position--;
                Grille[NbLignes - 1][Canon.Position] = Canon;
                Console.Clear();
                Console.WriteLine(this);
            }
        }

        public void DeplaceInvaderBas(int ligneInvader)
        {
            int i = 0;
            int nbInvaderDeplacer = 0;
            while(nbInvaderDeplacer < NbInvader)
            {
                if (Grille[ligneInvader][i].GetType().Equals(typeof(Invader)))
                {
                    Grille[ligneInvader+1][i] = Grille[ligneInvader][i];
                    Grille[ligneInvader][i] = ' ';
                    nbInvaderDeplacer++;
                }
                i++;
            }
            Console.Clear();
            Console.WriteLine(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DetruitInvader()
        {
            NbInvader--;
            Score += 100;
        }

        public override string ToString()
        {
            String ligne = DessineLigne(NbColonnes);


            String ret = String.Format("{0,10:D8}", Score)+"\n┌"+ ligne + "┐\n";

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
