using System;
using System.Text;
using Coderingen.Pattern;

namespace Coderingen.CodeerZin
{
    public class CodeerZin
    {
        static void Main(string[] args)
        {

            // Inlezen zin en uit te voeren codering(en)
            Console.Out.Write("Geef zin: ");
            string zin = Console.In.ReadLine();
            Console.Out.Write("Geef codering(en): ");
            string typeInvoer = Console.In.ReadLine();

            // Voer verschillende coderingen uit
            ICodering codering = Helpers.MeerdereCoderingen(new BasisCodering(), typeInvoer);

            // Gecodereerde zin afdrukken
            Console.Out.WriteLine(codering.Codeer(zin));
            Console.ReadKey();

        }
    }
}
