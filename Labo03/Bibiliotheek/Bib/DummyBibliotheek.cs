using Bibliotheek.Pattern;
using System;

namespace Bib
{
    class DummyBibliotheek
    {
        Afdeling bib;
        public DummyBibliotheek()
        {
            bib = new Afdeling { Id = "BIB", Naam = "Bibliotheek" };
            Afdeling afdeling = new Afdeling { Id = "FICTIE", Naam = "Fictie" };
            bib.AddTo(afdeling);
            Afdeling subafdeling = new Afdeling { Id = "VOLW", Naam = "Volwassenen" };
            afdeling.AddTo(subafdeling);
            // boek
            Boek boek = new Boek { Id = "ID04", Titel = "Ik ben Pelgrim", Auteur = "Terry Hayes", Uitgeverij = "Bruna", Jaartal = 2014 };
            subafdeling.AddTo(boek);
            // boek
            boek = new Boek { Id = "ID05", Titel = "Kou uit het oosten", Auteur = "Ken Follett", Uitgeverij = "Van Holkema", Jaartal = 2014 };
            subafdeling.AddTo(boek);
            // boek
            boek = new Boek { Id = "ID06", Titel = "De monogrammoorden", Auteur = "Ken Follett", Uitgeverij = "Van Holkema", Jaartal = 2014 };
            subafdeling.AddTo(boek);
            // boek
            boek = new Boek { Id = "ID07", Titel = "Kou uit het oosten", Auteur = "Ken Follett", Uitgeverij = "Van Holkema", Jaartal = 2014 };
            subafdeling.AddTo(boek);
            afdeling = new Afdeling { Id = "NONFICTIE", Naam = "Non Fictie" };
            bib.AddTo(afdeling);
            subafdeling = new Afdeling { Id = "WET", Naam = "Wetenschappen" };
            afdeling.AddTo(subafdeling);
            // tijdschrift
            Tijdschrift tijdschrift = new Tijdschrift { Id = "ID01", Titel = "Scientific American", Datum = new DateTime(2014, 8, 1), Uitgeverij = "Scientific American" };
            Artikel artikel = new Artikel { Id = "ID02", Titel = "Planets we could call home", Auteur = "Dimitar Sasselov" };
            tijdschrift.AddTo(artikel);
            artikel = new Artikel { Id = "ID03", Titel = "Robot Pills", Auteur = "Paolo Dario" };
            tijdschrift.AddTo(artikel);
            subafdeling.AddTo(tijdschrift);
            // afdeling
            Afdeling afdeling2 = new Afdeling { Id = "GESCH", Naam = "Geschiedenis" };
            afdeling.AddTo(afdeling2);
            // boek
            boek = new Boek { Id = "ID08", Titel = "Ik ben Pelgrim", Auteur = "Terry Hayes", Uitgeverij = "Bruna", Jaartal = 2014 };
            afdeling2.AddTo(boek);
            // boek
            boek = new Boek { Id = "ID09", Titel = "Kou uit het oosten", Auteur = "Ken Follett", Uitgeverij = "Van Holkema", Jaartal = 2014 };
            afdeling2.AddTo(boek);
            // boek
            boek = new Boek { Id = "ID10", Titel = "De monogrammoorden", Auteur = "Ken Follett", Uitgeverij = "Van Holkema", Jaartal = 2014 };
            afdeling2.AddTo(boek);
            // boek
            boek = new Boek { Id = "ID11", Titel = "Kou uit het oosten", Auteur = "Ken Follett", Uitgeverij = "Van Holkema", Jaartal = 2014 };
            afdeling2.AddTo(boek);
        }

        public IBibItem Bibliotheek
        {
            get { return bib; }
        }
    }
}
