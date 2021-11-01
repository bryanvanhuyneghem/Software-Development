using System;
using System.Collections.Generic;
using System.Text;

namespace Coderingen.Pattern
{
    public class WisselCodering : ACodering
    {
        public WisselCodering(ICodering codering) : base(codering)
        {
        }

        public override string Codeer(string zin)
        {
            zin = codering.Codeer(zin); // om te kunnen wrappen

            // Lengte van de zin even maken
            if(zin.Length%2 != 0)
            {
                zin += '0';
            }

            // Nieuwe zin maken
            StringBuilder nieuweZin = new StringBuilder();
            for(int i = 0; i<zin.Length; i += 2)
            {
                // zin overlopen om de 2 karakters
                nieuweZin.Append(zin[i + 1]);
                nieuweZin.Append(zin[i]);
            }
            return nieuweZin.ToString();
        }
    }
}
