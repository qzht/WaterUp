using System;
using System.Collections.Generic;
using System.Text;
using XK.NBear.Common;
using System.Data;

namespace XK.NBear.Extends
{
    /// <summary>
    /// 摘要: string 的扩展方法类.
    /// </summary>
    public static class StringExtends
    {
        /// <summary>
        /// 摘要: ToInt 方法.
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <returns>int</returns>
        public static int ToInt(string objectData)
        {
            int intData = 0;
            bool result = int.TryParse(objectData, out intData);
            return intData;
        }
        /// <summary>
        /// 摘要: ToInt 方法,并提供默认返还值.
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns>int</returns>
        public static int ToInt(string objectData, int defaultValue)
        {
            int intData = 0;
            bool result = int.TryParse(objectData, out intData);
            return result ? intData : defaultValue;
        }
        /// <summary>
        /// 摘要: ToDouble 方法.
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <returns>double</returns>
        public static double ToDouble(string objectData)
        {
            double intData = 0;
            bool result = double.TryParse(objectData, out intData);
            return intData;
        }

        public static float ToFloat(string data)
        {
            return float.Parse(data);
        }

        public static float ToFloat(string data, float defaultValue)
        {
            float floatData = 0f;
            bool result = float.TryParse(data, out floatData);
            return result ? floatData : defaultValue;
        }

        /// <summary>
        /// 摘要: ToDouble 方法,并提供默认返还值..
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns>double</returns>
        public static double ToDouble(string objectData, double defaultValue)
        {
            double intData = 0;
            bool result = double.TryParse(objectData, out intData);
            return result ? intData : defaultValue;
        }
        /// <summary>
        /// 摘要: 判断 string 是否为空。
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <returns>bool</returns>
        public static bool INOE(string objectData)
        {
            return string.IsNullOrEmpty(objectData);
        }
        /// <summary>
        /// 摘要: 判断 string 是否为整数。
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <returns>bool</returns>
        public static bool IsInt(string objectData)
        {
            int result = 0;
            return int.TryParse(objectData, out result);
        }
        /// <summary>
        /// 摘要: 判断 string 是否为double。
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <returns>bool</returns>
        public static bool IsDouble(string objectData)
        {
            double result = 0;
            return double.TryParse(objectData, out result);
        }
        /// <summary>
        /// 摘要: 字符串转化为bool值.
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <returns>bool</returns>
        public static bool ToBool(string objectData)
        {
            if (objectData == "0")
            {
                objectData = "false";
            }
            if (objectData == "1")
            {
                objectData = "true";
            }
            return bool.Parse(objectData);
        }
        /// <summary>
        /// 摘要: 字符串转化为bool值.
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <returns>bool</returns>
        public static bool ToBool(string objectData, bool defaultValue)
        {
            bool result = defaultValue;
            return bool.TryParse(objectData, out result);
        }
        /// <summary>
        /// 摘要: 字符串加密为XinDES值.
        /// </summary>
        /// <param name="objectData"></param>
        /// <returns></returns>
        public static string ToEncrypt(string objectData)
        {
            return XinDES.Encrypt(objectData);
        }
        /// <summary>
        /// 摘要: 字符串解密为XinDES值.
        /// </summary>
        /// <param name="objectData"></param>
        /// <returns></returns>
        public static string ToDecrypt(string objectData)
        {
            return XinDES.Decrypt(objectData);
        }

        public static string ToMD5(string defaultValue)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(defaultValue, "md5");
        }

        public static string ToDate(string data, string fomatString)
        {
            return Convert.ToDateTime(data).ToString(fomatString);
        }

        public static DataTable XmlToDataTable(string data)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(data);
            return dataSet.Tables[0];
        }
    }
}
