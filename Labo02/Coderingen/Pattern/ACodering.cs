using System;
using System.Collections.Generic;
using System.Text;

namespace Coderingen.Pattern
{
    public abstract class ACodering : ICodering
    {
        // Het te decoreren object wordt hier doorgegeven
        protected ICodering codering;

        protected ACodering(ICodering codering)
        {
            this.codering = codering;
        }

        // Verschillende Decorators implementeren deze methode
        public abstract string Codeer(string zin);
    }
}
