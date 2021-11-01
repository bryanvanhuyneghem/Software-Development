using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public abstract class ACategory : ICategory
    {
        protected int id;
        protected string description;

        public string Description { get => description;}
        public int Id { get => id; }

        // Voor de GUI applicatie: ToString() methode
        public override string ToString()
        {
            return description;
        }
    }
}
