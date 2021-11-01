using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public class TXTCategory : ACategory
    {
        //1:Kleuters
        public TXTCategory(string txtLine)
        {
            string[] elements = txtLine.Split(':');
            id = Int32.Parse(elements[0]);
            description = elements[1];
        }
    }
}
