using GebruikersPortaal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDatabase;

namespace Singleton.Pattern
{
    // Een SingletonDatabase implementeert een IDatabase. Het heeft een attribuut database van het type IDatabase
    // dat ervoor  zorgt dat er een nieuwe connectie met een MySQLDatabase gemaakt kan worden.
    // De destructor sluit de connectie met de MySQLDatabase netjes af.
    // Indien er op de Singleton (die 1 connectie voorstelt met de MySQLDatabase) methodes opgeroepen worden, worden die
    // automatisch opgeroepen op het database attribuut.
    public class SingletonDatabase : IDatabase
    {
        // Singleton
        // Statisch zodat je er maar 1 kan aanmaken
        private static SingletonDatabase uniqueInstance = new SingletonDatabase(); // noodzakelijk (zie UML)
        // De database
        private IDatabase database;

        // Constructor
        private SingletonDatabase()
        {
            database = new MySQLDatabase(); // maak SQLDatabase object aan
            database.OpenConnection(); // open connectie met database
        }

        // Destructor
        ~SingletonDatabase()
        {
            database.CloseConnection(); // sluit connectie met database
        }

        // Singleton Property (noodzakelijk, zie UML)
        public static SingletonDatabase UniqueInstance
        {
            get
            {
                return uniqueInstance;
            }
        }

        public void DeleteUser(User user)
        {
            database.DeleteUser(user);
        }

        public void InsertUser(User user)
        {
            database.InsertUser(user);
        }

        public List<User> SelectAllUsers()
        {
            return database.SelectAllUsers();
        }

        public void UpdateUser(User user)
        {
            database.UpdateUser(user);
        }

        // Should always return 'true' as we open the connection in the constructor
        public bool IsConnected
        {
            get { return database.IsConnected; }
        }



        // Geen implementatie
        public void CloseConnection()
        {
            throw new NotImplementedException();
        }


        // Geen implementatie
        public void OpenConnection()
        {
            throw new NotImplementedException();
        }
    }
}
