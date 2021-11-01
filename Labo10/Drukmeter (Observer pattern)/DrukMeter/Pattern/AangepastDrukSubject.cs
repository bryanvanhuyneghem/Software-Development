using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrukMeter.Pattern
{
    public class AangepastDrukSubject : IDrukSubject
    {
        private string eenheid;
        private DrukSubject drukSubject;
        private double verhouding;

        public AangepastDrukSubject(DrukSubject drukSubject, string eenheid, double verhouding)
        {
            this.drukSubject = drukSubject;
            this.eenheid = eenheid;
            this.verhouding = verhouding;
        }

        public double Druk {
            get {
                return drukSubject.Druk / verhouding;
            }
            set {
                drukSubject.Druk = (value * verhouding);
            }
        }

        public double MaximaleDruk { get { return drukSubject.MaximaleDruk / verhouding; } }

        public string Eenheid { get { return eenheid; } }

        public void RegisterObserver(Action observer)
        {
            drukSubject.RegisterObserver(observer);
        }

        public void Verhoog()
        {
            Druk++;
        }

        public void Verlaag()
        {
            Druk--;
        }
    }
}
