using GebruikersPortaal;
using UserDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singleton.Pattern;

namespace Singleton.Adapters
{
    class UserToGebruikerAdapter : IGebruikersLijst
    {
        private SingletonDatabase instance; // singleton database die achterliggend een IDatabase voorstelt

        // Property
        public Gebruiker[] Gebruikers
        {
            get
            {
                List<User> users = instance.SelectAllUsers();
                List<Gebruiker> gebruikers = new List<Gebruiker>();
                foreach (User user in users)
                {
                    gebruikers.Add(Converter.Convert(user));
                }
                return gebruikers.ToArray(); ;
            }
        }

        // Constructor, krijgt een SingletonDatabase mee
        public UserToGebruikerAdapter(SingletonDatabase database)
        {
            instance = database;
        }


        public void PasAan(Gebruiker gebruiker)
        {
            instance.UpdateUser(Converter.Convert(gebruiker));
        }

        public void Verwijder(Gebruiker gebruiker)
        {
            instance.DeleteUser(Converter.Convert(gebruiker));
        }

        public void VoegToe(Gebruiker gebruiker)
        {
            instance.InsertUser(Converter.Convert(gebruiker));
        }
    }
}
