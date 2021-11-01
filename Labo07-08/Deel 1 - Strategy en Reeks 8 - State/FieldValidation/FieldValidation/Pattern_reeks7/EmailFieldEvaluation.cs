using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation.Pattern_reeks7
{
    public class EmailFieldEvaluation : IFieldEvaluation
    {
        public bool IsValid(string text)
        {
            try
            {
                MailAddress m = new MailAddress(text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
