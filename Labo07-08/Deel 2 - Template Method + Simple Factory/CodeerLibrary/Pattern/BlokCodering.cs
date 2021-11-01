using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeerLibrary.Pattern
{
    public class BlokCodering : ACodering
    {
        // Fields
        Dictionary<char, int[]> letterLocatie = new Dictionary<char, int[]>();
        char[,] code = new char[,]
                   {{'a', 'z', 'e', 'r', 't', '1'},
                        {'2', 'y', 'u', 'i', 'o', 'p'},
                        {'q', '3', 's', '4', '8', 'd'},
                        {'f', 'g', 'h', 'n', 'j', 'k'},
                        {'9', '7', 'l', 'm', '6', 'w'},
                        {'5', '0', 'x', 'c', 'v', 'b'}};

        // Constructor
        public BlokCodering()
        {
            // dictionary om snel locatie van letter in code te vinden
            for (int i = 0; i < code.GetLength(0); i++)
            {
                for (int j = 0; j < code.GetLength(1); j++)
                {
                    char c = code[i, j];
                    letterLocatie.Add(c, new int[] { i, j });
                }
            }
        }


        // ExtraCodering
        protected override StringBuilder ExtraCodering(StringBuilder zinBuffer)
        {
            zinBuffer = MakeEven(zinBuffer);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < zinBuffer.Length; i += 2)
            {
                // gelijke tekens??
                if (zinBuffer[i] == zinBuffer[i + 1])
                {
                    result.Append(zinBuffer[i]);
                    result.Append(zinBuffer[i]);
                }
                else
                {
                    int[] loc1, loc2;
                    loc1 = letterLocatie[zinBuffer[i]];
                    loc2 = letterLocatie[zinBuffer[i + 1]];
                    // letters op zelfde rij of kolom?
                    if (loc1[0] == loc2[0] || loc1[1] == loc2[1])
                    {
                        // letters verwisselen
                        result.Append(zinBuffer[i + 1]);
                        result.Append(zinBuffer[i]);
                    }
                    else
                    {
                        result.Append(code[loc1[0], loc2[1]]);
                        result.Append(code[loc2[0], loc1[1]]);
                    }
                }
            }
            return result;
        }
    }
}
