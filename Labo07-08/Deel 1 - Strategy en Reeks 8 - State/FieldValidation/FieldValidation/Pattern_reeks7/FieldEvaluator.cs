using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation.Pattern_reeks7
{
    public class FieldEvaluator
    {
        private IFieldEvaluation fieldEval;

        public FieldEvaluator(IFieldEvaluation fieldEval)
        {
            this.fieldEval = fieldEval;
        }

        public void SetEvaluation(IFieldEvaluation fieldEval)
        {
            this.fieldEval = fieldEval;
        }

        public bool Evaluate(string s)
        {
            return fieldEval.IsValid(s);
        }
    }
}
