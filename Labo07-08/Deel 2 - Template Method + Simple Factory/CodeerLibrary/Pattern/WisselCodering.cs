using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeerLibrary.Pattern
{
    public class WisselCodering : ACodering
    {
        protected override StringBuilder ExtraCodering(StringBuilder zinBuffer)
        {
            zinBuffer = MakeEven(zinBuffer);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < zinBuffer.Length; i += 2)
            {
                // letters verwisselen
                result.Append(zinBuffer[i + 1]);
                result.Append(zinBuffer[i]);
            }
            return result;
        }
    }
}
