using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SorteerBestanden
{
    // Delegates
    // Staat buiten de klasse:
    public delegate T LeesType<T>(string lijn); // ParkLezer of SchoolLezer; neemt 1 argument, namelijk een string lijn
    public delegate IList<T> SorteerType<T>(IList<T> list, IComparer<T> comparer); // Sorteertype (SelectionSort of BubbleSort); 
                                                                                   // neemt 2 argumenten, namelijk een list en een comparer

    public class BestandSorteerder<T>
    {
        LeesType<T> lezer;
        SorteerType<T> sorteerMethode;
        IComparer<T> comparer;

        public BestandSorteerder(LeesType<T> lezer, SorteerType<T> sorteerMethode, IComparer<T> comparer)
        {
            this.lezer = lezer;
            this.sorteerMethode = sorteerMethode;
            this.comparer = comparer;
        }

        public void Parse(string invoer, string uitvoer)
        {
            // Geparste objecten zullen bewaard worden in deze list
            IList<T> list = new List<T>();

            // bestand inlezen
            StreamReader sr = new StreamReader(invoer);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine(); // lijn inlezen
                // Gebruik lezer om lijn te lezen en juiste object aan te maken.
                // Voeg het toe aan de list.
                list.Add(lezer(line)); // delegate gebruiken
            }


            // Sorteer de list en en schrijf de gesorteerde lijst uit naar een tweede bestand bepaald
            // door de parameter uitvoer.
            IList<T> gesorteerd = sorteerMethode(list, comparer); // delegate gebruiken
            // Bestand uitschrijven
            using (TextWriter tw = new StreamWriter(uitvoer))
            {
                foreach(T lijntje in gesorteerd)
                {
                    tw.WriteLine(lijntje);
                }
            }
        }
    }
}
