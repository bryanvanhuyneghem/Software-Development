using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public class TXTQuizFactory : AQuizFactory
    {
        public TXTQuizFactory(ICategory category) : base(category)
        {

        }

        protected override void InitLevels(ICategory category)
        {
            int nr = category.Id;

            string[] lines = System.IO.File.ReadAllLines(@"quiz_dataset\txt\niveaus" + nr + ".txt");
            foreach (string line in lines)
            {
                levels.Add(new TXTLevel(line));
            }
        }

        protected override void InitVragen(ICategory category)
        {
            int nr = category.Id;
            string[] lines = System.IO.File.ReadAllLines(@"quiz_dataset\txt\vragen" + nr + ".txt");
            // 4 lijnen per vraag
            for (int i = 0; i < lines.Length; i = i + 4)
            {
                //eerste lijn bevat geen zinvolle informatie
                vragen.Add(new TXTVraag(lines[i + 1], lines[i + 2], lines[i + 3]));
            }
        }
    }
}
