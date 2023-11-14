using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Program
    {
        static void Main(string[] args)
        {
            Space s = new Space(10, 25);
            Console.WriteLine(s);
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            bool end = false;

            new Thread(new ThreadStart(() =>
            {
                while (!end)
                {
                    key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            new Thread(new ThreadStart(() =>
                            {
                                s.Tirer();
                            })).Start();
                            break;
                        case ConsoleKey.LeftArrow:
                            s.DeplaceCanonGauche();
                            break;

                        case ConsoleKey.RightArrow:
                            s.DeplaceCanonDroite();
                            break;
                        case ConsoleKey.Escape:
                            end = true;
                            break;
                        default:
                            break;
                    }
                } 
            })).Start();

            int i = 0;
            while (i < s.NbLignes - 1 && s.NbInvader > 0 )
            {
                Thread.Sleep(3000);
                s.DeplaceInvaderBas(i);
                i++;
            }
            end = true;

            Console.Clear();
            if (s.NbInvader > 0)
            {
                Console.WriteLine("\n\n\n\tGAME OVER");
            }else 
            {
                Console.WriteLine("\n\n\n\tWIN");
            }
        }
       
    }
}