using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public class Quiz : IQuiz
    {
        private int nrVraag;
        private int nrLevel;
        private int score;
        List<IVraag> vragen;
        List<ILevel> levels;

        public Quiz(IQuizFactory quizFactory)
        {
            this.vragen = quizFactory.Vragen;
            this.levels = quizFactory.Levels;
            score = 0;
            nrVraag = 0;
            nrLevel = -1; //geen level
        }


        public int Score => score;

        public IVraag Vraag => vragen[nrVraag];

        public ILevel Level
        {
            get
            {
                if (nrLevel >= 0) return levels[nrLevel];
                else return null;
            }
        }

        public ILevel NextLevel
        {
            get
            {
                if (nrLevel + 1 < levels.Count) //nog hogere level beschikbaar
                    return levels[nrLevel + 1];
                else
                    return levels[nrLevel];
            }
        }

        public bool Check(string answer)
        {
            bool correct = Vraag.IsCorrect(answer);
            if (correct)
            {
                score++;
            }
            if(score == NextLevel.Grens) //&& nrLevel + 1 < levels.Count)
            {
                nrLevel++;
            }
            nrVraag++;
            if(nrVraag == vragen.Count)
            {
                nrVraag = 0;
            }
            return correct;
        }
    }
}
