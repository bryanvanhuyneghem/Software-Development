namespace FieldValidation.Pattern_reeks8.states
{
    interface IState
    {
        bool IsNextValid(string token, EmailFieldEvaluation2 validator);
    }
}