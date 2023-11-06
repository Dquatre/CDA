using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_08
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = 'a';
            Console.WriteLine(a);
            int uniA = Convert.ToInt32(a)-32;
            a = Convert.ToChar(uniA);
            Console.WriteLine(a);
        }
    }
}
