using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotheek.Pattern
{
    // Abstracte klasse voor componenten
    public abstract class ABibItem : IBibItem
    {
        public string Id { get; set; }
        public IBibItem Parent { get; set; }


        // Toevoegen (enkel voor compositie objecten)
        public virtual void AddTo(IBibItem bibItem)
        {
            throw new NotImplementedException();
        }

        // Verwijderen (enkel voor compositie objecten)
        public virtual void DeleteFrom(IBibItem bibItem)
        {
            throw new NotImplementedException();
        }

        // Keyword vinden
        public virtual ISet<IBibItem> FindKeyword(string keyword)
        {
            ISet<IBibItem> result = new HashSet<IBibItem>();
            if (IsRightKeyword(keyword))
            {
                result.Add(this);
            }
            return result;
        }

        // [nieuw] Abstracte Hulpmethode om te checken of het het juiste keyword is
        protected abstract bool IsRightKeyword(string keyword);

        // Verplaatsen bibitem
        public void MoveTo(IBibItem bibItem)
        {
            Parent.DeleteFrom(this);
            bibItem.AddTo(this);
        }

        // Zoeken op basis van een id
        public virtual IBibItem SearchFor(string id)
        {
            // Vergelijk de opgegeven id met de Id van dit bib-object
            if (id.Equals(Id))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        // Toon met indents
        public virtual string Show(int indent)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(new string('-', indent));
            sb.Append("");
            sb.Append(Id);
            sb.Append(": \"");
            return sb.ToString();
        }
    }
}
