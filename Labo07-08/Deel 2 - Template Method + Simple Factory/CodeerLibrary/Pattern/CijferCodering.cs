using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeerLibrary.Pattern
{
    public class CijferCodering : ACodering
    {
        protected override StringBuilder ExtraCodering(StringBuilder zinBuffer)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < zinBuffer.Length; i++)
            {
                int code = zinBuffer[i];
                result.Append(code);
            }
            return result;

        }
    }
}
