using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotheek.Pattern
{
    public interface IBibItem
    {
        // Een id property
        string Id { get; set; }
        // Een ouder property
        IBibItem Parent { get; set; }


        // Toevoegen aan bib
        void AddTo(IBibItem bibItem);
        // Verwijderen uit bib
        void DeleteFrom(IBibItem bibItem);
        // Zoeken in bib op id
        IBibItem SearchFor(string id);
        // Zoeken in bib op trefwoord (keyword)
        ISet<IBibItem> FindKeyword(string keyword);
        // Verplaatsen naar andere items
        void MoveTo(IBibItem bibItem);
        // Methode 'Show' (Toon) bepaalt het aantal "-" voor een item
        string Show(int indent);

    }
}
