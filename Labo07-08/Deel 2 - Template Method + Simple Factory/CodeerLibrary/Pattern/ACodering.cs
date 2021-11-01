using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeerLibrary.Pattern
{
    public abstract class ACodering : ICodering
    {
        // zin coderen
        public string Codeer(string zin)
        {
            StringBuilder zinBuffer = VervangLetters(zin);
            return ExtraCodering(zinBuffer).ToString();
        }

        protected abstract StringBuilder ExtraCodering(StringBuilder zinBuffer);

        private StringBuilder VervangLetters(string zin)
        {
            zin = zin.ToLower();
            // opsplitsen in woorden
            string[] woorden = zin.Split(' ');
            // spaties in zin vervangen door 0
            StringBuilder zinBuffer = new StringBuilder();
            foreach (string woord in woorden)
            {
                zinBuffer.Append(woord);
                zinBuffer.Append('0');
            }
            // laatste nul was teveel
            zinBuffer.Length--;
            // verwijder speciale tekens
            for (int i = 0; i < zinBuffer.Length; i++)
            {
                if (!char.IsLower(zinBuffer[i])
                        && !char.IsDigit(zinBuffer[i]))
                {
                    zinBuffer[i] = '0';
                }
            }
            return zinBuffer;
        }


        private StringBuilder SpatieVerwijderen(string zin)
        {
            // opsplitsen in woorden
            string[] woorden = zin.Split(' ');
            // spaties in zin vervangen door 0
            StringBuilder zinBuffer = new StringBuilder();
            foreach (string woord in woorden)
            {
                zinBuffer.Append(woord);
                zinBuffer.Append('0');
            }
            return zinBuffer;
        }

        protected StringBuilder MakeEven(StringBuilder zinBuffer)
        {
            // lengte even?
            if (zinBuffer.Length % 2 != 0)
            {
                zinBuffer.Append('0');
            }
            return zinBuffer;
        }

    }
}
