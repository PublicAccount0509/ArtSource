namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：LoginRequstModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：第三方登陆请求参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/16 23:52
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class TelephoneNumLoginParameter
    {

        /// <summary>
        /// Gets or sets the name of the key.
        /// </summary>
        /// <value>
        /// The name of the key.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：2014-2-18 16:21
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the AppKey of LoginParameter
        /// </summary>
        /// <value>
        /// The AppKey
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 11:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AppKey { get; set; }
    }
}