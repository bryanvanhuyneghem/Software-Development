using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDatabase;
using GebruikersPortaal;

namespace Adapters.Pattern
{
    public class GebruikerToUserAdapter : IDatabase
    {
        public bool IsConnected
        {
            get
            {
                return true;
            }
        }

        private IGebruikersLijst list;

        // Constructor
        public GebruikerToUserAdapter(IGebruikersLijst lijst)
        {
            list = lijst;
        }

        public void CloseConnection()
        {

        }

        // DeleteUser
        public void DeleteUser(User user)
        {
            list.Verwijder(Converter.Convert(user));
        }

        // InsertUser
        public void InsertUser(User user)
        {
            list.VoegToe(Converter.Convert(user));
        }

        public void OpenConnection()
        {

        }

        // SelectAllUsers
        public List<User> SelectAllUsers()
        {
            Gebruiker[] gebruikers = list.Gebruikers;
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
            list.PasAan(Converter.Convert(user));
        }
    }
}

