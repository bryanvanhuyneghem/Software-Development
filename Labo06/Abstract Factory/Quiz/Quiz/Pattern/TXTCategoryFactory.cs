using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public class TXTCategoryFactory
    {
        public static IList<ICategory> Categories
        {
            get
            {
                IList<ICategory> categories = new List<ICategory>();
                string[] lines = System.IO.File.ReadAllLines(@"quiz_dataset\txt\categorieen.txt"); // HELP, hoe zorg ik ervoor dat dit juist uitgevoerd wordt?

                foreach (string line in lines)
                {
                    categories.Add(new TXTCategory(line));
                }
                return categories;
            }
        }
    }
}
