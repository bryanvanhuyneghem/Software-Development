using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestandsbeheer.Pattern
{
    public class RealFile : IFile
    {
        private string filename;
        private string content;

        // Bestand afschermen
        internal RealFile(string filename)
        {
            this.filename = filename;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("[INF] ");
            Console.ResetColor();
            content = System.IO.File.ReadAllText(@"C:\temp\Labo02\Program\TestFolder\file.txt");
        }

        public string Content
        {
            get
            {
                return content;
            }
        }
    }
}
