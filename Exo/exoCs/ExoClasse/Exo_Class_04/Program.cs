using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exo_Class_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle(5, 5);
            r.AfficherRectangle();
            TriangleRectangle tr = new TriangleRectangle(5, 4);
            tr.AfficherTriangleRectangle();
            Cercle c = new Cercle(5);
            c.AfficherCercle();
            ParallelepipedeRectangle pr = new ParallelepipedeRectangle(5, 5, 5);
            pr.AfficherParallelepipedeRectangle();
            Prisme prs = new Prisme(4, 6, 8);
            prs.AfficherPrisme();
            Sphere sp = new Sphere(7);
            sp.AfficherSphere();

        }
    }
}