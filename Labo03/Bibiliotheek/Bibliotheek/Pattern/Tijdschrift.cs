using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotheek.Pattern
{
    // Compositie object
    public class Tijdschrift : ABibComposite
    {
        public string Titel { get; set; }
        public DateTime Datum { get; set; }
        public string Uitgeverij { get; set; }

        public Tijdschrift() : base(new List<IBibItem>())
        {

        }

        protected override bool IsRightKeyword(string keyword)
        {
            if (Titel.Contains(keyword) || Uitgeverij.Contains(keyword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string Show(int indent)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Show(indent));
            sb.Append(Titel);
            sb.Append("\", ");
            sb.Append(Datum);
            sb.Append(", ");
            sb.Append(Uitgeverij);
            sb.Append(": \n");
            ShowChildren(indent, sb);
            return sb.ToString();
        }
    }
}
