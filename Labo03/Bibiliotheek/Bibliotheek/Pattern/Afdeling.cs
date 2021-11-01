using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotheek.Pattern
{
    // Compositie object
    public class Afdeling : ABibComposite
    {
        public string Naam { get; set; }

        public Afdeling() : base(new SortedSet<IBibItem>(new Sorteerder()))
        {
        }

        // We zoeken niet op keywords voor een Afdeling
        protected override bool IsRightKeyword(string keyword)
        {
            return false;
        }

        public override string Show(int indent)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(new string('-', indent));
            sb.Append(Naam);
            sb.Append(": \n");
            ShowChildren(indent, sb);
            return sb.ToString();
        }

    }
}
