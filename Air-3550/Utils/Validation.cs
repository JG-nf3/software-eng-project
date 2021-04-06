using System;
using System.Collections.Generic;
using System.Linq;

namespace Air_3550.Utils
{
    /// <summary>
    /// Class to validate user input.
    /// </summary>
    internal class Validation
    {
        /// <summary>
        /// Validate input given as dictionary
        /// </summary>
        /// <param name="inputDict"></param>
        /// <returns></returns>
        public static bool ValidateInputs(Dictionary<string, string> inputDict)
        {
            foreach (KeyValuePair<string, string> input in inputDict)
            {
                var i = input.Value;
                // address1 and address2 can contain space
                // address2 can be empty
                if (String.IsNullOrWhiteSpace(i) && !"address2".Equals(input.Key))
                {
                    return false;
                }

                switch (input.Key)
                {
                    case "firstName":
                    case "lastName":
                    case "city":
                        if (!i.All(c => char.IsLetter(c))) { return false; }
                        break;

                    case "password":
                        if (i.Contains(" ")) { return false; }
                        break;

                    case "email":
                        if (i.Contains(" ") || !i.Contains("@")) { return false; }
                        break;

                    case "phoneNumber":
                        if (i.Length != 10 || !i.All(c => char.IsDigit(c))) { return false; }
                        break;

                    case "zipCode":
                        if (i.Length != 5 || !i.All(c => char.IsDigit(c))) { return false; }
                        break;

                    case "creditCardNumber":
                        if (!i.All(c => char.IsDigit(c))) { return false; }
                        break;

                    case "state":
                        if ("State".Equals(i)) { return false; }
                        break;

                    case "userId":
                        if (i.Length != 6 || !i.All(c => char.IsDigit(c))) { return false; }
                        break;

                    default:
                        break;
                }
            }
            return true;
        }
    }
}