using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_02_01
{
    class Program
    {
        static void Main(string[] args)
        {
            String charSaisie = "";
            Char charSuiv = ' ';
            int unicodeChar = 0;

            charSaisie = Console.ReadLine();
            charSuiv = Convert.ToChar(charSaisie);
            unicodeChar = Convert.ToUInt16(charSuiv) + 1;
            charSuiv = Convert.ToChar(unicodeChar);
            Console.WriteLine(charSuiv);
        }
    }
}
