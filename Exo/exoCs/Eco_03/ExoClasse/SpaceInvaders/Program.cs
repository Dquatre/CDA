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
            Space s = new Space(6, 10);
            Console.WriteLine(s);
            Console.Clear();
            s.Tirer();
        }
    }
}