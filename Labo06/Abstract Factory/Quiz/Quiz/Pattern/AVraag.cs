using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public abstract class AVraag : IVraag
    {
        protected string opgave;
        protected List<string> antwoorden;
        protected int nrCorrect;
        private static int nr; // aantal vragen

        public AVraag()
        {
            antwoorden = new List<string>();
            nr = 0;
        }

        public string Opgave
        {
            get
            {
                nr++;
                return "#" + nr + " " + opgave;
            }
        }

        public List<string> Antwoorden => antwoorden;

        public bool IsCorrect(string answer)
        {
            // ga met nrCorrect in list gaan controleren of het antwoord juist is
            return answer.Equals(antwoorden[nrCorrect]);
        }
            
    }
}
