using System;
using System.Collections.Generic;
using Bibliotheek.Pattern;

namespace Bib
{
    class Program
    {
        static void Main(string[] args)
        {
            IBibItem bib = new DummyBibliotheek().Bibliotheek;

            Console.WriteLine("\"STOP\" om te stoppen;" +
                "\n\"toon\" om bibiliotheek te tonen;" +
                "\n \"zoek\" + TREFWOORD om te zoeken op een trefwoord.");
            string command = Console.In.ReadLine();
            while (command != "STOP")
            {
                if (command.StartsWith("toon"))
                {
                    Console.Out.WriteLine(bib.Show(0));
                }
                else if (command.StartsWith("zoek"))
                {
                    string term = command.Substring(5);
                    IBibItem result = bib.SearchFor(term);
                    ISet<IBibItem> results = bib.FindKeyword(term);
                    if (result != null)
                    {
                        results.Add(result);
                    }
                    foreach (var item in results)
                    {
                        Console.Out.WriteLine(item.Show(0));
                    }
                }
                command = Console.In.ReadLine();
            }
        }
    }
}
