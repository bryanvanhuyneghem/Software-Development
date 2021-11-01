using Bibliotheek.Pattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotheek
{
    public class Sorteerder : IComparer<IBibItem>
    {
        public int Compare(IBibItem x, IBibItem y)
        {
            if (x is Afdeling && !(y is Afdeling))
            {
                return -1;
            }
            else if (y is Afdeling && !(x is Afdeling))
            {
                return 1;
            }
            else if (x is Afdeling && y is Afdeling)
            {
                string naamX = (x as Afdeling).Naam;
                string naamY = (y as Afdeling).Naam;
                return naamX.CompareTo(naamY);
            }
            else if (x is Boek && y is Boek)
            {
                string stringX = (x as Boek).Auteur;
                string stringY = (y as Boek).Auteur;
                if (stringX == stringY)
                {
                    stringX = (x as Boek).Titel;
                    stringY = (y as Boek).Titel;
                    if (stringX == stringY)
                    {
                        stringX = x.Id;
                        stringY = y.Id;
                    }
                }
                return stringX.CompareTo(stringY);
            }
            else if (x is Tijdschrift && y is Tijdschrift)
            {
                string stringX = (x as Tijdschrift).Titel;
                string stringY = (y as Tijdschrift).Titel;
                if (stringX != stringY)
                {
                    return stringX.CompareTo(stringY);
                }
                else
                {
                    DateTime tijdX = (x as Tijdschrift).Datum;
                    DateTime tijdY = (y as Tijdschrift).Datum;
                    if (tijdX != tijdY)
                    {
                        return stringX.CompareTo(stringY);
                    }
                    else { return x.Id.CompareTo(y.Id); }

                }
            }
            else if (x is Boek && y is Tijdschrift)
            {
                return -1;
            }
            else if (y is Boek && x is Tijdschrift)
            {
                return 1;
            }

            else
            {
                return x.Id.CompareTo(y.Id);
            }
        }
    }
}
