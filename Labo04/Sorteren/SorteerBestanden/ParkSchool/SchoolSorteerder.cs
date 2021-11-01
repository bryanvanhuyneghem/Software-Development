using System.Collections.Generic;

namespace SorteerBestanden
{
    // Extra klasse die vastlegt hoe een School gesorteerd moet worden.
    public class SchoolSorteerder : IComparer<School>
    {
        public int Compare(School x, School y)
        {
            int resultaat = x.Naam.CompareTo(y.Naam);
            return resultaat != 0 ? resultaat : x.Id.CompareTo(y.Id);
        }
    }
}
