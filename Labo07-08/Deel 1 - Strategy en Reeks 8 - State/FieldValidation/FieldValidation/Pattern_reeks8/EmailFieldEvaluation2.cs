using FieldValidation.Pattern_reeks7;
using FieldValidation.Pattern_reeks8.states;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FieldValidation.Pattern_reeks8
{

    public enum ValidationState { INIT, WORD, POINT, DOMAIN_INIT, /*DOMAIN, DOMAIN_POINT,*/ ACCEPT, FAULT}

    public class EmailFieldEvaluation2 : IFieldEvaluation
    {
        // Fields
        // ------
        Dictionary<ValidationState, IState> states;
        IState state; // According to the pattern: the Context (this) needs to have an IState member
        // Property
        internal ValidationState State
        {
            set
            {
                state = states[value];
            }
        }
        // ------


        // Constructor
        public EmailFieldEvaluation2()
        {
            // Create a mapping in the dictionary for every state to the members of the enum
            states = new Dictionary<ValidationState, IState>();
            states[ValidationState.INIT] = new SeparatorState(ValidationState.WORD);
            states[ValidationState.WORD] = new WordState();
            states[ValidationState.POINT] = new SeparatorState(ValidationState.WORD);
            states[ValidationState.DOMAIN_INIT] = new SeparatorState(ValidationState.ACCEPT);
            states[ValidationState.ACCEPT] = new DomainState();
            states[ValidationState.FAULT] = new FaultState();
        }

        // Function IsValid (== Request, which invokes a Handle() on the IState state)
        public bool IsValid(string emailString)
        {
            // Initialize state
            state = states[ValidationState.INIT];

            // Split the given emailString into parts using regex
            string pattern = @"(\w+)|(@)|(\.)+";
            MatchCollection parts = Regex.Matches(emailString, pattern);

            // Loop through separate parts but stop once an invalid part has been detected
            bool stillValid = true;
            int tempIndex = 0;
            while(stillValid && tempIndex < parts.Count)
            {
                stillValid = state.IsNextValid(parts[tempIndex].Value, this); // will have 'false' if FaultState
                tempIndex++;
            }

            // Check if we are in the correct end state
            return state == states[ValidationState.ACCEPT];
        }

        
    }
}
