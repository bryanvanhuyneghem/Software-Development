using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorteren;
using System.Collections.Generic;
using Bibliotheek.Pattern;
using System;
using Bibliotheek;
//using Catalogus;

namespace TestSorteren
{
    // DEBUGGEN MET DEBUG
    // System.Diagnostics.Debug.WriteLine(...)
    [TestClass]
    public class UnitTestSorteren
    {
        // NIET OK
        [TestMethod]
        public void TestBubblesorteerMethodesInt()
        {
            // Om naar terug te kunnen keren
            int[] start = { 5, 1, -10, 667, 4 };

            // Array + Selection
            int[] getallen = { 5, 1, -10, 667, 4 };
            SorteerBib<int>.SelectionSort(getallen);
            int[] resultaat = { -10, 1, 4, 5, 667 }; // de oplossing
            CollectionAssert.AreEqual(resultaat, getallen);

            // List + Selection
            getallen = start;
            IList<int> reeks = new List<int>(getallen);
            IList<int> gesorteerd = SorteerBib<int>.SelectionSort(reeks);
            CollectionAssert.AreEqual(resultaat, gesorteerd.ToArray<int>());

            // Array + Bubble
            getallen = start;
            SorteerBib<int>.BubbleSort(getallen);
            CollectionAssert.AreEqual(resultaat, getallen);

            // List + Bubble
            getallen = start;
            reeks = new List<int>(getallen);
            gesorteerd = SorteerBib<int>.BubbleSort(reeks);
            CollectionAssert.AreEqual(resultaat, gesorteerd.ToArray<int>());
        }

        // OK
        [TestMethod]
        public void TestGegevenInt()
        {
            int[] start = { 5, 1, -10, 667, 4 };
            int[] getallen = { 5, 1, -10, 667, 4 };
            SorteerBib<int>.SelectionSort(getallen);
            int[] resultaat = { -10, 1, 4, 5, 667 };
            CollectionAssert.AreEqual(resultaat, getallen);
            getallen = start;
            
            SorteerBib<int>.BubbleSort(getallen);
            CollectionAssert.AreEqual(resultaat, getallen);
            
        }

        // OK
        [TestMethod]
        public void TestSorteerMethodesString()
        {
            string[] namen = { "Jeroen", "Ann", "Els", "Veerle", "Thomas"};
            SorteerBib<string>.SelectionSort(namen);
            string[] resultaat = { "Ann", "Els", "Jeroen", "Thomas", "Veerle" };
            CollectionAssert.AreEqual(resultaat, namen);
            namen = new string[] { "Jeroen", "Ann", "Els", "Veerle", "Thomas"};
            SorteerBib<string>.BubbleSort(namen);
            CollectionAssert.AreEqual(resultaat, namen);
        }

        // OK
        // Toegevoegde Testmethode op Boek-objecten met arrays
        [TestMethod]
        public void TestSorteerIBibItem1()
        {
            // eerst op naam, dan titel, dan id
            Boek boek1 = new Boek { Id = "ID04", Titel = "Ik ben Pelgrim", Auteur = "Terry Hayes", Uitgeverij = "Bruna", Jaartal = 2014 };
            Boek boek2 = new Boek { Id = "ID05", Titel = "Kou uit het oosten", Auteur = "Ken Follett", Uitgeverij = "Van Holkema", Jaartal = 2014 };
            Boek boek3 = new Boek { Id = "ID06", Titel = "De monogrammoorden", Auteur = "Ken Follett", Uitgeverij = "Van Holkema", Jaartal = 2014 };
            Boek boek4 = new Boek { Id = "ID07", Titel = "Kou uit het oosten", Auteur = "Ken Follett", Uitgeverij = "Van Holkema", Jaartal = 2014 };
            Boek[] boeken1 = { boek3, boek2, boek1, boek4};
            Boek[] boeken2 = { boek3, boek2, boek1, boek4 };
            IComparer<Boek> comparer = new Sorteerder(); // comparer

            SorteerBib<Boek>.SelectionSort(boeken1, comparer); // selection
            Boek[] oplossing = { boek3, boek2, boek4, boek1 };

            //-----------------------------------------------
            System.Diagnostics.Debug.WriteLine("TEST START");
            System.Diagnostics.Debug.WriteLine("Na sorting:");
            foreach (Boek boek in boeken1)
            {
                System.Diagnostics.Debug.WriteLine(boek.Show(0));
            }
            System.Diagnostics.Debug.WriteLine("-------------");
            System.Diagnostics.Debug.WriteLine("Vooropgestelde oplossing:");
            foreach (Boek boek in oplossing)
            {
                System.Diagnostics.Debug.WriteLine(boek.Show(0));
            }
            //-----------------------------------------------
            CollectionAssert.AreEqual(oplossing, boeken1);

            boeken1 = boeken2; // reset
            SorteerBib<Boek>.BubbleSort(boeken2, comparer); // bubble
            CollectionAssert.AreEqual(oplossing, boeken2);
            
        }

        // NIET OK
        // Toegevoegde Testmethode op Boek-objecten met Lists
        [TestMethod]
        public void TestSorteerIBibItem2()
        {
            // List
            // Sorteren = eerst op naam, dan titel, dan id
            IList<Boek> reeks = new List<Boek>(); 
            Boek boek = new Boek { Id = "ID04", Titel = "Ik ben Pelgrim", Auteur = "Terry Hayes", Uitgeverij = "Bruna", Jaartal = 2014 };
            reeks.Add(boek);
            boek = new Boek { Id = "ID05", Titel = "Kou uit het oosten", Auteur = "Ken Follett", Uitgeverij = "Van Holkema", Jaartal = 2014 };
            reeks.Add(boek);
            boek = new Boek { Id = "ID06", Titel = "De monogrammoorden", Auteur = "Ken Follett", Uitgeverij = "Van Holkema", Jaartal = 2014 };
            reeks.Add(boek);
            boek = new Boek { Id = "ID07", Titel = "Kou uit het oosten", Auteur = "Ken Follett", Uitgeverij = "Van Holkema", Jaartal = 2014 };
            reeks.Add(boek);

            // Comparer
            IComparer<Boek> comparer = new Sorteerder();

            // Resultaat om mee te controleren
            IList<Boek> resultaat = new List<Boek>();
            resultaat.Add(reeks[2]);
            resultaat.Add(reeks[1]);
            resultaat.Add(reeks[3]);
            resultaat.Add(reeks[0]);

            // Debugging
            //-----------------------------------------------
            System.Diagnostics.Debug.WriteLine("TEST START");
            System.Diagnostics.Debug.WriteLine("Na sorting:");
            foreach (Boek book in reeks.ToArray<Boek>())
            {
                System.Diagnostics.Debug.WriteLine(book.Show(0));
            }
            System.Diagnostics.Debug.WriteLine("-------------");
            System.Diagnostics.Debug.WriteLine("Vooropgestelde oplossing:");
            foreach (Boek book in resultaat)
            {
                System.Diagnostics.Debug.WriteLine(book.Show(0));
            }
            //-----------------------------------------------

            // Selection Sort
            IList<Boek> gesorteerd = SorteerBib<Boek>.SelectionSort(reeks, comparer); 
            CollectionAssert.AreEqual(resultaat.ToArray<Boek>(), gesorteerd.ToArray<Boek>());

            // Bubble Sort
            gesorteerd = SorteerBib<Boek>.BubbleSort(reeks, comparer);
            CollectionAssert.AreEqual(resultaat.ToArray<Boek>(), gesorteerd.ToArray<Boek>());

        }
    }
}
