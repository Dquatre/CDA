using System;
namespace Exo_04_01
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int a = 0, b = 0, c = 0, d = 3, m = 3, n = 4;
            for (a = 0; a < m; a++)
            {
                d = 0;
                for (b = 0; b < n; b++)
                    d += b;
                c += d;
            }
            Console.WriteLine(a + " , " + b + " , " + c + " , " + d + " . ");
        }
    }
}
