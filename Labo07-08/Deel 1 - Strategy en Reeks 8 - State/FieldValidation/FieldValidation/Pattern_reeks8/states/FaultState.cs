using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation.Pattern_reeks8.states
{
    class FaultState : IState
    {
        public bool IsNextValid(string token, EmailFieldEvaluation2 validator)
        {
            return false;
        }
    }
}
