using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_02_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Double du = 0;
            int nbPiece = 0;
            String saisie = "";
            Console.WriteLine("Vous deve : ");

            saisie = Console.ReadLine();
            du = Convert.ToDouble(saisie);
    
            if(du >= 0.5)
            {
                Console.WriteLine("1 Pièce de 50 centime");
                du -= 0.5;
            }

            Console.WriteLine(du);
            while (du >= 0.2)
            {
                nbPiece++ ;
                du -= 0.2;
            }          
            if (nbPiece > 0) 
            {
                Console.WriteLine(nbPiece+" Pièce de 20 centime");
            }
            Console.WriteLine(du);
            if (du >= 0.1)
            {
                Console.WriteLine("1 Pièce de 10 centime");
                du -= 0.1;
            }
            Console.WriteLine(du);
            if (du >= 0.05)
            {
                Console.WriteLine("1 Pièce de 5 centime");
                du -= 0.05;
            }
            Console.WriteLine(du);
            nbPiece = 0;
            while (du >= 0.02)
            {
                nbPiece++;
                du -= 0.02;
            }
            if (nbPiece > 0)
            {
                Console.WriteLine(nbPiece + " Pièce de 2 centime");
            }
            Console.WriteLine(du);
            if (du >= 0.01)
            {
                Console.WriteLine("1 Pièce de 1 centime");
            }
        }
    }
}
