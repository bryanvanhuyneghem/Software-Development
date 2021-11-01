using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public abstract class ALevel : ILevel
    {
        protected string beschrijving;
        protected string beloning;
        protected int grens;

        public string Beschrijving { get => beschrijving + " (Reward: " + beloning + ") "; }
        public string Beloning { get => beloning; set => beloning = value; }
        public int Grens { get => grens; set => grens = value; }
    }
}
