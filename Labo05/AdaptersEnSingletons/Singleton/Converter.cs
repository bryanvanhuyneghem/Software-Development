using GebruikersPortaal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDatabase;

namespace Singleton
{
    public static class Converter
    {
        internal static User Convert(Gebruiker gebruiker)
        {
            User user = new User
            {
                ID = gebruiker.GebruikersCode,
                FirstName = gebruiker.VoorNaam,
                LastName = gebruiker.Achternaam
            };
            return user;
        }

        internal static Gebruiker Convert(User user)
        {
            Gebruiker gebruiker = new Gebruiker
            {
                GebruikersCode = user.ID,
                VoorNaam = user.FirstName,
                Achternaam = user.LastName
            };
            return gebruiker;
        }
    }
}