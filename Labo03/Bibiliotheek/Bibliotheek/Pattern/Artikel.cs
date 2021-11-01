using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotheek.Pattern
{
    // Component
    public class Artikel : ABibItem
    {
        public string Auteur { get; set; }
        public string Titel { get; set; }

        protected override bool IsRightKeyword(string keyword)
        {
            if (Auteur.Contains(keyword) || Titel.Contains(keyword))
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
            sb.Append(Auteur);
            return sb.ToString();
        }
    }
}
