using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class Invader
    {
        public Char Motif { get; set; } = '#';

        public Invader()
        {
        }

        public override string ToString()
        {
            return Convert.ToString(Motif);
        }
    }
}
