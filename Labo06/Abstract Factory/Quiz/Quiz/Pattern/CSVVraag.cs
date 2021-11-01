using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public class CSVVraag : AVraag
    {
        //Which one doesn't belong?;Sunglasses;Umbrella;Boots;Raincoat;0
        public CSVVraag(string lijn)
        {
            string[] parts = lijn.Split(';');
            this.opgave = parts[0];
            for (int i = 1; i < parts.Length - 1; i++)
            {
                antwoorden.Add(parts[i]);
            }
            nrCorrect = Int32.Parse(parts[parts.Length - 1]); // 0
        }
    }
}
