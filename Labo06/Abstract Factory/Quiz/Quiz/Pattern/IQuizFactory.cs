using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public interface IQuizFactory
    {
        List<IVraag> Vragen { get; } // Produceert vragen
        List<ILevel> Levels { get; } // Produceert levels
    }
}
