using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace XK.NBear.TemplateEngine
{
    /// <summary>
    /// Class checking by Regex.
    /// </summary>
    public static class RegexCheck
    {
        /// <summary>
        /// Sync object.
        /// </summary>
        public static object syncObj = new object();

        /// <summary>
        /// Check the input string variable name is a valid variable name.
        /// </summary>
        /// <param name="name">The input string variable name.</param>
        /// <returns>A bool result with true/false.</returns>
        public static bool IsValidVariableName(string name)
        {
            return RegexChecking(name, "^[a-zA-Z_][a-zA-Z0-9_]*$");
        }

        /// <summary>
        /// Gets the match string.
        /// </summary>
        /// <param name="val">The input string.</param>
        /// <param name="pattern">The regex string.</param>
        /// <returns>The match string.</returns>
        public static string GetMatchString(string val, string pattern)
        {
            //Check.Require(!RegexChecking(val, pattern), "could not find the match string");

            Regex regex = new Regex(pattern, RegexOptions.Compiled);
            return regex.Match(val).Value;
        }

        /// <summary>
        /// Regex check.
        /// </summary>
        /// <param name="val">The input string.</param>
        /// <param name="pattern">The regex pattern.</param>
        /// <returns>True/False.</returns>
        public static bool RegexChecking(string val, string pattern)
        {
            Regex regex = new Regex(pattern, RegexOptions.Compiled);

            // check is match.
            return regex.IsMatch(val);
        }
    }
}
