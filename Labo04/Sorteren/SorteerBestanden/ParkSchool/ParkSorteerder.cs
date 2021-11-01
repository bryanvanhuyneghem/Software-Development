using System.Collections.Generic;

namespace SorteerBestanden
{
    // Extra klasse die vastlegt hoe een Park gesorteerd moet worden.
    public class ParkSorteerder : IComparer<Park>
    {
        public int Compare(Park x, Park y)
        {
            int resultaat = x.Naam.CompareTo(y.Naam);
            return resultaat != 0 ? resultaat : x.Id.CompareTo(y.Id);
        }
    }
}
