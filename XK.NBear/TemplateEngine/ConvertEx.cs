using System;
using System.Collections.Generic;
using System.Text;

namespace XK.NBear.TemplateEngine
{
    /// <summary>
    /// Expand the .NET Framework Library Class <see cref="Convert"/>.
    /// </summary>
    public static class ConvertEx
    {
        #region ToBool

        /// <summary>
        /// Convert a <see cref="object"/> typed data to a <see cref="bool"/> data.
        /// </summary>
        /// <param name="obj">The object typed data.</param>
        /// <returns>The bool typed data with true/false.</returns>
        public static bool ObjectToBool(object obj)
        {
            if (obj is bool)
            {
                return (bool)obj;
            }
            else if (obj is string)
            {
                string str = (string)obj;

                if (string.Compare(str, "true", true) == 0)
                {
                    return true;
                }
                else if (string.Compare(str, "yes", true) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region ToString

        /// <summary>
        /// Convert a <see cref="object"/> typed data to a <see cref="string"/> data.
        /// </summary>
        /// <param name="obj">The object typed data.</param>
        /// <returns>The string typed data.</returns>
        public static string ObjectToString(object obj)
        {
            return ObjectToString(obj, String.Empty);
        }

        /// <summary>
        /// Convert a <see cref="object"/> typed data to a <see cref="string"/> data with the default value.
        /// </summary>
        /// <param name="obj">The object typed data.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The string typed data.</returns>
        public static string ObjectToString(object obj, string defaultValue)
        {
            try
            {
                return obj.ToString();
            }
            catch
            {
                return defaultValue;
            }
        }

        #endregion

        #region ToInt32

        /// <summary>
        /// 二进制数转化为整数
        /// </summary>
        /// <param name="binary">二进制</param>
        /// <returns>十进制</returns>
        public static int BinaryToInt(string binary)
        {
            int rv = 0;
            char[] chs = binary.ToCharArray();

            for (int i = 0; i < chs.Length; i++)
            {
                rv = rv * 2 + Convert.ToInt32(chs[i].ToString());
            }

            return rv;
        }

        /// <summary>
        /// Convert a <see cref="object"/> typed data to a <see cref="Int32"/> data.
        /// </summary>
        /// <param name="obj">The object typed data.</param>
        /// <returns>The int typed data.</returns>
        public static int ObjectToInt32(object obj)
        {
            return ObjectToInt32(obj, 0);
        }

        /// <summary>
        /// Convert a <see cref="object"/> typed data to a <see cref="Int32"/> data with a default value.
        /// </summary>
        /// <param name="obj">The object typed data.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The int typed data.</returns>
        public static int ObjectToInt32(object obj, int defaultValue)
        {
            try
            {
                return Convert.ToInt32(obj.ToString());
            }
            catch
            {
                return defaultValue;
            }
        }

        #endregion

        #region ToScriptString

        /// <summary>
        /// Convert a <see cref="string"/> typed data to a javascript string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>The javascript string.</returns>
        public static string ObjectToScriptString(string str)
        {
            return ObjectToScriptString(str, false);
        }

        /// <summary>
        /// Convert a <see cref="string"/> typed data to a javascript string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="clearLineBreak">Clear line break.</param>
        /// <returns>The javascript string.</returns>
        public static string ObjectToScriptString(string str, bool clearLineBreak)
        {
            str = str.Replace("\\", "\\\\");
            str = str.Replace("\"", "\\\"");
            str = str.Replace("'", "\\'");

            if (clearLineBreak)
            {
                str = str.Replace("\r", "");
                str = str.Replace("\n", "");
            }

            return str;
        }

        #endregion
    }
}
