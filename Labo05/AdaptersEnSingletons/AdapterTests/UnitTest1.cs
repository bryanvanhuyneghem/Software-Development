using System;
using Adapters.Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserDatabase;
using GebruikersPortaal;
using System.Collections.Generic;
using System.Linq;

namespace AdapterTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGebruikersPortaal()
        {
            IGebruikersLijst lijst = new GebruikersLijst();

            // Voeg gebruiker toe
            Gebruiker g = new Gebruiker() { GebruikersCode = 1, VoorNaam = "John", Achternaam = "Doe" };
            lijst.VoegToe(g);
            List<Gebruiker> list = new List<Gebruiker>(lijst.Gebruikers);
            Assert.IsTrue(list.Contains(g));

            // Wijzig
            g.VoorNaam = "Jane";
            lijst.PasAan(g);
            list = new List<Gebruiker>(lijst.Gebruikers);
            Gebruiker test = list.First(s => s.GebruikersCode == 1);
            Assert.AreEqual("Jane", test.VoorNaam);

            // Verwijder gebruiker
            lijst.Verwijder(g);
            list = new List<Gebruiker>(lijst.Gebruikers);
            Assert.IsFalse(list.Contains(g));
        }

        [TestMethod]
        public void TestUserDatabase()
        {
            IDatabase db = new MySQLDatabase();

            // Open connectie
            db.OpenConnection();
            Assert.IsTrue(db.IsConnected);

            // Voeg user toe
            User u = new User() { ID = 1, FirstName = "John", LastName = "Doe" };
            db.InsertUser(u);
            Assert.IsTrue(db.SelectAllUsers().Contains(u));

            // Wijzig user
            u.FirstName = "Jane";
            db.UpdateUser(u);
            User test = db.SelectAllUsers().First(s => s.ID == 1);
            Assert.AreEqual("Jane", test.FirstName);

            // Verwijer user
            db.DeleteUser(u);
            Assert.IsFalse(db.SelectAllUsers().Contains(u));

            // Sluit connectie
            db.CloseConnection();
            Assert.IsFalse(db.IsConnected);
        }

        [TestMethod]
        public void TestGebruikerToUserAdapter()
        {
            IGebruikersLijst lijst = new GebruikersLijst();
            GebruikerToUserAdapter adapter = new GebruikerToUserAdapter(lijst);

            // Voeg user toe via adapter en verifieer in gebruikerslijst
            User u = new User() { ID = 1, FirstName = "John", LastName = "Doe" };
            adapter.InsertUser(u);
            List<Gebruiker> list = new List<Gebruiker>(lijst.Gebruikers);
            Gebruiker test = list.First(s => s.GebruikersCode == 1);
            Assert.AreEqual("John", test.VoorNaam);
            Assert.AreEqual("Doe", test.Achternaam);

            // Pas user aan via adapter en verifieer in gebruikerslijst
            u.FirstName = "Jane";
            adapter.UpdateUser(u);
            list = new List<Gebruiker>(lijst.Gebruikers);
            test = list.First(s => s.GebruikersCode == 1);
            Assert.AreEqual("Jane", test.VoorNaam);

            // Verwijder user en verifieer in gebruikerslijst
            adapter.DeleteUser(u);
            list = new List<Gebruiker>(lijst.Gebruikers);
            test = list.FirstOrDefault(s => s.GebruikersCode == 1);
            Assert.IsNull(test);
        }

        [TestMethod]
        public void TestUserToGebruikerAdapter()
        {
            IDatabase db = new MySQLDatabase();
            UserToGebruikerAdapter adapter = new UserToGebruikerAdapter(db);

            // Voeg gebruiker toe via adapter en verifieer in originele database
            Gebruiker g = new Gebruiker() { GebruikersCode = 1, VoorNaam = "John", Achternaam = "Doe" };
            adapter.VoegToe(g);
            db.OpenConnection();
            User test = db.SelectAllUsers().First(s => s.ID == 1);
            Assert.AreEqual("John", test.FirstName);
            Assert.AreEqual("Doe", test.LastName);
            db.CloseConnection();

            // Pas gebruiker aan via adapter en verifieer in originele database
            g.VoorNaam = "Jane";
            adapter.PasAan(g);
            db.OpenConnection();
            test = db.SelectAllUsers().First(s => s.ID == 1);
            Assert.AreEqual("Jane", test.FirstName);
            db.CloseConnection();

            // Verwijder gebruiker en verifieer in originele database
            adapter.Verwijder(g);
            db.OpenConnection();
            test = db.SelectAllUsers().FirstOrDefault(s => s.ID == 1);
            Assert.IsNull(test);
            db.CloseConnection();
        }
    }
}
}
