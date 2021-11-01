using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Coderingen;
using Coderingen.Pattern;

namespace Coderingen.CodeerBestand
{
    public class CodeerBestand
    {
        static void Main(string[] args)
        {
            // Bestanden en codering inlezen
            Console.Out.Write("Geef bestandsnaam voor invoer: ");
            string bestandIn = Console.ReadLine();
            Console.Out.Write("Geef bestandsnaam voor uitvoer: ");
            string bestandUit = Console.ReadLine();
            Console.Out.Write("Geef codering: ");
            string typeInvoer = Console.ReadLine();

            // Voer verschillende coderingen uit
            ICodering codering = Helpers.MeerdereCoderingen(new BasisCodering(), typeInvoer);

            // Bestand inlezen, coderen en wegschrijven
            using (StreamReader bInvoer = new StreamReader(bestandIn))
            {
                StreamWriter bUitvoer = new StreamWriter(bestandUit);
                while (!bInvoer.EndOfStream) // Zolang de StreamReader niet aan het einde zit
                {
                    // lijn inlezen, coderen en afdrukken
                    bUitvoer.WriteLine(codering.Codeer(bInvoer.ReadLine()));
                }
                bUitvoer.Close();
            }
        }
    }
        
}
