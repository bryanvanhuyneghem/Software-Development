using Bibliotheek.Pattern;
using Sorteren;
using System;

namespace SorteerBestanden
{
    class Program
    {
        static void Main(string[] args)
        {
            string sorteerMethode = null;
            string invoer = null;
            string uitvoer = null;


            Console.Write("Type invoer: ");
            string type = Console.ReadLine();
            bool typeCorrect = false;
            // check correct
            while (!typeCorrect)
            {
                if (type == "school" || type == "park")
                {
                    typeCorrect = true;
                }
                else
                {
                    Console.WriteLine("Geef een gekend type op: \"school\" of \"park\".");
                    Console.Write("Type invoer: ");
                    type = Console.ReadLine();
                }
            }

            Console.Write("Sorteermethode: ");
            sorteerMethode = Console.ReadLine();
            bool methodCorrect = false;
            // check correct
            while (!methodCorrect)
            {
                if (sorteerMethode == "selection" || sorteerMethode == "bubble")
                {
                    methodCorrect = true;
                }
                else
                {
                    Console.WriteLine("Geef een gekende sorteermethode op: \"selection\" of \"bubble\".");
                    Console.Write("Sorteermethode: ");
                    sorteerMethode = Console.ReadLine();
                }
            }

            // invoer & uitvoer opgeven
            Console.Write("Geef invoerbestand: ");
            invoer = Console.ReadLine();
            Console.Write("Geef uitvoerbestand: ");
            uitvoer = Console.ReadLine();

            // uitvoeren 
            if (type == "school")
            {
                SchoolSorteerder comparer = new SchoolSorteerder();
                if (sorteerMethode == "selection")
                {
                    BestandSorteerder<School> bs = new BestandSorteerder<School>(SchoolLezer.LeesSchool, SorteerBib<School>.SelectionSort, comparer);
                    bs.Parse(invoer, uitvoer);
                }
                else if (sorteerMethode == "bubble")
                {
                    BestandSorteerder<School> bs = new BestandSorteerder<School>(SchoolLezer.LeesSchool, SorteerBib<School>.BubbleSort, comparer);
                    bs.Parse(invoer, uitvoer);
                }
            }
            else if (type == "park")
            {
                ParkSorteerder comparer = new ParkSorteerder();
                if (sorteerMethode == "selection")
                {
                    BestandSorteerder<Park> bs = new BestandSorteerder<Park>(ParkLezer.LeesPark, SorteerBib<Park>.SelectionSort, comparer);
                    bs.Parse(invoer, uitvoer);
                }
                else if (sorteerMethode == "bubble")
                {
                    BestandSorteerder<Park> bs = new BestandSorteerder<Park>(ParkLezer.LeesPark, SorteerBib<Park>.BubbleSort, comparer);
                    bs.Parse(invoer, uitvoer);
                }
            }
        }
    }
}
