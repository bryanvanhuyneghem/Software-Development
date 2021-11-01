using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeerLibrary.Pattern;

namespace CodeerBestand
{
    public class CodeerBestand
    {
        static void Main(string[] args)
        {
            CoderingFactory factory = new CoderingFactory();
            // Bestanden en codering inlezen
            Console.Out.Write("Geef bestandsnaam voor invoer: ");
            string bestandIn = Console.In.ReadLine();
            Console.Out.Write("Geef bestandsnaam voor uitvoer: ");
            string bestandUit = Console.In.ReadLine();
            Console.Out.Write("Geef codering: ");
            string type = Console.In.ReadLine();
            ICodering codering = factory[type];

            // bestand inlezen, coderen en wegschrijven
            using (StreamReader bInvoer = new StreamReader(bestandIn))
            {
                using (StreamWriter bUitvoer = new StreamWriter(bestandUit)) {
                    while (!bInvoer.EndOfStream)
                    {
                        string zin = bInvoer.ReadLine();
                        string gecodeerdeZin = codering.Codeer(zin);
                        // gecodeerde zin afdrukken
                        bUitvoer.WriteLine(gecodeerdeZin);                        
                    }
                }
            }
        }
    }
}


