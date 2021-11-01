using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public interface IVraag
    {
        string Opgave { get; }
        List<string> Antwoorden { get; }
        bool IsCorrect(string answer);
    }
}
