using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaadjes
{
    // Hulpklasse die een koppel coördinaten bijhoudt van een figuurtje.
    public class Punt
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Punt(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
