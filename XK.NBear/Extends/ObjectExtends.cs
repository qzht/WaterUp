using System;
using System.Collections.Generic;
using System.Text;

namespace XK.NBear.Extends
{
    /// <summary>
    /// 摘要: object 的扩展方法类.
    /// </summary>
    public static class ObjectExtends
    {
        /// <summary>
        /// 摘要: ToInt 方法.
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <returns>int</returns>
        public static int ToInt(object objectData)
        {
            int intData = 0;
            bool result = int.TryParse(objectData.ToString(), out intData);
            return intData;
        }
        /// <summary>
        /// 摘要: ToInt 方法,并提供默认返还值.
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns>int</returns>
        public static int ToInt(object objectData, int defaultValue)
        {
            int intData = 0;
            bool result = int.TryParse(objectData.ToString(), out intData);
            return result ? intData : defaultValue;
        }
        /// <summary>
        /// 摘要: ToDouble 方法.
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <returns>double</returns>
        public static double ToDouble(object objectData)
        {
            return double.Parse(objectData.ToString());
        }
        /// <summary>
        /// 摘要: ToDouble 方法,并提供默认返还值..
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns>double</returns>
        public static double ToDouble(object objectData, double defaultValue)
        {
            double intData = 0;
            if (objectData == null)
            {
                objectData = "0";
            }
            bool result = double.TryParse(objectData.ToString(), out intData);
            return result ? intData : defaultValue;
        }
        /// <summary>
        /// 摘要: 判断 object 是否为空。
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <returns>bool</returns>
        public static bool INOE(object objectData)
        {
            return objectData == null;
        }
        /// <summary>
        /// 摘要: 判断 object 是否为整数。
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <returns>bool</returns>
        public static bool IsInt(object objectData)
        {
            int result = 0;
            return int.TryParse(objectData.ToString(), out result);
        }
        /// <summary>
        /// 摘要: 判断 object 是否为double。
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <returns>bool</returns>
        public static bool IsDouble(object objectData)
        {
            double result = 0;
            return double.TryParse(objectData.ToString(), out result);
        }
        /// <summary>
        /// 摘要: object转化为bool值.
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <returns>bool</returns>
        public static bool ToBool(object objectData)
        {
            string value;
            if (objectData.ToString() == "1")
            {
                value = "true";
            }
            else if (objectData.ToString() == "0")
            {
                value = "false";
            }
            else
            {
                value = objectData.ToString();
            }
            return Convert.ToBoolean(value.ToString());
        }
        /// <summary>
        /// 摘要: object转化为bool值.
        /// </summary>
        /// <param name="objectData">objectData</param>
        /// <returns>bool</returns>
        public static bool ToBool(object objectData, bool defaultValue)
        {
            bool result = defaultValue;
            return bool.TryParse(objectData.ToString(), out result);
        }
    }
}
