using System;
using System.Text.RegularExpressions;

namespace PasswordRegEx
{
    /// <summary>
    /// Instantiate this to test passwords against a given RegEx
    /// </summary>
    public class RegExEval
    {

        /// <summary>
        /// Naked constructor
        /// </summary>
        public RegExEval()
        {
            RegExToTest = "";
            PasswordToTest = "";
        }
        
        /// <summary>
        /// Constructor with initial regular expression
        /// </summary>
        /// <param name="initialRegEx">Regular expression to use in tests unless/until otherwise specified</param>
        public RegExEval(string initialRegEx)
        {
            RegExToTest = initialRegEx;
            PasswordToTest = "";
        }

        /// <summary>
        /// The Regular Expression to test
        /// </summary>
        public string RegExToTest { get; set; }

        /// <summary>
        /// The password to test
        /// </summary>
        public string PasswordToTest { get; set; }

        /// <summary>
        /// Checks to see if the password fails to match the RegEx.  
        /// </summary>
        /// <param name="passwordToTryNow">Optional password to test now</param>
        /// <returns>True if the password matches the RegEx, false otherwise.</returns>
        public bool PasswordMatchesRegEx(string passwordToTryNow)
        {
            PasswordToTest = passwordToTryNow;
            return PasswordMatchesRegEx();
        }

        /// <summary>
        /// Checks to see if the password fails to match the RegEx.  
        /// </summary>
        /// <returns>True if the password matches the RegEx, false otherwise.</returns>
        public bool PasswordMatchesRegEx()
        {
            if (RegExToTest.Length == 0)
            {
                throw new ArgumentException("Your regular expression cannot be blank!");
            }
            var regex = new Regex(RegExToTest);
            return regex.IsMatch(PasswordToTest);
        }

        /// <summary>
        /// Checks to see if the password fails to match the RegEx.  
        /// This behavior duplicates Microsoft's default MembershipProvider behavior.
        /// </summary>
        /// <param name="passwordToTryNow">Optional password to test now</param>
        /// <returns>True if the password fails to match the RegEx, false otherwise.</returns>
        public bool PasswordFailsAgainstRegEx(string passwordToTryNow)
        {
            PasswordToTest = passwordToTryNow;
            return PasswordFailsAgainstRegEx();
        }

        /// <summary>
        /// Checks to see if the password MATCHES ("fails") against the RegEx.  
        /// This behavior duplicates Microsoft's default MembershipProvider behavior.
        /// </summary>
        /// <returns>True if the password fails to match the RegEx, false otherwise.</returns>
        public bool PasswordFailsAgainstRegEx()
        {
            return !PasswordMatchesRegEx();
        }



    }
}
