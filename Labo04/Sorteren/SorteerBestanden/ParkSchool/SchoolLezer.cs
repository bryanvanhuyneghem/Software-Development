using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteerBestanden
{
    public class SchoolLezer
    {
        // Maakt een School-object aan op basis van een string als invoer.
        // Statische methode, dus geen aanmaak van SchoolLezer-object nodig.
        public static School LeesSchool(string invoer)
        {
            string[] stukjes = invoer.Split(';');
            School school = new School
            {
                Id = stukjes[3],
                Naam = stukjes[6],
                Adres = stukjes[5],
                Type = stukjes[7],
                Net = stukjes[8]
            };
            return school;
        }
    }
}
