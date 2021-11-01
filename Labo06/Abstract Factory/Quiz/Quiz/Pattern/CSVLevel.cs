using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public class CSVLevel : ALevel
    {
        //3;good;bal
        public CSVLevel(string lijn)
        {
            string[] parts = lijn.Split(';');
            grens = Int32.Parse(parts[0]);
            beschrijving = parts[1];
            beloning = parts[2];
        }
    }
}
