using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_02_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Char charSuiv = '0';
            int unicodeChar = Convert.ToUInt16(charSuiv);
            for(int i = 0;i < 10;i++)
            {
                Console.WriteLine(charSuiv+" : "+ unicodeChar);
                unicodeChar = Convert.ToUInt16(charSuiv) + 1;
                charSuiv = Convert.ToChar(unicodeChar);
            }    
        }
    }
}
