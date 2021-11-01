using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public class TXTVraag : AVraag
    {
        /* vraag1
        3 * 7 = 
        21,18,22,19
        A*/
        public TXTVraag(string opgave, string alleAntwoorden, string correct)
        {
            this.opgave = opgave;
            foreach(string antw in alleAntwoorden.Split(','))
            {
                antwoorden.Add(antw);
            }
            nrCorrect = correct[0] - 'A';
        }
    }
}
