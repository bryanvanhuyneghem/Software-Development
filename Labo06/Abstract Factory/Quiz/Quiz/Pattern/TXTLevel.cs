using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public class TXTLevel : ALevel
    {
        //gevorderd: puzzel, 6
        public TXTLevel(string lijn)
        {
            string[] parts = lijn.Split(':'); //   gevorderd       puzzel, 6
            beschrijving = parts[0]; // gevorderd
            parts = parts[1].Substring(1).Split(','); // puzzel   6
            beloning = parts[0]; // puzzel
            grens = Int32.Parse(parts[1].Substring(1)); // 6
        }
    }
}
