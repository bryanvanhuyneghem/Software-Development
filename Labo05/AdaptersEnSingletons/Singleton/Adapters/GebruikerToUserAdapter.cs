using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDatabase;
using GebruikersPortaal;

namespace Singleton.Adapters
{
    class GebruikerToUserAdapter : IDatabase
    {
        private IGebruikersLijst instance;

        public bool IsConnected
        {
            get
            {
                return true;
            }
        }


        // Constructor
        public GebruikerToUserAdapter(IGebruikersLijst lijst)
        {
            instance = lijst;
        }

        // DeleteUser
        public void DeleteUser(User user)
        {
            instance.Verwijder(Converter.Convert(user));
        }

        // InsertUser
        public void InsertUser(User user)
        {
            instance.VoegToe(Converter.Convert(user));
        }

        // SelectAllUsers
        public List<User> SelectAllUsers()
        {
            Gebruiker[] gebruikers = instance.Gebruikers;
            List<User> users = new List<User>();
            foreach (Gebruiker gebruiker in gebruikers)
            {
                users.Add(Converter.Convert(gebruiker));
            }
            return users;
        }

        // UpdateUser
        public void UpdateUser(User user)
        {
            instance.PasAan(Converter.Convert(user));
        }


        public void CloseConnection()
        {
            // Hier n.v.t.
        }

        public void OpenConnection()
        {
            // Hier n.v.t.
        }

    }
}
