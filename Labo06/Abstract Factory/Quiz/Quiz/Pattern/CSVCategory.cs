using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public class CSVCategory : ACategory
    {
        public CSVCategory(string csvLine)
        {
            string[] elements = csvLine.Split(';');
            id = Int32.Parse(elements[0]);
            description = elements[1];
        }
    }
}
