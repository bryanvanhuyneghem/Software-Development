using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrukMeter.Pattern
{
    public class DrukSubject : IDrukSubject
    {
        private Action observers;

        private const string EENHEID = "Pa";
        private const double MAX_DRUK = 1700000;
        private double druk = 101325;

        // Properties
        // ----------
        public double Druk {
            get
            {
                return druk;
            }
            set
            {
                druk = value;
                if(druk < 0)
                {
                    druk = 0;
                }
                else if(druk > MaximaleDruk)
                {
                    druk = MaximaleDruk;
                }
                NotifyObservers();
            }
        }

        public double MaximaleDruk => MAX_DRUK;

        public string Eenheid => EENHEID;


        // Methods
        // -------
        public void Verhoog()
        {
            druk++;
            NotifyObservers();
        }

        public void Verlaag()
        {
            druk--;
            NotifyObservers();
        }

        // Register an observer
        public void RegisterObserver(Action observer)
        {
            // dit is een manier om de Observers zich te laten registreren
            // de observers geven zelf op welke Action ze willen ondernemen
            observers += observer;
        }

        // Notify all listening observers;
        private void NotifyObservers()
        {
            // Het Subject stelt de observers op de hoogte
            observers.Invoke();
        }

    }
}
