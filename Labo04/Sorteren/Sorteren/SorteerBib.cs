using System.Collections.Generic;
using System.Linq;

namespace Sorteren
{
    public class SorteerBib<T>
    {
        // CONCEPT:
        // --------
        // Ik wil SelectionSort toepassen op een List, maar ook een array, dus kan ik de methodes
        // ook gebruiken om een array te sorteren
        // Ik heb 1 methode met enkel een list of array en 1 methode met zowel een list of array + comparer
        // Totaal = 4 methodes die beroep doen op elkaar.
        // Beide algoritmes van Wikipedia: aanpassingen int => T (generic) en vergelijken met comparer.Compare(x,y)

        // ICompare<T>.Default:
        // --------------------
        // Defining a custom comparer is often needed for non-natural ordering or defining 
        // alternative orderings, but when you just want to compare two items 
        // that are IComparable<T> and account for null behavior, you can use the Comparer<T>.Default 
        // comparer generator and you’ll never have to worry about correct null value sorting again.


        // EIGENLIJKE ALGORITME
        // Met array én comparer
        public static void SelectionSort(T[] array, IComparer<T> comparer)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {  //Loop door de hele array
                int minIndex = i; //Hou de kleinste waarde bij, als we beginnen is die gelijk aan het element dat we proberen te sorteren
                for (int j = i + 1; j < array.Length; j++)
                { //Loop door het ongesorteerde deel
                    if (comparer.Compare(array[j], array[minIndex]) < 0) // deze regel werd aangepast met comparer.Compare
                    {
                        minIndex = j;
                    }
                }
                //Zet het kleinste element uit de rij op positie I
                T temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        } // einde SelectionSort

        // Enkel array
        public static void SelectionSort(T[] array)
        {
            // Gebruik de methode die array én comparer nodig heeft
            // Gebruik Comparer<T>.Default
            SelectionSort(array, Comparer<T>.Default);
        }
        
        // Met List én comparer
        // Omzetten van een List naar een array om het eigenlijke algoritme te kunnen toepassen
        // SelectionSort met array én comparer oproepen en dan terug omzetten naar een List
        public static IList<T> SelectionSort(IList<T> list, IComparer<T> comparer)
        {
            T[] array = list.ToArray<T>();
            SelectionSort(array, comparer);
            return array.ToList<T>(); // terug omzetten naar een List
        }

        // Enkel List
        // Roep (net zoals bij een array) de methode op die zowel een List als de comparer mee krijgt
        public static IList<T> SelectionSort(IList<T> list)
        {
            return SelectionSort(list, Comparer<T>.Default);
        }

        // --------------------------------
        // Analoog voor Bubblesort
        // --------------------------------

        // EIGENLIJKE ALGORITME
        // Met array én comparer
        public static void BubbleSort(T[] array, IComparer<T> comparer)
        {
            T X;
            for (int i = array.Length - 1; i >= 1; i--)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (comparer.Compare(array[j], array[j+1]) > 0) // deze regel werd aangepast met comparer.Compare
                    {
                        X = array[j];      // bijhouden inhoud van T[J]
                        array[j] = array[j + 1]; // inhoud van T[J] wordt de kleinere inhoud van T[J+1]
                        array[j + 1] = X;    // inhoud van T[J+1] wordt de grotere inhoud van de oorspronkelijke T[J] of dus X 
                    }
                }
            }
        }  // einde BubbleSort

        // Enkel array
        public static void BubbleSort(T[] array)
        {
            // Gebruik de methode die array én comparer nodig heeft
            // Gebruik Comparer<T>.Default
            BubbleSort(array, Comparer<T>.Default);
        }

        // Met List én comparer
        // Omzetten van een List naar een array om het eigenlijke algoritme te kunnen toepassen
        // SelectionSort met array én comparer oproepen en dan terug omzetten naar een List
        public static IList<T> BubbleSort(IList<T> list, IComparer<T> comparer)
        {
            T[] array = list.ToArray<T>();
            BubbleSort(array, comparer);
            return array.ToList<T>(); // terug omzetten naar een List
        }

        // Enkel List
        // Roep (net zoals bij een array) de methode op die zowel een List als de comparer mee krijgt
        public static IList<T> BubbleSort(IList<T> list)
        {
            return BubbleSort(list, Comparer<T>.Default);
        }

    }
}
