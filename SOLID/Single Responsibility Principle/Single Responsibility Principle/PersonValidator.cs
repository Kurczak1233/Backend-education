using System;
using System.Collections.Generic;
using System.Text;

namespace Single_Responsibility_Principle
{
    public class PersonValidator
    {
        public static bool ValidatePerson(Person user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                StandardMessages.DisplayValidationError("First name");
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.LastName))
            {
                StandardMessages.DisplayValidationError("Last name");
                return false;
            }
            return true;
        }
    }
}
