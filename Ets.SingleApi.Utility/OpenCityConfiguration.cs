namespace Ets.SingleApi.Utility
{
    using System.Configuration;

    /// <summary>
    /// 类名称：OpenCityConfiguration
    /// 命名空间：Ets.SingleApi.Utility
    /// 类功能：开通城市配置
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/19/2013 6:53 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class OpenCityConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("etaoshi.opencity", IsRequired = false)]
        public string WebName
        {
            get
            {
                return this["etaoshi.opencity"] as string;
            }
        }
    }
}