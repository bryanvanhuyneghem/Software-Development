using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public abstract class AQuizFactory : IQuizFactory
    {
        protected List<IVraag> vragen;
        protected List<ILevel> levels;

        public AQuizFactory(ICategory category)
        {
            levels = new List<ILevel>();
            vragen = new List<IVraag>();
            InitLevels(category);
            InitVragen(category);
        }

        protected abstract void InitLevels(ICategory category);
        protected abstract void InitVragen(ICategory category);

        public List<IVraag> Vragen => vragen;

        public List<ILevel> Levels => levels;
    }
}
