using System;
using System.Configuration;

namespace Ets.SingleApi.Model.ExternalServices
{
    /// <summary>
    /// 类名称：SingleApiExternalServiceAuthenParameter
    /// 命名空间：Ets.SingleApi.Model.ExternalServices
    /// 类功能：
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：2/28/2014 5:15 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SingleApiExternalServiceAuthenParameter
    {
        /// <summary>
        /// 取得AppKey值
        /// </summary>
        /// <value>
        /// AppKey值
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 5:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AppKey { get; set; }

        /// <summary>
        /// 取得AppPassword值
        /// </summary>
        /// <value>
        /// AppPassword值
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 5:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AppPassword { get; set; }

        /// <summary>
        /// 取得Source值
        /// </summary>
        /// <value>
        /// Source值
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/5/2013 10:37 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Source { get; set; }
    }
}
