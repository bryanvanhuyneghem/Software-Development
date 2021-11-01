using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation.Pattern_reeks7
{
    public class BankFieldEvaluation : IFieldEvaluation
    {
        public bool IsValid(string text)
        {
            // string van 14 karakters
            if (text.Length != 14)
            {
                return false;
            }

            // in 3 stukken hakken
            var parts = text.Split('-');

            // We hebben nu 3 stukken
            if (parts.Length != 3)
            {
                return false;
            }

            // Controleer de lengte van elk stuk
            if (parts[0].Length != 3 || parts[1].Length != 7 || parts[2].Length != 2)
            {
                return false;
            }

            // Voer eigenlijke controle op volgens opgegeven methodiek
            try
            {
                long rekening = long.Parse(string.Concat(parts[0], parts[1]));
                int controlegetal = int.Parse(parts[2]);
                if (rekening % 97 == controlegetal)
                {
                    return true;
                }
                else
                {
                    var x = int.Parse(string.Concat(parts[0], parts[1])) % 97;
                    return false;
                }
            }
            // indien een Exception dan false
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
