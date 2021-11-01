using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrukMeter.Pattern
{
    public interface IDrukSubject
    {
        double Druk { get; set; }
        double MaximaleDruk { get; }
        string Eenheid { get; }

        void RegisterObserver(Action observer);
        void Verhoog();
        void Verlaag();
        
    }
}
