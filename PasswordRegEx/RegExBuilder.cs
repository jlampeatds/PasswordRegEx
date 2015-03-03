using System;
using System.Text;

namespace PasswordRegEx
{
    public class RegExBuilder
    {
        /// <summary>
        /// RegEx that matches strings that have lowercase, uppercase and numeric components.
        /// </summary>
        public const string RegExComponentThreeLowerUpperNumeric = "(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])";
        /// <summary>
        /// RegEx that matches strings that have lowercase, special and numeric components.
        /// </summary>
        public const string RegExComponentThreeLowerNumericSpecial = "(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])";
        /// <summary>
        /// RegEx that matches strings that have uppercase, special and numeric components.
        /// </summary>
        public const string RegExComponentThreeUpperNumericSpecial = "(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])";
        /// <summary>
        /// RegEx that matches strings that have uppercase, lowercase and numeric components.
        /// </summary>
        public const string RegExComponentThreeLowerUpperSpecial = "(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])";
        /// <summary>
        /// RegEx that matches strings that have three-digit consecutive numeric runs.
        /// </summary>
        public const string RegExComponentConsecutiveNumerics = "(012|123|234|345|456|567|678|789|890|098|987|876|765|654|543|432|321|210)";
        /// <summary>
        /// RegEx that matches strings that have three-digit "numberpad" horizontal or vertical runs not already listed in the list of consecutive numerics.
        /// </summary>
        public const string RegExComponentKeypadNumerics = "(147|741|369|963|025|520)";
        /// <summary>
        /// RegEx that contains restricted words.  (Used to build case- and symbol-insensitive RegExComponentRestrictedWords.)
        /// </summary>
        private const string RegExComponentRestrictedWordsRaw = "(admin|nurs)";

        /// <summary>
        /// Returns a RegEx that combines length, complexity and restricted word limitations
        /// </summary>
        public static string RegExCombined(string regExLength, string regExComplexity, string regExRestrictedWords, string regExRepeatedChars)
        {
            //return "(" + "(?=" + RegExLength + ")" + RegExComplexity + ")";
            return
                regExRepeatedChars +
                "(" + 
                    "(?=" + regExLength + ")" + 
                    regExComplexity +
                    "(^(?!.*" + regExRestrictedWords + "))" +                
                ")";
        }

        /// <summary>
        /// Returns a RegEx that combines both case/symbol-insensitive restricted words and restricted numerics.
        /// </summary>
        public static string RegExRestrictedWordsAndNumerics
        {
            get
            {
                // We basically want to "crack off" the paranthesis on the clauses and slam them together
                return "(" +
                    StripParentheses(RegExComponentConsecutiveNumerics) + "|" +
                    StripParentheses(RegExComponentKeypadNumerics) + "|" +
                    StripParentheses(RegExComponentRestrictedWords) +
                    ")";

            }
        }

        /// <summary>
        /// Strips off the leading and trailing parenthesis of a phrase
        /// </summary>
        /// <param name="stringToStrip">A string with leading and trailing paranthesis.</param>
        /// <returns>Stripped string or blank string if it is not in the correct format.</returns>
        public static string StripParentheses(string stringToStrip)
        {
            if (stringToStrip.StartsWith("(") && stringToStrip.EndsWith(")"))
            {
                return stringToStrip.Substring(1, stringToStrip.Length - 2);
            }
            return "";
        }

        /// <summary>
        /// Returns a RegEx that only matches strings with X or fewer of the same character in a row.
        /// </summary>
        /// <param name="repeat">Maximum number of same characters to allow in a row.</param>
        /// <returns>RegEx that only matches strings with [repeat] or fewer of the same character in a row.</returns>
        public static string RexExComponentMaximumCharacterRepeat(int repeat)
        {
            // (?=^(?!.*(.)\1{2}))            
            return "(?=^(?!.*(.)\\1{" + repeat + "}))";
        }

        /// <summary>
        /// Returns a RegEx that matches strings of a minimum length.
        /// </summary>
        /// <param name="length">Minimum length to match.</param>
        /// <returns>RegEx that matches strings of a minimum length.</returns>
        public static string RegExComponentMinimumLength(int length)
        {
            if (length < 1 | length > 512)
            {
                throw new ArgumentException("Keep the length between 1 and 512!");
            }
            return ".{" + length + "}";
        }

        /// <summary>
        /// Returns a RegEx that matches three of four complexity rules: lowercase, uppercase, numeric and symbol.
        /// </summary>
        public static string RegExComponentAnyThreeOfFourComplexity
        {
            get
            {
                return "(" + 
                    RegExComponentThreeLowerUpperNumeric + "|" +
                       RegExComponentThreeLowerNumericSpecial + "|" +
                       RegExComponentThreeUpperNumericSpecial + "|" +
                       RegExComponentThreeLowerUpperSpecial +
                       ")";
            }   
        }

        /// <summary>
        /// Returns a RegEx that matches a list of restricted words.
        /// (This is a case- and symbol-insensitive version of RegExComponentRestrictedWordsRaw.)
        /// </summary>
        public static string RegExComponentRestrictedWords
        {
            get
            {
                var finalregex = new StringBuilder();
                const string alphabet = "abcdefghijklmnopqrstuvwxyz";
                for (int i = 0; i < RegExComponentRestrictedWordsRaw.Length; i++)
                {
                    string oneChar = RegExComponentRestrictedWordsRaw.Substring(i, 1);
                    if (alphabet.Contains(oneChar))
                    {
                        finalregex.Append("[" + oneChar.ToLower() + oneChar.ToUpper());
                        // Map in common numeric and special character replacements
                        switch (oneChar)
                        {
                            case "a":
                                finalregex.Append("@");
                                break;
                            case "i":
                                finalregex.Append("1!");
                                break;
                            case "l":
                                finalregex.Append("17");
                                break;
                            case "o":
                                finalregex.Append("0");
                                break;
                            case "e":
                                finalregex.Append("3");
                                break;
                            case "s":
                                finalregex.Append("5$");
                                break;
                            case "z":
                                finalregex.Append("2");
                                break;
                            case "b":
                                finalregex.Append("8");
                                break;
                        }
                        finalregex.Append("]");

                    }
                    else
                    {
                        finalregex.Append(oneChar);                        
                    }

                }
                return finalregex.ToString();
            }
        }

    }
}
