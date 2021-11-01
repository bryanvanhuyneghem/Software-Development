using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public interface IQuiz
    {
        int Score { get; }
        IVraag Vraag { get; }
        ILevel Level { get; }
        ILevel NextLevel { get; } // Nodig voor berekenen "te gaan"

        bool Check(string answer); // Controleert het antwoord + return
    }
}
