﻿
namespace Ets.SingleApi.Utility
{
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// 类名称：XmlSerializationUtility
    /// 命名空间：Ets.WechatServer.Utility
    /// 类功能：
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 创建者：孟祺宙 创建日期：2014/6/3 14:44
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public static class XmlSerializationUtility<T>
    {
        /// <summary>
        /// 序列化 UTF-8编码
        /// </summary>
        /// <param name="t">The t</param>
        /// <returns>
        /// String
        /// </returns>
        public static string XmlSerialize(T t)
        {
            string lstXml;

            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };

            using (var stream = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(stream, settings))
                {
                    //去除默认命名空间xmlns:xsd和xmlns:xsi
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    var formatter = new XmlSerializer(typeof(T));
                    formatter.Serialize(writer, t, ns);
                }
                stream.GetBuffer();
                lstXml = Encoding.UTF8.GetString(stream.ToArray());//GetBuffer 
            }
            return System.Text.RegularExpressions.Regex.Replace(lstXml, "^[^<]", "");
        }

        /// <summary>
        /// XML反序列化
        /// </summary>
        /// <param name="content">内容文本</param>
        /// <returns>
        /// `0
        /// </returns>
        public static T XmlDeserialize(string content)
        {
            T t = default(T);
            var serializer = new XmlSerializer(typeof(T));

            using (var reader = new StringReader(content))
            {
                t = (T)serializer.Deserialize(reader);
            }
            return t;
        }
    }
}
