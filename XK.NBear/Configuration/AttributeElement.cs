using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace XK.NBear.Cofiguration
{
    /// <summary>
    /// 摘要: 继承与 ConfigurationElement 的 AttributeElement
    /// </summary>
    public class AttributeElement : ConfigurationElement
    {
        /// <summary>
        /// 摘要: 特性名称
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }
        /// <summary>
        /// 摘要: 特性值
        /// </summary>
        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return (string)base["value"]; }
            set { base["value"] = value; }
        }
    }
}
