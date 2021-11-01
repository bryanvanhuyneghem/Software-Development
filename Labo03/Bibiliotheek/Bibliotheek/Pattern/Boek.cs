using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotheek.Pattern
{
    // Component
    public class Boek : ABibItem
    {
        public string Auteur { get; set; }
        public string Titel { get; set; }
        public string Uitgeverij { get; set; }
        public int Jaartal { get; set; }

        protected override bool IsRightKeyword(string keyword)
        {
            if(Auteur.Contains(keyword) || Titel.Contains(keyword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Opbouw van een Boek volgens opgave
        // Roep eerst de base Show(indent) op
        public override string Show(int indent)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Show(indent));
            sb.Append(Titel);
            sb.Append("\", ");
            sb.Append(Auteur);
            sb.Append(", ");
            sb.Append(Uitgeverij);
            sb.Append(", ");
            sb.Append(Jaartal);
            return sb.ToString();
        }
    }
}
