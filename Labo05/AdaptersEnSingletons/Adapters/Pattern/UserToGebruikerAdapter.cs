using GebruikersPortaal;
using UserDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.Pattern
{
    public class UserToGebruikerAdapter : IGebruikersLijst
    {
        private IDatabase database;
        public Gebruiker[] Gebruikers
        {
            get
            {
                database.OpenConnection();
                if (database.IsConnected)
                {
                    List<User> users = database.SelectAllUsers();
                    List<Gebruiker> gebruikers = new List<Gebruiker>();
                    foreach (User user in users)
                    {
                        gebruikers.Add(Converter.Convert(user));
                    }
                    database.CloseConnection();
                    return gebruikers.ToArray();
                }
                else
                {
                    throw new Exception("[Gebruikers] Kan niet connecteren met database.");
                }
            }
        }

        // Constructor
        public UserToGebruikerAdapter(IDatabase database)
        {
            this.database = database;
        }

        // PasAan
        public void PasAan(Gebruiker gebruiker)
        {
            database.OpenConnection();
            if (database.IsConnected)
            {
                database.UpdateUser(Converter.Convert(gebruiker));
                database.CloseConnection();
            }
            else
            {
                throw new Exception("[PasAan] Kan niet connecteren met database.");
            }

        }

        // Verwijder
        public void Verwijder(Gebruiker gebruiker)
        {
            database.OpenConnection();
            if (database.IsConnected)
            {
                database.DeleteUser(Converter.Convert(gebruiker));
                database.CloseConnection();
            }
            else
            {
                throw new Exception("[Verwijder] Kan niet connecteren met database.");
            }
        }

        // VoegToe
        public void VoegToe(Gebruiker gebruiker)
        {
            database.OpenConnection();
            if (database.IsConnected)
            {
                database.InsertUser(Converter.Convert(gebruiker));
                database.CloseConnection();
            }
            else
            {
                throw new Exception("[VoegToe] Kan niet connecteren met database.");
            }
        }
    }
}

