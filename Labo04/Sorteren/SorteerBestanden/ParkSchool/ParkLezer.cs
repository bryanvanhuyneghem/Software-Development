using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteerBestanden
{
    public class ParkLezer
    {
        // Maakt een Park-object aan op basis van een string als invoer.
        // Statische methode, dus geen aanmaak van ParkLezer-object nodig.
        public static Park LeesPark(string invoer)
        {
            string[] stukjes = invoer.Split(';');
            Park park = new Park
            {
                Id = stukjes[1],
                Naam = stukjes[6],
                Oppervlakte = stukjes[8]
            };
            return park;
        }
    }
}
