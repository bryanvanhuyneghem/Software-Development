using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation.Pattern_reeks7
{
    public class NumberFieldEvaluation : IFieldEvaluation
    {
        public bool IsValid(string text)
        {
            double number;

            if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out number))
                return true;
            else
                return false;
        }
    }
}
