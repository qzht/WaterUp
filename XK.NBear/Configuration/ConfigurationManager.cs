using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace XK.NBear.Cofiguration
{
    /// <summary>
    /// 摘要： XK.NBear.Cofiguration.ConfigurationManager
    /// </summary>
    public static class ConfigurationManager
    {
        /// <summary>
        /// 获取指定路径的Page.config配置文件中的指定PageSettings节点信息.
        /// </summary>
        /// <param name="configPath">配置文件路径</param>
        /// <returns>PageSettings</returns>
        public static PageSettings GetPageConfig(string configPath)
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = configPath;
            PageSection moduleSection = (PageSection)System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None).GetSection("PageSection");
            return (PageSettings)moduleSection.Settings;
        }
    }
}
