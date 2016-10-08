using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml.Serialization;

namespace XK.NBear.Cofiguration
{
    /// <summary>
    /// 摘要: 继承与 ConfigurationSection, IXmlSerializable 的 PageSection
    /// </summary>
    public class PageSection : ConfigurationSection, IXmlSerializable
    {
        private const string pageSettingName = "PageSettings";
        /// <summary>
        /// 摘要: SectionName
        /// </summary>
        public string SectionName
        {
            get { return "PageSection"; }
        }

        #region IXmlSerializable 成员
        /// <summary>
        /// 摘要: IXmlSerializable 成员 GetSchema
        /// </summary>
        /// <returns></returns>
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        /// <summary>
        /// 摘要: IXmlSerializable 成员 ReadXml
        /// </summary>
        /// <returns></returns>
        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.Read();
            DeserializeSection(reader);
        }
        /// <summary>
        /// 摘要: IXmlSerializable 成员 WriteXml
        /// </summary>
        /// <returns></returns>
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            String serialized = SerializeSection(this, "PageSection", ConfigurationSaveMode.Full);
            writer.WriteRaw(serialized);
        }

        #endregion
        /// <summary>
        /// 摘要: PageSettings
        /// </summary>
        [ConfigurationProperty(pageSettingName, IsDefaultCollection = true)]
        public PageSettings Settings
        {
            get { return (PageSettings)base[pageSettingName]; }
        }
    }
}
