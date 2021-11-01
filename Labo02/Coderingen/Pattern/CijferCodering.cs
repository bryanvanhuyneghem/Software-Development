using System;
using System.Collections.Generic;
using System.Text;

namespace Coderingen.Pattern
{
    public class CijferCodering : ACodering
    {
        public CijferCodering(ICodering codering) : base(codering)
        {
        }

        public override string Codeer(string zin)
        {
            zin = codering.Codeer(zin); // om te kunnen wrappen

            // Nieuwe zin maken
            StringBuilder nieuweZin = new StringBuilder();
            for (int i = 0; i < zin.Length; i++)
            {
                // zin overlopen en karakters omzetten naar ASCII
                // zinkarakters casten naar een int om ASCII te verkrijgen
                int code = (int) zin[i];
                nieuweZin.Append(code);
            }

            return nieuweZin.ToString();
        }
    }
}
