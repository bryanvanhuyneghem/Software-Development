using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public class CSVCategoryFactory
    {
        public static IList<ICategory> Categories
        {
            get
            {
                IList<ICategory> categories = new List<ICategory>();
                string[] lines = System.IO.File.ReadAllLines(@"quiz_dataset\csv\categorieen.csv"); // HELP, hoe zorg ik ervoor dat dit juist uitgevoerd wordt?

                foreach (string line in lines)
                {
                    categories.Add(new CSVCategory(line));
                }
                return categories;
            }
        }
    }
}
