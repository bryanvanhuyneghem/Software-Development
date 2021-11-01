using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public interface ILevel
    {
        string Beschrijving { get; }
        string Beloning { get; }
        int Grens { get; }
    }
}
