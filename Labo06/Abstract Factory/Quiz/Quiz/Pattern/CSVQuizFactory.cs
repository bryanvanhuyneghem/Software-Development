using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public class CSVQuizFactory : AQuizFactory
    {
        public CSVQuizFactory(ICategory category) : base(category)
        {
        }

        protected override void InitLevels(ICategory category)
        {
            int nr = category.Id;
            string[] lines = System.IO.File.ReadAllLines(@"quiz_dataset\csv\levels" + nr + ".csv");
            foreach (string line in lines)
            {
                levels.Add(new CSVLevel(line));
            }
        }


        protected override void InitVragen(ICategory category)
        {
            int nr = category.Id;
            string[] lines = System.IO.File.ReadAllLines(@"quiz_dataset\csv\questions" + nr + ".csv");
            foreach (string line in lines)
            {
                vragen.Add(new CSVVraag(line));
            }
        }
    }
}
