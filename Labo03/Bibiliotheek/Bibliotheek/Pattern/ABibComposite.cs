using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotheek.Pattern
{
    // Abstracte klasse voor alle compositie objecten
    public abstract class ABibComposite : ABibItem
    {
        protected ICollection<IBibItem> items;

        public ABibComposite(ICollection<IBibItem> items)
        {
            this.items = items;
        }

        public override IBibItem SearchFor(string id)
        {
            // Zelfde id? Return dit object
            if (id.Equals(Id))
            {
                return this;
            }
            // Niet dezelfde id?:
            else
            {
                // Overloop de volledige node waarvoor hij Parent is
                foreach(IBibItem item in items)
                {
                    IBibItem result = item.SearchFor(id);
                    if(result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }

        public override ISet<IBibItem> FindKeyword(string keyword)
        {
            ISet<IBibItem> result = new HashSet<IBibItem>();
            result.UnionWith(base.FindKeyword(keyword)); // ...
            foreach (IBibItem item in items)
            {
                result.UnionWith(item.FindKeyword(keyword));
            }
            return result;
        }

        public override void AddTo(IBibItem bibItem)
        {
            items.Add(bibItem);
            bibItem.Parent = this;
        }

        public override void DeleteFrom(IBibItem bibItem)
        {
            if (items.Contains(bibItem))
            {
                items.Remove(bibItem);
                bibItem.Parent = null;
            }   
        }

        // Schrijft voor een compositie object zijn subboom uit.
        // De boom waarvoor hij Parent is
        protected void ShowChildren(int indent, StringBuilder sb)
        {
            foreach(IBibItem item in items)
            {
                sb.Append(item.Show(indent + 2));
                sb.Append(" \n");
            }
        }

    }
}
