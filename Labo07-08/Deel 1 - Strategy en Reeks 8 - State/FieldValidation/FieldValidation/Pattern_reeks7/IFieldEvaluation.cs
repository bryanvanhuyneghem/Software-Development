using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation.Pattern_reeks7
{
    public interface IFieldEvaluation
    {
        bool IsValid(string text);  // Is de input geldig?
    }
}
