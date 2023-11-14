using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class Canon
    {
        

        public Char Motif { get; set; } = 'U';
        public int Position { get; set; } = 2;

        public Canon(int position)
        {
            Position = position;
        }

        
        public override string ToString()
        {
            return Convert.ToString(Motif);
        }
    }
}
