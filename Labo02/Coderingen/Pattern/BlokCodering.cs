using System;
using System.Collections.Generic;
using System.Text;

namespace Coderingen.Pattern
{
    public class BlokCodering : ACodering
    {
        // Vierkant letterrooster
        // static readonly om te voorkomen dat elke instantie een kopie heeft van deze tabel
        // 2D-array
        private static readonly char[,] code = new char[,]
        {{'a', 'z', 'e', 'r', 't', '1'}, // 0,0 0,1 0,2 0,3 0,4 0,5   array indices
        {'2', 'y', 'u', 'i', 'o', 'p'},  // 1,0 1,1 1,2 1,3 1,4 1,5   array indices
        {'q', '3', 's', '4', '8', 'd'},  // ...
        {'f', 'g', 'h', 'n', 'j', 'k'},
        {'9', '7', 'l', 'm', '6', 'w'},
        {'5', '0', 'x', 'c', 'v', 'b'}};

        // Dictionary
        private readonly Dictionary<char, int[]> letterLocatie;

        // Constructor
        public BlokCodering(ICodering codering) : base(codering)
        {
            // Opvullen van een dictionary om snel een letter te vinden
            letterLocatie = new Dictionary<char, int[]>();
            //Overloop 2D-array
            for (int i = 0; i < code.GetLength(0); i++) 
            {
                for (int j = 0; j < code.GetLength(1); j++) 
                {
                    // lees een lettertje uit de array in en koppel het aan z'n array indices met Dictionary
                    char c = code[i, j];
                    letterLocatie.Add(c, new int[] { i, j });
                }
            }
        }


        // Overgeërfde methode
        public override string Codeer(string zin)
        {
            zin = codering.Codeer(zin);
            // naar Lowercase
            zin.ToLower();
            // vreemde lettertekens en spaties worden 0
            StringBuilder tempZin = RemoveSpaces(zin);
            tempZin = RemoveStrange(tempZin);
            // zin even maken
            string evenZin = MakeEven(tempZin);
            StringBuilder readyZin = new StringBuilder(evenZin);
            // roep uiteindelijk een methode Codeer op die de StringBuilder meekrijgt
            // en de codering uitvoert
            // Coderen:
            readyZin = Code(readyZin);
            return readyZin.ToString();
        }


        // Eigenlijke codering
        private StringBuilder Code(StringBuilder tempZin)
        {
            StringBuilder result = new StringBuilder();
            // Overloop de ingelezen string per 2 letters
            for (int i = 0; i < tempZin.Length; i+=2)
            {
                // Gelijke tekens? Dan blijven ze onvertaald
                if(tempZin[i] == tempZin[i + 1])
                {
                    result.Append(tempZin[i]);
                    result.Append(tempZin[i+1]);
                }
                else // Anders... zoek in het rooster
                {
                    // Staan ze op dezelfde rij of kolom, wissel ze dan om
                    // Dus: '3s' wordt 's3' en 'hx' wordt 'xh'
                    int[] loc1, loc2;
                    // Locaties van tempZin[i] en tempZin[i+1] inlezen uit Dictionary letterLocatie
                    loc1 = letterLocatie[tempZin[i]];
                    loc2 = letterLocatie[tempZin[i+1]];
                    if (loc1[0] == loc2[0] || loc1[1] == loc2[1]) // Letters op dezelfde rij of kolom?
                    {
                        // Letters verwisselen
                        result.Append(tempZin[i + 1]);
                        result.Append(tempZin[i]);
                    }
                    else // Letters niet op dezelfde rij of kolom?
                    {
                        // Vervang het paar nu door de andere twee hoeken van die rechthoek
                        // Elk teken vervang je door een teken op dezelfde rij
                        // Dus: 'nb' wordt 'kc' en 'rs' wordt 'e4'
                        result.Append(code[loc1[0], loc2[1]]);                          
                        result.Append(code[loc1[0], loc2[1]]);
                    }

            
                }

            }
            return result;
        }


        // Hulpmethode
        private string MakeEven(StringBuilder tempZin)
        {
            string temp = tempZin.ToString();
            if (tempZin.Length %2 != 0)
            {
                temp += '0';
            }
            return temp;
        }

        // Hulpmethode
        private StringBuilder RemoveStrange(StringBuilder tempZin)
        {
            // Speciale tekens verwijderen
            for (int i = 0; i < tempZin.Length; i++)
            {
                // Als het geen lowercase en geen digit is...
                if (!char.IsLower(tempZin[i])
                    && !char.IsDigit(tempZin[i]))
                    tempZin[i] = '0'; // ... vervang door karakter 0
            }

            return tempZin;
        }

        // Hulpmethode
        private StringBuilder RemoveSpaces(string zin)
        {
            // zin splitten in woorden wanneer je een spatie tegenkomt
            string[] woorden = zin.Split(' ');
            StringBuilder temp = new StringBuilder();
            foreach (string woord in woorden)
            {
                temp.Append(woord);
                temp.Append('0'); // spaties vervangen door 0 (waar woord eindigt)
            }

            return temp;
        }
    }
}
