using CodeerLibrary.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderingZin
{
    public class CoderingZin
    {
        static void Main(string[] args)
        {
            CoderingFactory factory = new CoderingFactory();
            // zin inlezen
            Console.Out.Write("Geef zin: ");
            string zin = Console.In.ReadLine();
            // type codering inlezen
            Console.Out.Write("Geef codering: ");
            string type = Console.In.ReadLine();
            string gecodeerdeZin;
            ICodering codering = factory[zin];
            gecodeerdeZin = codering.Codeer(zin);
            // gecodereerde zin afdrukken
            Console.Out.WriteLine(gecodeerdeZin);
            Console.ReadKey();
        }

    }
}