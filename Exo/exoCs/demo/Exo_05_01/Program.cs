using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_05_01
{
    class Program
    {
        static void Main(string[] args)
        {
            String phrases = "Les framboises sont perchées sur le tabouret de mon grand-père.";


            for (int i = 0; i < phrases.Length; i++)
            {
                Console.WriteLine(phrases[i]);
            }
        }
    }
}