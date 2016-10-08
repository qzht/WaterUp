using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace XK.NBear.Cofiguration
{
    /// <summary>
    /// 摘要: 继承于 System.Configuratin.ConfigurationElementCollection
    /// </summary>
    public class PageSettings : ConfigurationElementCollection
    {
        /// <summary>
        /// 摘要: 重写 CreateNewElement
        /// </summary>
        /// <returns>AttributeElement</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new AttributeElement();
        }
        /// <summary>
        /// 摘要: 重写 GetElementKey
        /// </summary>
        /// <returns>AttributeElement</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((AttributeElement)element).Name;
        }
        /// <summary>
        /// 摘要: 重写 CollectionType
        /// </summary>
        /// <returns>ConfigurationElementCollectionType.BasicMap</returns>
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }
        /// <summary>
        /// 摘要: 重写 ElementName
        /// </summary>
        /// <returns>add</returns>
        protected override string ElementName
        {
            get
            {
                return "add";
            }
        }
        /// <summary>
        /// 摘要： 返回AttributeElement的所引起
        /// </summary>
        /// <param name="name">AttributeElement.Name</param>
        /// <returns>AttributeElement</returns>
        public new AttributeElement this[string name]
        {
            get { return (AttributeElement)BaseGet(name); }
        }
        /// <summary>
        /// 摘要： 返回AttributeElement的所引起
        /// </summary>
        /// <param name="index">AttributeElement.Index</param>
        /// <returns>AttributeElement</returns>
        public AttributeElement this[int index]
        {
            get { return (AttributeElement)BaseGet(index); }
        }
    }
}
